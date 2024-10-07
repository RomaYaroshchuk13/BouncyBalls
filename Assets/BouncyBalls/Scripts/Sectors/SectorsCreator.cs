using Assets.BouncyBalls.Scripts.PatternServiceLocator;
using System;
using System.Collections.Generic;
using UnityEngine;
using static Assets.BouncyBalls.Scripts.Sectors.Sector;

namespace Assets.BouncyBalls.Scripts.Sectors
{
    public class SectorsCreator : MonoBehaviour, IService
    {
        private const float PI = 3.1415f;
        private const float CONVERSION_FACTOR = PI/180F;

        [SerializeField] private Sector sectorPrefab;
        [SerializeField] private Figure figurePrefab;
        [SerializeField] private Transform figureContainer;

        public Figure CreateCirle(float radius, List<int> removingSectors = null, float sectorCount = 32f, float sectorHight = 10f)
        {
            Figure figure = Instantiate(figurePrefab, figureContainer);
            figure.name = "Circle";

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

                Sector sector = Instantiate(sectorPrefab, figure.transform);
                sector.Init(model);
                figure.sectors.Add(sector);
            }

            return figure;
        }
        public Figure CreateSquare(float radius, float sectorHight = 10f)
        {
            Figure figure = Instantiate(figurePrefab, figureContainer);
            figure.name = "Square";

            Vector3 sectorSize = new(sectorHight, radius*2);
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
                Sector sector = Instantiate(sectorPrefab, figure.transform);
                sector.Init(model);
                figure.sectors.Add(sector);
            }

            return figure;
        }
}
}