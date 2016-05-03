using System;
using Microsoft.Xna.Framework;
using Mixle.Entities;

namespace Mixle.Animations {
	public class WidthAnimation: AbstractAnimation {

		public WidthAnimation(Area area, int target): base(area, target) { }

		public override bool Animate(GameTime time) {
			var speed = SPEED * time.ElapsedGameTime.Milliseconds;

			area.Width += speed;

			if(area.X + area.Width > target) {
				area.Width = target - area.X;

				return false;
			}

			return true;
		}
	}
}

