using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using PixelCards.Cards;
using HarmonyLib;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;

namespace PixelCards
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch",
   BepInDependency.DependencyFlags.HardDependency)]
    // Declares our mod to Bepin
    [BepInPlugin(ModId, PixelCards, Version)]
    // The game our mod is associated with
    [BepInProcess("Rounds.exe")]
    public class PixelCards : BaseUnityPlugin
    {
        private const string Modid = "com.My.Mod.Id";
        private const string ModName = "PixelCards";
        public const string Version = "0.0.1"; // What version are we on (major.minor.patch)?

        void Awake()
        {
            // Use this to call any harmony patch files your mod may have
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }
        void Start()
        {
            CustomCard.BuildCard<MEME>();
        }
    }
}