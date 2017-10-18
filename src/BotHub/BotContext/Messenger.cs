using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Web;
using Microsoft.Bot.Connector;
using System.Threading.Tasks;

namespace BotHub.BotContext
{
    public class Messenger
    {
        private readonly ConnectorClient _botConnector;
        private ConcurrentQueue<Activity> _actitivyQueue;
        private Activity _lastActivity;

        public Messenger(string serviceUrl)
        {
            if (String.IsNullOrEmpty(serviceUrl))
                throw new ArgumentNullException(nameof(serviceUrl));

            this._botConnector = new ConnectorClient(new Uri(serviceUrl));
            this._actitivyQueue = new ConcurrentQueue<Activity>();
            this._lastActivity = null;
        }

        public void Route(Activity activity)
        {
            _actitivyQueue.Enqueue(activity);
        }

        public void Send(string text)
        {
            if (_lastActivity == null)
                throw new InvalidOperationException("Cannot initiate a conversation");

            var reply = _lastActivity.CreateReply(text);

            _botConnector.Conversations.ReplyToActivity(reply);
        }

        public string Receive()
        {
            Activity activity = null;

            _actitivyQueue.TryDequeue(out activity);

            if (activity == null)
            {
                return null;
            }

            // set last activity
            _lastActivity = activity;

            return activity.Text;
        }

        public async Task<string> WaitReceiveAsync()
        {
            string textMessage;

            while ((textMessage = Receive()) == null)
            {
                await Task.Delay(1000);
            }

            return textMessage;
        }
    }
}