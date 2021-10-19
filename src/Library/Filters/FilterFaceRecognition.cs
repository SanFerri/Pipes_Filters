using System;
using  CognitiveCoreUCU;
using CompAndDel.Pipes;

namespace CompAndDel.Filters
{
    public class FilterFaceRecognition : IFilter
    {

        public IPicture Filter(IPicture image)
        {
            CognitiveFace cog = new CognitiveFace(true);
            cog.Recognize(FilterSavePicture.path);
            FoundFace(cog);
            return image;
        }
        static void FoundFace(CognitiveFace cog)
        {
        if (cog.FaceFound)
        {
            Console.WriteLine("Face Found!");
            if (cog.SmileFound)
            {
                Console.WriteLine("Found a Smile :)");
            }
            else
            {
                Console.WriteLine("No smile found :(");
            }
        }
        else
        {
            Console.WriteLine("No Face Found");
        }
        }
    }
}