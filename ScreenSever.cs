using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Snow_fall.Properties;

namespace Snow_fall
{
    internal class ScreenSever : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D snow;
        private Texture2D background;
        private SnowFall snowFall;

        private int timeCounter = 0;
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

            if (!Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                timeCounter++;
            }
            else
            {
                timeCounter = 0;
            }
            if (timeCounter > 100)
            {
                snowFall.Move();
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (timeCounter > 100)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(background, new Rectangle(0, 0, Constants.WindowWidth, Constants.WindowHeight), Color.White);
                foreach (var s in snowFall.snowfleaks)
                {
                    spriteBatch.Draw(s.Texture, new Rectangle(s.Pos.X, s.Pos.Y, s.Size, s.Size), new Rectangle(0, 0, snow.Width, snow.Height), Color.White);
                }
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }
    }
}
