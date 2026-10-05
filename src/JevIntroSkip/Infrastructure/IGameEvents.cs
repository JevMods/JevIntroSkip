using System;

namespace JevIntroSkip.Infrastructure
{
    public interface IGameEvents
    {
        event LogoFadingHandler LogoFading;
        event Action StartupCinematicStarting;
        event IntroShowingHandler IntroShowing;
        event PlayerSpawningHandler PlayerSpawning;
    }
}
