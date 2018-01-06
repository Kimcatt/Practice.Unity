using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Unity.Calculator
{
    public class SimpleCalculator : ICalculator
    {
        

        private void TryParse(string expr, out double operandL, out char op, out double operandR)
        {
            int index = 0;
            while (index < expr.Length && char.IsDigit(expr[index]))
            {
                index++;
            }
            operandL = Convert.ToDouble(expr.Substring(0, index).Trim());
            op = expr[index];
            operandR = Convert.ToDouble(expr.Substring(index + 1).Trim());
        }

        private double Calculate(double operandL, char op, double operandR)
        {
            switch(op)
            {
                case '+':
                    return operandL + operandR;
                case '-':
                    return operandL - operandR;
                case '*':
                    return operandL * operandR;
                case '/':
                    return operandL / operandR;
                default:
                    throw new System.NotImplementedException();
            }
        }

        public double Calculator(string expr)
        {
            double operandL, operandR;
            char op;
            TryParse(expr, out operandL, out op, out operandR);
            return Calculate(operandL, op, operandR);
        }
    }
}
