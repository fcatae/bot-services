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
            string code = "while(true) { var message = await Messenger.WaitReceiveAsync(); Messenger.Debug(); }";
            
            await _scripter.RunScriptAsync(code, _messenger).ConfigureAwait(false);

            //while (true)
            //{
            //    string message = await _messenger.WaitReceiveAsync().ConfigureAwait(false);
            //    _messenger.Send(message);
            //}
        }
    }
}