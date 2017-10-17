using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BotHub.BotContext;
using Microsoft.Bot.Connector;

namespace BotHub.Services
{
    public class BotHubServices
    {
        static Messenger _messenger = null;
        static HelloWorldContext _context = null;

        public static void Route(Activity activity)
        {
            if (_messenger == null)
            {
                _messenger = new Messenger(activity.ServiceUrl);
                _context = new HelloWorldContext(_messenger);
                var loop = _context.RunAsync();
            }
            
            _messenger.Route(activity);
        }

    }
}