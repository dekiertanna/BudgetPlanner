using Ciamajda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciamajda
{
    public class DateTimeComparator : IComparer<Flow>
    {
        
        public int Compare(Flow x, Flow y)
        {
           if (x.Time>y.Time)
            {
                return -1;
            }
           else
            {
                if (x.Time == y.Time)
                {
                    return 0;

                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
