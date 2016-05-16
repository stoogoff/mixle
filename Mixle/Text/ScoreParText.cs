using System;
using Mixle.Entities;

namespace Mixle.Text {
	public class ScoreParText: PositionedText {
		protected Score score;

		public ScoreParText(Score score, int x, int y): base(score.Par.ToString(), x, y) {
			this.score = score;
		}

		public override string Content() {
			return score.Par.ToString();
		}
	}
}

