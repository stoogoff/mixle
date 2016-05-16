using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using evolve.Input;
using evolve.Screens;
using Mixle.Config;
using Mixle.Screens;

namespace Mixle {
	public class MixleGame : Game {
		private readonly GraphicsDeviceManager graphics;
		private SpriteBatch renderer;
		private readonly ScreenManager screens = new ScreenManager();

		public MixleGame() {
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			// TODO device dependant
			graphics.IsFullScreen = false;
			graphics.PreferredBackBufferWidth = Dimensions.ScreenWidth;
			graphics.PreferredBackBufferHeight = Dimensions.ScreenHeight;

			IsMouseVisible = true;
		}

		protected override void Initialize() {
			//screens.Add((int) ScreenIndex.Loading,  new Loading(this));
			//screens.Add((int) ScreenIndex.Start,    new StartMenu(this));
			screens.Add((int) ScreenIndex.Play,     new GamePlay(this));
			//screens.Add((int) ScreenIndex.GameOver, new GameOver(this));

			base.Initialize();
		}

		protected override void LoadContent() {
			renderer = new SpriteBatch(GraphicsDevice);

			screens.LoadContent();

			/*var levels = new List<Mixle.Entities.Level>()
			{
				new Mixle.Entities.Level() {
					Number = 1,
					Par = 4,
					Size = 2,
					Sequence = new string[] { "RED", "GREEN", "BLUE" },
					Shuffle = true,
					Grid = new int[] { 0, 0, 1, 1 },
					Target = new int[] { 1, 1, 2, 2 },
				},
				new Mixle.Entities.Level() {
					Number = 2,
					Par = 8,
					Size = 3,
					Sequence = new string[] { "RED", "GREEN", "BLUE" },
					Shuffle = true,
					Grid = new int[] { 1, 2, 1, 2, 2, 0, 1, 1, 1 },
					Target = new int[] { 1, 0, 1, 0, 0, 0, 1, 0, 1 },
				}
			};

			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Indent = true;

			using( XmlWriter writer = XmlWriter.Create( "Levels.xml", settings ) )
			{
				Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate.IntermediateSerializer.Serialize( writer, levels, null );
			}*/
		}

		protected override void Update(GameTime time) {
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			// Exit() is obsolete on iOS
			#if !__IOS__ &&  !__TVOS__
			if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
			#endif

			// TODO multiple device inputs, not just mouse
			var state = Mouse.GetState();

			screens.Update(new InputEvent(time, state.X, state.Y, state.LeftButton == ButtonState.Pressed));
            
			base.Update(time);
		}

		protected override void Draw(GameTime time) {
			graphics.GraphicsDevice.Clear(new Color(55, 55, 55));

			renderer.Begin();
			screens.Draw(renderer);
			renderer.End();

			base.Draw(time);
		}
	}
}

