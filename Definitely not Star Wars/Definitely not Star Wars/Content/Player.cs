﻿using Microsoft.Xna.Framework;
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
        public Player(Texture2D texture, Texture2D shielded, string name)
            : base(texture, shielded, name)
        {
            HP = 3;
            shieldedP = shielded;
        }



        int hp;

        private bool _fire;
        double time = 0;

        double tripleTime = 0;
        double rapidTime = 0;

        bool moveAble = true;
        bool triple = false;
        bool shield = false;
        bool rapid = false;
        public bool TripleActive {
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
            set {
                if (Convert.ToInt32(value) >= 0) { hp = value;  }
            }
        }
        public bool Fire { 
        get{ return _fire; }
            set { _fire = value; }
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {

            
            if (tripleTime > 0)
            {
                TripleActive = true;
                tripleTime -= gameTime.ElapsedGameTime.TotalSeconds;
                if (tripleTime < 0)
                { tripleTime = 0; }
            }
            else {
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
                        Game1._sprites.Remove(sprite);
                        if (ShieldActive)
                        { 
                            ShieldActive = false; 
                        }
                        else {
                            HP -= 1;
                            if (Game1._hp.Count != 0)
                                Game1._hp.RemoveAt(Game1._hp.Count - 1);
                        }
                        


                    }
                    if (sprite.Name == "EBullet")
                    {

                        Game1._sprites.Remove(sprite);
                        if (ShieldActive)
                        {
                            ShieldActive = false;
                        }
                        else {
                            HP -= 1;
                            if (Game1._hp.Count != 0)
                                Game1._hp.RemoveAt(Game1._hp.Count - 1);
                        }

                       


                    }
                    if (sprite.Name == "Triple")
                    {
                        tripleTime = Triple.tripletime;

                        Game1._sprites.Remove(sprite);
                        
                    }
                    if (sprite.Name == "Shield")
                    {
                        ShieldActive = true;

                        Game1._sprites.Remove(sprite);

                    }
                    if (sprite.Name == "Rapid")
                    {
                        rapidTime = Rapid.rapidtime;

                        Game1._sprites.Remove(sprite);

                    }

                }


            }
            Position += Velocity;
            Velocity = Vector2.Zero;

            
        }

        private void GameOver()
        {
            moveAble = false;
        }

        private void Move()
        {
            

            
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
                Velocity.Y = -Speed;

            }
            else if (Keyboard.GetState().IsKeyDown(Input.Down))
            {
                Velocity.Y = Speed;
            }
            
                if (time  == 0)
               {

                if (Keyboard.GetState().IsKeyDown(Input.Fire))
                {

                    Game1._sprites.Add(new PBullet(Game1.pbulletImg, Game1.pbulletImg, "PBullet")
                    {
                        Position = new Vector2(this.Position.X - 27, this.Position.Y - 15),
                        w = 60f,
                        h = 50f

                    });
                    Game1._sprites.Add(new PBullet(Game1.pbulletImg, Game1.pbulletImg, "PBullet")
                    {
                        Position = new Vector2(this.Position.X + 47, this.Position.Y - 15),
                        w = 60f,
                        h = 50f

                    });
                    if (TripleActive)
                    {
                        Game1._sprites.Add(new PBullet(Game1.pbulletImg, Game1.pbulletImg, "PBullet")
                        {
                            Position = new Vector2(this.Position.X+10, this.Position.Y - 45),
                            w = 60f,
                            h = 50f

                        });
                    }

                    if (RapidActive)
                    {
                        time = 0.1f;
                    }
                    else {
                        time = 0.3f;
                    }
                    
                }
            }
            




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
