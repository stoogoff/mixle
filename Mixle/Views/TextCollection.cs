using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using evolve.Components;
using Mixle.Text;

namespace Mixle.Views {
	public class TextCollection: IView {
		protected List<PositionedText> texts = new List<PositionedText>();
		protected Color colour = Color.White;
		protected SpriteFont font;

		public TextCollection(SpriteFont font) {
			this.font = font;
			Visible = true;
		}

		public TextCollection(SpriteFont font, Color colour): this(font) {
			this.colour = colour;
		}

		public TextCollection(SpriteFont font, IEnumerable<PositionedText> texts): this(font) {
			this.texts.AddRange(texts);
		}

		public TextCollection(SpriteFont font, IEnumerable<PositionedText> texts, Color colour): this(font, texts) {
			this.colour = colour;
		}

		public bool Visible { get; set; }

		public void Add(PositionedText text) {
			texts.Add(text);
		}

		public void Remove(PositionedText text) {
			texts.Remove(text);
		}

		public void Draw(SpriteBatch renderer) {
			foreach(var text in texts) {
				renderer.DrawString(font, text.Content(), text.Position, colour);
			}
		}
	}
}

