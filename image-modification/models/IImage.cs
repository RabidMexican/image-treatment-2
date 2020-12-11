using System.Drawing;

namespace image_modification
{
    interface IImage
    {
        Bitmap Original();
        Bitmap Preview();

    }
}
