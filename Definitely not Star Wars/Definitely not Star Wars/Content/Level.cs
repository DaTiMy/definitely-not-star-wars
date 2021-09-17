﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definitely_not_Star_Wars
{
    class Level
    {
        public List<Sprite> Enemies;
        Texture2D tieFighterImg;

        public Level(Texture2D _tieFighterImg)
        {

            tieFighterImg = _tieFighterImg;




        }
        public void AddEnemy()
        {
            
            Game1._sprites.Add(new TieFighter(tieFighterImg)
            {
                Position = new Vector2(Game1.windowW / 2 - 25, Game1.windowH - 600),
                w = 80f,
                h = 80f,

            });
        }

        public void Update(GameTime gameTime)
        {
            if (gameTime.ElapsedGameTime.TotalSeconds == 3)
            {
                Game1._sprites.Add(new TieFighter(tieFighterImg)
                {
                    Position = new Vector2(Game1.windowW / 2 - 25, Game1.windowH - 600),
                    w = 80f,
                    h = 80f,

                });
            }
        }

        
    }
}
