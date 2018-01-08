using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Unity.Calculator
{
    public interface IOperation
    {
        int Operate(int leftOperand, int rightOperand);
    }
}
