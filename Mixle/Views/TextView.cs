using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using evolve.Components;
using Mixle.Text;

namespace Mixle.Views {
	public class TextView: IView {
		protected PositionedText text;
		protected Color colour = Color.White;
		protected SpriteFont font;

		public TextView(SpriteFont font) {
			this.font = font;
			Visible = true;
		}

		public TextView(SpriteFont font, Color colour): this(font) {
			this.colour = colour;
		}

		public TextView(SpriteFont font, PositionedText text): this(font) {
			this.text = text;
		}

		public TextView(SpriteFont font, PositionedText text, Color colour): this(font, text) {
			this.colour = colour;
		}

		public bool Visible { get; set; }

		public void Draw(SpriteBatch renderer) {
			renderer.DrawString(font, text.Content(), text.Position, colour);
		}
	}
}

