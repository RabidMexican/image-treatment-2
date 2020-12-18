using System.Drawing;

namespace image_modification
{
    interface IImageController
    {
        BitmapImage getPreviewImage(int canvasSize);
        BitmapImage getResultImage();
    }
}
