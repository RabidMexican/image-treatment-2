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

            streamReader.Close();
        }

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
