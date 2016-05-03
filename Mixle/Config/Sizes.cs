using System;

namespace Mixle.Config {
	// TODO these need to come from a config file for easy update between devices
	public static class Sizes {
		public static int ScreenWidth {
			get {
				return 800;
			}
		}
		public static int ScreenHeight {
			get {
				return 600;

			}
		}

		// padding between blocks on the grid
		public static int Pad {
			get {
				return 20;
			}
		}

		// grid play area
		public static int PlayArea {
			get {
				return 600;
			}
		}

		// info column
		public static int InfoWidth {
			get {
				return 200;
			}
		}

		public static int InfoHeight {
			get {
				return 600;
			}
		}

		// colour sequence display
		public static int SequenceHeight {
			get {
				return 20;
			}
		}
	}
}

