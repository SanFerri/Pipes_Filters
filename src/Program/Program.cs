using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using TwitterUCU;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");


            IFilter greyFilter = new FilterGreyscale();
            IFilter negativeFilter = new FilterNegative();

            
            PipeNull pipe3 = new PipeNull();
            PipeSerial pipe2 = new PipeSerial(negativeFilter, pipe3);
            PipeSerial pipe1 = new PipeSerial(greyFilter, pipe2);

            picture = pipe1.Send(picture);
            provider.SavePicture(picture, @"luke1.jpg");

                
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("Imagen previa al filtro", @"luke.jpg"));
            for(int i = 0; i < FilterSavePicture.number; i++)
            {
                Console.WriteLine(twitter.PublishToTwitter($"Imagen del filtro N°{i + 1}", @$"../Program/Proceso/luke{i}.jpg"));
            }
        }
    }
}
