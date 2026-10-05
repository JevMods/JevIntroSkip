using JevIntroSkip.Config;
using JevIntroSkip.Infrastructure;

namespace JevIntroSkip.Features
{
    public sealed class LogoSkipFeature : IFeature
    {
        private readonly IGameEvents _events;
        private readonly IModSettings _settings;

        public LogoSkipFeature(IGameEvents events, IModSettings settings)
        {
            _events = events;
            _settings = settings;
        }

        public void Enable()
        {
            _events.LogoFading += OnLogoFading;
        }

        public void Disable()
        {
            _events.LogoFading -= OnLogoFading;
        }

        private void OnLogoFading(ref bool skip)
        {
            skip = _settings.SkipLogos;
        }
    }
}
