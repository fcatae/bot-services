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
        Scripter _scripter;

        public HelloWorldContext(Messenger messenger)
        {
            this._messenger = messenger;
            this._scripter = new Scripter();
        }

        public async Task RunAsync()
        {
            // await _scripter.RunAsync();

            while (true)
            {
                //await _scripter.LoadAsync(_messenger);

                string message = await _messenger.WaitReceiveAsync().ConfigureAwait(false);

                _messenger.Send(message);
            }
        }
    }
}