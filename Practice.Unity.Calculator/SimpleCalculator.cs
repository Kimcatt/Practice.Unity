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
            while (index < expr.Length && (char.IsDigit(expr[index]) || char.IsWhiteSpace(expr[index])))
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

        public double Calculate(string expr)
        {
            double operandL, operandR;
            char op;
            TryParse(expr, out operandL, out op, out operandR);
            double r = Calculate(operandL, op, operandR);
            Console.WriteLine(string.Format("{0} = {1}", expr, r));
            return r;
        }

        public SimpleCalculator()
        {
            Console.WriteLine(string.Format("{0} instance #{1} is contructing", nameof(SimpleCalculator), this.GetHashCode()));
        }
    }
}
