using JevIntroSkip.Config;
using JevIntroSkip.Infrastructure;

namespace JevIntroSkip.Features
{
    public sealed class LoreTextSkipFeature : IFeature
    {
        private readonly IGameEvents _events;
        private readonly IModSettings _settings;

        public LoreTextSkipFeature(IGameEvents events, IModSettings settings)
        {
            _events = events;
            _settings = settings;
        }

        public void Enable()
        {
            _events.IntroShowing += OnIntroShowing;
        }

        public void Disable()
        {
            _events.IntroShowing -= OnIntroShowing;
        }

        private void OnIntroShowing(Game game, ref bool skip)
        {
            if (!_settings.SkipLoreText)
            {
                return;
            }

            game.m_inIntro = true;
            skip = true;
        }
    }
}
