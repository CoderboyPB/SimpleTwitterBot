using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TweetSharp;

namespace TwitterBot
{
    class TwitterFacade
    {
        private TwitterService _twitterService;
        private ISender _sender;
        public TwitterFacade()
        {
            string apiKey = Preferences.Instance.ApiKey;
            string apiSecretKey = Preferences.Instance.ApiSecretKey;
            string accessToken = Preferences.Instance.AccessToken;
            string accessTokenSecret = Preferences.Instance.AccessSecretToken;

            var twitterService = new TwitterService(apiKey, apiSecretKey, accessToken, accessTokenSecret);
            _twitterService = twitterService;

            var factory = new SenderFactory();
            _sender = factory.createSender();
        }
        public void Send(string message)
        {
            _sender.Send(message, _twitterService);
        }
    }
}
