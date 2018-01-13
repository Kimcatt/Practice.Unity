using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Unity.Utility;

namespace Practice.Unity.Storage
{
    public class SimpleConnectionStringStorage : IConnectionStringStorage
    {
        private Random random = new Random((int)DateTime.Now.Ticks);

        public string GetConnectionString(string key)
        {
            ConsoleHelper.WriteYellowLine(string.Format("{0} istance is working on get...", nameof(SimpleConnectionStringStorage)));
            return string.Format("Connection string #{0}", random.Next(100));
        }

        public void SaveConnectionString(string key, string val)
        {
            Console.WriteLine("{0} istance is working on save...", nameof(SimpleConnectionStringStorage));
        }
    }
}
