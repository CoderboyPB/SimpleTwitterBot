using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TweetSharp;

namespace TwitterBot
{
    class TextSender : ISender
    {
        private HttpStatusCode _status;
        public void Send(string Message, TwitterService ts)
        {
            ts.SendTweet(new SendTweetOptions() { Status = Message }, (tweet, response) =>
            {
                _status =  response.StatusCode;
            });

            Helpers.Log(Message, _status);
        }
    }
}
