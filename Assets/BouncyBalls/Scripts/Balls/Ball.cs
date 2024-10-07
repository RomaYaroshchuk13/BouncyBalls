using Assets.BouncyBalls.Scripts.PatternServiceLocator;
using Assets.BouncyBalls.Scripts.PatternSignalBus;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.BouncyBalls.Scripts.Balls
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    public abstract class Ball : MonoBehaviour
    {
        private Image _sprite;
        private int _health;
        protected SignalBus _signalBus;

        public void Init(Sprite sprite, int health)
        {
            _sprite.sprite = sprite;
            _health = health;   

            _signalBus = ServiceLocator.Current.Get<SignalBus>();
        }
        protected abstract void Interact();

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag.Equals("Sector"))
            {
                Interact();
                Dispose();
            }
        }

        private void Dispose()
        {

        }
    }
}
