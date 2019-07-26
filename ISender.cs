using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TweetSharp;
namespace TwitterBot
{
    interface ISender
    {
        void Send(string Message, TwitterService ts);
    }
}
