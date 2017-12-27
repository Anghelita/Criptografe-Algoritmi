using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algorithms.Karatsuba
{
    class LargeNumberOperation
    {
      

        public static CatRest DIV(long n, long m)
        {
            if(n == 0)
            {
                return new CatRest(0, 0);
            }

            if(m == 1)
            {
                return new CatRest(n, 0);
            }

            if(m < 0)
            {
                CatRest catRest = DIV(n, -m);
                return new CatRest(-catRest.Cat, catRest.Rest);
            }

            if (n < 0)
            {
                CatRest catRest = DIV(-n, m);
                if (catRest.Rest > 0)
                    return new CatRest(-catRest.Cat - 1, m - catRest.Rest);
                return new CatRest(-catRest.Cat, 0);
            }

            int N = n.ToString().Length;
            int M = m.ToString().Length;

            if (N < M)
                return new CatRest(0, n);

            if(N == M)
            {
                //for(int q = 0; q <= 9; q++)
                //{
                //    if (m > n - PROD(m.ToString(), q.ToString()))
                //    {
                //        return new CatRest(q, n - PROD(m.ToString(), q.ToString()));
                //    }
                //}
            }

            if (N > M)
            {
                List<long> y = new List<long>();
                long l = (long)(Math.Floor(Math.Pow(10, M) / m));

                if (Math.Pow(10, M) / m - Math.Floor(Math.Pow(10, M) / m) <= 0.5)
                    y.Add((long)(Math.Pow(10, N - M) * Math.Floor(Math.Pow(10, M) / m)));
                else
                    y.Add((long)(Math.Pow(10, N - M) * (Math.Floor(Math.Pow(10, M) / m) + 1)));

                while (true)
                {
                    y.Add((long)(2 * y[y.Count-1] - Math.Floor((m / Math.Pow(10, M)) * Math.Floor(Math.Pow(y[y.Count-1], 2) / Math.Pow(10, N - M)))));
                    if (y[y.Count-1] <= y[y.Count-2])
                    {
                        break;
                    }
                }

                long k;

                foreach (long val in y)
                {
                }



            }




            return new CatRest(0, 0); ;
        }

    }
}
