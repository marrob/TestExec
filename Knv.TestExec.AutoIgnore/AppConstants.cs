namespace Knv.TestExec.AutoIgnore
{
    using System;
    public class AppConstants
    {
        public const string SoftwareCustomer = "AltonTech";
        public const string ValueNotAvailable2 = "n/a";
        public const string InvalidFlieNameChar = "A file name can't contain any of flowing characters:";
        public const string WindowsServiceName = "AutoIgnorService";
        public const string GenericTimestampFormat = "yyyy.MM.dd HH:mm:ss";
        public const string FileNameTimestampFormat = "yyMMdd_HHmmss";
        public const string NewLine = "\r\n";
        public static string LogDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    }
}

