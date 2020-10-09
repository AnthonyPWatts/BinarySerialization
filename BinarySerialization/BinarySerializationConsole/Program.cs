using MessagePack;
using System;
using System.Collections.Generic;
using System.IO;

namespace BinarySerializationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var objectsToSerialize = new List<SerializationObject>();
            var deserializedObjects = new List<SerializationObject>();
            var serializedObjects = new List<byte[]>();

            Console.WriteLine($"{DateTime.Now:mm.ss.fff}: Generating Objects");
            for (int i = 0; i < 3000000; i++)
            {
                objectsToSerialize.Add(new SerializationObject());
            }

            Console.WriteLine($"{DateTime.Now:mm.ss.fff}: Serializing Objects");
            foreach (var source in objectsToSerialize)
            {
                serializedObjects.Add(MessagePackSerializer.Serialize(source));
            }

            Console.WriteLine($"{DateTime.Now:mm.ss.fff}: Deserializing Objects");
            foreach (var serializedObject in serializedObjects)
            {
                deserializedObjects.Add(MessagePackSerializer.Deserialize<SerializationObject>(serializedObject));

            }

            Console.WriteLine($"{DateTime.Now:mm.ss.fff}: Finished.");
            Console.ReadKey();
        }
    }
}
