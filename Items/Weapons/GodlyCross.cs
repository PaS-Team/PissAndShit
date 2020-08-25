﻿using Microsoft.Xna.Framework;
using PissAndShit.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons
{
    public class GodlyCross : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Godly Cross");
            Tooltip.SetDefault("Rain godly vibes on your enemies");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;

            item.melee = true;
            item.damage = 780;
            item.knockBack = 2.5f;
            item.useTime = 10;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.SwingThrow;

            item.autoReuse = true;
            item.rare = ItemRarityID.Red;
            item.shoot = ModContent.ProjectileType<GodlyCrossProj>();
            item.shootSpeed = 10.5f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) //This lets you modify the firing of the item
        {
            int spread = 10;
            float spreadMult = 0.1f;
            for (int i = 0; i < 10; i++)
            {
                float vX = speedX + Main.rand.Next(-spread, spread + 1) * spreadMult;
                float vY = speedY + Main.rand.Next(-spread, spread + 1) * spreadMult;
                Projectile.NewProjectile(position.X, position.Y, vX, vY, type, damage, knockBack, Main.myPlayer);
            }
            return false;
        }
    }
}