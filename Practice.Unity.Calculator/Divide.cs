﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Unity.Calculator
{
    public class Divide : IOperation
    {
        public int Operate(int leftOperand, int rightOperand)
        {
            return leftOperand / rightOperand;
        }
    }
}
