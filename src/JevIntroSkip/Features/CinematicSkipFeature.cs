using JevIntroSkip.Config;
using JevIntroSkip.Infrastructure;

namespace JevIntroSkip.Features
{
    public sealed class CinematicSkipFeature : IFeature
    {
        private readonly IGameEvents _events;
        private readonly IModSettings _settings;

        public CinematicSkipFeature(IGameEvents events, IModSettings settings)
        {
            _events = events;
            _settings = settings;
        }

        public void Enable()
        {
            _events.StartupCinematicStarting += OnStartupCinematicStarting;
        }

        public void Disable()
        {
            _events.StartupCinematicStarting -= OnStartupCinematicStarting;
        }

        private void OnStartupCinematicStarting()
        {
            if (_settings.SkipCinematic)
            {
                Game.m_hasStartedOnce = true;
            }
        }
    }
}
