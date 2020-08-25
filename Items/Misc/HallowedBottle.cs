﻿using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Misc
{
    public class HallowedBottle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallowed Bottle");
            Tooltip.SetDefault("King Arthur's bottle of choice");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.rare = ItemRarityID.LightPurple;
            item.width = 20;
            item.height = 26;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 3);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}