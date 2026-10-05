using HarmonyLib;
using JevIntroSkip.Infrastructure;

namespace JevIntroSkip.Patches
{
    internal static class GamePatches
    {
        [HarmonyPatch(typeof(Game), nameof(Game.ShowIntro))]
        private static class ShowIntro
        {
            private static bool Prefix(Game __instance)
            {
                var skip = false;
                GameEvents.Instance?.RaiseIntroShowing(__instance, ref skip);
                return !skip;
            }
        }

        [HarmonyPatch(typeof(Game), nameof(Game.SpawnPlayer))]
        private static class SpawnPlayer
        {
            private static void Prefix(ref bool spawnValkyrie)
            {
                GameEvents.Instance?.RaisePlayerSpawning(ref spawnValkyrie);
            }
        }
    }
}
