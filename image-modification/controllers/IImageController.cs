namespace image_modification
{
    interface IImageController
    {
        void AddFilter(int filter);
        void RemoveFilter(int filter);
        void AddEdgeDetection(int edgeDet);
        void RemoveEdgeDetection(int edgeDet);

        ImageModel GetResultImage(int width);
        ImageModel ApplyFilters(ImageModel image);
        ImageModel ApplyEdgeDetection(ImageModel image);
    }
}
