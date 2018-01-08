using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Unity.Utility
{
    public static class RandomHelper
    {
        private static Random rnd = new Random((int)DateTime.Now.Ticks);

        public static int NextInt(int minValue, int maxValue)
        {
            return rnd.Next(minValue, maxValue);
        }
    }
}
