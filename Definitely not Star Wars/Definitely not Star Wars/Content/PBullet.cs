﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Definitely_not_Star_Wars
{
    class PBullet : Sprite
    {
        public PBullet(Texture2D texture, Texture2D second, string name): base(texture,second, name) {

            this.Speed = 10f;
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            move();

            Position += Velocity;

            foreach (var sprite in sprites.ToArray())
            {
                if (sprite == this)
                {
                    continue;
                }
                if (this.Position.Y < 1)
                {
                    GameManager._sprites.Remove(this);
                }
                
            }


                
        }
        public void move()
        {
            Velocity.Y -= Speed;

        }
    }
}
