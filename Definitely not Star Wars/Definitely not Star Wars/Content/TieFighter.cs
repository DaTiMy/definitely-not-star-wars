using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definitely_not_Star_Wars
{
    class TieFighter : Sprite
    {
        
        public TieFighter(Texture2D texture) : base(texture)
        {
            this.Speed = 3f;
            
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            move();
          
            foreach (var sprite in sprites.ToArray())
            {
                if (sprite == this)
                {
                    continue;
                }
                if (this.Rectangle.Intersects(sprite.Rectangle))
                {
                    Game1._sprites.Remove(this);
                }
                if (this.Position.Y > 900)
                {
                    Game1._sprites.Remove(this);
                }
              


            }
            Position += Velocity;
        }
        public void move()
        {
            Velocity.Y = Speed;
           
        }
    }
}
