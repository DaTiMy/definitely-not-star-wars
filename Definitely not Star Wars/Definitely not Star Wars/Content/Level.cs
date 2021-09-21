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

        DeathStar ds;

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

            GameManager._sprites.Add(new TieFighter(tieFighterImg, tieFighterImg, "Tie-Fighter", tieexp, false)
            {
                Position = new Vector2(posx, posy),
                w = 80f,
                h = 80f,

            });



        }
        public void AddEnemyAbNormal(float posx, float posy)
        {

            GameManager._sprites.Add(new TieFighter(tieFighterImg, tieFighterImg, "Tie-Fighter", tieexp, true)
            {
                Position = new Vector2(posx, posy),
                w = 80f,
                h = 80f,

            });



        }
        public void AddRapidFire(float posx, float posy)
        {
            GameManager._sprites.Add(new Rapid(rapid, rapid, "Rapid")
            {
                Position = new Vector2(posx, posy),
                w = 80f,
                h = 80f,


            });
        }
        public void AddShield(float posx, float posy)
        {
            GameManager._sprites.Add(new Shield(shield, shield, "Shield")
            {
                Position = new Vector2(posx, posy),
                w = 80f,
                h = 80f,


            });
        }
        public void AddTriple(float posx, float posy)
        {
            GameManager._sprites.Add(new Triple(triple, triple, "Triple")
            {
                Position = new Vector2(posx, posy),
                w = 80f,
                h = 80f,


            });
        }
        public void AddDeathStar(float posx, float posy, int hp)
        {
            GameManager._sprites.Add(ds = new DeathStar(deathStarImg, deathStarImg, "DeathStar", bossHitSFX, hp)
            {
                Position = new Vector2(posx, posy),
                w = 150f,
                h = 150f,
                Speed = 0.5f

            });
        }

        public void AddPlasmaStorm(float posx, float posy)
        {
            GameManager._sprites.Add(new EPlasma(plasma, plasma, "EPlasma", true, true, false, false)
            {
                Position = new Vector2(posx, posy),
                w = 20f,
                h = 20f,

            });
            GameManager._sprites.Add(new EPlasma(plasma, plasma, "EPlasma", false, false, false, false)
            {
                Position = new Vector2(posx, posy + 10),
                w = 20f,
                h = 20f,

            });
            GameManager._sprites.Add(new EPlasma(plasma, plasma, "EPlasma", true, false, true, false)
            {
                Position = new Vector2(posx, posy),
                w = 20f,
                h = 20f,

            });
            GameManager._sprites.Add(new EPlasma(plasma, plasma, "EPlasma", true, true, false, true)
            {
                Position = new Vector2(posx, posy),
                w = 20f,
                h = 20f,

            });
            GameManager._sprites.Add(new EPlasma(plasma, plasma, "EPlasma", false, false, false, true)
            {
                Position = new Vector2(posx, posy - 10),
                w = 20f,
                h = 20f,

            });
            GameManager._sprites.Add(new EPlasma(plasma, plasma, "EPlasma", true, false, true, true)
            {
                Position = new Vector2(posx, posy),
                w = 20f,
                h = 20f,

            });
            GameManager._sprites.Add(new EPlasma(plasma, plasma, "EPlasma", false, true, false, false)
            {
                Position = new Vector2(posx - 10, posy),
                w = 20f,
                h = 20f,

            });
            GameManager._sprites.Add(new EPlasma(plasma, plasma, "EPlasma", false, false, true, false)
            {
                Position = new Vector2(posx + 10, posy),
                w = 20f,
                h = 20f,

            });
        }

        public void Update(int time, GameTime gameTime)
        {

            if (spawnCD > 0)
            {
                spawned = true;
                spawnCD -= gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                spawned = false;
            }
            if (time == 1 && !spawned)
            {



                spawnCD = 1f;


            }
            if (time == 1 && !spawned)
            {

                AddEnemyNormal(100, 100);
                AddEnemyNormal(300, 100);
                AddEnemyNormal(500, 100);
                AddEnemyNormal(700, 100);
                AddShield(400, 300);


                spawnCD = 1f;

            }
            if (time == 2 && !spawned)
            {

                AddEnemyAbNormal(200, 100);
                AddEnemyNormal(400, 100);
                AddEnemyAbNormal(600, 100);

                spawnCD = 1f;

            }
            if (time == 5 && !spawned)
            {
                AddTriple(300, 300);
                AddEnemyNormal(300, 100);
                AddEnemyAbNormal(500, 100);
                AddEnemyNormal(700, 100);
                AddPlasmaStorm(200, 500);
                spawnCD = 1f;

            }
            if (time == 6 && !spawned)
            {
                AddEnemyNormal(400, 100);
                AddEnemyNormal(600, 100);
                spawnCD = 1f;
            }
            if (time == 8 && !spawned)
            {
                AddEnemyNormal(100, 100);
                AddEnemyAbNormal(300, 100);
                AddEnemyNormal(500, 100);
                AddPlasmaStorm(600, 500);
                spawnCD = 1f;

            }
            if (time == 9 && !spawned)
            {
                AddEnemyNormal(200, 100);
                AddEnemyNormal(400, 100);
                spawnCD = 1f;
            }
            if (time == 11 && !spawned)
            {
                AddEnemyNormal(300, 100);
                AddEnemyNormal(500, 100);
                spawnCD = 1f;
            }
            if (time == 12 && !spawned)
            {
                AddEnemyAbNormal(400, 100);

                spawnCD = 1f;
            }
            if (time == 13 && !spawned)
            {
                AddShield(400, 500);
                AddEnemyNormal(100, 100);
                AddEnemyNormal(300, 100);
                AddEnemyNormal(500, 100);
                AddEnemyNormal(700, 100);
                spawnCD = 1f;
            }
            if (time == 14 && !spawned)
            {
                AddEnemyAbNormal(200, 100);
                AddEnemyAbNormal(600, 100);
                spawnCD = 1f;
            }
            if (time == 16 && !spawned)
            {
                AddEnemyNormal(100, 100);
                AddEnemyNormal(300, 100);
                AddEnemyNormal(500, 100);
                AddEnemyNormal(700, 100);
                AddPlasmaStorm(400, 500);

                spawnCD = 1f;
            }
            if (time == 17 && !spawned)
            {
                AddEnemyAbNormal(200, 100);
                AddEnemyAbNormal(600, 100);
                spawnCD = 1f;
            }
            if (time == 19 && !spawned)
            {
                AddShield(400, 500);
                AddRapidFire(600, 300);
                AddEnemyAbNormal(100, 100);
                AddEnemyAbNormal(250, 100);
                AddEnemyAbNormal(400, 100);
                AddEnemyAbNormal(550, 100);
                AddEnemyAbNormal(700, 100);
                AddPlasmaStorm(200, 500);
                AddPlasmaStorm(600, 500);


                spawnCD = 1f;
            }
            if (time == 20 && !spawned)
            {
                AddEnemyAbNormal(350, 100);
                AddEnemyAbNormal(200, 100);
                AddEnemyAbNormal(600, 100);
                AddEnemyAbNormal(450, 100);
                spawnCD = 1f;
            }
            if (time == 23 && !spawned)
            {
                AddEnemyNormal(100, 100);
                AddEnemyNormal(300, 100);
                AddEnemyNormal(500, 100);
                AddEnemyNormal(700, 100);
                AddPlasmaStorm(200, 200);
                AddPlasmaStorm(600, 200);
                AddPlasmaStorm(200, 600);
                AddPlasmaStorm(600, 600);


                spawnCD = 1f;
            }
            if (time == 24 && !spawned)
            {
                AddEnemyAbNormal(200, 100);
                AddEnemyAbNormal(600, 100);
                spawnCD = 1f;
            }
            if (time == 26 && !spawned)
            {
                AddShield(400, 500);
                AddEnemyAbNormal(200, 100);
                AddEnemyAbNormal(600, 100);
                AddEnemyAbNormal(400, 100);

                spawnCD = 1f;
            }
            if (time == 27 && !spawned)
            {
                AddEnemyAbNormal(300, 100);
                AddEnemyAbNormal(500, 100);
                spawnCD = 1f;
            }
            if (time == 29 && !spawned)
            {
                AddShield(200, 100);
                AddRapidFire(600, 100);
                spawnCD = 1f;
            }

            if (time == 30 && !spawned)
            {
                AddEnemyAbNormal(100, 100);
                AddEnemyAbNormal(700, 100);
                spawnCD = 1f;

            }
            if (time == 31 && !spawned)
            {
                AddPlasmaStorm(200, 500);
                AddPlasmaStorm(600, 500);
                AddDeathStar(400, 100, 110);
                spawnCD = 1f;
            }

            if (DeathStar.isDead)
            {
                float temptime = time + 3;
                temptime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                GameManager._sprites.RemoveAll(x => x.Name == "EBullet");
                GameManager._sprites.RemoveAll(x => x.Name == "DeathStar");
                GameManager._sprites.RemoveAll(x => x.Name == "Tie-Fighter");
                if (Convert.ToInt32(temptime) == 3)
                {

                    GameManager._sprites.RemoveAll(x => x.Name == "EPlasma");


                }


            }
        }




    }
}
