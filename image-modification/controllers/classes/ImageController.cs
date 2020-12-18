using System.Drawing;
using System.Drawing.Drawing2D;
using image_modification.controllers;
using System.Collections.Generic;

namespace image_modification.controllers.classes
{
    class ImageController : IImageController
    {
        private ImageModel image;
        private IFilterController filterController;
        private IEdgeDetectionController edgeDetectionController;

        private List<int> filters = new List<int>();
        private List<int> edgeDetections = new List<int>();

        private const int 
            FILTER_1 = 0, 
            FILTER_2 = 1, 
            FILTER_3 = 2;

        private const int 
            EDGE_DET_1 = 0, 
            EDGE_DET_2 = 1, 
            EDGE_DET_3 = 2;


        public ImageController(ImageModel source)
        {
            image = source;
            filterController = new FilterController();
            edgeDetectionController = new EdgeDetectionController();
        }

        // Returns the full quality image
        public ImageModel getResultImage()
        {
            return image;
        }

        // Add a filter to the list
        public void AddFilter(int filter)
        {
            filters.Add(filter);
        }

        // Add an edge detection to the list
        public void AddEdgeDetection(int edgeDet)
        {
            edgeDetections.Add(edgeDet);
        }

        // Applys all filters in order
        public void applyFilters()
        {
            foreach(int filter in filters)
            {
                switch(filter)
                {
                    case FILTER_1:      image = filterController.Filter1(image);    break;
                    case FILTER_2:      image = filterController.Filter2(image);    break;
                    case FILTER_3:      image = filterController.Filter3(image);    break;
                    default:            return;

                }
            }
        }
        
        // Applys all edge detections in order
        public void applyEdgeDetection()
        {
            foreach (int edgeDet in edgeDetections)
            {
                switch (edgeDet)
                {
                    case EDGE_DET_1:    image = edgeDetectionController.EdgeDet1(image);    break;
                    case EDGE_DET_2:    image = edgeDetectionController.EdgeDet2(image);    break;
                    case EDGE_DET_3:    image = edgeDetectionController.EdgeDet3(image);    break;
                    default: return;

                }
            }
        }

        // Creates a square bitmap for displaying in the app
        public ImageModel getPreviewImage(int width)
        {
            // TODO : replace this with something better?
            float ratio = 1.0f;
            int maxSide = image.getImage().Width > image.getImage().Height ?
                          image.getImage().Width : image.getImage().Height;

            ratio = (float)maxSide / (float)width;

            Bitmap bitmapResult = (
                image.getImage().Width > image.getImage().Height 
                    ? new Bitmap(width, (int)(image.getImage().Height / ratio))
                    : new Bitmap((int)(image.getImage().Width / ratio), width));

            using (Graphics graphicsResult = Graphics.FromImage(bitmapResult))
            {
                graphicsResult.CompositingQuality = CompositingQuality.HighQuality;
                graphicsResult.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsResult.PixelOffsetMode = PixelOffsetMode.HighQuality;

                graphicsResult.DrawImage(image.getImage(),
                                        new Rectangle(0, 0,
                                            bitmapResult.Width, bitmapResult.Height),
                                        new Rectangle(0, 0,
                                            image.getImage().Width, image.getImage().Height),
                                            GraphicsUnit.Pixel);
                graphicsResult.Flush();
            }

            return new ImageModel(bitmapResult);
        }

    }
}
