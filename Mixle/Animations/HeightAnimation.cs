using System;
using Microsoft.Xna.Framework;
using Mixle.Entities;

namespace Mixle.Animations {
	public class HeightAnimation: AbstractAnimation {

		public HeightAnimation(Area area, int target): base(area, target) { }

		public override bool Animate(GameTime time) {
			var speed = SPEED * time.ElapsedGameTime.Milliseconds;

			area.Height += speed;

			if(area.Y + area.Height > target) {
				area.Height = target - area.Y;

				return false;
			}

			return true;
		}
	}
}

