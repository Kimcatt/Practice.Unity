using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Unity.Calculator
{
    public class Add : IOperation
    {
        public int Operate(int leftOperand, int rightOperand)
        {
            return leftOperand + rightOperand;
        }

        public Add()
        {
            Console.WriteLine(string.Format("{0} instance #{1} is constructing...", nameof(Add), this.GetHashCode()));
        }
    }
}
