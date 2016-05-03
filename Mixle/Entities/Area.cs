using System;
using Microsoft.Xna.Framework;

namespace Mixle.Entities {
	public class Area {
		public Rectangle Initial;
		public float X, Y, Width, Height;

		public Area(float x, float y, float w, float h, Rectangle initial) {
			Initial = initial;

			X = x;
			Y = y;
			Width = w;
			Height = h;
		}

		public Area(float x, float y, float w, float h): this(x, y, w, h, new Rectangle((int) x, (int) y, (int) w, (int) h)) { }

		public Rectangle Rectangle {
			get {
				return new Rectangle((int) X, (int) Y, (int) Width, (int) Height);
			}
		}

		public Point Center {
			get {
				return Initial.Center;
			}
		}

		public bool Contains(Point p) {
			return Rectangle.Contains(p);
		}
	}
}

