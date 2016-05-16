using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using evolve.Components;
using Mixle.Config;

namespace Mixle.Views {
	public class Sidebar: ImageView {
		public Sidebar(Game game) {
			Image = new Texture2D(game.GraphicsDevice, 1, 1);
			Image.SetData(new Color[] { Color.White });

			position = new Rectangle(Dimensions.PlayArea + Dimensions.PadHalf, Dimensions.PadHalf, 200 - Dimensions.Pad, 600 - Dimensions.Pad);
			colour = new Color(50, 50, 50, 160);

			Visible = true;
		}
	}
}

