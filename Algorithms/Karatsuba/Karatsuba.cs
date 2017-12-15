using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Karatsuba
{
    class Karatsuba
    {
        public static long PROD(long n, long m)
        {

            if (n == 0 && m == 0)
                return 0;
            if ((n < 0 && m > 0) || (n > 0 && m < 0))
            {
                long t = PROD(Math.Abs(n), Math.Abs(m));
                return -t;
            }

            if ((n < 0 && m < 0))
            {
                long t = PROD(Math.Abs(n), Math.Abs(m));
                return t;
            }

            if(n<10 && m < 10)
            {
                return n*m;
            }


            if (n >= 10 || m >= 10)
            {
                int k;
                if(n > m)
                    k = n.ToString().Length/2;
                else
                    k = m.ToString().Length / 2;

                long a = n / (int)Math.Pow(10, k);
                long b = n % (int)Math.Pow(10, k);
                long c = m / (int)Math.Pow(10, k);
                long d = m % (int)Math.Pow(10, k);

                long prod1 = PROD(a + b, c + d);
                long prod2 = PROD(a, c);
                long prod3 = PROD(b, d);
                return (int)Math.Pow(10, 2*k) * prod2 + (int)Math.Pow(10, k) * (prod1 - prod2 - prod3) + prod3;
            }
            return 0;
        }

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
                for(int q = 0; q <= 9; q++)
                {
                    if (m > n - Karatsuba.PROD(m, q))
                    {
                        return new CatRest(q, n - Karatsuba.PROD(m, q));
                    }
                }
            }

            if (N > M)
            {
                List<long> y = new List<long>();
                long l = (long)(Math.Floor(Math.Pow(10, M) / m));

                if (Math.Pow(10, M) / m - Math.Floor(Math.Pow(10, M) / m) <= 1 / 2)
                    y.Add((long)(Math.Pow(10, N - M) * Math.Floor(Math.Pow(10, M) / m)));
                else
                    y.Add((long)(Math.Pow(10, N - M) * (Math.Floor(Math.Pow(10, M) / m) + 1)));

                while (true)
                {
                    y.Add((long)(2 * y[y.Count-1] - Math.Floor(m / Math.Pow(10, M) * Math.Floor(Math.Pow(y[y.Count-1], 2) / Math.Pow(10, N - M)))));
                    if (y[y.Count-1] <= y[y.Count-2])
                    {
                        break;
                    }
                }

                long k;

                foreach(long val in y)
                {
                    if (Karatsuba.PROD(m, l) == val)
                    {
                        k = val;
                        break;
                    }
                }



            }




            return new CatRest(0, 0); ;
        }

    }
}
