using System;
using Microsoft.Xna.Framework;

namespace Mixle.Text {
	public class PositionedText {
		protected string content;

		public PositionedText(string content, int x, int y): this(content, new Vector2(x, y)) { }

		public PositionedText(string content, Vector2 position) {
			this.content = content;
			Position = position;
		}

		public Vector2 Position { get; set; }

		public virtual string Content() {
			return content;
		}
	}
}

