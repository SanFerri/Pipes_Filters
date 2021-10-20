using TwitterUCU;
using System;
using CompAndDel.Pipes;

namespace CompAndDel.Filters
{
    public class FilterTwitter : IFilter
    {
        public IPicture Filter(IPicture image)
        {
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("Imagen previa al filtro", @"luke.jpg"));
            for(int i = 0; i < FilterSavePicture.number; i++)
            {
                Console.WriteLine(twitter.PublishToTwitter($"Imagen del filtro N°{i + 1}", @$"../Program/Proceso/luke{i}.jpg"));
            }   
            return image;
        }
    }
}