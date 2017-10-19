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
            string code = "while(true) { var message = Messenger.WaitReceiveAsync().Result; Messenger.Send(message); }";
            
            var task = _scripter.CreateTask(code, _messenger);
            _scripter.Run(task);
                        
            //while (true)
            //{
            //    string message = await _messenger.WaitReceiveAsync().ConfigureAwait(false);
            //    _messenger.Send(message);
            //}
        }
    }
}