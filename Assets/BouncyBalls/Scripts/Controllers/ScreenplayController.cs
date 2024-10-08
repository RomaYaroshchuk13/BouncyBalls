using Assets.BouncyBalls.Scripts.Balls;
using Assets.BouncyBalls.Scripts.PatternServiceLocator;
using Assets.BouncyBalls.Scripts.PatternSignalBus;
using Assets.BouncyBalls.Scripts.PatternSignalBus.Signals.GameSignals;
using Assets.BouncyBalls.Scripts.Screenplay;
using Assets.BouncyBalls.Scripts.Sectors;

namespace Assets.BouncyBalls.Scripts.Controllers
{
    public class ScreenplayController : IService
    {
        SignalBus _signalBus;
        BallsCreator _ballsCreator;
        SectorsCreator _sectorCreator;
        UICreator _UICreator;
        ScreenplayData _screenplayData;
        IScreenplay _screenplay;

        public void Init(ScreenplayData screenplayData)
        {
            _signalBus = ServiceLocator.Current.Get<SignalBus>();
            _ballsCreator = ServiceLocator.Current.Get<BallsCreator>();
            _sectorCreator = ServiceLocator.Current.Get<SectorsCreator>();
            _UICreator = ServiceLocator.Current.Get<UICreator>();

            _screenplay = screenplayData.Screenplay;
            _screenplayData = screenplayData;

            _signalBus.Subscribe<GameStartedSignal>(Play);
            _signalBus.Invoke(new SetScreenplaySignal());
        }

        private void Play(GameStartedSignal signal)
        {
            _UICreator.SetTitle(_screenplayData.Title);
            _screenplay.Init(_ballsCreator, _sectorCreator, _screenplayData);
            _screenplay.Play();
        }
    }
}
