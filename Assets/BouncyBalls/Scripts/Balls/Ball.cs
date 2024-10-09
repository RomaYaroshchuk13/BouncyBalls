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
        protected SignalBus _signalBus;

        public void Init()
        {
            _signalBus = ServiceLocator.Current.Get<SignalBus>();
        }

        protected abstract void Interact();

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag.Equals("Sector"))
            {
                Interact();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals("Figure"))
            {
                Dispose();
            }
        }

        private void Dispose()
        {
            _signalBus.Invoke(new DisposeBallSignal(this));
        }
    }
}
