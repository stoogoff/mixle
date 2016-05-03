using evolve.Input;

namespace evolve.Components {
	public interface IController {
		bool Enabled { get; set; }
		void Update(InputEvent evt);
	}
}

