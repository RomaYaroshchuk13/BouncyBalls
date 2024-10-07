using Assets.BouncyBalls.Scripts.Balls;
using UnityEngine;

namespace Assets.BouncyBalls.Scripts.Screenplay
{
    [System.Serializable]
    public class ScreenplayData
    {
        [SerializeField] private string _title;
        [SerializeField] private BallType _ballType;
        [SerializeField] private SectorType _sectorType;
        [SerializeField] private Screenplay _screenplay;

        public string Title => _title;
        public BallType BallType => _ballType;
        public SectorType SectorType => _sectorType;
        public IScreenplay Screenplay => _screenplay;
    }
}