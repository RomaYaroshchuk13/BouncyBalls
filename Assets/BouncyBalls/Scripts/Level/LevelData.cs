using UnityEngine;

namespace Assets.BouncyBalls.Scripts.Level
{
    [System.Serializable]
    public class LevelData
    {
        /// <summary>
        /// Уникальный ID уровня
        /// </summary>
        [SerializeField] private int id;
        /// <summary>

        public int ID => id;
    }
}