using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using evolve.Components;
using evolve.Input;
using Mixle.Entities;

namespace Mixle.Animations {
	public class Animator: AbstractController {
		protected Action complete;
		protected readonly IList<IAnimation> animations = new List<IAnimation>();

		public Animator(Area from, IList<Area> to, Action complete) {
			Enabled = true;

			this.complete = complete;

			foreach(var target in to) {
				if(from.Initial.Y < target.Initial.Y) {
					animations.Add(new HeightAnimation(from, target.Initial.Y));
				}
				else if(from.Initial.Y > target.Initial.Y) {
					animations.Add(new TopAnimation(from, target.Initial.Y + target.Initial.Height));
				}
				else {
					if(from.Initial.X < target.Initial.X) {
						animations.Add(new WidthAnimation(from, target.Initial.X));
					}
					else {
						animations.Add(new LeftAnimation(from, target.Initial.X + target.Initial.Width));
					}
				}
			}
		}

		public override void Update(InputEvent evt) {
			if(!Enabled) {
				return;
			}

			int more = 0;

			foreach(var animation in animations) {
				if(animation.Animate(evt.Time)) {
					more++;
				}
			}

			Enabled = more == animations.Count;

			if(!Enabled) {
				complete();
			}
		}
	}
}

