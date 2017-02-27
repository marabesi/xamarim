using System;

namespace ConsoleApplication
{
    public class VideoEncoder
    {

        // Define o delegate para gerenciar o evento
        public delegate void VideoEncodado(object sender, EventArgs args);
        
        // Cria o evento para ser desparado 
        public event VideoEncodado videoEncodado;

        // Começa o processo
        public void Encodar(Video video)
        {
            System.Console.WriteLine("Encodando video " + video.Titulo + " ...");
            OnAcabouDeEncodar();
        }

        protected virtual void OnAcabouDeEncodar()
        {
            if (videoEncodado != null)
            {
                videoEncodado(this, EventArgs.Empty);
            }
        }
    }
}
