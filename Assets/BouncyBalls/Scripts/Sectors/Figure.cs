using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.BouncyBalls.Scripts.Sectors
{
    public class Figure : MonoBehaviour
    {
        public List<Sector> sectors = new();

        public void Rotate(float speed, float delay)
        {
            transform.DORotate(new Vector3(0, 0, speed), 1f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear).SetDelay(delay);
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }
    }
}
