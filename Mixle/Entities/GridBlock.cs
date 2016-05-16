using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using evolve.Components;
using evolve.Input;

namespace Mixle.Entities {
	public class GridBlock: AbstractComponent {
		protected Texture2D texture;
		protected IList<Area> areas = new List<Area>();

		public GridBlock(Game game, Color colour) {
			Colour = colour;
			Enabled = false;
			Visible = true;

			texture = new Texture2D(game.GraphicsDevice, 1, 1);
			texture.SetData(new Color[] { Color.White });
		}

		public Color Colour { get; set; }
		public bool Active { get; set; }

		public void AddArea(int x, int y, int width, int height) {
			areas.Add(new Area(x, y, width, height));
		}

		public void AddArea(Area area) {
			areas.Add(area);
		}

		public IList<ColourPoint> GetSequence() {
			var points = new List<ColourPoint>();

			foreach(var area in areas) {
				points.Add(new ColourPoint(area.Center, Colour));
			}

			return points;
		}

		public bool Contains(Point p) {
			foreach(var area in areas) {
				if(area.Contains(p)) {
					return true;
				}
			}

			return false;
		}

		public void Merge(GridBlock block) {
			foreach(var area in block.areas) {
				AddArea(area);
			}
		}

		public IList<Area> Adjacent(GridBlock block) {
			var adjacent = new List<Area>();

			if(block.Colour != Colour) {
				return adjacent;
			}

			var points = new List<Point>();

			foreach(var rectangle in areas) {
				var p = rectangle.Center;
				var w = rectangle.Width;
				var h = rectangle.Height;

				points.Add(new Point((int) (p.X - w), p.Y)); // left
				points.Add(new Point((int) (p.X + w), p.Y)); // right
				points.Add(new Point(p.X, (int) (p.Y - h))); // above
				points.Add(new Point(p.X, (int) (p.Y + h))); // below
			}

			foreach(var p in points) {
				foreach(var area in block.areas) {
					if(area.Initial.Contains(p)) {
						adjacent.Add(area);
					}
				}
			}

			return adjacent;
		}

		public int Size() {
			return areas.Count;
		}

		#region Game drawing and update
		public override void Update(InputEvent evt) { }

		public override void Draw(SpriteBatch renderer) {
			var displayColour = Active ? new Color(Colour, 20) : Colour;

			foreach(var area in areas) {
				renderer.Draw(texture, area.Rectangle, displayColour);
			}
		}
		#endregion
	}
}

