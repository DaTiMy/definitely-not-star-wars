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
            this.Speed = 5f;
            
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
