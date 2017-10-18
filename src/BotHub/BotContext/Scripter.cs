using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace BotHub.BotContext
{
    public class Scripter
    {
        public Task<object> RunScriptAsync(string textCode, Messenger messenger)
        {
            return RunScriptAsync(textCode, new ScripterGlobals { Messenger = messenger });
        }

        public async Task<object> RunScriptAsync(string textCode, ScripterGlobals globals)
        {
            object returnValue = null;

            try
            {
                var script = CSharpScript.Create(textCode, globalsType: typeof(ScripterGlobals));
                //script.Compile();
                //script.CreateDelegate();

                ScriptState state = await script.RunAsync(globals, catchException: ex => true).ConfigureAwait(false); ;

                returnValue = state.ReturnValue;
            }
            catch(Exception ex)
            {
                returnValue = ex;
            }

            return returnValue;
        }


    }
}