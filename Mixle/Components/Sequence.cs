using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using evolve.Components;
using Mixle.Config;
using Mixle.Entities;

namespace Mixle.Components {
	public class Sequence: IView {
		protected IList<TargetBlock> sequence;
		protected Texture2D texture;

		public Sequence(MixleGame game){
			texture = new Texture2D(game.GraphicsDevice, 1, 1);
			texture.SetData(new Color[] { Color.White });

			Visible = true;			
		}

		public bool Visible { get; set; }

		public void Create(Level level) {
			if(sequence != null) {
				sequence.Clear();
			}

			sequence = new List<TargetBlock>();

			var height = Sizes.InfoHeight - Sizes.SequenceHeight - Sizes.Pad / 2;
			var width = (Sizes.InfoWidth - Sizes.Pad) / level.Sequence.Length;
			var currentX = Sizes.PlayArea + Sizes.Pad / 2;

			for(var i = 0; i < level.Sequence.Length; ++i) {
				sequence.Add(new TargetBlock(currentX, height, width, Sizes.SequenceHeight, level.GetSequenceColourAtIndex(i)));

				currentX += width;
			}
		}

		public void Draw(SpriteBatch renderer) {
			foreach(var block in sequence) {
				renderer.Draw(texture, block.Rectangle, block.Colour);
			}
		}
	}
}

