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
    [BepInPlugin(Modid, ModName, Version)]
    // The game our mod is associated with
    [BepInProcess("Rounds.exe")]
    public class PixelCards : BaseUnityPlugin
    {
        private const string Modid = "com.GuardandRat.Rounds.PixelCards";
        private const string ModName = "PixelCards";
        public const string Version = "1.0.0"; // What version are we on (major.minor.patch)?
        public const string ModInitials = "PX";
        public static PixelCards instance {get; private set;}
        

      




        void Awake()
        {
            // Use this to call any harmony patch files your mod may have
            var harmony = new Harmony("GuardandRat.Rounds.PixelCards");
            harmony.PatchAll();
        }
        void Start()
        {
            instance = this;
            CustomCard.BuildCard<EvasiveManeuvers>();
            CustomCard.BuildCard<Test>();
        }
    }
}
