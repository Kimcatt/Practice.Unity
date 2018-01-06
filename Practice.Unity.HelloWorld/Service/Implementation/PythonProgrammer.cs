using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Unity.HelloWorld.Service.Implementation
{
    public class PythonProgrammer : IProgrammer
    {
        public void Work()
        {
            Console.WriteLine("Python programmer working...#{0}", this.GetHashCode());
        }
    }
}
