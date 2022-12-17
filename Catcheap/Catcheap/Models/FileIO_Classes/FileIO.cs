namespace Catcheap.Models.FileIO_Classes
{
    public class FileIO
    {
        public FileIO ()
        {
        }
        public static void WriteTextToFile(string text, string targetFileName)
        {
            string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), targetFileName);

            try
            {
                File.WriteAllText(_fileName, text);
            }
            catch (Exception)
            {

            }

        }

        public static void UpdateTextFile(string text, string targetFileName)
        {
            string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), targetFileName);

            try
            {
                File.AppendAllText(_fileName, text);
            }
            catch (Exception)
            {

            }

        }

        public static string ReadTextFile(string targetFileName)
        {
            string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), targetFileName);

            try
            {
                if (File.Exists(_fileName))
                    return File.ReadAllText(_fileName);
                else
                    return null;
            }
            catch
            {
                return null;
            }
            
        }

        public static string ReadTextFileCustom(string targetFileName)
        {
            string _fileName = Path.Combine(FileSystem.AppDataDirectory, targetFileName);

            try
            {
                if (File.Exists(_fileName))
                    return File.ReadAllText(_fileName);
                else
                    return null;
            }
            catch
            {
                return null;
            }
                
        }

        public static void ClearTextFile(string targetFileName)
        {
            string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), targetFileName);

            try
            {
                File.WriteAllText(_fileName, string.Empty);
            }
            catch
            {

            }
        }

    }
}
