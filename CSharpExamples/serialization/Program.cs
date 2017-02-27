using System;
using System.Xml.Serialization;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
             Book overview = new Book();
            overview.title = "Serializando meu objeto";
            
            XmlSerializer writer = new XmlSerializer(typeof(Book));

            var path = "./ObjetoSerializado.xml";
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, overview);

            /*
             * Geralmente o método CLose é invocado para finalizar
             * a manipulação do stream, mas em ambientes híbridos onde
             * é possível utilizar o dotnet core como MAC OS ou Linux
             * o método a ser invocado é o Dispose
             */
            file.Dispose();
        }
    }
}
