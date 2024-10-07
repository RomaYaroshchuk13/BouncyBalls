using Assets.BouncyBalls.Scripts.Balls;
using UnityEngine;

namespace Assets.BouncyBalls.Scripts.Storages
{
    public class Storage : MonoBehaviour
    {
        [SerializeField] private SerializableDictionary<BallType, Sprite> _ballSprite;
        [SerializeField] private SerializableDictionary<BallType, AudioClip> _ballAudioClips;
        public Sprite GetSprite(BallType type)
        {

            if (_ballSprite.ContainsKey(type))
            {
                return _ballSprite[type];
            }

            return _ballSprite[BallType.NONE];
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
