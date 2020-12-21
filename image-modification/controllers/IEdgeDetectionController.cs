namespace image_modification
{
    interface IEdgeDetectionController
    {
        ImageModel ApplyLaplacian3x3(ImageModel image, bool grayscale = false);
        ImageModel ApplyPrewitt(ImageModel image, bool grayscale = false);
        ImageModel ApplyKirsch(ImageModel image, bool grayscale = false);

    }
}
