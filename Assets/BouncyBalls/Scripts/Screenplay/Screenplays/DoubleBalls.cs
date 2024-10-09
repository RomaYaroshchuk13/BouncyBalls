using Assets.BouncyBalls.Scripts.Balls;
using Assets.BouncyBalls.Scripts.PatternServiceLocator;
using Assets.BouncyBalls.Scripts.PatternSignalBus;
using Assets.BouncyBalls.Scripts.Sectors;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.BouncyBalls.Scripts.Screenplay.Screenplays
{
    [CreateAssetMenu(fileName = "DoubleBalls", menuName = "Screenplays/DoubleBalls", order = 1)]
    public class DoubleBalls : Screenplay
    {
        private SignalBus _signalBus;
        private BallsCreator _ballsCreator;
        private SectorsCreator _sectorsCreator;
        private ScreenplayData _screenplayData;
        private PoolBase<Ball> _ballsPool;

        private Vector2 _spawnPosition = new(-150,150);
        private Vector2 _spawnPosition1 = new(150,150);
        public override void Init(ScreenplayData screenplayData)
        {
            _signalBus = ServiceLocator.Current.Get<SignalBus>();
            _ballsCreator = ServiceLocator.Current.Get<BallsCreator>();
            _sectorsCreator = ServiceLocator.Current.Get<SectorsCreator>();
            _screenplayData = screenplayData;
            _ballsPool = new(Preload, GetAction, ReturnAction, 500);

            _signalBus.Subscribe<DisposeBallSignal>(DoubleBall);
        }

        private void DoubleBall(DisposeBallSignal signal)
        {
            _ballsPool.Return(signal.Ball);

            Ball ball = _ballsPool.Get();
            Ball ball1 = _ballsPool.Get();

            ball.transform.localPosition = _spawnPosition;
            ball1.transform.localPosition = _spawnPosition1;
        }

        public override void Play()
        {
            CreatePlayZone();
            Ball ball = _ballsPool.Get();

            ball.transform.localPosition = new(Random.Range(0f,20f), 0);
        }

        private Ball InitBall()
        {
            BallModel model = new BallModel(_screenplayData.BallType);
            Ball ball = _ballsCreator.CreateBall(model);

            return ball;
        }

        private void CreatePlayZone()
        {
            List<int> removedSectors = new() { 1, 2, 3, 4, 5, 6 };
            Figure cirle = _sectorsCreator.CreateCirle(500, removedSectors);
            cirle.Rotate(-10, 2);
        }

        private Ball Preload() => InitBall();
        private void GetAction(Ball ball) => ball.gameObject.SetActive(true);
        private void ReturnAction(Ball ball) => ball.gameObject.SetActive(false);
    }
}
