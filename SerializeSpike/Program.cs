using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SerializeSpike
{

    public class Context
    {
        public string ActivityId { get; set; }
    }
    [DataContract]
    public class Message
    {
        public Message(int id, string name)
        {
            Id = id;
            Name = name;
        }
        [DataMember]
        public int Id { get; private set; }
        [DataMember]
        public string Name { get; private set; }

        public int Age { get; set; }
        [DataMember]
        public Context Context { get; set; }
        [DataMember]
        public IList Books { get; set; }

    }


    class Program
    {
        static void Main(string[] args)
        {
            var message = new Message(1, "ushio");
            message.Age = 47;
            message.Context = new Context()
            {
                ActivityId = "abc"
            };
            message.Books = new List<string>()
            {
                "foo", "bar"
            };

            // No parameter
            var messageJson = JsonConvert.SerializeObject(message);
            Console.WriteLine("---- normal");
            Console.WriteLine(messageJson);
            var messageJsonWithObjects = JsonConvert.SerializeObject(message, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects
            });
            Console.WriteLine("---- Object");
            Console.WriteLine(messageJsonWithObjects);
            var messageJsonWithArrays = JsonConvert.SerializeObject(message, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Arrays
            });
            Console.WriteLine("---- Array");
            Console.WriteLine(messageJsonWithArrays);
            var messageJsonWithAll = JsonConvert.SerializeObject(message, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            });
            Console.WriteLine("---- All");
            Console.WriteLine(messageJsonWithAll);
            var messageJsonWithAuto = JsonConvert.SerializeObject(message, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            Console.WriteLine("---- Auto");
            Console.WriteLine(messageJsonWithAuto);
            Console.ReadLine();

        }
    }
}
