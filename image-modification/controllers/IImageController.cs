namespace image_modification
{
  public interface IImageController
    {
        bool LoadImage(string source);
        void SaveImage(string destination);

        void AddFilter(int filter);
        void RemoveFilter(int filter);

        void AddEdgeDetection(int edgeDet);
        void RemoveEdgeDetection(int edgeDet);

        ImageModel ApplyFilters(ImageModel image);
        ImageModel ApplyEdgeDetection(ImageModel image);

        ImageModel GetResultImage(int width);
    }
}
