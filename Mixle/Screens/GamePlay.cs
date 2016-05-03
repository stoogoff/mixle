using System;
using Microsoft.Xna.Framework;
using evolve.Input;
using evolve.Screens;
using Mixle.Components;
using Mixle.Entities;

namespace Mixle.Screens {
	public class GamePlay: Screen {
		protected Grid grid;
		protected Target target;
		protected Level level;
		protected Sequence sequence;

		// input is active
		protected bool activated = false;

		public GamePlay(MixleGame game): base(game) {
			grid = new Grid(game);
			target = new Target(game);
			sequence = new Sequence(game);

			Add(grid);
			Add(target);
			Add(sequence);

			/*level = new Level() {
				Par = 4,
				Size = 2,
				Sequence = new string[] { "RED", "GREEN", "BLUE" },
				Shuffle = true,
				Grid = new int[] { 0, 0, 1, 1 },
				Target = new int[] { 1, 1, 2, 2 },
			};*/
			level = new Level() {
				Par = 8,
				Size = 3,
				Sequence = new string[] { "RED", "GREEN", "BLUE" },
				Shuffle = true,
				Grid = new int[] { 1, 2, 1, 2, 2, 0, 1, 1, 1 },
				Target = new int[] { 1, 0, 1, 0, 0, 0, 1, 0, 1 },
			};
		}

		public override void LoadContent() {
			grid.Create(level);
			target.Create(level);
			sequence.Create(level);
		}

		protected void NextLevel() {
			// TODO update scores
			// TODO get next level

			LoadContent();
		}

		protected void RestartLevel() {
			// TODO reset scores

			LoadContent();
		}

		public override void Update(InputEvent evt) {
			var isClicked = !evt.Active && activated;

			base.Update(evt);

			if(isClicked) {
				grid.Activate(evt.Position);
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

