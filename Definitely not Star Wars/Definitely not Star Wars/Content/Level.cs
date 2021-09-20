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

        Texture2D plasma;

        Texture2D triple;
        Texture2D shield;
        Texture2D rapid;

        bool spawned = false;
        double spawnCD = 0f;

        SoundEffect tieexp;
        SoundEffect bossHitSFX;
       
       

        public Level(Texture2D _tieFighterImg, Texture2D _triple, Texture2D _shield, Texture2D _rapid, SoundEffect _tieexp, Texture2D _deathStarImg, SoundEffect _bossHitSFX, Texture2D _plasma)
        {

            tieFighterImg = _tieFighterImg;
            triple = _triple;
            shield = _shield;
            rapid = _rapid;
            tieexp = _tieexp;
            bossHitSFX = _bossHitSFX;
            deathStarImg = _deathStarImg;
            plasma = _plasma;
            SoundEffect.MasterVolume = 0.01f;

        }
        public void AddEnemyNormal(float posx, float posy)
        {
            
            Game1._sprites.Add(new TieFighter(tieFighterImg, tieFighterImg, "Tie-Fighter", tieexp , false)
            {
                Position = new Vector2(posx, posy),
                w = 80f,
                h = 80f,

            });
            
            

        }
        public void AddEnemyAbNormal(float posx, float posy)
        {

            Game1._sprites.Add(new TieFighter(tieFighterImg, tieFighterImg, "Tie-Fighter", tieexp, true)
            {
                Position = new Vector2(posx, posy),
                w = 80f,
                h = 80f,

            });



        }
        public void AddRapidFire(float posx, float posy)
        {
            Game1._sprites.Add(new Rapid(rapid, rapid, "Rapid")
            {
                Position = new Vector2(posx, posy),
                w = 80f,
                h = 80f,


            });
        }
        public void AddShield(float posx, float posy)
        {
            Game1._sprites.Add(new Shield(shield, shield, "Shield")
            {
                Position = new Vector2(posx, posy),
                w = 80f,
                h = 80f,


            });
        }
        public void AddTriple(float posx, float posy)
        {
            Game1._sprites.Add(new Triple(triple, triple, "Triple")
            {
                Position = new Vector2(posx, posy),
                w = 80f,
                h = 80f,


            });
        }
        public void AddDeathStar(float posx, float posy, int hp)
        {
            Game1._sprites.Add(new DeathStar(deathStarImg, deathStarImg, "DeathStar", bossHitSFX, hp)
            {
                Position = new Vector2(posx, posy),
                w = 150f,
                h = 150f,
                Speed = 0.5f

            });
        }

        public void AddPlasmaStorm(int posx, int posy)
        {
            Game1._sprites.Add(new EPlasma(plasma, plasma, "EPlasma", true,true,false,false)
            {
                Position = new Vector2(posx, posy),
                w = 20f,
                h = 20f,

            });
            Game1._sprites.Add(new EPlasma(plasma, plasma, "EPlasma", false, false, false, false)
            {
                Position = new Vector2(posx, posy + 10),
                w = 20f,
                h = 20f,

            });
            Game1._sprites.Add(new EPlasma(plasma, plasma, "EPlasma", true, false, true, false)
            {
                Position = new Vector2(posx, posy),
                w = 20f,
                h = 20f,

            });
            Game1._sprites.Add(new EPlasma(plasma, plasma, "EPlasma", true, true, false, true)
            {
                Position = new Vector2(posx, posy),
                w = 20f,
                h = 20f,

            });
            Game1._sprites.Add(new EPlasma(plasma, plasma, "EPlasma", false, false, false, true)
            {
                Position = new Vector2(posx , posy - 10),
                w = 20f,
                h = 20f,

            });
            Game1._sprites.Add(new EPlasma(plasma, plasma, "EPlasma", true, false, true, true)
            {
                Position = new Vector2(posx, posy ),
                w = 20f,
                h = 20f,

            });
            Game1._sprites.Add(new EPlasma(plasma, plasma, "EPlasma", false, true, false, false)
            {
                Position = new Vector2(posx - 10, posy),
                w = 20f,
                h = 20f,

            });
            Game1._sprites.Add(new EPlasma(plasma, plasma, "EPlasma", false, false, true, false)
            {
                Position = new Vector2(posx + 10, posy),
                w = 20f,
                h = 20f,

            });
        }

        public void Update(int time, GameTime gameTime)
        {
           /* if (spawnCD > 0)
            {
                spawned = true;
                spawnCD -= gameTime.ElapsedGameTime.TotalSeconds;
            }
            else {
                spawned = false;
            }
            if (time == 1 && !spawned)
            {
                

               
                spawnCD = 1f;
             
            }

            
            if (time == 5 && !spawned)
            {
                AddEnemyAbNormal(50,200);
                AddEnemyAbNormal(280, 200);
                AddEnemyAbNormal(500, 200);
                AddEnemyAbNormal(700, 200);
                AddEnemyAbNormal(30, 0);
                AddEnemyAbNormal(250, 0);
                AddEnemyAbNormal(420, 0);
                AddEnemyAbNormal(720, 0);
                spawnCD = 1f;

            }
            if(time == 8 && !spawned)
            {
                
              
                spawnCD = 1f;

            }

            if (time == 10 && !spawned)
            {

                AddPlasmaStorm(300, 500);
                AddPlasmaStorm(500, 500);
                AddPlasmaStorm(400, 500);
                spawnCD = 1f;
            }

            if (time == 11 && !spawned)
            {
                AddEnemyAbNormal(50, 200);
                AddEnemyAbNormal(280, 200);
                AddEnemyAbNormal(500, 200);
                AddEnemyAbNormal(700, 200);
                AddEnemyAbNormal(30, 0);
                AddEnemyAbNormal(250, 0);
                AddEnemyAbNormal(420, 0);
                AddEnemyAbNormal(720, 0);
                spawnCD = 1f;

            }
            if (time == 15 && !spawned)
            {
                AddEnemyAbNormal(50, 200);
                AddEnemyAbNormal(280, 200);
                AddEnemyAbNormal(500, 200);
                AddEnemyAbNormal(700, 200);
                AddEnemyAbNormal(30, 0);
                AddEnemyAbNormal(250, 0);
                AddEnemyAbNormal(420, 0);
                AddEnemyAbNormal(720, 0);
                spawnCD = 1f;

            }
            if (time == 20 && !spawned)
            {
               
                AddPlasmaStorm(300,500);
                AddPlasmaStorm(500, 500);
                AddPlasmaStorm(400, 500);
                spawnCD = 1f;

            }
               



            */

        }

        
    }
}
