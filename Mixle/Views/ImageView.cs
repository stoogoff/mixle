﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using evolve.Components;

namespace Mixle.Views {
	public class ImageView: IView {
		protected Rectangle position;

		public ImageView(Texture2D image, Rectangle position) {
			Visible = true;
			Image = image;

			this.position = position;
		}

		public ImageView(Texture2D image, int width, int height): this(image, new Rectangle(0, 0, width, height)) { }

		public bool Visible { get; set; }
		public Texture2D Image { get; set; }

		public void Draw(SpriteBatch renderer) {
			if(!Visible || Image == null) {
				return;
			}

			renderer.Draw(Image, position, Color.White);
		}
	}
}

