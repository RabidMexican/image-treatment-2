namespace image_modification
{
    interface IImageController
    {
        ImageModel GetResultImage(int width);
        ImageModel ApplyFilters(ImageModel image);
        ImageModel ApplyEdgeDetection(ImageModel image);
    }
}
