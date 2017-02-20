using System;

namespace ConsoleApplication
{
    public class Program
    {
        public int sum(out int a, out int b)
        {
            a = 10;
            b = 10;

            return a + b;
        }

        public static void Main(string[] args)
        {
            Program exec = new Program();

            // Declara a variável mas não a inicializa
            int a;
            int b;

            // realiza a soma
            Console.Write(exec.sum(out a, out b));

            /*
             * Como passamos por referência cada uma das variáveis 
             * possuem o valor 10
             */ 
            Console.Write(a);
            Console.Write(b);
        }
    }
}
