using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySerializationConsole
{
    [MessagePackObject]
    public class SerializationObject
    {
        public SerializationObject()
        {
        }

        public SerializationObject(
            int integerCount = 10, 
            int stringCount = 10, 
            int stringLength = 100, 
            int dataSizeBytes = megabyte)
        {
            for (int i = 0; i < integerCount; i++) this.Integers.Add(_random.Next(1, 100));
            for (int s = 0; s < stringCount; s++) this.Strings.Add(_generateRandomString(stringLength));
            this.Data = new byte[dataSizeBytes];
            _random.NextBytes(this.Data);
        }

        [Key(0)]
        public List<int> Integers { get; set; } = new List<int>();

        [Key(1)]
        public List<string> Strings { get; set; } = new List<string>();

        [Key(2)]
        public byte[] Data { get; set; }


        private const int kilobyte = 1024;
        private const int megabyte = 1024 * kilobyte;

        private static Random _random = new Random();
        private static string _generateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
