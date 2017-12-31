using Algorithms.Large_Number_Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                StringArithmetics a, b;
                a = new StringArithmetics(Console.ReadLine().ToString());
                //b = new StringArithmetics(Console.ReadLine().ToString());

                //CatRest c = a / b;

                //Console.WriteLine(c.Cat.Operand + " " + c.Rest.Operand);
                Console.WriteLine(StringArithmetics.Sqrt(a).Operand);
                break;
            }
            Console.ReadLine();
        }
    }
}
