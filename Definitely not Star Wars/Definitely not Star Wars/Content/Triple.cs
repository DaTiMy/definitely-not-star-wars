﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Definitely_not_Star_Wars
{
    class Triple : Sprite
    {
       public static double tripletime = 20;


        public Triple(Texture2D texture, string name) : base(texture, name)
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
                    if (sprite.Name == "Player")
                    {
                        
                        Game1._sprites.Remove(this);
                    }


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