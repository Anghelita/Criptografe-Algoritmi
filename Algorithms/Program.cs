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
            Console.WriteLine(Karatsuba.Karatsuba.PROD(2512, 11414));
            CatRest catRest = Karatsuba.Karatsuba.DIV(554, 123);
            Console.WriteLine("Cat:{0} Rest:{1}", catRest.Cat,catRest.Rest);
            Console.ReadKey();
        }
    }
}
