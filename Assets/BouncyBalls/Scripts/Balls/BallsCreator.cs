using Assets.BouncyBalls.Scripts.PatternServiceLocator;
using Assets.BouncyBalls.Scripts.Storages;
using UnityEngine;

namespace Assets.BouncyBalls.Scripts.Balls
{
    public class BallsCreator : MonoBehaviour, IService
    {
        [SerializeField] private Transform _ballsContainer;

        public Ball CreateBall(BallModel model)
        {
            Storage storage = ServiceLocator.Current.Get<Storage>();
            Ball ballPrefab = storage.GetBallPrefab(model.Type);
            Ball ball = Instantiate(ballPrefab, _ballsContainer);
            ball.Init();

            return ball;
        }
    }
}
