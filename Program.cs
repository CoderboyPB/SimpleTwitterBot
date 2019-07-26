using System;
using System.Net;
using System.Threading.Tasks;
using TweetSharp;

namespace TwitterBot
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Preferences.Instance.Message;
            var twitterFacade = new TwitterFacade();
            twitterFacade.Send(message);
            Console.WriteLine("Send");
            _ = Console.Read();
        }
    }
}
