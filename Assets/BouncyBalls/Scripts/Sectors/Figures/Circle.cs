using UnityEngine;

namespace Assets.BouncyBalls.Scripts.Sectors.Figures
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Circle : Figure
    {
        private const string NAME = "Circle";
        private CircleCollider2D _circleCollider;

        public void Init(float radius)
        {
            gameObject.name = NAME;
            _circleCollider = GetComponent<CircleCollider2D>();
            _circleCollider.radius = radius;
        }
    }
}
