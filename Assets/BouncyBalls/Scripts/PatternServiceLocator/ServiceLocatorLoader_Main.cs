using Assets.BouncyBalls.Scripts.Controllers;
using Assets.BouncyBalls.Scripts.PatternSignalBus;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.BouncyBalls.Scripts.PatternServiceLocator
{
    public class ServiceLocatorLoader_Main : MonoBehaviour
    {
        private SignalBus _signalBus;
        private GameController _gameController;
        private ScoreController _scoreController;

        private List<IDisposable> _disposables = new List<IDisposable>();

        private void Awake()
        {
            _signalBus = new SignalBus();
            _gameController = new GameController();
            _scoreController = new ScoreController();


            RegisterServices();
            Init();
            AddDisposables();
        }

        private void RegisterServices()
        {
            ServiceLocator.Initialize();

            ServiceLocator.Current.Register(_signalBus);
            ServiceLocator.Current.Register(_gameController);
            ServiceLocator.Current.Register(_scoreController);
        }

        private void Init()
        {
            _gameController.Init();
            _scoreController.Init();

        }

        private void AddDisposables()
        {
            _disposables.Add(_gameController);
            _disposables.Add(_scoreController);
        }

        private void OnDestroy()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}