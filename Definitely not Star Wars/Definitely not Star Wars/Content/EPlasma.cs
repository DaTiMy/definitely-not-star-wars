using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Definitely_not_Star_Wars
{
    class EPlasma : Sprite
    {
        

        public bool Diagonal {
            get;set;
        }
        public bool Left
        {
            get; set;
        }
        public bool Right
        {
            get; set;
        }

        public bool Back
        {
            get; set;
        }
        public EPlasma(Texture2D texture, Texture2D second, string name, bool _diagonal, bool _left, bool _right, bool _back) : base(texture, second, name)
        {

            this.Speed = 0.005f;
            Diagonal = _diagonal;
            Left = _left;
            Right = _right;
            Back = _back;

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
                if (this.Position.Y > 1000 || this.Position.Y < 1)
                {
                    Game1._sprites.Remove(this);
                }
                if (this.Position.X > 700 || this.Position.X < 1 )
                {
                    Game1._sprites.Remove(this);
                }

            }



        }
        public void move()
        {
            if (!Diagonal && !Left && !Right && !Back || !Diagonal && Left && Right && !Back)
            {
                Velocity.Y += Speed;
            }
            else if (Diagonal && Left && !Back)
            {
                Velocity.Y += Speed;
                Velocity.X -= Speed;
            }
            else if (Diagonal && Right && !Back)
            {
                Velocity.Y += Speed;
                Velocity.X += Speed;
            }
            else if (Diagonal && Left && Back)
            {
                Velocity.Y -= Speed;
                Velocity.X -= Speed ;
            }
            else if (Diagonal && Right && Back)
            {
                Velocity.Y -= Speed;
                Velocity.X += Speed ;
            }
            else if (!Diagonal && !Right && !Left && Back || Diagonal && Back)
            {
                Velocity.Y -= Speed;
                
            }
            else if (!Diagonal && Right && !Left && !Back)
            {
                Velocity.X += Speed;

            }
            else if (!Diagonal && !Right && Left && !Back)
            {
                Velocity.X -= Speed;

            }

        }
    }
}
