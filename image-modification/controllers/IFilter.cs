
using System.Drawing;

namespace image_modification
{
    interface IFilter
    {
        Bitmap Filter1(Bitmap image);
        Bitmap Filter2(Bitmap image);
        Bitmap Filter3(Bitmap image);

    }
}
