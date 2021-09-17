using System;
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

           
            Position += Velocity;
        }
        public void move()
        {
            Velocity.Y = Speed;

        }
    
}
}
