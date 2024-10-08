using UnityEngine;

namespace Assets.BouncyBalls.Scripts.Sectors
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Sector : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private Rigidbody2D _rigidbody2D;
        private BoxCollider2D _boxCollider2D;

        public void Init(SectorModel model)
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rectTransform = GetComponent<RectTransform>();
            _boxCollider2D = GetComponent<BoxCollider2D>();

            transform.localPosition = model.SectorPosition;
            transform.Rotate(model.SectorRotation);

            _rigidbody2D.isKinematic = true;

            _rectTransform.sizeDelta = new Vector2(model.SectorSize.x, model.SectorSize.y);

            _boxCollider2D.enabled = true;
            _boxCollider2D.size = new Vector2(model.SectorSize.x, model.SectorSize.y);
            _boxCollider2D.offset = new Vector2(0, 0);
        }
    }
}
