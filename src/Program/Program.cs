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
            PictureProvider provider2 = new PictureProvider();
            provider2.SavePicture(picture, @"luke1.jpg");

            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("text", @"PathToImage.png"));
        }
    }
}
