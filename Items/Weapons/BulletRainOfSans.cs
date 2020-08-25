﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons
{
    public class BulletRainOfSans : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bullet Hell");
            Tooltip.SetDefault("80% chance to not consume ammo.");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 16;
            item.damage = 325;
            item.ranged = true;
            item.useTime = 2;
            item.useAnimation = 2;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 2;
            item.value = Item.sellPrice(platinum: 5);
            item.rare = ItemRarityID.Purple;
            item.UseSound = SoundID.Item40;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Bullet;
            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 10f;
            item.noMelee = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.VortexBeater, 1);
            recipe.AddIngredient(ItemID.SDMG, 1);
            recipe.AddIngredient(ItemID.ChainGun, 1);
            recipe.AddIngredient(ItemID.FragmentVortex, 25);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int spread = 100;
            float spreadMult = 0.1f;
            for (int i = 0; i < 3; i++)
            {
                float vX = speedX + Main.rand.Next(-spread, spread + 1) * spreadMult;
                float vY = speedY + Main.rand.Next(-spread, spread + 1) * spreadMult;
                Projectile.NewProjectile(position.X, position.Y, vX, vY, type, damage, knockBack, Main.myPlayer);
            }
            return false;
        }

        public override bool ConsumeAmmo(Player p)
        {
            int rand = Main.rand.Next(1, 6);
            if (rand >= 1 && rand <= 4)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}