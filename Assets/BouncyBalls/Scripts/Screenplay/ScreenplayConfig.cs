using System.Collections.Generic;
using UnityEngine;

namespace Assets.BouncyBalls.Scripts.Screenplay
{
    [CreateAssetMenu(fileName = "ScreenplayConfig", menuName = "ScriptableObjects/ScreenplayConfig", order = 1)]
    public class ScreenplayConfig : ScriptableObject
    {
        [SerializeField] private List<ScreenplayData> _screenplays;

        public List<ScreenplayData> Screenplays => _screenplays;
    }
}