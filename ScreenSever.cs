using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Snow_fall
{
    internal class ScreenSever : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D snow;
        private Texture2D background;
        private SnowFall snowFall;

        private readonly Random random = new Random();

        /// <summary>
        /// 
        /// </summary>
        public ScreenSever()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = Constants.WindowHeight;
            graphics.PreferredBackBufferWidth = Constants.WindowWidth;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            snowFall = new SnowFall();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            snow = TextureLoader.Load("snow", Content);
            background = TextureLoader.Load("backgraund", Content);
            snowFall.CreatSnowfleakList(Constants.WindowWidth, Constants.WindowHeight, snow);
        }

        protected override void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Exit();
            }
            snowFall.Move();
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, Constants.WindowWidth, Constants.WindowHeight), Color.White);
            foreach (var s in snowFall.snowfleaks)
            {
                spriteBatch.Draw(s.Texture, new Rectangle(s.Pos.X, s.Pos.Y, s.Size, s.Size), new Rectangle(0, 0, snow.Width, snow.Height), Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
