using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Accessories
{
    public class HiveChunk : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hive Chunk");
            Tooltip.SetDefault("Gives permanent honey buff\n+250 max life\n+50 defense");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 30;

            item.value = Item.buyPrice(gold: 50);
            item.rare = ItemRarityID.Expert;
            item.accessory = true;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(BuffID.Honey, 10, false);
            player.statLifeMax2 += 250;
            player.statDefense += 50;
        }
    }
}