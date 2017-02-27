using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var video  = new Video() { Titulo = "Meu filme" };

            // Essa classe é quem dispara o evento
            var encoder = new VideoEncoder();

            // Irá "escutar o evento" e trata-lo enviando uma mensagem
            var tratar = new Mensagem();
            
            encoder.videoEncodado += tratar.OnAcabouDeEncodar;

            // Começa o processo
            encoder.Encodar(video);
        }
    }
}
