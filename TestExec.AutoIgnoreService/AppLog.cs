
namespace TestExec.AutoIgnoreService
{
    using System;
    using System.IO;
    using System.Text;
    using System.Diagnostics;

    public class AppLog
    {
        public static AppLog Instance { get; } = new AppLog();
        public string FilePath { get; set; }
        public bool Enabled;
        public double? GetFileSizeKB
        {
            get
            {
                if (File.Exists(FilePath))
                {
                    FileInfo fi = new FileInfo(FilePath);
                    return fi.Length / 1024;
                }
                else
                    return null;
            }
        }

        public AppLog()
        {
            Enabled = true;
            FilePath =  AppConstants.LogDirectory + "\\" + "AutoIngoreServiceLog.txt";
        }

        public void WriteLine(string line)
        {
            Debug.WriteLine(line);
            try
            {

                if (Enabled)
                {
                    if (!Directory.Exists(Path.GetDirectoryName(FilePath)))
                    {
                        Enabled = false;
                    }
                    else
                    {
                        line = DateTime.Now.ToString(AppConstants.GenericTimestampFormat, System.Globalization.CultureInfo.InvariantCulture) + ";" + line + AppConstants.NewLine;
                        var fileWrite = new StreamWriter(FilePath, true, Encoding.ASCII);
                        fileWrite.NewLine = AppConstants.NewLine;
                        fileWrite.Write(line);
                        fileWrite.Flush();
                        fileWrite.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Enabled = false;
                string msg = "AppLog.cs.WriteLine().Exception:Cannot write to log file, please check the path.\r\n" + ex.Message;
                Debug.WriteLine(msg);
                throw new IOException(msg);
            }
        }
    }
}
