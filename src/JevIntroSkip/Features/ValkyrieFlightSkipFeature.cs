using JevIntroSkip.Config;
using JevIntroSkip.Infrastructure;

namespace JevIntroSkip.Features
{
    public sealed class ValkyrieFlightSkipFeature : IFeature
    {
        private readonly IGameEvents _events;
        private readonly IModSettings _settings;

        public ValkyrieFlightSkipFeature(IGameEvents events, IModSettings settings)
        {
            _events = events;
            _settings = settings;
        }

        public void Enable()
        {
            _events.PlayerSpawning += OnPlayerSpawning;
        }

        public void Disable()
        {
            _events.PlayerSpawning -= OnPlayerSpawning;
        }

        private void OnPlayerSpawning(ref bool spawnValkyrie)
        {
            if (_settings.SkipValkyrieFlight)
            {
                spawnValkyrie = false;
            }
        }
    }
}
