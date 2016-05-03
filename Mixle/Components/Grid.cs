using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using evolve.Components;
using evolve.Input;
using Mixle.Animations;
using Mixle.Config;
using Mixle.Entities;

namespace Mixle.Components {
	public class Grid: AbstractComponent {
		protected Level level;
		protected MixleGame game;
		protected IList<GridBlock> blocks;
		protected Animator animation;

		protected const int MAX_ACTIVE = 2;

		public Grid(MixleGame game) {
			this.game = game;

			Enabled = true;
			Visible = true;
		}

		public void Create(Level nextLevel) {
			if(blocks != null) {
				blocks.Clear();
			}

			blocks = new List<GridBlock>();
			level = nextLevel;

			var padHalf = Sizes.Pad / 2;
			var colour = 0;
			var currentX = padHalf;
			var currentY = padHalf;
			var tile = (Sizes.PlayArea / level.Size) - Sizes.Pad;

			for(var y = 0; y < level.Size; ++y) {
				currentX = padHalf;

				for(var x = 0; x < level.Size; ++x) {
					var block = new GridBlock(game, level.GetGridColourAtIndex(colour++));

					block.AddArea(currentX, currentY, tile, tile);

					currentX += tile + Sizes.Pad;

					blocks.Add(block);
				}

				currentY += tile + Sizes.Pad;
			}
		}

		public IList<Color> GetSequence() {
			var points = new List<ColourPoint>();

			foreach(var block in blocks) {
				points.AddRange(block.GetSequence());
			}

			points.Sort();

			return points.Select(p => p.Colour).ToList();
		}

		protected IList<GridBlock> GetActiveBlocks() {
			var active = new List<GridBlock>();

			foreach(var block in blocks) {
				if(block.Active) {
					active.Add(block);
				}
			}

			return active;
		}

		public bool Activate(Point position) {
			var active = GetActiveBlocks();
			var activated = active.Count;
			string toPlay = null;

			foreach(var block in blocks) {
				if(block.Contains(position)) {
					if(active.Count < MAX_ACTIVE) {
						block.Active = !block.Active;
					}
					else {
						block.Active = false;
					}

					// TODO sfx
					if(block.Active) {
						toPlay = "activate";
					}
					else {
						toPlay = "deactivate";
					}

					if(block.Active) {
						active.Add(block);
					}
					else if(active.Contains(block)) {
						active.Remove(block);
					}
				}
			}

			if(active.Count == MAX_ACTIVE) {
				var head = active[0];
				var tail = active[1];

				var headAdjacent = tail.Adjacent(head);
				var tailAdjacent = head.Adjacent(tail);

				if(headAdjacent.Count > 0 && tailAdjacent.Count > 0) {
					// TODO sfx
					toPlay = "goodlink";

					// head is bigger than tail so merge head into tail rather than tail into head
					if(head.Size() > tail.Size()) {
						var tmp = headAdjacent;

						headAdjacent = tailAdjacent;
						tailAdjacent = tmp;
					}

					head.Active = tail.Active = false;

					var nextColour = level.NextInSequence(head.Colour);

					animation = new Animator(headAdjacent[0], tailAdjacent, () => {
						head.Merge(tail);
						head.Colour = nextColour;

						blocks.Remove(tail);
					});
				}
				else {
					// TODO sfx
					toPlay = "badlink";
				}
			}

			if(toPlay != null) {
				// TODO sfx
				// toPlay.play() or whatever
			}

			return activated != active.Count;
		}

		public override void Update(InputEvent evt) {
			if(animation != null) {
				animation.Update(evt);
			}
		}

		public override void Draw(SpriteBatch renderer) {
			foreach(var block in blocks) {
				block.Draw(renderer);
			}
		}
	}
}

