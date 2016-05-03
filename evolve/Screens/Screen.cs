using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using evolve.Components;
using evolve.Input;

namespace evolve.Screens {
	public abstract class Screen: AbstractComponent {
		private readonly IList<object> components = new List<object>();

		protected Screen(Game game) {
			Game = game;
		}

		public Game Game { get; protected set; }

		public virtual void LoadContent() {}

		public void Add(object component) {
			components.Add(component);
		}

		public void Remove(object component) {
			if(components.Contains(component)) {
				components.Remove(component);
			}
		}

		public override void Draw(SpriteBatch renderer) {
			foreach(var obj in components) {
				var component = obj as IView;

				if(component != null && component.Visible) {
					component.Draw(renderer);
				}
			}			
		}

		public override void Update(InputEvent evt) {
			foreach(var obj in components) {
				var component = obj as IController;

				if(component != null && component.Enabled) {
					component.Update(evt);
				}
			}
		}
	}
}

