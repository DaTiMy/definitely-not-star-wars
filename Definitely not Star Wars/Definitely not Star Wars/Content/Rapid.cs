using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Definitely_not_Star_Wars
{
    class Rapid : Sprite
    {
        public static double rapidtime = 15;


        public Rapid(Texture2D texture, Texture2D second, string name) : base(texture, second, name)
        {
            this.Speed = 3f;

        }



        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            move();


            Position += Velocity;
        }
        public void move()
        {
            Velocity.Y = Speed;

        }

    }
}
