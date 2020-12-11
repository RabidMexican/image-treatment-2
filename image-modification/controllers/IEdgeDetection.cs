using System.Drawing;

namespace image_modification
{
    interface IEdgeDetection
    {
        Bitmap EdgeDet1(Bitmap image);
        Bitmap EdgeDet2(Bitmap image);
        Bitmap EdgeDet3(Bitmap image);

    }
}
