using System;
using System.Collections;

namespace ConsoleApplication.CollectionsTypeSafe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var integers = new ArrayList();
            integers.Add(1);
            integers.Add(2);
            integers.Add("3"); // um erro ocorrerá em tempo de execução

            for (int i = 0; i < integers.Count; ++i) {
                int integer = (int)integers[i];
            }
        }
    }
}
