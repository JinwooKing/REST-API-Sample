using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;

namespace net_framework_sample.Common
{
    public class ConfigEx
    {
        public static readonly string currentPath = HttpContext.Current.Server.MapPath("/");
        public static readonly string iniFilePath = Path.Combine(currentPath, "ConfigEx.ini");
        public static string CONNECTIONSTRING = "";

        private static StringBuilder SERVER = new StringBuilder();
        private static StringBuilder DATABASE = new StringBuilder();
        private static StringBuilder UID = new StringBuilder();
        private static StringBuilder PWD = new StringBuilder();

        public static void ConstsInit()
        {
            if (!File.Exists(iniFilePath))
                File.Create(iniFilePath);

            //WritePrivateProfileString("SQL", "server", "", iniFilePath);
            //WritePrivateProfileString("SQL", "database", "", iniFilePath);
            //WritePrivateProfileString("SQL", "uid", "", iniFilePath);
            //WritePrivateProfileString("SQL", "pwd", "", iniFilePath);

            GetPrivateProfileString("SQL", "server", "", SERVER, 32, iniFilePath);
            GetPrivateProfileString("SQL", "database", "", DATABASE, 32, iniFilePath);
            GetPrivateProfileString("SQL", "uid", "", UID, 32, iniFilePath);
            GetPrivateProfileString("SQL", "pwd", "", PWD, 32, iniFilePath);

            CONNECTIONSTRING = $"server={SERVER};database={DATABASE};uid={UID};pwd={PWD}";
        }


    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
    }
}