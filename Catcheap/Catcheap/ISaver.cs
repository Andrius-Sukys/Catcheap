using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcheap
{
    public interface ISaver<in T>
    {

        public void Save(T t, String fileName);

    }
}
