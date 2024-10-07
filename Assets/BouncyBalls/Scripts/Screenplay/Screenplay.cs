using Assets.BouncyBalls.Scripts.Balls;
using Assets.BouncyBalls.Scripts.Sectors;
using UnityEngine;

namespace Assets.BouncyBalls.Scripts.Screenplay
{

    public abstract class Screenplay : ScriptableObject, IScreenplay
    {
        public abstract void Init(BallsCreator ballsCreator, SectorsCreator sectorsCreator, ScreenplayData screenplayData);

        public abstract void Play();
    }
}
