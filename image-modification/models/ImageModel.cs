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

        public ImageModel(string source)
        {
            // Extract the filename with extension
            name = Path.GetFileName(source);

            // Get image from source
            StreamReader streamReader = new StreamReader(source);
            image = (Bitmap)Image.FromStream(streamReader.BaseStream);

            // Extract height and width from image
            height = image.Height;
            width = image.Width;
            Console.WriteLine(name + " : " + height + "x" + width);
            streamReader.Close();
        }

        public ImageModel(Bitmap source)
        {
            image = source;
        }

        public Bitmap GetBitmapImage()
        {
            return image;
        }

        public void SetImage(Bitmap image)
        {
            this.image = image;
        }
    }
}
