using Assets.BouncyBalls.Scripts.PatternServiceLocator;
using Assets.BouncyBalls.Scripts.Screenplay;
using System.Collections.Generic;

namespace Assets.BouncyBalls.Scripts.ConfigLoader
{
    public interface IScreenplayLoader : IService, ILoader
    {
        public IEnumerable<ScreenplayData> GetScreenplays();
    }
}
