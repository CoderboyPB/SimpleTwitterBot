using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace TwitterBot
{
    class Helpers
    {
        public static void Log(string Message, HttpStatusCode status)
        {
            string logFilePath = Preferences.Instance.LogFilePath;
            if (!String.IsNullOrEmpty(logFilePath))
            {
                var logger = new Logger();
                logger.Log(status, Message);
            }
        }

        public static string GetRandomPicture()
        {
            var imageFiles = Directory.GetFiles(Preferences.Instance.PhotoPath)
                            .Where(file => Regex.IsMatch(file, @"^.+\.(gif|jpg|png)$"));
            int anz = imageFiles.Count();
            string randomPicture = imageFiles.ElementAt(new Random(DateTime.Now.Millisecond).Next(anz));
            return randomPicture;
        }
    }
}
