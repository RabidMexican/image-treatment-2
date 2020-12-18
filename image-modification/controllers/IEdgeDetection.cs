using System.Drawing;

namespace image_modification
{
    interface IEdgeDetection
    {
        ImageModel EdgeDet1(ImageModel image);
        ImageModel EdgeDet2(ImageModel image);
        ImageModel EdgeDet3(ImageModel image);

    }
}
