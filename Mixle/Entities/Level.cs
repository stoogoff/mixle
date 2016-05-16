using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;

namespace Mixle.Entities {
	[XmlType(TypeName="level")]
	public class Level {
		public Level() { }

		[XmlElement(ElementName="number")]
		public int Number { get; set; }

		[XmlElement(ElementName="par")]
		public int Par { get; set; }

		[XmlElement(ElementName="size")]
		public int Size { get; set; }

		[XmlElement(ElementName="shuffle")]
		public bool Shuffle { get; set; }

		[XmlIgnore]
		public string[] Sequence { get; set; }

		[XmlIgnore]
		public int[] Grid { get; set; }

		[XmlIgnore]
		public int[] Target { get; set; }

		public string sequence {
			get {
				return String.Join(" ", Sequence);
			}
			set {
				Sequence = value.Split(new char[] { ' ' });
			}
		}

		public string grid {
			get {
				return String.Join(" ", Grid);
			}
			set {
				Grid = value.Split(new char[] { ' ' }).Select(i => int.Parse(i)).ToArray();
			}
		}

		public string target {
			get {
				return String.Join(" ", Target);
			}
			set {
				Target = value.Split(new char[] { ' ' }).Select(i => int.Parse(i)).ToArray();
			}
		}

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
