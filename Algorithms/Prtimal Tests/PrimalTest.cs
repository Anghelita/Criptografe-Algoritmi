using Algorithms.Large_Number_Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Prtimal_Tests
{
    class PrimalTest
    {

        public static bool Parrat(StringArithmetics n)
        {

            if (n == 2 || n == 3)
                return true;


            if ((n / 2).Rest == 0)
            {
                return false;
            }


            for (StringArithmetics x = 2.ToStringArithmetics(); x <= n - 1; x = x+1)
            {
                if ((((x ^ (n - 1)) - 1) / n).Rest != 0)
                {
                    continue;
                }


                List<StringArithmetics> factori = new List<StringArithmetics>();

                StringArithmetics q = n - 1;
                StringArithmetics i = 2.ToStringArithmetics();
                CatRest r = new CatRest();

                while (q > 1)
                {
                    r = q / i;
                    if (r.Rest == 0)
                    {
                        factori.Add(i);
                        q = (q/i).Cat;
                    }
                    else
                    {
                        i = i + 1;
                    }
                }

                foreach (StringArithmetics a in factori)
                {
                    if (!Parrat(a))
                    {
                        return false;
                    }
                }

                bool Ok = true;

                foreach (StringArithmetics a in factori)
                {
                    if ((((x ^ ((n - 1) / a).Cat) - 1) / n).Rest == 0)
                    {
                        Ok = false;
                    }
                }
                if (Ok)
                {
                    return true;
                }
            }
            return true;
        }

        public static bool MillerRabin(int n)
        {
            if (n % 2 == 0)
                return false;
            int l = 0;
            int m = n - 1;
            while (m % 2 == 0)
            {
                l++;
                m = m / 2;
            }

            int d = (int)((n - 1) / Math.Pow(2, l));

            for (int i = 0; i < l - 1; i++)
            {

            }




            return false;
        }

    }
}
