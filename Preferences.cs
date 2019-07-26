using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace TwitterBot
{
    sealed class Preferences
    {
        static private Preferences _instance;

        public static Preferences Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                else
                {
                    _instance = new Preferences();
                    return _instance;
                }      
            }
        }

        public string ApiKey { get; set; }
        public string ApiSecretKey { get; set; }
        public string AccessToken { get; set; }
        public string AccessSecretToken { get; set; }
        public string Message { get; set; }
        public string LogFilePath { get; set; }
        public string PhotoPath { get; set; }

        private Preferences()
        {
            using (var sr = new StreamReader("twitter.config"))
            {
                ApiKey = sr.ReadLine().Split('=')[1];
                ApiSecretKey = sr.ReadLine().Split('=')[1];
                AccessToken = sr.ReadLine().Split('=')[1];
                AccessSecretToken = sr.ReadLine().Split('=')[1];
                Message = sr.ReadLine().Split('=')[1];

                string currentPath = Directory.GetCurrentDirectory();

                if (!sr.EndOfStream)
                {
                    PhotoPath = sr.ReadLine().Split('=')[1];
                    PhotoPath = Path.Combine(currentPath, PhotoPath);                
                }

                if (!sr.EndOfStream)
                {
                    LogFilePath = sr.ReadLine().Split('=')[1];
                    LogFilePath = Path.Combine(currentPath, LogFilePath);
                } 
            }             
        }
    }
}
