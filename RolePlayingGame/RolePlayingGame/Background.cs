using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace RolePlayingGame
{
    class Background
    {
        public Texture2D Texture;
        public Rectangle Rectangle;

        public Background(int x, int y, int w, int h)
        {
            Rectangle = new Rectangle(x, y, w, h);
        }

        public void LoadContent(ContentManager content, string texture)
        {
            Texture = content.Load<Texture2D>(texture);
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Rectangle, Color.White);
        }
    }
}
