using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RolePlayingGame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player = new Player(0, 0, 30, 30);
        Background[,] background;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 480;

            background = new Background[graphics.PreferredBackBufferWidth / 30, graphics.PreferredBackBufferHeight / 30];
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            for (int i = 0; i < graphics.PreferredBackBufferWidth / 30; i++)
            {
                for (int j = 0; j < graphics.PreferredBackBufferHeight / 30; j++)
                {
                    background[i, j] = new Background(i * 30, j * 30, 30, 30);
                    background[i, j].LoadContent(Content, "back");
                }
            }

            player.LoadContent(Content, "player");
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            for (int i = 0; i < graphics.PreferredBackBufferWidth / 30; i++)
            {
                for (int j = 0; j < graphics.PreferredBackBufferHeight / 30; j++)
                {
                    background[i, j].Update(gameTime);
                }
            }

            player.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            for (int i = 0; i < graphics.PreferredBackBufferWidth / 30; i++)
            {
                for (int j = 0; j < graphics.PreferredBackBufferHeight / 30; j++)
                {
                    background[i, j].Draw(spriteBatch);
                }
            }

            player.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
