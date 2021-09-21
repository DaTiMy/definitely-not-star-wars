using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Definitely_not_Star_Wars
{

    public class Sprite
    {
        protected Texture2D _texture;
        protected Texture2D _secondtexture;

        public Vector2 Position;
        public Vector2 Velocity;
        public float w, h;
        public Color SColor = Color.White;
        public float Speed;
        public Input Input;
        public float rotation;
        static int sid = 0;
        int id;
        string name;
        //ID vergabe
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (value != null)
                { name = value; }
            }
        }
        public Rectangle Rectangle
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, (int)w, (int)h); }

        }
        //test
        public Sprite(Texture2D texture, Texture2D second, string name)
        {
            _texture = texture;
            _secondtexture = second;

            Id = sid + 1;
            sid++;
            Name = name;
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {
        }


        public virtual void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(_texture, Rectangle, SColor);
        }
        public virtual void Draw2(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_secondtexture, Rectangle, SColor);
        }

 




    }
}
