using System;

namespace ConsoleApplication.Struct
{
    public struct Livro
    {
        public string titulo;
        public string autor;
        public int anoPublicacao;
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Livro csharp;
            csharp.titulo = "Csharp";
            csharp.autor = "Desconhecido";
            csharp.anoPublicacao = 2017;

            Console.WriteLine(csharp.autor);
            Console.WriteLine(csharp.titulo);
        }
    }
}
