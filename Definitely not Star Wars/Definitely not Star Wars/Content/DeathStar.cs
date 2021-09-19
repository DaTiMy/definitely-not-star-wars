﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definitely_not_Star_Wars
{
    class DeathStar : Sprite
    {
        double time = 2f;
        SoundEffect bossHitSFX;

        int hp;

        bool direction = true;


        public int HP
        {
            get { return hp; }
            set { hp = value; }
        
        }
        public DeathStar(Texture2D texture, Texture2D second, string name, SoundEffect _bossHitSFX, int _hp) : base(texture, second, name)
        {
            this.Speed = 1f;
            bossHitSFX = _bossHitSFX;
            HP = _hp;

        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
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
                        bossHitSFX.Play();
                        if (HP > 0)
                        {
                            Game1._sprites.Remove(sprite);
                            HP -= 1; 
                        
                        }
                        else {

                            Game1._sprites.Remove(sprite);
                            Game1._sprites.Remove(this);
                        }
                        
                    }

                    if (sprite.Name == "Player")
                    {
                        

                    }


                }



                if (this.Position.Y > 900)
                {
                    Game1._sprites.Remove(this);
                }



            }

            if (Position.X == 600)
            {

                direction = false;

            }
            else if (Position.X == 100)
            {

                direction = true;
            }
            if (direction)
            {
                Position += Velocity;
            }
            else {
                Position -= Velocity;
            }
           
            

        }
        public void move()
        {
            
                Velocity.X = Speed;
           
          
            

        }

        public void Shoot()
        {
            Game1._sprites.Add(new EBullet(Game1.ebulletImg, Game1.ebulletImg, "EBullet")
            {
                Position = new Vector2(this.Position.X+20, this.Position.Y + 100),
                w = 40f,
                h = 30f,
                Speed = 0.02f
            });
            
            Game1._sprites.Add(new EBullet(Game1.ebulletImg, Game1.ebulletImg, "EBullet")
            {
                Position = new Vector2(this.Position.X+40, this.Position.Y + 100),
                w = 40f,
                h = 30f,
                Speed = 0.005f
            });
            Game1._sprites.Add(new EBullet(Game1.ebulletImg, Game1.ebulletImg, "EBullet")
            {
                Position = new Vector2(this.Position.X+60, this.Position.Y + 100),
                w = 40f,
                h = 30f,
                Speed = 0.02f
            });
            Game1._sprites.Add(new EBullet(Game1.ebulletImg, Game1.ebulletImg, "EBullet")
            {
                Position = new Vector2(this.Position.X+80, this.Position.Y + 100),
                w = 40f,
                h = 30f,
                Speed = 0.005f
            });

            time = 1f;

        }

    }
}
