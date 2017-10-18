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
        public class Globals
        {
            public int X;
            public int Y;
            public Task<int> ZS;
        }

        public async Task RunAsync()
        {
            var globals = new Globals { X = 1, Y = 2, ZS=Task.FromResult(3) };

            var val = await RunScriptAsync(globals);
        }

        public async Task<object> EvaluateAsync(Globals globals)
        {
            return await CSharpScript.EvaluateAsync<object>("X+Y", globals: globals);
        }

        public async Task<object> RunScriptAsync(Globals globals)
        {
            // bot 
            // Data = new {};
            // Services = new {};

            //var options = ScriptOptions.Default.WithFilePath();
            var script = CSharpScript.Create<object>("X*Y*(await ZS)", globalsType: typeof(Globals));
            script.Compile();

            var del = script.CreateDelegate();            

            return (await script.RunAsync(globals)).ReturnValue;
        }


    }
}