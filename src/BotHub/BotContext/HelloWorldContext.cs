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
            //string code = "while(true) { var message = await Messenger.WaitReceiveAsync(); Messenger.Debug(); }";
            //string code = "async System.Threading.Tasks.Task R() { while(true) { var message = await Messenger.WaitReceiveAsync(); Messenger.Debug(); } } Messenger.Debug1(); throw new System.Exception(); Messenger.Debug2();";
            string code = "int f(int a) { return a+1 ; } \n return f(1); \n return f(2); \n return f(3); \n";

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