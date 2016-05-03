using System;
using Microsoft.Xna.Framework;
using Mixle.Entities;

namespace Mixle.Animations {
	public class LeftAnimation: AbstractAnimation {
		public LeftAnimation(Area area, int target): base(area, target) { }

		public override bool Animate(GameTime time) {
			var speed = SPEED * time.ElapsedGameTime.Milliseconds;

			area.Width += speed;
			area.X -= speed;

			if(area.X < target) {
				area.X = target;

				return false;
			}

			return true;
		}
	}
}

