using System;
using Newtonsoft.Json;

namespace Pack_Light
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(JsonConvert.SerializeObject(OptionsParser.Parse(args)));
            OptionsParser.Parse(args);
        }
    }
}
