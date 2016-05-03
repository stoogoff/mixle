using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Mixle.Config;

namespace Mixle.Entities {
	public class Level {
		public Level() { }

		public int Par { get; set; }
		public int Size { get; set; }
		public bool Shuffle { get; set; }
		public string[] Sequence { get; set; }
		public int[] Grid { get; set; }
		public int[] Target { get; set; }

		public bool IsComplete(IList<Color> state) {
			if(state.Count != Target.Length) {
				return false;
			}

			var match = 0;

			for(var index = 0; index < state.Count; ++index) {
				if(state[index] == GetTargetColourAtIndex(index)) {
					match++;
				}
			}

			return match == Target.Length;
		}

		public Color GetSequenceColourAtIndex(int index) {
			return ColourSequence.Get(Sequence[index]);
		}

		public Color GetGridColourAtIndex(int index) {
			var colour = Grid[index];

			return ColourSequence.Get(Sequence[colour]);
		}

		public Color GetTargetColourAtIndex(int index) {
			var colour = Target[index];

			return ColourSequence.Get(Sequence[colour]);
		}

		public Color NextInSequence(Color nextColour) {
			for(int i = 0; i < Sequence.Length; ++i) {
				var colour = ColourSequence.Get(Sequence[i]);

				if(colour == nextColour) {
					var next = i + 1;

					return ColourSequence.Get(Sequence[next < Sequence.Length ? next : 0]);
				}
			}

			return nextColour;
		}
	}
}
