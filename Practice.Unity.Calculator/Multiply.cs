using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Unity.Calculator
{
    public class Multiply : IOperation
    {
        public int Operate(int leftOperand, int rightOperand)
        {
            return leftOperand * rightOperand;
        }

        public Multiply()
        {
            Console.WriteLine(string.Format("{0} instance #{1} is constructing...", nameof(Multiply), this.GetHashCode()));
        }
    }
}
