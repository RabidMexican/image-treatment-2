using System.Drawing;

namespace image_modification.models
{
    class Image : IImage
    {
        private Bitmap image;

        public Image()
        {
            // init image here with paramter 
        }

        public Bitmap Original()
        {
            return image;
        }

        public Bitmap Preview()
        {
            return image;
        }

    }
}
