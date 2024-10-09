using Assets.BouncyBalls.Scripts.PatternServiceLocator;
using Assets.BouncyBalls.Scripts.Sectors.Figures;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.BouncyBalls.Scripts.Sectors
{
    public class SectorsCreator : MonoBehaviour, IService
    {
        private const float PI = 3.1415f;
        private const float CONVERSION_FACTOR = PI/180F;

        [SerializeField] private Sector sectorPrefab;
        [SerializeField] private Circle _circlePrefab;
        [SerializeField] private Square _squarePrefab;
        [SerializeField] private Transform figureContainer;

        public Figure CreateCirle(float radius, List<int> removingSectors = null, float sectorCount = 32f, float sectorHight = 10f)
        {
            Circle circle = Instantiate(_circlePrefab, figureContainer);
            circle.Init(radius);

            float circuit = 2 * PI * radius;
            float sectorWidth = circuit / sectorCount; 
            float sectorDegrees = 360 / sectorCount;
            Vector3 sectorSize = new(sectorHight, sectorWidth);

            for (int i = 0; i < sectorCount; i++)
            {
                if (removingSectors != null && removingSectors.Contains(i))
                {
                    continue;
                }

                float radian = (sectorDegrees * i) * CONVERSION_FACTOR;
                float x = radius * (float)Math.Cos(radian);
                float y = radius * (float)Math.Sin(radian);

                Vector2 sectorPosition = new(x, y);
                Vector3 sectorRotation = new(0, 0, sectorDegrees * (i));

                SectorModel model = new(sectorPosition, sectorRotation, sectorSize);

                Sector sector = Instantiate(sectorPrefab, circle.transform);
                sector.Init(model);
                circle.sectors.Add(sector);
            }

            return circle;
        }

        public Figure CreateSquare(float radius, float sectorHight = 10f)
        {
            Square square = Instantiate(_squarePrefab, figureContainer);
            float sectorWidth = radius * 2;
            square.Init(new(sectorWidth, sectorWidth));

            Vector3 sectorSize = new(sectorHight, sectorWidth);
            float sectorDegrees = 90;
            float modifyRadius = radius - (sectorHight*0.5f);

            for (int i = 0; i < 4; i++)
            {
                float radian = (sectorDegrees * i) * CONVERSION_FACTOR;
                float x = modifyRadius * (float)Math.Cos(radian);
                float y = modifyRadius * (float)Math.Sin(radian);

                Vector2 sectorPosition = new(x, y);
                Vector3 sectorRotation = new(0, 0, sectorDegrees * (i));

                SectorModel model = new(sectorPosition, sectorRotation, sectorSize);
                Sector sector = Instantiate(sectorPrefab, square.transform);
                sector.Init(model);
                square.sectors.Add(sector);
            }

            return square;
        }
}
}