using Assets.BouncyBalls.Scripts.Balls;
using Assets.BouncyBalls.Scripts.ConfigLoader.ScriptableObjectScreenplayLoaders;
using Assets.BouncyBalls.Scripts.Controllers;
using Assets.BouncyBalls.Scripts.PatternSignalBus;
using Assets.BouncyBalls.Scripts.Screenplay;
using Assets.BouncyBalls.Scripts.Sectors;
using Assets.BouncyBalls.Scripts.Storages;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.BouncyBalls.Scripts.PatternServiceLocator
{
    public class ServiceLocatorLoader_Main : MonoBehaviour
    {
        [SerializeField] private ScriptableObjectScreenplayLoader _scriptableObjectScreenplayLoader;
        [SerializeField] private int _currentScreenplay;
        [SerializeField] private Storage _storage;
        [SerializeField] private SectorsCreator _sectorsCreator;
        [SerializeField] private BallsCreator _ballsCreator;
        [SerializeField] private UICreator _UICreator;

        private SignalBus _signalBus;
        private GameController _gameController;
        private ScoreController _scoreController;
        private ScreenplayController _screenplayController;
        private ScreenplayData _screenplayData;

        private List<IDisposable> _disposables = new List<IDisposable>();

        private void Awake()
        {
            _signalBus = new SignalBus();
            _gameController = new GameController();
            _scoreController = new ScoreController();
            _screenplayController = new ScreenplayController();

            SelectScreenplay();
            RegisterServices();
            Init();
            AddDisposables();
        }

        private void SelectScreenplay()
        {
            IEnumerable<ScreenplayData> screenplays = _scriptableObjectScreenplayLoader.GetScreenplays();
            _screenplayData = screenplays.ElementAt(_currentScreenplay);
        }

        private void RegisterServices()
        {
            ServiceLocator.Initialize();

            ServiceLocator.Current.Register(_signalBus);
            ServiceLocator.Current.Register(_gameController);
            ServiceLocator.Current.Register(_scoreController);
            ServiceLocator.Current.Register(_screenplayController);
            ServiceLocator.Current.Register(_sectorsCreator);
            ServiceLocator.Current.Register(_ballsCreator);
            ServiceLocator.Current.Register(_UICreator);
            ServiceLocator.Current.Register(_storage);
        }

        private void Init()
        {
            _gameController.Init();
            _screenplayController.Init(_screenplayData);
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