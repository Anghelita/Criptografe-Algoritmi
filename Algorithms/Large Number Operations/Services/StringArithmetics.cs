using Algorithms.Large_Number_Operations;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Algorithms
{
    class StringArithmetics
    {
        public String Operand;

        public StringArithmetics(String Op)
        {
            Operand = new String(Op.ToCharArray());
        }

        public override bool Equals(object obj)
        {
            var arithmetics = obj as StringArithmetics;
            return arithmetics != null &&
                   Operand == arithmetics.Operand;
        }
        public override int GetHashCode()
        {
            return -1936841426 + EqualityComparer<string>.Default.GetHashCode(Operand);
        }

        public static StringArithmetics Abs(StringArithmetics a)
        {
            StringArithmetics b = new StringArithmetics(a.Operand);
            if (a.Operand[0].Equals('-'))
            {
                b = new StringArithmetics(a.Operand.Remove(0, 1));
            }
            return b;
        }

        public static StringArithmetics Floor(CatRest a)
        {
            return new StringArithmetics(a.Cat.Operand);
        }
        public static StringArithmetics Ceiling(CatRest a)
        {
            if (a.Rest >= 0)
            {
                return new StringArithmetics((a.Cat +1).Operand);
            }
            return new StringArithmetics(a.Cat.Operand);
        }

        public static bool operator >(StringArithmetics a, Object n)
        {
            if (n is int)
            {
                StringArithmetics b = (Convert.ToInt32(n)).ToStringArithmetics();
                return a > b;
            }
            if (n is StringArithmetics)
            {
                StringArithmetics b = n as StringArithmetics;
                if (!(a < b) && !(a == b))
                    return true;
                return false;
            }
            return false;
        }
        public static bool operator <(StringArithmetics a, Object n)
        {
            if (n is int)
            {
                StringArithmetics b = (Convert.ToInt32(n)).ToStringArithmetics();
                return a < b;
            }
            if (n is StringArithmetics)
            {
                StringArithmetics b = n as StringArithmetics;

                // a si b au acelas semn

                if (a.Operand[0].Equals('-') && !b.Operand[0].Equals('-'))
                    return true;
                if (!a.Operand[0].Equals('-') && b.Operand[0].Equals('-'))
                    return false;

                //lungimea lui a e mai mica

                if (a.Operand.Length < b.Operand.Length)
                {
                    if (a.Operand[0].Equals("-"))
                        return false;
                    return true;
                }

                //lungimea lui a e mai mare

                if (a.Operand.Length > b.Operand.Length)
                {
                    if (a.Operand[0].Equals('-'))
                        return true;
                    return false;
                }

                StringArithmetics absa = Abs(a);
                StringArithmetics absb = Abs(b);


                for (int i = 0; i < absa.Operand.Length; i++)
                {
                    if (absa.Operand[i] > absb.Operand[i])
                    {
                        if (a.Operand[0].Equals('-'))
                        {
                            return true;
                        }
                        return false;
                    }

                    if (absa.Operand[i] < absb.Operand[i])
                    {
                        if (a.Operand[0].Equals('-'))
                        {
                            return false;
                        }
                        return true;
                    }
                }
                return false;
            }
            return false;
        }

        public static bool operator ==(StringArithmetics a, Object n)
        {
            if(n is int)
            {
                StringArithmetics b = (Convert.ToInt32(n)).ToStringArithmetics();
                return a == b;
            }
            if (n is StringArithmetics)
            {
                StringArithmetics b = n as StringArithmetics;
                if (a.Operand[0].Equals('-') && !b.Operand[0].Equals('-'))
                    return false;
                if (!a.Operand[0].Equals('-') && b.Operand[0].Equals('-'))
                    return false;

                if (a.Operand.Length != b.Operand.Length)
                    return false;


                StringArithmetics absa = Abs(a);
                StringArithmetics absb = Abs(b);

                for (int i = 0; i < absa.Operand.Length; i++)
                {
                    if (absa.Operand[i] != absb.Operand[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        public static bool operator !=(StringArithmetics a, Object n)
        {
            if (n is int)
            {
                StringArithmetics b = (Convert.ToInt32(n)).ToStringArithmetics();
                return a != b;
            }
            if (n is StringArithmetics)
            {
                StringArithmetics b = n as StringArithmetics;
                if (a == b)
                    return false;
                return true;
            }
            return false;
        }

        public static bool operator >=(StringArithmetics a, Object n)
        {
            if (n is int)
            {
                StringArithmetics b = (Convert.ToInt32(n)).ToStringArithmetics();
                return a >= b;
            }
            if (n is StringArithmetics)
            {
                StringArithmetics b = n as StringArithmetics;
                if (a > b)
                    return true;
                if (a == b)
                    return true;
                return false;
            }
            return false;
        }
        public static bool operator <=(StringArithmetics a, Object n)
        {
            if (n is int)
            {
                StringArithmetics b = (Convert.ToInt32(n)).ToStringArithmetics();
                return a <= b;
            }
            if (n is StringArithmetics)
            {
                StringArithmetics b = n as StringArithmetics;
                if (a < b)
                    return true;
                if (a == b)
                    return true;
                return false;
            }
            return false;
        }


        public static StringArithmetics operator +(StringArithmetics a, Object n)
        {
            if (n is int)
            {
                StringArithmetics b = (Convert.ToInt32(n)).ToStringArithmetics();
                return a + b;
            }
            if (n is StringArithmetics)
            {
                StringArithmetics b = n as StringArithmetics;
                if (b.Operand[0].Equals('-'))
                {
                    StringArithmetics s = a - Abs(b);
                    return s;
                }

                if (a.Operand[0].Equals('-'))
                {
                    StringArithmetics s = b - Abs(a);
                    return s;
                }


                String Sum = "";
                char[] rev = a.Operand.ToCharArray();
                Array.Reverse(rev);
                String reva = new String(rev);
                rev = b.Operand.ToCharArray();
                Array.Reverse(rev);
                String revb = new String(rev);

                int i = 0;
                int carry = 0;
                int digitsum;


                while (true)
                {
                    if (reva.Length >= i + 1 && revb.Length >= i + 1)
                    {
                        digitsum = Convert.ToInt32(reva[i]) - 48 + Convert.ToInt32(revb[i]) - 48 + carry;
                    }
                    else
                    {
                        if (reva.Length >= i + 1)
                            digitsum = Convert.ToInt32(reva[i]) - 48 + carry;
                        else
                        {
                            if (revb.Length >= i + 1)
                            {
                                digitsum = Convert.ToInt32(revb[i]) - 48 + carry;
                            }
                            else
                                break;
                        }
                    }
                    carry = digitsum / 10;
                    Sum = Sum.PadRight(i + 1, (digitsum % 10).ToString()[0]);
                    i++;
                }
                if (carry == 1)
                {
                    Sum = Sum.PadRight(i + 1, (carry).ToString()[0]);
                }

                rev = Sum.ToCharArray();
                Array.Reverse(rev);
                return new StringArithmetics(new String(rev));
            }
            return new StringArithmetics("0");
        }

        public static StringArithmetics operator -(StringArithmetics a, Object n)
        {
            if (n is int)
            {
                StringArithmetics b = (Convert.ToInt32(n)).ToStringArithmetics();
                return a - b;
            }
            if (n is StringArithmetics)
            {
                StringArithmetics b = n as StringArithmetics;
                if (b > a)
                {
                    StringArithmetics res = b - a;
                    res.Operand = res.Operand.PadLeft(res.Operand.Length + 1, '-');
                    return res;
                }

                if (b.Operand[0].Equals('-'))
                {
                    StringArithmetics s = a + Abs(b);
                    return s;
                }

                if (a.Operand[0].Equals('-'))
                {
                    StringArithmetics s = Abs(a) + b;
                    return s;
                }


                String Sub = "";

                char[] rev = a.Operand.ToCharArray();
                Array.Reverse(rev);
                String reva = new String(rev);
                rev = b.Operand.ToCharArray();
                Array.Reverse(rev);
                String revb = new String(rev);

                int i = 0;
                int carry = 0;
                int digitsum;


                while (true)
                {
                    if (reva.Length >= i + 1 && revb.Length >= i + 1)
                    {
                        int fd = Convert.ToInt32(reva[i]) - 48;
                        int sd = Convert.ToInt32(revb[i]) - 48;
                        digitsum = fd - sd + carry;
                    }
                    else
                    {
                        if (reva.Length >= i + 1)
                            digitsum = Convert.ToInt32(reva[i]) - 48 + carry;
                        else
                        {
                            if (revb.Length >= i + 1)
                            {
                                digitsum = Convert.ToInt32(revb[i]) - 48 + carry;
                            }
                            else
                                break;
                        }
                    }
                    if (digitsum < 0)
                    {
                        carry = -1;
                        Sub = Sub.PadRight(i + 1, (10 + digitsum % 10).ToString()[0]);
                    }
                    else
                    {
                        carry = 0;
                        Sub = Sub.PadRight(i + 1, (digitsum % 10).ToString()[0]);
                    }
                    i++;
                }

                rev = Sub.ToCharArray();
                Array.Reverse(rev);
                String input = new String(rev);

                string pattern = "^0*";
                string replacement = "";
                Regex rgx = new Regex(pattern);
                String result = rgx.Replace(input, replacement);
                if (result.Length == 0)
                {
                    result = "0";
                }

                return new StringArithmetics(result);
            }
            return new StringArithmetics("0");
        }

        public static StringArithmetics operator -(StringArithmetics a)
        {
            return 0.ToStringArithmetics() - a;
        }

        public static StringArithmetics operator *(StringArithmetics a, Object z)
        {
            if (z is int)
            {
                StringArithmetics b = (Convert.ToInt32(z)).ToStringArithmetics();
                return a * b;
            }
            if (z is StringArithmetics)
            {
                StringArithmetics b = new StringArithmetics( (z as StringArithmetics).Operand);
                string pattern = "^0*";
                string replacement = "";
                Regex rgx = new Regex(pattern);
                a.Operand = rgx.Replace(a.Operand, replacement);

                if (a.Operand.Length == 0)
                {
                    a.Operand = "0";
                }

                b.Operand = rgx.Replace(b.Operand, replacement);

                if (b.Operand.Length == 0)
                {
                    b.Operand = "0";
                }

                if (a == 0 || b == 0)
                    return new StringArithmetics("0");

                if ((a < 0 && b > 0) ||
                    (a > 0) && b < 0)
                {
                    StringArithmetics t = Abs(a) * Abs(b);
                    t = -t;
                    return t;
                }

                if (a < 0 && b < 0)
                {
                    StringArithmetics t = Abs(a) * Abs(b);
                    return t;
                }

                if (a < 10 && b < 10)
                {
                    return (Int32.Parse(a.Operand) * Int32.Parse(b.Operand)).ToStringArithmetics();
                }


                if (a >= 10 || b >= 10)
                {
                    int k;
                    if (a > b)
                    {
                        k = a.Operand.Length / 2;
                        b.Operand = b.Operand.PadLeft(2 * k + a.Operand.Length % 2, '0');
                        a.Operand = a.Operand.PadLeft(2 * k + a.Operand.Length % 2, '0');
                    }
                    else
                    {
                        k = b.Operand.Length / 2;
                        b.Operand = b.Operand.PadLeft(2 * k + b.Operand.Length % 2, '0');
                        a.Operand = a.Operand.PadLeft(2 * k + b.Operand.Length % 2, '0');
                    }



                    StringArithmetics m = new StringArithmetics(a.Operand.Substring(0, k + a.Operand.Length % 2));
                    StringArithmetics n = new StringArithmetics(a.Operand.Substring(k + a.Operand.Length % 2));
                    StringArithmetics o = new StringArithmetics(b.Operand.Substring(0, k + b.Operand.Length % 2));
                    StringArithmetics p = new StringArithmetics(b.Operand.Substring(k + a.Operand.Length % 2));


                    StringArithmetics prod1 = (m + n) * (o + p);
                    StringArithmetics prod2 = m * o;
                    StringArithmetics prod3 = n * p;

                    StringArithmetics aux = prod1 - prod2 - prod3;
                    //TODO: fa si tu ridicarea aia la putere boss
                    StringArithmetics resuoulr = prod2.Operand.PadRight(prod2.Operand.Length + (2 * k), '0').ToStringArithmetics() +
                        aux.Operand.PadRight(aux.Operand.Length + k, '0').ToStringArithmetics() +
                        prod3;

                    resuoulr.Operand = rgx.Replace(resuoulr.Operand, replacement);
                    if (resuoulr.Operand.Length == 0)
                    {
                        resuoulr.Operand = "0";
                    }
                    return resuoulr;

                    //StringArithmetics qq1 = 10.ToStringArithmetics() ^ (2 * k).ToStringArithmetics() * prod2;
                    //StringArithmetics asdf = prod1 - prod2 - prod3;
                    //StringArithmetics qq2 = (10^ k).ToStringArithmetics() * (asdf);
                    //StringArithmetics qq3 = prod3;
                    //return qq1 + qq2 + qq3;
                }
                return new StringArithmetics("0");
            }
            return new StringArithmetics("0");
        }

        public static StringArithmetics operator ^(StringArithmetics a, Object n)
        {
            if (n is int)
            {
                StringArithmetics b = (Convert.ToInt32(n)).ToStringArithmetics();
                return a - b;
            }
            if (n is StringArithmetics)
            {
                StringArithmetics b = n as StringArithmetics;
                StringArithmetics Power = new StringArithmetics(a.Operand);
                for (int i = 1; i.ToStringArithmetics() < b; i++)
                {
                    Power = Power * a;
                }
                return Power;
            }
            return new StringArithmetics("0");
        }

        public static CatRest operator /(StringArithmetics a, Object n)
        {
            if (n is int)
            {
                StringArithmetics b = (Convert.ToInt32(n)).ToStringArithmetics();
                return a / b;
            }
            if (n is StringArithmetics)
            {
                StringArithmetics b = n as StringArithmetics;
                if (a == 0)
                {
                    return new CatRest("0", "0");
                }

                if (b == 1)
                {
                    return new CatRest(a.Operand, "0");
                }

                if (b < 0)
                {
                    CatRest catRest = a / -b;
                    return new CatRest((-catRest.Cat).Operand, catRest.Rest.Operand);
                }

                if (a < 0)
                {

                    CatRest catRest = -a / b;
                    StringArithmetics q = -catRest.Cat - 1.ToStringArithmetics();
                    if (catRest.Rest > 0)
                        return new CatRest((-catRest.Cat - 1.ToStringArithmetics()).Operand, (b - catRest.Rest).Operand);
                    return new CatRest((-catRest.Cat).Operand, "0");
                }

                int LengthA = a.Operand.Length;
                int LengthB = b.Operand.Length;

                if (LengthA < LengthB)
                    return new CatRest("0", a.Operand);

                if (a <= b * 10)
                {
                    for (int q = 0; q <= 9; q++)
                    {
                        if (a < b * q + b)
                        {
                            CatRest catRest = new CatRest(q.ToString(), (a - b * q.ToStringArithmetics()).Operand);
                            return catRest;
                        }
                    }
                }



                if (LengthA > LengthB)
                {
                    List<StringArithmetics> list = new List<StringArithmetics>();

                    //a.Operand = a.Operand.PadRight(a.Operand.Length + (b.Operand.Length -(a.Operand.Length % b.Operand.Length)), '0');
                    //LengthA = a.Operand.Length;

                    int startindex = 0;
                    int length = 1;



                    while (startindex + length <= LengthA)
                    {
                        list.Add(new StringArithmetics(a.Operand.Substring(startindex, length)));
                        startindex += length;
                    }

                    CatRest catRest = new CatRest();

                    foreach (StringArithmetics val in list)
                    {
                        StringArithmetics pow = 10.ToStringArithmetics() ^ val.Operand.Length.ToStringArithmetics();
                        CatRest aux = (val + (pow * catRest.Rest)) / b;
                        catRest.Cat = catRest.Cat * pow + aux.Cat;
                        catRest.Rest = aux.Rest;
                    }

                    return catRest;


                    //StringArithmetics q = Floor(a, b);
                    //return new CatRest(q.Operand, (a - q * b).Operand);

                    //List<StringArithmetics> y = new List<StringArithmetics>();
                    //StringArithmetics l = ((10.ToStringArithmetics() ^ B)/ b).Cat;
                    //StringArithmetics l2 = Floor(10.ToStringArithmetics() ^ A, a);

                    //if (2.ToStringArithmetics() * (10.ToStringArithmetics() ^ B) <= b * (1.ToStringArithmetics() + 2.ToStringArithmetics() * l))
                    //    y.Add((10.ToStringArithmetics() ^ (A - B)) * l);
                    //else
                    //    y.Add((10.ToStringArithmetics() ^ (A - B)) * (l + 1.ToStringArithmetics()));

                    //while (true)
                    //{
                    //    StringArithmetics f1 = Floor(y[y.Count - 1] ^ 2.ToStringArithmetics(), 10.ToStringArithmetics() ^ (A - B));
                    //    StringArithmetics f2 = Floor(b * f1, 10.ToStringArithmetics() ^ B);

                    //    y.Add(2.ToStringArithmetics() * y[y.Count - 1] - f2);

                    //    if (y[y.Count - 1] <= y[y.Count - 2])
                    //    {
                    //        break;
                    //    }
                    //}

                    //foreach (StringArithmetics val in y)
                    //{
                    //    if (Floor(a * b, 10.ToStringArithmetics() ^ (A - B)) == Floor(val * b, 10.ToStringArithmetics() ^ (A - B)))
                    //    {
                    //        StringArithmetics t = Floor(val * l, 10.ToStringArithmetics() ^ (A - B));
                    //        return new CatRest(t.Operand, (a - b * t).Operand);
                    //    }
                    //}

                }
                return new CatRest("0", "0"); ;
            }
            return new CatRest("0", "0"); ;
        }

        public static StringArithmetics Sqrt(StringArithmetics a)
        {

            if(a ==0 || a == 1)
            {
                return new StringArithmetics(a.Operand);
            }

            double da = Convert.ToInt32(a.Operand);
            double l = Math.Floor(Math.Log(da, 10));
            List<double> y = new List<double>();

            y.Add(Math.Pow(2, Math.Ceiling(a.Operand.Length / l)));

            int i = 0;

            do
            {
                y.Add(Math.Floor((1 / l) * ((l - 1) * y[i] + Math.Floor(da / Math.Pow(y[i],(l - 1))))));
                i++;
            } while (y[i] < y[i - 1]) ;

            double check = Math.Floor(Math.Pow(da, 1 / l));

            int j = 1;
            while(true)
            {
                if(y[i-1]*j==check)
                {
                    return new StringArithmetics(j.ToString());
                }
                j++;
            };

        }

    }
}
