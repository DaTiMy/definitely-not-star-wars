using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;

namespace Definitely_not_Star_Wars
{
    class Level
    {
        public List<Sprite> Enemies;
        Texture2D tieFighterImg;
        Texture2D deathStarImg;

        Texture2D triple;
        Texture2D shield;
        Texture2D rapid;


        SoundEffect tieexp;
        SoundEffect bossHitSFX;

       

        public Level(Texture2D _tieFighterImg, Texture2D _triple, Texture2D _shield, Texture2D _rapid, SoundEffect _tieexp, Texture2D _deathStarImg, SoundEffect _bossHitSFX)
        {

            tieFighterImg = _tieFighterImg;
            triple = _triple;
            shield = _shield;
            rapid = _rapid;
            tieexp = _tieexp;
            bossHitSFX = _bossHitSFX;
            deathStarImg = _deathStarImg;
            SoundEffect.MasterVolume = 0.01f;

        }
        public void AddEnemy()
        {
            
            Game1._sprites.Add(new TieFighter(tieFighterImg, tieFighterImg, "Tie-Fighter", tieexp)
            {
                Position = new Vector2(Game1.windowW / 2 - 25, Game1.windowH - 600),
                w = 80f,
                h = 80f,

            });
            Game1._sprites.Add(new TieFighter(tieFighterImg, tieFighterImg, "Tie-Fighter", tieexp)
            {
                Position = new Vector2(Game1.windowW / 2 - 0, Game1.windowH - 500),
                w = 80f,
                h = 80f,

            });
            

        }

        public void Update(float time)
        {


            if (time > 1 && time < 1.02)
            {
                Game1._sprites.Add(new DeathStar(deathStarImg, deathStarImg, "DeathStar", bossHitSFX, 1000)
                {
                    Position = new Vector2(100, 0),
                    w = 100f,
                    h = 100f,
                    Speed = 0.5f

                });

            }
               





        }

        
    }
}
