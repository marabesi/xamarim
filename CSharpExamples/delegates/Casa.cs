using System;

namespace ConsoleApplication
{
    
    public class Casa
    {
        public delegate void CortarGrama();

        delegate CortarGrama();

        private static void LimparGrama()
        {
            Console.WriteLine("Cortando grama");
        }

        public static void Main(string[] args)
        {
            CortarGrama invocarDelegate = new CortarGrama(LimparGrama); 
            invocarDelegate();
        }
    }
}
