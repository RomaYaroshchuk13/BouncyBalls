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
        _signalBus.Subscribe<LevelFinishedSignal>(LevelFinished);
        //_eventBus.Subscribe<SetLevelSignal>(StartGame, -1);
    }

    public void StartGame()
    {
        _signalBus.Invoke(new GameStartedSignal());

    }

    public void StopGame()  
    {
        _signalBus.Invoke(new GameStopSignal());
    }

    private void LevelFinished(LevelFinishedSignal signal)
    {
        var level = signal.LevelData;

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
