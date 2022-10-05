using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcheap
{
    internal class FileIO
    {
        public void WriteTextToFile(string text, string targetFileName)
        {
            string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), targetFileName);
            
            File.WriteAllText(_fileName, text);

        }

        public void UpdateTextFile(string text, string targetFileName)
        {
            string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), targetFileName);

            File.AppendAllText(_fileName, text);

        }

        public string ReadTextFile(string targetFileName)
        {
            string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), targetFileName);
           
            if(File.Exists(_fileName))
                return File.ReadAllText(_fileName);
            else 
                return null;
        }

        public string ReadTextFileCustom(string targetFileName)
        {
            string _fileName = Path.Combine(FileSystem.AppDataDirectory, targetFileName);
            if (File.Exists(_fileName))
                return File.ReadAllText(_fileName);
            else
                return null;
        }

        public void ClearTextFile(string targetFileName)
        {
            string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), targetFileName);

            File.WriteAllText(_fileName, String.Empty);
        }

    }
}
