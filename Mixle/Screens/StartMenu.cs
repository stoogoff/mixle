using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using evolve.Components;
using evolve.Screens;
using Mixle.Config;
using Mixle.Text;
using Mixle.Views;

namespace Mixle.Screens {
	public class StartMenu: Screen {
		public StartMenu(Game game): base(game) {	}

		public override void LoadContent() {
			var background = Game.Content.Load<Texture2D>("Graphics/800x600/menu");
			var title = Game.Content.Load<SpriteFont>("Fonts/Title");
			var body = Game.Content.Load<SpriteFont>("Fonts/Body");

			Add(new ImageView(background, Dimensions.ScreenWidth, Dimensions.ScreenHeight));
			Add(new TextView(title, new PositionedText("Mixle", Dimensions.ScreenWidth / 2 - 60, 110)));
			Add(new TextView(body, new PositionedText("Join same colour blocks together to create a new block.\n\nClick anywhere to start", 180, 220)));
		}
	}
}
