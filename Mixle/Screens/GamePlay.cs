using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using evolve.Components;
using evolve.Input;
using evolve.Screens;
using Mixle.Components;
using Mixle.Config;
using Mixle.Entities;
using Mixle.Text;
using Mixle.Views;

namespace Mixle.Screens {
	public class GamePlay: Screen {
		protected Grid grid;
		protected Target target;
		protected Level level;
		protected Sequence sequence;
		protected Score score;
		protected IList<PositionedText> texts = new List<PositionedText>();

		// input is active
		protected bool activated = false;

		public GamePlay(MixleGame game): base(game) {
			grid = new Grid(game);
			target = new Target(game);
			sequence = new Sequence(game);
			score = new Score();

			/*level = new Level() {
				Par = 4,
				Size = 2,
				Sequence = new string[] { "RED", "GREEN", "BLUE" },
				Shuffle = true,
				Grid = new int[] { 0, 0, 1, 1 },
				Target = new int[] { 1, 1, 2, 2 },
			};*/
			level = new Level() {
				Number = 1,
				Par = 8,
				Size = 3,
				Sequence = new string[] { "RED", "GREEN", "BLUE" },
				Shuffle = true,
				Grid = new int[] { 1, 2, 1, 2, 2, 0, 1, 1, 1 },
				Target = new int[] { 1, 0, 1, 0, 0, 0, 1, 0, 1 },
			};

			var textX = Dimensions.PlayArea + Dimensions.Pad + Dimensions.PadHalf;

			// static text
			texts.Add(new PositionedText("Level:", textX, Dimensions.InfoWidth + Dimensions.Pad * 2));
			texts.Add(new PositionedText("Par:",   textX, Dimensions.InfoWidth + Dimensions.Pad * 2 + Dimensions.TextPadding));
			texts.Add(new PositionedText("Moves:", textX, Dimensions.InfoWidth + Dimensions.Pad * 3 + Dimensions.TextPadding * 2));
			texts.Add(new PositionedText("Par:",   textX, Dimensions.InfoWidth + Dimensions.Pad * 3 + Dimensions.TextPadding * 3));

			textX = Dimensions.ScreenWidth - Dimensions.PadHalf - ((int) ((float) Dimensions.Pad * 1.5f));

			// updatable text
			texts.Add(new PositionedText("1", textX, (int) texts[0].Position.Y));
			texts.Add(new PositionedText(level.Par.ToString(), textX, (int) texts[1].Position.Y));
			texts.Add(new ScoreMovesText(score, textX, (int) texts[2].Position.Y));
			texts.Add(new ScoreParText(score, textX, (int) texts[3].Position.Y));
		}

		public override void LoadContent() {
			// TODO the image size directory (800x600) needs to be handled automatically, could this be part of the content pipeline?
			var background = Game.Content.Load<Texture2D>("Graphics/800x600/background");
			var font = Game.Content.Load<SpriteFont>("Fonts/Game");

			Add(new ImageView(background, Dimensions.ScreenWidth, Dimensions.ScreenHeight));
			Add(new Sidebar(Game));
			Add(new TextCollection(font, texts));
			Add(grid);
			Add(target);
			Add(sequence);

			LoadLevel();
		}

		protected void LoadLevel() {
			grid.Create(level);
			target.Create(level);
			sequence.Create(level);
		}

		protected void NextLevel() {
			score.EndLevel(level.Par);

			// TODO get next level

			LoadLevel();
		}

		protected void RestartLevel() {
			score.Moves = 0;

			LoadLevel();
		}

		public override void Update(InputEvent evt) {
			var isClicked = !evt.Active && activated;

			base.Update(evt);

			if(isClicked) {
				if(grid.Activate(evt.Position)) {
					score.Moves++;
				}
			}

			var current = grid.GetSequence();

			if(level.IsComplete(current)) {
				// TODO sfx
				// TODO show overlay
				Console.WriteLine("Complete");
			}

			activated = evt.Active;
		}
	}
}

