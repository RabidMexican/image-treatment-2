using System;

namespace image_modification.controllers
{
    class EdgeDetectionController : IEdgeDetectionController
    {
        public ImageModel EdgeDet1(ImageModel image)
        {
            Console.WriteLine("\n\tPERFORMING DETECTION 1");
            return image;
        }

        public ImageModel EdgeDet2(ImageModel image)
        {
            Console.WriteLine("\n\tPERFORMING DETECTION 2");
            return image;
        }

        public ImageModel EdgeDet3(ImageModel image)
        {
            Console.WriteLine("\n\tPERFORMING DETECTION 3");
            return image;
        }
    }
}
