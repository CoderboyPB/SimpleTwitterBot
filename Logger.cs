using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace TwitterBot
{
    class Logger
    {
        private string _type;
        private string _logFilePath;

        public Logger()
        {
            _logFilePath = Preferences.Instance.LogFilePath;

            if (!String.IsNullOrEmpty(Preferences.Instance.PhotoPath))
                _type = "PIC";
            else
                _type = "TXT";
        }

        public void Log(HttpStatusCode status, string Message)
        {
            string st;

            if (status == HttpStatusCode.OK)
                st = "OK";
            else
                st = "Error";

            using (var sw = new StreamWriter(new FileStream(_logFilePath, FileMode.Append)))
            {
                string text = $"{DateTime.Now.ToString("g")} --- {_type} --- {Message} --- {st}";
                sw.WriteLine(text);
            }
        }
    }
}
