using System;

namespace ConsoleApplication.In
{
    public class Program
    {
        public int sum(ref int a, ref int b)
        {
            /*
             * Não precisamos mais inicializar a variável dentro
             * do método, pois ref garante uma variável inicializada
             *
             * a = 10;
             * b = 10;
             */
            return a + b;
        }

        public static void Main(string[] args)
        {
            Program exec = new Program();

            /*
             * Declara a variável e inicializa, ao contrário do out
             * ao utilizar ref é obrigatória a inicialização da variável
             */ 
            int a = 0;
            int b = 0;

            // realiza a soma
            Console.Write(exec.sum(ref a, ref b));

            /*
             * Como passamos por referência cada uma das variáveis 
             * possuem o valor 10
             */ 
            Console.Write(a);
            Console.Write(b);
        }
    }
}
