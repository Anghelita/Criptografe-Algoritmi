using System;
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

        public static StringArithmetics Abs(StringArithmetics a)
        {
            StringArithmetics b = new StringArithmetics(a.Operand);
            if (a.Operand[0].Equals('-'))
            {
                b = new StringArithmetics(a.Operand.Remove(0,1));
            }
            return b;
        }

        public static StringArithmetics Floor(StringArithmetics a , StringArithmetics b)
        {
            int i = 0;
            while(true)
            {
                i++;
                if (i.ToStringArithmetics()*b>a)
                {
                    break;
                }
            }
            return (i-1).ToStringArithmetics();
        }

        public static StringArithmetics Ceiling(StringArithmetics a, StringArithmetics b)
        {
            int i = 0;
            while (true)
            {
                i++;
                if (i.ToStringArithmetics() * b > a)
                {
                    break;
                }
            }
            return i.ToStringArithmetics();
        }

        public static bool operator >(StringArithmetics a, StringArithmetics b)
        {
            if (!(a < b) && !(a == b))
                return true;
            return false;
        }

        public static bool operator <(StringArithmetics a, StringArithmetics b)
        {

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

        public static bool operator ==(StringArithmetics a, StringArithmetics b)
        {
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

        public static bool operator !=(StringArithmetics a, StringArithmetics b)
        {
            if (a == b)
                return false;
            return true;
        }

        public static bool operator >=(StringArithmetics a, StringArithmetics b)
        {
            if (a > b)
                return true;
            if (a == b)
                return true;
            return false;
        }

        public static bool operator <=(StringArithmetics a, StringArithmetics b)
        {
            if (a < b)
                return true;
            if (a == b)
                return true;
            return false;
        }



        public static StringArithmetics operator +(StringArithmetics a, StringArithmetics b)
        {

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

        public static StringArithmetics operator -(StringArithmetics a, StringArithmetics b)
        {
            if (b > a)
            {
                StringArithmetics res = b-a;
                res.Operand =  res.Operand.PadLeft(res.Operand.Length + 1, '-');
                return res;
            }

            if (b.Operand[0].Equals('-'))
            {
                StringArithmetics s = a + Abs(b);
                return s;
            }

            if (a.Operand[0].Equals('-'))
            {
                StringArithmetics s = Abs(a)+ b;
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

        public static StringArithmetics operator *(StringArithmetics a, StringArithmetics b)
        {
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

            if (a == 0.ToStringArithmetics() || b == 0.ToStringArithmetics())
                return new StringArithmetics("0");

            if ((a < 0.ToStringArithmetics() && b> 0.ToStringArithmetics()) ||
                (a> 0.ToStringArithmetics()) && b < 0.ToStringArithmetics())
            {
                StringArithmetics t = Abs(a) * Abs(b);
                t.Operand = t.Operand.PadLeft(t.Operand.Length + 1, '-');
                return t;
            }

            if ( a < 0.ToStringArithmetics() && b < 0.ToStringArithmetics())
            {
                StringArithmetics t = Abs(a) * Abs(b);
                return t;
            }

            if (a < 10.ToStringArithmetics() && b < 10.ToStringArithmetics())
            {
                return (Int32.Parse(a.Operand) * Int32.Parse(b.Operand)).ToStringArithmetics();
            }


            if (a >= "10".ToStringArithmetics() || b >= "10".ToStringArithmetics()) 
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


                StringArithmetics prod1 = (m + n)*(o + p);
                StringArithmetics prod2 = m* o;
                StringArithmetics prod3 = n* p;

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
            return "0".ToStringArithmetics();
        }

        public static StringArithmetics operator ^(StringArithmetics a, StringArithmetics b)
        {
            StringArithmetics Power = new StringArithmetics(a.Operand);
            for (int i = 1; i.ToStringArithmetics() < b; i++)
            {
                Power = Power * a;
            }
            return Power;
        }



    }
}
