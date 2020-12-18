using System.Drawing;
using System.IO;

namespace image_modification
{
    class BitmapImage
    {
        private Bitmap image;

        public BitmapImage(string fileName)
        {
            StreamReader streamReader = new StreamReader(fileName);
            image = (Bitmap)Image.FromStream(streamReader.BaseStream);
            streamReader.Close();
        }

        public BitmapImage(Bitmap source)
        {
            image = source;
        }

        public Bitmap getImage()
        {
            return image;
        }
    }
}
