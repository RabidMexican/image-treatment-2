using System.Drawing;
using System.Drawing.Drawing2D;

namespace image_modification.controllers.classes
{
    class ImageController : IImageController
    {
        private ImageModel image;

        public ImageController(ImageModel source)
        {
            image = source;
        }

        // Returns the full quality image
        public ImageModel getResultImage()
        {
            return image;
        }

        // Creates a square bitmap for displaying in the app
        public ImageModel getPreviewImage(int width)
        {
            // TODO : replace this with something better?
            float ratio = 1.0f;
            int maxSide = image.getImage().Width > image.getImage().Height ?
                          image.getImage().Width : image.getImage().Height;

            ratio = (float)maxSide / (float)width;

            Bitmap bitmapResult = (
                image.getImage().Width > image.getImage().Height 
                    ? new Bitmap(width, (int)(image.getImage().Height / ratio))
                    : new Bitmap((int)(image.getImage().Width / ratio), width));

            using (Graphics graphicsResult = Graphics.FromImage(bitmapResult))
            {
                graphicsResult.CompositingQuality = CompositingQuality.HighQuality;
                graphicsResult.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsResult.PixelOffsetMode = PixelOffsetMode.HighQuality;

                graphicsResult.DrawImage(image.getImage(),
                                        new Rectangle(0, 0,
                                            bitmapResult.Width, bitmapResult.Height),
                                        new Rectangle(0, 0,
                                            image.getImage().Width, image.getImage().Height),
                                            GraphicsUnit.Pixel);
                graphicsResult.Flush();
            }

            return new ImageModel(bitmapResult);
        }
    }
}
