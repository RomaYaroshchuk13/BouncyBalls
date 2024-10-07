using Assets.BouncyBalls.Scripts.ConfigLoader;

namespace Assets.BouncyBalls.Scripts.PatternSignalBus.Signals.SystemSignals
{
    public class DataLoadedSignal
    {
        public readonly ILoader Loader;
        public DataLoadedSignal(ILoader loader)
        {
            Loader = loader;
        }
    }
}
