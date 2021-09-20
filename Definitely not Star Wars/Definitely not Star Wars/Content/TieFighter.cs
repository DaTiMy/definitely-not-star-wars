using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
        double time = 2f;
        SoundEffect tieexp;
        bool direction = true;
        float tempPos = 0;
        private int dmgCounter;
        private double immunityTime;

        public TieFighter(Texture2D texture, Texture2D second, string name, SoundEffect _tieexp, bool  _abnormal) : base(texture,second, name)
        {
            this.Speed = 1f;
            tieexp = _tieexp;
            Abnormal = _abnormal;
        }
     

        public bool Abnormal {
            get;set;
        
        }
        public bool Immunity { get; private set; }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (tempPos == 0)
            {
                tempPos = Position.X;
            }


            if (immunityTime > 0)
            {
                Immunity = true;
                immunityTime -= gameTime.ElapsedGameTime.TotalSeconds;
                if (immunityTime < 0)
                {
                    immunityTime = 0;
                }
            }
            else
            {
                dmgCounter = 0;
                Immunity = false;

            }


            move();


            if (time > 0)
            {
                time -= gameTime.ElapsedGameTime.TotalSeconds;
                if (time < 0)
                { time = 0; }
            }
            if(time == 0)
            Shoot();

            foreach (var sprite in sprites.ToArray())
            {
                if (sprite == this)
                {
                    continue;
                }
                if (this.Rectangle.Intersects(sprite.Rectangle))
                {
                    if (sprite.Name == "PBullet")
                    {
                        tieexp.Play();
                        Game1._sprites.Remove(sprite);
                        Game1._sprites.Remove(this);
                    }

                    if (sprite.Name == "Player")
                    {
                        if (!Immunity)
                        {
                            if (dmgCounter > 0 && dmgCounter < 2)
                            {
                                tieexp.Play();
                                immunityTime = 2f;
                            }
                        }
                               

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
            if (Abnormal)
            {
                Velocity.Y = Speed;

                if (this.Position.X >= this.tempPos + 30)
                {

                    direction = false;

                }
                else if (this.Position.X <= this.tempPos - 30)
                {

                    direction = true;
                }

                if (direction)
                {
                    Position.X += Speed*3;
                }
                else
                {
                    Position.X -= Speed*3;
                }
            }
            else {
                Velocity.Y = Speed;
            }
            
           
        }

        public void Shoot()
        {
            Game1._sprites.Add(new EBullet(Game1.ebulletImg, Game1.ebulletImg, "EBullet")
            {
                Position = new Vector2(this.Position.X+20, this.Position.Y+30),
                w = 40f,
                h = 30f

            });
            time = 2f;
        }

       

    }
}
