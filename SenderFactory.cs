using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TwitterBot
{
    class SenderFactory
    {  
        public ISender createSender()
        {
            string photoPath = Preferences.Instance.PhotoPath;

            if (!String.IsNullOrEmpty(photoPath))
            {
                return new ImageSender();
            }
            else
            {
                return new TextSender();
            }
        }
    }
}
