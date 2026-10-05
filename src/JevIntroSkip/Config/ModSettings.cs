using BepInEx.Configuration;

namespace JevIntroSkip.Config
{
    public sealed class ModSettings : IModSettings
    {
        private readonly ConfigEntry<bool> _skipLogos;
        private readonly ConfigEntry<bool> _skipCinematic;
        private readonly ConfigEntry<bool> _skipLoreText;
        private readonly ConfigEntry<bool> _skipValkyrieFlight;

        public ModSettings(ConfigFile file)
        {
            _skipLogos = file.Bind(
                "Startup",
                "SkipLogos",
                true,
                "Skips the Coffee Stain and Iron Gate logos shown when the game starts.");

            _skipCinematic = file.Bind(
                "Startup",
                "SkipCinematic",
                true,
                "Skips the intro cinematic video shown before the main menu.");

            _skipLoreText = file.Bind(
                "NewWorld",
                "SkipLoreText",
                true,
                "Skips the lore text shown when a new character enters a world.");

            _skipValkyrieFlight = file.Bind(
                "NewWorld",
                "SkipValkyrieFlight",
                true,
                "Skips the Valkyrie flight and spawns a new character straight at the start "
                    + "point.");
        }

        public bool SkipLogos => _skipLogos.Value;

        public bool SkipCinematic => _skipCinematic.Value;

        public bool SkipLoreText => _skipLoreText.Value;

        public bool SkipValkyrieFlight => _skipValkyrieFlight.Value;
    }
}
