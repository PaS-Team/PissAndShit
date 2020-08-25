using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs
{
    public class CoochieSnatcher : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Coochie Snatcher");
        }

        public override void SetDefaults()
        {
            npc.width = 64;
            npc.height = 64;
            npc.damage = 28;
            npc.defense = 12;
            npc.lifeMax = 400;
            npc.HitSound = SoundID.NPCHit5;
            npc.DeathSound = SoundID.NPCDeath5;
            npc.value = 31f;
            npc.knockBackResist = 0.2f;
            npc.aiStyle = 69;
            npc.noGravity = true;
            npc.noTileCollide = true;
        }

        public override void NPCLoot()
        {

        }
    }
}
