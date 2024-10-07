using Assets.BouncyBalls.Scripts.Screenplay;

namespace Assets.BouncyBalls.Scripts.PatternSignalBus.Signals.GameSignals
{
    public class ScreenplayFinishedSignal
    {
        public readonly ScreenplayData ScreenplayData;

        public ScreenplayFinishedSignal(ScreenplayData screenplayData)
        {
            ScreenplayData = screenplayData;
        }
    }
}
