﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Definitely_not_Star_Wars
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static List<Sprite> _sprites;
        public static List<Sprite> _hp;
        Texture2D playerImg;
        public static Texture2D pbulletImg, ebulletImg;

        Level level1;
        Texture2D tieFighterImg;
        Texture2D heart;
        Texture2D triple;
        Player playerObj;
        float currentTime;
       

        public static int windowW = 800, windowH = 1000;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = windowW;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = windowH;   // set this value to the desired height of your window
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            //Load Player IMG
            playerImg = Content.Load<Texture2D>("PlayerSprite");
            pbulletImg = Content.Load<Texture2D>("Green_Blaster_Long");
            tieFighterImg = Content.Load<Texture2D>("TieFighter");
            heart = Content.Load<Texture2D>("Heart");
            triple = Content.Load<Texture2D>("TripleshotPowerUp");
            level1 = new Level(tieFighterImg, triple);

            playerObj = new Player(playerImg, "Player")
            {
                Input = new Input()
                {
                    Left = Keys.A,
                    Right = Keys.D,
                    Up = Keys.W,
                    Down = Keys.S,
                    Fire = Keys.Space

                },
                Position = new Vector2(windowW / 2 - 25, windowH - 80),
                SColor = Color.White,
                Speed = 8f,
                w = 80f,
                h = 80f

            };
            // Player Load
            _sprites = new List<Sprite>(){ 
                playerObj
            };
            

            _hp = new List<Sprite>() { 
            };
            int x = 10, y = 10;
            for (int i = 0; i < playerObj.HP; i++)
            {
                
               _hp.Add(new Sprite(heart, "Heart")
               {
                   
                   w = 50f,
                   h = 50f,
                   Position = new Vector2(x, y)
               });
                x += 55;
            }
            level1.AddEnemy();
           




            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
    
                foreach (var sprite in _sprites.ToArray())
                {
                    
                    sprite.Update(gameTime, _sprites);
                
                }
            
            
            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
           
            level1.Update(currentTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();


            foreach (var sprite in _sprites)
            {
                sprite.Draw(spriteBatch);
            }
            foreach (var sprite in _hp)
            {
                sprite.Draw(spriteBatch);
            }



            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
