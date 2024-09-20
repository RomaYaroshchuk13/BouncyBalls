using Assets.BouncyBalls.Scripts.Level;

namespace Assets.BouncyBalls.Scripts.PatternSignalBus.Signals.GameSignals
{
    public class LevelFinishedSignal
    {
        public readonly LevelData LevelData;

        public LevelFinishedSignal(LevelData levelData)
        {
            LevelData = levelData;
        }
    }
}
