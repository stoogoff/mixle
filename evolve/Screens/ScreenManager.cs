using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using evolve.Input;

namespace evolve.Screens {
	// TODO handle popups
	public class ScreenManager {
		private readonly IDictionary<int, Screen> screens = new Dictionary<int, Screen>();
		private readonly string keyError = "Key '{0}' not found in screens.";

		public ScreenManager() { }

		#region Adding and removing screens
		public void Add(int index, Screen screen) {
			screens.Add(index, screen);

			if(screens.Count == 1) {
				EnableScreen(screen, true);
			}
		}

		public void Remove(int index) {
			if(!screens.ContainsKey(index)) {
				throw new KeyNotFoundException(string.Format(keyError, index));
			}

			var screen = screens[index];

			EnableScreen(screen, false);
			screens.Remove(index);
		}
		#endregion

		#region Manipulating screen state
		public void Activate(int index) {
			if(!screens.ContainsKey(index)) {
				throw new KeyNotFoundException(string.Format(keyError, index));
			}

			foreach(var kvp in screens) {
				if(kvp.Key == index) {
					continue;
				}

				EnableScreen(kvp.Value, false);
			}

			EnableScreen(screens[index], true);
		}

		public void Deactivate(int index) {
			if(!screens.ContainsKey(index)) {
				throw new KeyNotFoundException(string.Format(keyError, index));
			}

			EnableScreen(screens[index], false);
		}

		public void LoadContent() {
			foreach(var kvp in screens) {
				kvp.Value.LoadContent();
			}
		}
		#endregion

		protected void EnableScreen(Screen screen, bool enable) {
			screen.Enabled = enable;
			screen.Visible = enable;
		}

		#region Game loop
		public void Update(InputEvent evt) {
			foreach(var kvp in screens) {
				if(kvp.Value.Enabled) {
					kvp.Value.Update(evt);
				}
			}
		}

		public void Draw(SpriteBatch renderer) {
			foreach(var kvp in screens) {
				if(kvp.Value.Visible) {
					kvp.Value.Draw(renderer);
				}
			}
		}
		#endregion
	}
}

