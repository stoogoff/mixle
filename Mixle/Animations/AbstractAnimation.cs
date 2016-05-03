using System;
using Microsoft.Xna.Framework;
using Mixle.Entities;

namespace Mixle.Animations {
	public abstract class AbstractAnimation: IAnimation {
		protected Area area;
		protected int target;

		protected const float SPEED = 0.1f;

		protected AbstractAnimation(Area area, int target) {
			this.area = area;
			this.target = target;
		}

		public abstract bool Animate(GameTime time);
	}
}

