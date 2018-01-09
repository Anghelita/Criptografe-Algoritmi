using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Crypt
{
    class Crypt
    {
        public static String CaesarCrypt(String msg, int shift)
        {
            if (shift / 255 > 1)
                shift = shift % 255;

            String s = "";
            int len = msg.Length;
            for (int x = 0; x < len; x++)
            {
                char c = (char)((msg[x] + shift) % 255);
                s += c;
            }
            return s;

        }

        public static String CaesarDeCrypt(String msg, int shift)
        {
            if (shift / 255 > 1)
                shift = shift % 255;

            String s = "";
            int len = msg.Length;
            for (int x = 0; x < len; x++)
            {
                int poz = msg[x] - shift;
                if (poz < 0)
                    poz = 255 + poz;
                char c = (char)(poz);
                s += c;
            }
            return s;

        }

    }
}
