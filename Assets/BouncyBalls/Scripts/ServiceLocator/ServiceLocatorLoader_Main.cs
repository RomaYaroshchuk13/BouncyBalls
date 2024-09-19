using SignalBus;
using UnityEngine;

namespace Assets.Patterns.Scripts.ServiceLocator
{
    public class ServiceLocatorLoader_Main : MonoBehaviour
    {

        //[SerializeField] private Player _player;

        private EventBus _eventBus;
        //private GameController _gameController;
        //private ScoreController _scoreController;

        private void Awake()
        {
            _eventBus = new EventBus();
            //_gameController = new GameController();
            //_scoreController = new ScoreController();


            RegisterServices();
            Init();
            AddDisposables();
        }

        private void RegisterServices()
        {
            ServiceLocator.Initialize();

            ServiceLocator.Current.Register(_eventBus);
            //ServiceLocator.Current.Register<Player>(_player);
            //ServiceLocator.Current.Register(_gameController);
            //ServiceLocator.Current.Register(_scoreController);
        }

        private void Init()
        {
            //_player.Init();
            //_gameController.Init();
            //_scoreController.Init();

        }

        private void AddDisposables()
        {
            //_disposables.Add(_gameController);
            //_disposables.Add(_scoreController);
        }

        private void OnDestroy()
        {
            //foreach (var disposable in _disposables)
            //{
            //    disposable.Dispose();
            //}
        }
    }
}