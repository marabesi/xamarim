using System;

namespace ConsoleApplication
{
    public class Dynamic
    {
        public static void Main(string[] args)
        {
             dynamic teste = "Object";
            teste += 1;

            Console.WriteLine(teste); // O resultado será "Object1"
        }
    }
}

