using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using System.Threading;

namespace BotHub.BotContext
{
    public class Scripter
    {
        public Task<object> CreateTask(string textCode, Messenger messenger)
        {
            return CreateTask(textCode, new ScripterGlobals { Messenger = messenger });
        }

        public async Task<object> CreateTask(string textCode, ScripterGlobals globals)
        {
            object returnValue = null;

            try
            {
                var script = CSharpScript.Create(textCode, globalsType: typeof(ScripterGlobals));
                //script.Compile();
                //script.CreateDelegate();

                ScriptState state = await script.RunAsync(globals, catchException: ex => true).ConfigureAwait(false); ;

                returnValue = state.ReturnValue;

                var state2 = await script.RunFromAsync(state, catchException: ex => true).ConfigureAwait(false); ;
            }
            catch(Exception ex)
            {
                returnValue = ex;
            }

            return returnValue;
        }

        public void Run(Task task)
        {
            var entryPoint = new ThreadStart(task.RunSynchronously);
            Thread thread = new Thread(entryPoint);
        }
        
    }
}