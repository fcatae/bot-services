using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BotHub.BotContext
{
    public class HelloWorldContext
    {
        private readonly Messenger _messenger;

        public HelloWorldContext(Messenger messenger)
        {
            this._messenger = messenger;
        }

        public async Task RunAsync()
        {
            while(true)
            {
                string message = await _messenger.WaitReceiveAsync();

                _messenger.Send(message);
            }
        }
    }
}