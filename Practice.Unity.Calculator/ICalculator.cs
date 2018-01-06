using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Unity.Calculator
{
    public interface ICalculator<T> where T: struct
    {
        T Calculate(string expr);
    }

    public interface ICalculator
    {
        double Calculator(string expr);
    }
}
