using System;

namespace Mixle.Entities {
	public class Score {
		public Score(int moves, int par) {
			Moves = moves;
			Par = par;
		}

		public Score(): this(0, 0) { }

		public int Moves { get; set; }
		public int Par { get; set; }

		public void EndLevel(int levelPar) {
			Par += Moves - levelPar;
			Moves = 0;
		}
	}
}

