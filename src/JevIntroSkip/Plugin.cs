using BepInEx;
using HarmonyLib;
using JevIntroSkip.Config;
using JevIntroSkip.Features;
using JevIntroSkip.Infrastructure;

namespace JevIntroSkip
{
    [BepInPlugin(PluginGuid, PluginName, BuildInfo.Version)]
    public sealed class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "JevMods.JevIntroSkip";
        public const string PluginName = "JevIntroSkip";

        private IFeature[] _features;
        private Harmony _harmony;

        private void Awake()
        {
            var events = new GameEvents();
            GameEvents.Instance = events;

            var settings = new ModSettings(Config);
            _features = new IFeature[]
            {
                new LogoSkipFeature(events, settings),
                new CinematicSkipFeature(events, settings),
                new LoreTextSkipFeature(events, settings),
                new ValkyrieFlightSkipFeature(events, settings)
            };
            foreach (var feature in _features)
            {
                feature.Enable();
            }

            _harmony = new Harmony(PluginGuid);
            _harmony.PatchAll();

            Logger.LogInfo("Loaded");
        }

        private void OnDestroy()
        {
            _harmony?.UnpatchSelf();
            if (_features != null)
            {
                foreach (var feature in _features)
                {
                    feature.Disable();
                }
            }

            GameEvents.Instance = null;
        }
    }
}
