﻿using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Consumables
{
    public class NocturnalOoze : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nocturnal Ooze");
            Tooltip.SetDefault("Dark and foul smelling");
        }

        public override void SetDefaults()
        {
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.EatingUsing;

            item.UseSound = SoundID.Item3;
            item.width = 20;
            item.buffType = BuffID.Blackout;
            item.buffTime = 300;
            item.height = 26;
            item.width = 20;
            item.rare = ItemRarityID.Pink;
            item.maxStack = 30;
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.BottledHoney);
            recipe.AddIngredient(ItemType<LavaBottle>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}