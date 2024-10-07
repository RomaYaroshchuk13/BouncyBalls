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

        public class SectorModel
        {
            private Vector3 _sectorPosition;
            private Vector3 _sectorRotation;
            private Vector3 _sectorSize;

            public Vector3 SectorPosition => _sectorPosition;
            public Vector3 SectorRotation => _sectorRotation;
            public Vector3 SectorSize => _sectorSize;

            public SectorModel(Vector3 sectorPositon, Vector3 sectorRotation, Vector3 sectorSize) {
                _sectorPosition = sectorPositon;
                _sectorRotation = sectorRotation;
                _sectorSize = sectorSize;
            }
        }
    }
}
