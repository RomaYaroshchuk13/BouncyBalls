using UnityEngine;

namespace Assets.BouncyBalls.Scripts.Sectors
{
    public class SectorModel
    {
        private Vector3 _sectorPosition;
        private Vector3 _sectorRotation;
        private Vector3 _sectorSize;

        public Vector3 SectorPosition => _sectorPosition;
        public Vector3 SectorRotation => _sectorRotation;
        public Vector3 SectorSize => _sectorSize;

        public SectorModel(Vector3 sectorPositon, Vector3 sectorRotation, Vector3 sectorSize)
        {
            _sectorPosition = sectorPositon;
            _sectorRotation = sectorRotation;
            _sectorSize = sectorSize;
        }
    }
}
