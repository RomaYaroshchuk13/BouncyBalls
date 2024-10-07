using Assets.BouncyBalls.Scripts.Balls;
using Assets.BouncyBalls.Scripts.Sectors;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.BouncyBalls.Scripts.Screenplay.Screenplays
{
    [CreateAssetMenu(fileName = "DoubleBalls", menuName = "Screenplays/DoubleBalls", order = 1)]
    public class DoubleBalls : Screenplay
    {
        private BallsCreator _ballsCreator;
        private SectorsCreator _sectorsCreator;
        private ScreenplayData _screenplayData;

        public override void Init(BallsCreator ballsCreator, SectorsCreator sectorsCreator, ScreenplayData screenplayData)
        {
            _ballsCreator = ballsCreator;
            _sectorsCreator = sectorsCreator;
        }

        public override void Play()
        {
            CreateBall();
            CreatePlayZone();
        }

        private void CreateBall()
        {

        }

        private void CreatePlayZone()
        {
            Figure cirle = _sectorsCreator.CreateCirle(500, null, 8);
            cirle.Rotate(-10, 2);
            Figure cirle2 = _sectorsCreator.CreateCirle(400);
            cirle2.Rotate(10, 3);

            Figure Squar = _sectorsCreator.CreateSquare(100);
            Squar.Rotate(10, 2);
        }
    }
}
