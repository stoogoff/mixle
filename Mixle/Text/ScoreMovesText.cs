using System;
using Mixle.Entities;

namespace Mixle.Text {
	public class ScoreMovesText: PositionedText {
		protected Score score;

		public ScoreMovesText(Score score, int x, int y): base(score.Moves.ToString(), x, y) {
			this.score = score;
		}

		public override string Content() {
			return score.Moves.ToString();
		}
	}
}

