using System;
using Microsoft.Xna.Framework;

namespace Mixle.Entities {
	public struct ColourPoint: IComparable<ColourPoint> {
		public int X;
		public int Y;
		public Color Colour;

		public ColourPoint(Point point, Color colour) {
			X = point.X;
			Y = point.Y;
			Colour = colour;
		}

		public int CompareTo(ColourPoint other) {
			if(Y == other.Y) {
				return X == other.X ? 0 : (X > other.X ? 1 : -1);
			}

			return Y > other.Y ? 1 : -1;
		}
	}
}

