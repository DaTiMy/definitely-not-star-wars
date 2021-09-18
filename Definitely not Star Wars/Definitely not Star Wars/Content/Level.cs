using System;
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
        Texture2D triple;
        Texture2D shield;
        Texture2D rapid;
        public Level(Texture2D _tieFighterImg, Texture2D _triple, Texture2D _shield, Texture2D _rapid)
        {

            tieFighterImg = _tieFighterImg;
            triple = _triple;
            shield = _shield;
            rapid = _rapid;


        }
        public void AddEnemy()
        {
            
            Game1._sprites.Add(new TieFighter(tieFighterImg, tieFighterImg, "Tie-Fighter")
            {
                Position = new Vector2(Game1.windowW / 2 - 25, Game1.windowH - 600),
                w = 80f,
                h = 80f,

            });
            Game1._sprites.Add(new TieFighter(tieFighterImg, tieFighterImg, "Tie-Fighter")
            {
                Position = new Vector2(Game1.windowW / 2 - 0, Game1.windowH - 500),
                w = 80f,
                h = 80f,

            });
            

        }

        public void Update(float time)
        {

            if (time > 4 && time < 4.02)
            {
                Game1._sprites.Add(new TieFighter(tieFighterImg, tieFighterImg, "Tie-Fighter")
                {
                    Position = new Vector2(Game1.windowW / 2 - 25, Game1.windowH - 500),
                    w = 80f,
                    h = 80f,

                });



            }

            if (time > 10 && time < 10.02)
            {
                Game1._sprites.Add(new TieFighter(tieFighterImg, tieFighterImg, "Tie-Fighter")
                {
                    Position = new Vector2(Game1.windowW / 2 - 25, Game1.windowH - 500),
                    w = 80f,
                    h = 80f,

                });

               
                Game1._sprites.Add(new Shield(shield, shield, "Shield")
                {
                    Position = new Vector2(Game1.windowW / 2 - 0, Game1.windowH - 800),
                    w = 80f,
                    h = 80f,

                });





            }

            if (time > 15 && time < 15.02)
            {

                Game1._sprites.Add(new TieFighter(tieFighterImg, tieFighterImg, "Tie-Fighter")
                {
                    Position = new Vector2(Game1.windowW / 2 - 25, Game1.windowH - 500),
                    w = 80f,
                    h = 80f,

                });
                Game1._sprites.Add(new Triple(triple, triple, "Triple")
                {
                    Position = new Vector2(Game1.windowW / 2 - 0, Game1.windowH - 800),
                    w = 80f,
                    h = 80f,

                });


                
            }

            if (time > 20 && time < 20.02)
            {


                Game1._sprites.Add(new Rapid(rapid, rapid, "Rapid")
                {
                    Position = new Vector2(Game1.windowW / 2 - 0, Game1.windowH - 800),
                    w = 80f,
                    h = 80f,

                });
            }
               





        }

        
    }
}
