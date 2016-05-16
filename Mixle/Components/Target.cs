using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using evolve.Components;
using Mixle.Config;
using Mixle.Entities;

namespace Mixle.Components {
	public class Target: IView {
		protected IList<TargetBlock> blocks;
		protected Texture2D texture;

		public Target(MixleGame game) {
			texture = new Texture2D(game.GraphicsDevice, 1, 1);
			texture.SetData(new Color[] { Color.White });

			Visible = true;
		}

		public bool Visible { get; set; }

		public void Create(Level level) {
			if(blocks != null) {
				blocks.Clear();
			}

			blocks = new List<TargetBlock>();

			var tile = (Dimensions.InfoWidth - Dimensions.Pad) / level.Size;
			var colour = 0;

			var startX = Dimensions.PlayArea + Dimensions.PadHalf;
			var currentX = 0;
			var currentY = Dimensions.PadHalf;

			for(var y = 0; y < level.Size; ++y) {
				currentX = startX;

				for(var x = 0; x < level.Size; ++x) {
					blocks.Add(new TargetBlock(currentX, currentY, tile, tile, level.GetTargetColourAtIndex(colour++)));

					currentX += tile;
				}

				currentY += tile;
			}
		}

		public void Draw(SpriteBatch renderer) {
			foreach(var block in blocks) {
				renderer.Draw(texture, block.Rectangle, block.Colour);
			}
		}
	}
}

