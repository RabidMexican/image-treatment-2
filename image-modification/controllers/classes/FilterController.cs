using System;

namespace image_modification.controllers
{
    class FilterController : IFilterController
    {
        public ImageModel Filter1(ImageModel image)
        {
            Console.WriteLine("\n\tPERFORMING FILTER 1");
            return image;
        }

        public ImageModel Filter2(ImageModel image)
        {
            Console.WriteLine("\n\tPERFORMING FILTER 2");
            return image;
        }

        public ImageModel Filter3(ImageModel image)
        {
            Console.WriteLine("\n\tPERFORMING FILTER 3");
            return image;
        }

    }
}
