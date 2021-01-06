namespace image_modification
{
    interface IImageController
    {
        bool LoadImage();
        void SaveImage();

        void AddFilter(int filter);
        void RemoveFilter(int filter);

        void AddEdgeDetection(int edgeDet);
        void RemoveEdgeDetection(int edgeDet);

        ImageModel ApplyFilters(ImageModel image);
        ImageModel ApplyEdgeDetection(ImageModel image);

        ImageModel GetResultImage(int width);
    }
}
