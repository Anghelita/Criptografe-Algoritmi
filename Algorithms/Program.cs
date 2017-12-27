using Algorithms.Karatsuba;
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
                //a = new StringArithmetics(Console.ReadLine().ToString());
                //b = new StringArithmetics(Console.ReadLine().ToString());

                //Console.WriteLine(StringArithmetics.Less("-10", "-20"));
                //Console.WriteLine(StringArithmetics.More(a, b));
                //Console.WriteLine(LargeNumberOperation.PROD(a,b));
                //Console.WriteLine(StringArithmetics.Subtract("000", "420"));

                StringArithmetics c = StringArithmetics.Floor(55.ToStringArithmetics() , 4.ToStringArithmetics());
                Console.WriteLine(c.Operand);
                //Console.WriteLine(StringArithmetics.Subtract("2345123516541325","-65413786517865786586175617617298658721"));
                break;
            }
            Console.ReadLine();
        }
    }
}
