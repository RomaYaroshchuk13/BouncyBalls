using Assets.BouncyBalls.Scripts.Balls;
using Assets.BouncyBalls.Scripts.PatternServiceLocator;
using UnityEngine;

namespace Assets.BouncyBalls.Scripts.Storages
{
    public class Storage : MonoBehaviour, IService
    {
        [SerializeField] private SerializableDictionary<BallType, Ball> _ballsPrefab;
        [SerializeField] private SerializableDictionary<BallType, AudioClip> _ballAudioClips;
        public Ball GetBallPrefab(BallType type)
        {

            if (_ballsPrefab.ContainsKey(type))
            {
                return _ballsPrefab[type];
            }

            return _ballsPrefab[BallType.NONE];
        }

        public AudioClip GetAudioClip(BallType type)
        {
            if (_ballAudioClips.ContainsKey(type))
            {
                return _ballAudioClips[type];
            }

            return _ballAudioClips[BallType.NONE];
        }
    }
}
