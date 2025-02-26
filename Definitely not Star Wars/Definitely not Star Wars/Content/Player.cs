﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Definitely_not_Star_Wars
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Player : Sprite
    {
        Texture2D shieldedP;
        SoundEffect shootSFX;

        public Player(Texture2D texture, Texture2D shielded, string name, SoundEffect seffect)
            : base(texture, shielded, name)
        {
            HP = 3;
            shieldedP = shielded;
            shootSFX = seffect;

        }



        int hp;
        double immunityTime = 0;
        int dmgCounter = 0;

        private bool _fire;
        double time = 0;

        double tripleTime = 0;
        double rapidTime = 0;

        bool moveAble = true;
        bool triple = false;
        bool shield = false;
        bool rapid = false;
        public bool TripleActive
        {
            get { return triple; }
            set { triple = value; }
        }

        public bool RapidActive
        {
            get { return rapid; }
            set { rapid = value; }
        }

        public bool ShieldActive
        {
            get { return shield; }
            set { shield = value; }
        }

        public int HP
        {
            get { return hp; }
            set
            {
                if (Convert.ToInt32(value) >= 0) { hp = value; }
            }
        }
        public bool Immunity
        {
            get; set;
        }

        public bool Fire
        {
            get { return _fire; }
            set { _fire = value; }
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
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

            if (tripleTime > 0)
            {
                TripleActive = true;
                tripleTime -= gameTime.ElapsedGameTime.TotalSeconds;
                if (tripleTime < 0)
                { tripleTime = 0; }
            }
            else
            {
                TripleActive = false;
            }

            if (rapidTime > 0)
            {
                RapidActive = true;
                rapidTime -= gameTime.ElapsedGameTime.TotalSeconds;
                if (rapidTime < 0)
                { rapidTime = 0; }
            }
            else
            {
                RapidActive = false;
            }

            if (moveAble)
            { Move(); }

            if (time > 0)
            {
                time -= gameTime.ElapsedGameTime.TotalSeconds;
                if (time < 0)
                { time = 0; }
            }
            if (HP < 1)
            {
                GameOver();
            }

            foreach (var sprite in sprites.ToArray())
            {
                if (sprite == this)
                {
                    continue;
                }
                ///if ((this.Velocity.X) > 0 && this.IsTouchingLeft(sprite) || (this.Velocity.X < 0 && this.IsTouchingRight(sprite)))
                ///{ this.Velocity.X = 0; }
                /// if ((this.Velocity.Y) > 0 && this.IsTouchingTop(sprite) || (this.Velocity.Y < 0 && this.IsTouchingBottom(sprite)))
                /// { this.Velocity.Y = 0; }

                if (this.Rectangle.Intersects(sprite.Rectangle))
                {
                    if (sprite.Name == "Tie-Fighter")
                    {
                        dmgCounter++;
                        if (!Immunity)
                        {
                            if (dmgCounter > 0 && dmgCounter < 2)
                            {
                                immunityTime = 2f;
                                GameManager._sprites.Remove(sprite);
                                if (ShieldActive)
                                {
                                    ShieldActive = false;
                                }
                                else
                                {

                                    HP -= 1;
                                    if (GameManager._hp.Count != 0)
                                        GameManager._hp.RemoveAt(GameManager._hp.Count - 1);
                                }

                            }
                        }




                    }
                    if (sprite.Name == "DeathStar")
                    {
                        dmgCounter++;
                        if (!Immunity)
                        {
                            if (dmgCounter > 1)
                            {
                                immunityTime = 2f;
                                GameManager._sprites.Remove(sprite);
                                if (ShieldActive)
                                {
                                    ShieldActive = false;
                                }
                                else
                                {

                                    HP -= 1;
                                    if (GameManager._hp.Count != 0)
                                        GameManager._hp.RemoveAt(GameManager._hp.Count - 1);
                                }
                                dmgCounter = 0;
                            }
                        }




                    }
                    if (sprite.Name == "EBullet")
                    {
                        dmgCounter++;
                        if (!Immunity)
                        {
                            if (dmgCounter > 0 && dmgCounter < 2)
                            {
                                GameManager._sprites.Remove(sprite);
                                immunityTime = 2f;

                                if (ShieldActive)
                                {
                                    ShieldActive = false;
                                }
                                else
                                {

                                    HP -= 1;
                                    if (GameManager._hp.Count != 0)
                                        GameManager._hp.RemoveAt(GameManager._hp.Count - 1);


                                }


                            }

                        }


                    }
                    if (sprite.Name == "EPlasma")
                    {
                        dmgCounter++;
                        if (!Immunity)
                        {
                            if (dmgCounter > 0 && dmgCounter < 2)
                            {
                                GameManager._sprites.Remove(sprite);
                                immunityTime = 2f;

                                if (ShieldActive)
                                {
                                    ShieldActive = false;
                                }
                                else
                                {

                                    HP -= 1;
                                    if (GameManager._hp.Count != 0)
                                        GameManager._hp.RemoveAt(GameManager._hp.Count - 1);






                                }


                            }

                        }


                    }

                    if (sprite.Name == "Triple")
                    {
                        tripleTime = Triple.tripletime;

                        GameManager._sprites.Remove(sprite);

                    }
                    if (sprite.Name == "Shield")
                    {
                        ShieldActive = true;

                        GameManager._sprites.Remove(sprite);

                    }
                    if (sprite.Name == "Rapid")
                    {
                        rapidTime = Rapid.rapidtime;

                        GameManager._sprites.Remove(sprite);

                    }

                }


            }


            Position += Velocity;
            Velocity = Vector2.Zero;


        }

        private void GameOver()
        {
            moveAble = false;
            AddPlasmaStorm(this.Position.X / 2, this.Position.Y / 2);
            GameManager.gameOver = true;

        }
        public void AddPlasmaStorm(float posx, float posy)
        {
            GameManager._sprites.Add(new EPlasma(GameManager.plasma, GameManager.plasma, "EPlasma", true, true, false, false)
            {
                Position = new Vector2(posx, posy),
                w = 20f,
                h = 20f,

            });
            GameManager._sprites.Add(new EPlasma(GameManager.plasma, GameManager.plasma, "EPlasma", false, false, false, false)
            {
                Position = new Vector2(posx, posy + 10),
                w = 20f,
                h = 20f,

            });
            GameManager._sprites.Add(new EPlasma(GameManager.plasma, GameManager.plasma, "EPlasma", true, false, true, false)
            {
                Position = new Vector2(posx, posy),
                w = 20f,
                h = 20f,

            });
            GameManager._sprites.Add(new EPlasma(GameManager.plasma, GameManager.plasma, "EPlasma", true, true, false, true)
            {
                Position = new Vector2(posx, posy),
                w = 20f,
                h = 20f,

            });
            GameManager._sprites.Add(new EPlasma(GameManager.plasma, GameManager.plasma, "EPlasma", false, false, false, true)
            {
                Position = new Vector2(posx, posy - 10),
                w = 20f,
                h = 20f,

            });
            GameManager._sprites.Add(new EPlasma(GameManager.plasma, GameManager.plasma, "EPlasma", true, false, true, true)
            {
                Position = new Vector2(posx, posy),
                w = 20f,
                h = 20f,

            });
            GameManager._sprites.Add(new EPlasma(GameManager.plasma, GameManager.plasma, "EPlasma", false, true, false, false)
            {
                Position = new Vector2(posx - 10, posy),
                w = 20f,
                h = 20f,

            });
            GameManager._sprites.Add(new EPlasma(GameManager.plasma, GameManager.plasma, "EPlasma", false, false, true, false)
            {
                Position = new Vector2(posx + 10, posy),
                w = 20f,
                h = 20f,

            });
        }
        private void Move()
        {


            if (Position.X > 780)
            { Position.X = -60; }
            if (Position.X < -60)
            { Position.X = 780; }

            if (Keyboard.GetState().IsKeyDown(Input.Left))
            {
                Velocity.X = -Speed;

            }
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
            {
                Velocity.X = Speed;
            }

            if (Keyboard.GetState().IsKeyDown(Input.Up))
            {
                if (Position.Y < 10)
                { this.Velocity.Y = 0; }
                else
                {
                    Velocity.Y = -Speed;
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Down))
            {

                if (Position.Y > 900)
                { this.Velocity.Y = 0; }
                else
                {
                    Velocity.Y = Speed;
                }
            }

            if (time == 0)
            {

                if (Keyboard.GetState().IsKeyDown(Input.Fire))
                {
                    shootSFX.Play();
                    GameManager._sprites.Add(new PBullet(GameManager.pbulletImg, GameManager.pbulletImg, "PBullet")
                    {
                        Position = new Vector2(this.Position.X - 27, this.Position.Y - 15),
                        w = 60f,
                        h = 50f

                    });
                    GameManager._sprites.Add(new PBullet(GameManager.pbulletImg, GameManager.pbulletImg, "PBullet")
                    {
                        Position = new Vector2(this.Position.X + 47, this.Position.Y - 15),
                        w = 60f,
                        h = 50f

                    });
                    if (TripleActive)
                    {
                        GameManager._sprites.Add(new PBullet(GameManager.pbulletImg, GameManager.pbulletImg, "PBullet")
                        {
                            Position = new Vector2(this.Position.X + 10, this.Position.Y - 45),
                            w = 60f,
                            h = 50f

                        });
                    }

                    if (RapidActive)
                    {
                        time = 0.1f;
                    }
                    else
                    {
                        time = 0.3f;
                    }

                }
            }






        }

        public void MoveOutOfScreen()
        {
            moveAble = false;
            Velocity.Y = -Speed;
           

        }
        public void FireRateCD()
        {
            Fire = false;
        }
        public void FireRateA()
        {
            Fire = true;
        }
    }
}
