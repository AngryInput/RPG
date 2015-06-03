using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace RolePlayingGame
{
    class Player
    {
        private const float velocityX = 3;
        private const float velocityY = 3;

        public Texture2D Texture;
        public Rectangle Rectangle;
        public Vector2 Velocity;
        public KeyboardState KeyState;

        public Player(int x, int y, int w, int h)
        {
            Rectangle = new Rectangle(x, y, w, h);
            Velocity = new Vector2(velocityX, velocityY);
        }

        public void LoadContent(ContentManager content, string asset)
        {
            Texture = content.Load<Texture2D>(asset);
        }

        public void Update(GameTime gameTime)
        {
            KeyState = Keyboard.GetState();

            if (KeyState.IsKeyDown(Keys.W))
                Rectangle.Y -= 5;
            if (KeyState.IsKeyDown(Keys.A))
                Rectangle.X -= 5;
            if (KeyState.IsKeyDown(Keys.S))
                Rectangle.Y += 5;
            if (KeyState.IsKeyDown(Keys.D))
                Rectangle.X += 5;

            if (Rectangle.X < 0)
                Rectangle.X = 0;

            if (Rectangle.X + Rectangle.Width > 640)
                Rectangle.X = 640 - Rectangle.Width;

            if (Rectangle.Y < 0)
                Rectangle.Y = 0;

            if (Rectangle.Y + Rectangle.Height > 480)
                Rectangle.Y = 480 - Rectangle.Height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Rectangle, Color.White);
        }
    }
}
