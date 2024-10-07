using Assets.BouncyBalls.Scripts.PatternServiceLocator;
using Assets.BouncyBalls.Scripts.PatternSignalBus;
using Assets.BouncyBalls.Scripts.PatternSignalBus.Signals.SystemSignals;
using Assets.BouncyBalls.Scripts.Screenplay;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.BouncyBalls.Scripts.ConfigLoader.ScriptableObjectScreenplayLoaders
{
    public class ScriptableObjectScreenplayLoader : MonoBehaviour, IScreenplayLoader
    {
        [SerializeField] private ScreenplayConfig _screenplaysConfig;

        public IEnumerable<ScreenplayData> GetScreenplays()
        {
            return _screenplaysConfig.Screenplays;
        }

        public bool IsLoaded()
        {
            return true;
        }

        public void Load()
        {
            var signalBus = ServiceLocator.Current.Get<SignalBus>();
            signalBus.Invoke(new DataLoadedSignal(this));
        }

        public bool IsLoadingInstant()
        {
            return true;
        }
    } }