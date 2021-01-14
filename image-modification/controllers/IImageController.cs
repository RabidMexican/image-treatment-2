using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace image_modification.controllers
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

        ImageModel GetResultImage(int width = 0);
    }
}
