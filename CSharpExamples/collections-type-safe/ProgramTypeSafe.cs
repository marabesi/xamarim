using System;
using System.Collections.Generic;

namespace ConsoleApplication.CollectionsTypeSafe.Generic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> integers = new List<int>();
            integers.Add(1);
            integers.Add(2);
            // integers.Add("3"); não é mais possível utilizar pois a lista só aceita inteiros

            for (int i = 0; i < integers.Count; ++i) {
                int integer = (int)integers[i];
            }
        }
    }
}
