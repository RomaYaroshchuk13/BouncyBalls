using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.BouncyBalls.Scripts.ConfigLoader
{
    public interface ILoader
    {
        public bool IsLoaded();
        public void Load();
        public bool IsLoadingInstant();
    }
}
