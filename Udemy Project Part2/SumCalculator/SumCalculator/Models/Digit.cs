using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SumCalculator.Models
{
    public class Digit
    {
        public decimal Num1 { get; set; }
        public decimal Num2 { get; set; }
        public string Operation { get; set; }
        public decimal Sum()
        {
            decimal result = Num1 + Num2;
            return result;
        }
        public decimal Sub()
        {
            decimal result = Num1 - Num2;
            return result;
        }
        public decimal Mul()
        {
            decimal result = Num1 * Num2;
            return result;
        }
        public decimal Div()
        {
            decimal result = Num1 / Num2;
            return result;
        }
    }
}
