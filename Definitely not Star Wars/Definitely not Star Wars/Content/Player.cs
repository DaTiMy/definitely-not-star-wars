using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Definitely_not_Star_Wars
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Player : Game
    {

        Texture2D playerImg;
        Vector2 position;
        Vector2 scale;
        Vector2 velocity;
        private float _rotation;
        public Vector2 Origin;

        private float _speed = 3f;
        public float rotationVelocity = 3f;
        KeyboardState keyboard;


        public Player(Texture2D _playerImg, Vector2 _position, Vector2 _scale)
        {

            playerImg = _playerImg;
            position = _position;
            scale = _scale;
            velocity = Vector2.Zero;
        }

        public void Update()
        {
            keyboard = Keyboard.GetState();





            
           

            if (keyboard.IsKeyDown(Keys.W))
            {
                position.Y -=  _speed;
            }

            if (keyboard.IsKeyDown(Keys.S))
            {
                position.Y +=  _speed;
            }

            if (keyboard.IsKeyDown(Keys.A))
            {
                position.X -=  _speed;
            }

            if (keyboard.IsKeyDown(Keys.D))
            {
                position.X +=  _speed;
            }

            if (keyboard.IsKeyDown(Keys.Space))
            {

            }

        }


        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(playerImg, GetRect(), Color.White);
         
        }
        public Rectangle GetRect()
        {
            Rectangle r = new Rectangle((int)position.X, (int)position.Y, (int)scale.X, (int)scale.Y);
            return r;
        }
    }
}
