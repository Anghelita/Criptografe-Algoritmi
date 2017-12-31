using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Large_Number_Operations
{
    class CatRest
    {
        public StringArithmetics Cat;
        public StringArithmetics Rest;

        public CatRest()
        {
            Cat = new StringArithmetics("0");
            Rest = new StringArithmetics("0");
        }
        public CatRest(String Cat, String Rest)
        {
            this.Cat = new StringArithmetics(Cat);
            this.Rest = new StringArithmetics(Rest);
        }

    }
}
