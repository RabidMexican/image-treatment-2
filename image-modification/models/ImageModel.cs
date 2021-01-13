using System;
using System.Drawing;
using System.IO;

namespace image_modification
{
    public class ImageModel
    {
        private Bitmap image;

        public string name;
        public int height;
        public int width;

        public ImageModel(Bitmap source, string name)
        {
            // Update from parameters
            image = source;
            this.name = name;

            // Update bitmap dimensions
            height = image.Height;
            width = image.Width;
        }

        public Bitmap GetBitmapImage()
        {
            return image;
        }

    }
}
