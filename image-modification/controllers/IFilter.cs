using System.Drawing;

namespace image_modification
{
    interface IFilter
    {
        BitmapImage Filter1(BitmapImage image);
        BitmapImage Filter2(BitmapImage image);
        BitmapImage Filter3(BitmapImage image);

    }
}
