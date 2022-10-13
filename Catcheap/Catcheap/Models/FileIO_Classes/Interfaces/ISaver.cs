using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcheap.Models.FileIO_Classes.Interfaces
{
    public interface ISaver<in T>
    {

        public void Save(T t, string fileName);

    }
}
