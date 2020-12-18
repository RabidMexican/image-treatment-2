using System.Drawing;
using System.IO;

namespace image_modification
{
    class ImageModel
    {
        private Bitmap image;

        public ImageModel(string fileName)
        {
            StreamReader streamReader = new StreamReader(fileName);
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
