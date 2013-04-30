using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TweetSharp;

namespace SquashLegaue.BusinessObjects
{
    public class Twitter
    {
        public static void Tweet(string Message)
        {
            TwitterService service = new TwitterService("AI8ldp9ZOc4QiwHcyRlXA", "jL8DYwQWN7UvTAQ4xcAjmvKnu7kjAfAZBDQ6mwv0raE");
            service.AuthenticateWith("1391429892-B8PSekvDJm2cQ6DJ42tLAILORHZaiXwm7R4kOB5", "q8WJT6oP5SVo6MFFZ29zfcUcnTbyOWaOe4I7kmse0ZM");
            service.SendTweet(new SendTweetOptions(){Status=Message});
        }
    }
}