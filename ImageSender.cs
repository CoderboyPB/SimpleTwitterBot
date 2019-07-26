using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TweetSharp;

namespace TwitterBot
{
    class ImageSender : ISender
    {
        private HttpStatusCode _status = HttpStatusCode.OK;

        public void Send(string Message, TwitterService ts)
        {
            string randomPicture = Helpers.GetRandomPicture();

            using(var stream = new CustomFileStream(randomPicture, FileMode.Open,5000,5000))
            {
                var tweet = new SendTweetWithMediaOptions
                {
                    Status = Message,
                    Images = new Dictionary<string, Stream>
                        {
                            { "Gundel", stream }
                        }
                };

                try
                {
                    ts.SendTweetWithMedia(tweet); 
                }
                catch(FileNotFoundException)
                { }
            }

            Helpers.Log(Message,_status);
        }
    }
}
