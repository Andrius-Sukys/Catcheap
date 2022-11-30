using Catcheap.Views;

namespace Catcheap.Models.Exception_Classes;

public static class ExceptionLogger
{
    static readonly string absolutePath = Android.App.Application.Context.GetExternalFilesDir("").AbsolutePath;
    static readonly string logPath = Path.Combine(absolutePath, "ErrorLog.txt");

    public static async Task LogException(Exception ex)
    {
        if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            using var streamWriter = new StreamWriter(logPath, true);

            string message = "[TIME] " + DateTime.Now + "\n";
            message += "[EXCEPTION] " + ex.ToString() + "\n\n";

            await streamWriter.WriteLineAsync(message);
        }
        else
        {
            System.Diagnostics.Debug.WriteLine(File.ReadAllText(logPath));
            return;
        }
        

        
    }
}
