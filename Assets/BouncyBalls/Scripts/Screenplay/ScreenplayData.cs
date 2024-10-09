using Assets.BouncyBalls.Scripts.Balls;
using UnityEngine;

namespace Assets.BouncyBalls.Scripts.Screenplay
{
    [System.Serializable]
    public class ScreenplayData
    {
        [SerializeField] private string _title;
        
        [SerializeField] private BallType _ballType;
        [SerializeField] private BallColorType _ballColorType;
        [SerializeField] private BallTailType _ballTailType;
           
        [SerializeField] private Screenplay _screenplay;

        public string Title => _title;
        public BallType BallType => _ballType;
        public BallColorType BallColorType => _ballColorType;
        public BallTailType BallTailType => _ballTailType;
        public IScreenplay Screenplay => _screenplay;
    }
}