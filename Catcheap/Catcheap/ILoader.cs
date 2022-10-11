using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcheap
{
    public interface ILoader<in T>
    {

        public void Load(T t, String fileName);

    }
}
