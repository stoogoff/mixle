using Microsoft.Xna.Framework.Graphics;

namespace evolve.Components {
	public interface IView {
		bool Visible { get; set; }
		void Draw(SpriteBatch renderer);
	}
}

