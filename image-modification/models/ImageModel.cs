using System.Drawing;
using System.IO;

namespace image_modification
{
    class ImageModel
    {
        private Bitmap image;

        public ImageModel(string source)
        {
            StreamReader streamReader = new StreamReader(source);
            image = (Bitmap)Image.FromStream(streamReader.BaseStream);
            streamReader.Close();
        }

        public ImageModel(Bitmap source)
        {
            image = source;
        }

        public Bitmap getImage()
        {
            return image;
        }
    }
}
