using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class SimpleCalc
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Devide(int a, int b)
        {
            if (b == 0)
                return a;

            return a / b;
        }
    }
}
