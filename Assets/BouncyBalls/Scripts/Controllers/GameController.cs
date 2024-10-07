using Assets.BouncyBalls.Scripts.Controllers;
using Assets.BouncyBalls.Scripts.PatternServiceLocator;
using Assets.BouncyBalls.Scripts.PatternSignalBus;
using Assets.BouncyBalls.Scripts.PatternSignalBus.Signals.GameSignals;

public class GameController : IService, IDisposable
{
    private SignalBus _signalBus;

    public void Init()
    {
        _signalBus = ServiceLocator.Current.Get<SignalBus>();
        _signalBus.Subscribe<ScreenplayFinishedSignal>(ScreenplayFinished);
        _signalBus.Subscribe<SetScreenplaySignal>(StartGame, -1);
    }

    private void StartGame(SetScreenplaySignal signal)
    {
        _signalBus.Invoke(new GameStartedSignal());
    }

    private void StopGame()  
    {
        _signalBus.Invoke(new GameStopSignal());
    }

    private void ScreenplayFinished(ScreenplayFinishedSignal signal)
    {
        var level = signal.ScreenplayData;

        StopGame();

        // Показываем окошко о победе
        var scoreController = ServiceLocator.Current.Get<ScoreController>();
        //YouWinDialog youWinDialog = DialogManager.ShowDialog<YouWinDialog>();
        //youWinDialog.Init(scoreController.Score, scoreController.GetMaxScore(level.ID), level.GoldForPass);
    }

    public void Dispose()
    {
    }
}
