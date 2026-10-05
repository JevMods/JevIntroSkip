using System.Collections;
using System.Linq;
using HarmonyLib;
using JevIntroSkip.Infrastructure;

namespace JevIntroSkip.Patches
{
    internal static class SceneLoaderPatches
    {
        [HarmonyPatch(typeof(SceneLoader), nameof(SceneLoader.FadeLogo))]
        private static class FadeLogo
        {
            private static bool Prefix(ref IEnumerator __result)
            {
                var skip = false;
                GameEvents.Instance?.RaiseLogoFading(ref skip);
                if (skip)
                {
                    __result = Enumerable.Empty<object>().GetEnumerator();
                }

                return !skip;
            }
        }
    }
}
