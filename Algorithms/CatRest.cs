using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class CatRest
    {
        long cat;
        long rest;

        public CatRest(long cat, long rest)
        {
            this.Cat = cat;
            this.Rest = rest;
        }

        public long Cat { get => cat; set => cat = value; }
        public long Rest { get => rest; set => rest = value; }
    }
}
