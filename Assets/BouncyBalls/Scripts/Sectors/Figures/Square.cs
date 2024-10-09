using UnityEngine;

namespace Assets.BouncyBalls.Scripts.Sectors.Figures
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Square : Figure
    {
        private const string NAME = "Square";
        private BoxCollider2D _boxCollider2D;

        public void Init(Vector2 coliderSize)
        {
            gameObject.name = NAME;
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _boxCollider2D.size = coliderSize;
        }
    }
}
