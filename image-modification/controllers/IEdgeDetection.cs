using System.Drawing;

namespace image_modification
{
    interface IEdgeDetection
    {
        BitmapImage EdgeDet1(BitmapImage image);
        BitmapImage EdgeDet2(BitmapImage image);
        BitmapImage EdgeDet3(BitmapImage image);

    }
}
