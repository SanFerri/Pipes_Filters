namespace CompAndDel.Pipes
{
    public class FilterSavePicture : IFilter
    {
        public static int number = 0;
        public IPicture Filter(IPicture image)
        {
            PictureProvider provider2 = new PictureProvider();
            provider2.SavePicture(image, @$"../Program/Proceso/luke{number}.jpg");
            FilterSavePicture.number += 1;
            return image;
        }
    }
}