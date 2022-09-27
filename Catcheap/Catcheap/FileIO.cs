using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcheap
{
    internal class FileIO
    {
        public void WirteTextToFile(string text, string targetFileName)
        {
            string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), targetFileName);

            File.WriteAllText(_fileName, text);
        }

        public string ReadTextFile(string targetFileName)
        {
            string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), targetFileName);

            return File.ReadAllText(_fileName);
        }

    }
}
