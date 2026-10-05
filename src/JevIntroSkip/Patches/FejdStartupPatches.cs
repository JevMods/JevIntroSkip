using HarmonyLib;
using JevIntroSkip.Infrastructure;

namespace JevIntroSkip.Patches
{
    internal static class FejdStartupPatches
    {
        [HarmonyPatch(typeof(FejdStartup), nameof(FejdStartup.TryPlayIntroCinematic))]
        private static class TryPlayIntroCinematic
        {
            private static void Prefix()
            {
                GameEvents.Instance?.RaiseStartupCinematicStarting();
            }
        }
    }
}
