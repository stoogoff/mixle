using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Mixle.Config {
	public static class ColourSequence {
		public static string Red = "RED";
		public static string Orange = "ORANGE";
		public static string Green = "GREEN";
		public static string Blue = "BLUE";
		public static string Purple = "PURPLE";

		private static readonly IDictionary<string, Color> colours = new Dictionary<string, Color>() {
			{ Red,    new Color(203, 31, 31)  },
			{ Orange, new Color(255, 204, 21) },
			{ Green,  new Color(53, 178, 59)  },
			{ Blue,   new Color(83, 159, 237) },
			{ Purple, new Color(159, 70, 191) },
		};

		public static Color Get(string name) {
			if(!colours.ContainsKey(name)) {
				throw new KeyNotFoundException(string.Format("Key '{0}' not found in colour sequence.", name));
			}

			return colours[name];
		}
	}
}

