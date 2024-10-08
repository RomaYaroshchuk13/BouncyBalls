using System;

namespace Assets.BouncyBalls.Scripts.Balls
{
    public class BallModel
    {
        private BallType _type;
        private bool customImage;// can add another sprite
        private bool tail;// tailType none, simple, rgb .. ets
        private bool randomColor; // random color sprite
        private Action _callBack = null;

        public BallType Type => _type;
        public Action CallBack => _callBack;

        public BallModel(BallType type)
        {
            _type = type;
        }
    }
}
