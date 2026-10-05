using System;

namespace JevIntroSkip.Infrastructure
{
    public sealed class GameEvents : IGameEvents
    {
        internal static GameEvents Instance { get; set; }

        public event LogoFadingHandler LogoFading;
        public event Action StartupCinematicStarting;
        public event IntroShowingHandler IntroShowing;
        public event PlayerSpawningHandler PlayerSpawning;

        internal void RaiseLogoFading(ref bool skip)
        {
            LogoFading?.Invoke(ref skip);
        }

        internal void RaiseStartupCinematicStarting()
        {
            StartupCinematicStarting?.Invoke();
        }

        internal void RaiseIntroShowing(Game game, ref bool skip)
        {
            IntroShowing?.Invoke(game, ref skip);
        }

        internal void RaisePlayerSpawning(ref bool spawnValkyrie)
        {
            PlayerSpawning?.Invoke(ref spawnValkyrie);
        }
    }
}
