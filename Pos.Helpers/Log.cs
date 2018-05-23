using Jil;
using System;
using System.IO;
using System.Web;


namespace Pos.Helpers
{
    public static class Log
    {
        /// <summary>
        /// Log untuk data yang akan di submit 
        /// </summary>
        /// <param name="model"></param>
        public static void Write(object model)
        {
            var user = HttpContext.Current.User.Identity.Name;
            using (var json = new StringWriter())
            {
                JSON.Serialize(
                   model,
                    json,
                    Options.ISO8601ExcludeNullsJSONPIncludeInheritedUtcCamelCase
                );
                StreamWriter log;
                FileStream fileStream = null;
                DirectoryInfo logDirInfo = null;
                FileInfo logFileInfo;

                string dirProject = System.AppDomain.CurrentDomain.BaseDirectory;
                string logFilePath = dirProject + "Log\\";
                logFilePath = logFilePath + user + "_" + "Object" + "_" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss tt") + "." + "txt";
                logFileInfo = new FileInfo(logFilePath);
                logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create();
                if (!logFileInfo.Exists)
                {
                    fileStream = logFileInfo.Create();
                }
                else
                {
                    fileStream = new FileStream(logFilePath, FileMode.Append);
                }
                log = new StreamWriter(fileStream);
                log.Write(json.ToString());
                log.Close();
            }
            
        }
        /// <summary>
        /// Log untuk Error / Exception
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <param name="msg"></param>
        public static void Write(string controller, string action, string msg)
        {

            var user = HttpContext.Current.User.Identity.Name;

            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;

            string dirProject = System.AppDomain.CurrentDomain.BaseDirectory;
            string logFilePath = dirProject + "ErrorLog\\";
            logFilePath = logFilePath + user + "_" + controller + "_" + action + "_" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss tt") + "." + "txt";
            logFileInfo = new FileInfo(logFilePath);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }
            log = new StreamWriter(fileStream);
            log.WriteLine("Error On Controller : " + controller);
            log.WriteLine("Error On Action : " + action);
            log.WriteLine("Error Message : " + msg);
            log.Close();
        }

    }
}
