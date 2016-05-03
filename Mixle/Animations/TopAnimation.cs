using System;
using Microsoft.Xna.Framework;
using Mixle.Entities;

namespace Mixle.Animations {
	public class TopAnimation: AbstractAnimation {

		public TopAnimation(Area area, int target): base(area, target) { }

		public override bool Animate(GameTime time) {
			var speed = SPEED * time.ElapsedGameTime.Milliseconds;

			area.Height += speed;
			area.Y -= speed;

			if(area.Y < target) {
				area.Y = target;

				return false;
			}

			return true;
		}
	}
}

