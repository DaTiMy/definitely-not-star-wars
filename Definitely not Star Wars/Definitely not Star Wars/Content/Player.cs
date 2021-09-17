using Microsoft.Xna.Framework;
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
        public Player(Texture2D texture, string name)
            : base(texture, name)
        {
            HP = 3;
        }
        private bool _fire;
        double time = 0;
        int hp;
        bool moveAble = true;


        public int HP
        {
            get { return hp; }
            set {
                if (Convert.ToInt32(value) >= 0) { hp = value; } else { throw new Exception("HP muss einen Wert über -1 haben!"); }
            }
        }
        public bool Fire { 
        get{ return _fire; }
            set { _fire = value; }
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {

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
                        HP -= 1;
                        Game1._hp.RemoveAt(Game1._hp.Count - 1);


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

                    Game1._sprites.Add(new PBullet(Game1.pbulletImg, "PBullet")
                    {
                        Position = new Vector2(this.Position.X - 27, this.Position.Y - 15),
                        w = 60f,
                        h = 50f

                    });
                    Game1._sprites.Add(new PBullet(Game1.pbulletImg, "PBullet")
                    {
                        Position = new Vector2(this.Position.X + 47, this.Position.Y - 15),
                        w = 60f,
                        h = 50f

                    });
                 

                    time = 0.4f;
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
