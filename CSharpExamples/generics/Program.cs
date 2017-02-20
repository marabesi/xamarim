using System;

namespace ConsoleApplication.Generics
{
    // Definição de uma classe "normal", sem ser genérica
    class Base { }

    // Definição de uma classe genérica
    class BaseGenerica<T> { }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Não é possível especificar qual será o tipo de dado a ser manipulado
            Base base1 = new Base();

            // Com classes genéricas é possível especificar qual tipo de dado será manipulado
            BaseGenerica<int> baseGenericaInt = new BaseGenerica<int>();
            BaseGenerica<string> baseGenericaString = new BaseGenerica<string>();
        }
    }
}
