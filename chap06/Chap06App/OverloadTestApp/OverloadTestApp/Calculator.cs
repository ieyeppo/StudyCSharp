using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadTestApp
{
    class Calculator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("계산기");
            int x = Calculator.Plus(3, 4);
            Console.WriteLine(x);
        }

        public static int Plus(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
