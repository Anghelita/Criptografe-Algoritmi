using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    static class StringExtension
    {
        public static StringArithmetics ToStringArithmetics(this String str)
        {
            return new StringArithmetics(str);
        }

        public static StringArithmetics ToStringArithmetics(this int str)
        {
            return new StringArithmetics(str.ToString());
        }

        public static StringArithmetics ToStringArithmetics(this long str)
        {
            return new StringArithmetics(str.ToString());
        }
    }
}
