using UnityEngine;

namespace Assets.BouncyBalls.Scripts.Screenplay
{
    public abstract class Screenplay : ScriptableObject, IScreenplay
    {
        public abstract void Init(ScreenplayData screenplayData);

        public abstract void Play();
    }
}
