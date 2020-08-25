using Microsoft.Xna.Framework;
using PissAndShit.Items.BossBags;
using PissAndShit.Items.Misc;
using PissAndShit.Items.Weapons;
using System;
using Terraria;
using Terraria.Graphics.Capture;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;

namespace PissAndShit.NPCs.Bosses
{
    [AutoloadBossHead]
    public class boozeshrume : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("boozeshrume.exe");
        }

        public override void SetDefaults()
        {
            npc.width = npc.height = 120;
            npc.damage = 69;
            npc.knockBackResist = 1f;
            npc.boss = true;
            npc.lifeMax = 8500;
            npc.defense = 30;
            npc.noTileCollide = true;
            npc.value = Item.buyPrice(0, 12, 80, 0);
            npc.aiStyle = -1;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.lavaImmune = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Staying_As_a_1.14");
            musicPriority = MusicPriority.BossHigh;

            bossBag = ModContent.ItemType<BoozeshrumeBag>();
        }

        public bool SpeeeenBool = false;
        public int SpeeeeedValue = 0;
        public int PhaseValueOrSomethingIDK = 0;
        public int GameCrashCounter = 0;
        public int SpeeeeenTimer = 0;
        public int AtttaackTimer = 0;

        public override void AI()
        {
            if (npc.life < npc.lifeMax / 2)
            {
                PhaseValueOrSomethingIDK = 1;
            }

            npc.TargetClosest(true);
            npc.spriteDirection = npc.direction;

            Player player = Main.player[npc.target];

            SpeeeeedValue = SpeeeenBool ? 5 : 7;

            Vector2 moveTo = player.Center - npc.Center;
            moveTo.Normalize();
            moveTo = moveTo * SpeeeeedValue;

            npc.velocity = moveTo;

            if (++SpeeeeenTimer % 180 == 0)
            {
                if (SpeeeenBool)
                {
                    SpeeeenBool = true;
                }
                else
                {
                    SpeeeenBool = false;
                }
            }

            if (SpeeeenBool)
            {
                npc.rotation += npc.velocity.X * 0.1f;
            }

            if (PhaseValueOrSomethingIDK == 0)
            {
                if (++AtttaackTimer >= 250)
                {
                    for (int i = 0; i < Main.rand.Next(10, 20); i++)
                    {
                        Projectile.NewProjectile(npc.Center.X - Main.rand.Next(-600, 600), npc.Center.Y - Main.screenHeight / 2 - 60, moveTo.X * 1.5f, moveTo.Y * 1.5f, ModContent.ProjectileType<Projectiles.rum>(), 35, 2);
                    }

                    AtttaackTimer = 0;
                }
            }
            else if (PhaseValueOrSomethingIDK == 1)
            {
                GameCrashCounter++;

                if (GameCrashCounter == 1)
                {
                    CombatText.NewText(npc.Hitbox, Color.DarkRed, "Kill me in 2 minute or you get booted", dramatic: true);
                }

                if (GameCrashCounter == 3600)
                {
                    CombatText.NewText(npc.Hitbox, Color.DarkRed, "One minute kill me or terraria go back to menu", dramatic: true);
                }

                if (GameCrashCounter == 7140)
                {
                    CombatText.NewText(npc.Hitbox, Color.DarkRed, "You are going to brazil", dramatic: true);
                }

                if (GameCrashCounter == 7200)
                {
                    CombatText.NewText(npc.Hitbox, Color.DarkRed, "Whoops gotta save your crap first", dramatic: true);
                }

                if (GameCrashCounter >= 7320)
                {
                    Main.SaveSettings();

                    if (Main.netMode == NetmodeID.SinglePlayer)
                    {
                        WorldFile.CacheSaveTime();
                    }

                    Main.invasionProgress = 0;
                    Main.invasionProgressDisplayLeft = 0;
                    Main.invasionProgressAlpha = 0f;
                    Main.menuMode = 10;
                    Main.gameMenu = true;
                    Main.StopTrackedSounds();
                    CaptureInterface.ResetFocus();
                    Main.ActivePlayerFileData.StopPlayTimer();

                    Player.SavePlayer(Main.ActivePlayerFileData, false);

                    if (Main.netMode == NetmodeID.SinglePlayer)
                    {
                        WorldFile.saveWorld();
                    }
                    else
                    {
                        Netplay.disconnect = true;
                        Main.netMode = NetmodeID.SinglePlayer;
                    }

                    Main.fastForwardTime = false;
                    Main.UpdateSundial();
                    Main.menuMode = 0;
                }

                if (++AtttaackTimer >= 40)
                {
                    Projectile.NewProjectile(npc.Center, moveTo * 4, ModContent.ProjectileType<Projectiles.beer>(), 50, 3);

                    AtttaackTimer = 0;
                }
            }
        }

        public override void NPCLoot()
        {
            PaSWorld.downedBoozeshrume = true;
            Main.NewText("boozeshrume.exe has stopped working", Color.MediumPurple);
            if (!Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ScrumpyCiderRedwineTequillaWhiskeyVodkaRumArrackSpiritPureEthanolDrinkMix>(), 3);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BeerBook>());
            }
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
        }
    }
}

/*boozeshrume.exe

Phase 1: Chases you, spins around, and throws rum all over the floor
Phase 2: Causes beer to rain from the sky, and then gives you 2 minute to fight him or else your game crash

Also replace the death message with "boozeshrume.exe has stopped working."

Drops Scrumpy Cider Redwine Tequilla Whiskey Vodka Rum snorts at book Arrack Spirit Pure Ethanol Drink Mix, which makes you super dronk
*/