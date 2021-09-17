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
        public TieFighter(Texture2D texture, Vector2 pos) : base(texture)
        {
            this.Speed = 5;
            this.Position = pos;
        }
        public void Move()
        {
            
        }
    }
}
