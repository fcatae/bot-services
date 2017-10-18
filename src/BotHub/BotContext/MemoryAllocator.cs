using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotHub.BotContext
{
    public class MemoryAllocator        
    {
        public Memory<T> Alloc<T>() 
            where T : new()
        {
            return new Memory<T>(new T());
        }

        public Memory<T> Load<T>(string value)
        {
            T memoryObject = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value);

            return new Memory<T>(memoryObject);
        }

        public string Save<T>(Memory<T> memory)
        {
            string serializedObject = Newtonsoft.Json.JsonConvert.SerializeObject(memory.Value);

            return serializedObject;
        }

        //public void Free<T>(Memory<T> memory)
        //{
        //    memory.Dispose();
        //}
    }
}