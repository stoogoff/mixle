using System;
using Microsoft.Xna.Framework;

namespace Mixle.Entities {
	public struct TargetBlock {
		public Rectangle Rectangle;
		public Color Colour;

		public TargetBlock(int x, int y, int width, int height, Color colour) {
			Rectangle = new Rectangle(x, y, width, height);
			Colour = colour;
		}
	}
}

