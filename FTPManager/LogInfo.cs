using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPManager
{
    public class LogInfo
    {
        public enum LogType
        {
            Info,
            Warning,
            Error
        }
        public static string GenerateInfo(string content, int type)
        {
            var text = "";
            string[] logType = new string[] { "Info   ", "Warning", "Error   " };
            string time = DateTime.Now.ToUniversalTime().ToString();
            text += "[" + time + "]:" + logType[type] + "->" + content + "\n";
            return text;
        }
    }
}
