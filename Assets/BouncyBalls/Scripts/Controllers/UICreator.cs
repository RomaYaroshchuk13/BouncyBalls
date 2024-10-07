using Assets.BouncyBalls.Scripts.PatternServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.BouncyBalls.Scripts.Controllers
{
    public class UICreator : MonoBehaviour, IService
    {
        [SerializeField] private Text _title;
        [SerializeField] private GameObject _scorePrefab;

        public void SetTitle(string title)
        {
            _title.text = title;
        }

        public void CreateScore() { 
        
        }
    }
}
