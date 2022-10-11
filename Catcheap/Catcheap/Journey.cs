using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcheap
{
    public struct Journey : IComparable<Journey>
    {
        public DateTime Date { get; set; }
        public int Dist { get; set; }

        public int CompareTo(Journey other)
        {
            return Date.CompareTo(other.Date);
        }
    }
}
