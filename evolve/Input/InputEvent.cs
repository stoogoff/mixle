using System;
using Microsoft.Xna.Framework;

namespace evolve.Input {
	public struct InputEvent {
		public Point Position;
		public bool Active;
		public GameTime Time;

		public InputEvent(GameTime time, int x, int y, bool active) {
			Time = time;
			Active = active;
			Position = new Point(x, y);
		}
	}
}

