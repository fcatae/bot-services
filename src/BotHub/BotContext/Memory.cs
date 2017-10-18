using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotHub.BotContext
{
    public class Memory<T> : IDisposable
    {
        public T Value { get; set; }

        public Memory(T value)
        {
            this.Value = value;
        }

        public void Dispose()
        {
            this.Value = default(T);
        }
    }
}