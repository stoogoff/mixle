using Microsoft.Xna.Framework.Graphics;
using evolve.Input;

namespace evolve.Components {
	public abstract class AbstractComponent: IController, IView {
		public bool Enabled { get; set; }
		public bool Visible { get; set; }

		public abstract void Draw(SpriteBatch renderer);
		public abstract void Update(InputEvent evt);
	}

	public abstract class AbstractView: IView {
		public bool Visible { get; set; }
		public abstract void Draw(SpriteBatch renderer);
	}

	public abstract class AbstractController: IController {
		public bool Enabled { get; set; }
		public abstract void Update(InputEvent evt);
	}
}

