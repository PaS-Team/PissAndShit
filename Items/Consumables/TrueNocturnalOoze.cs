﻿using PissAndShit.Items.Misc;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Consumables
{
    public class TrueNocturnalOoze : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Nocturnal Ooze");
            Tooltip.SetDefault("This is definitely not drinkable!");
        }

        public override void SetDefaults()
        {
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.UseSound = SoundID.Item3;
            item.width = 20;
            item.buffType = BuffID.Obstructed;
            item.buffTime = 600;
            item.height = 36;
            item.width = 28;
            item.rare = ItemRarityID.Lime;
            item.maxStack = 30;
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NocturnalOoze>());
            recipe.AddIngredient(ModContent.ItemType<BrokenHeroBottle>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}