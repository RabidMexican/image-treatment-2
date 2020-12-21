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
            FILTER_RAINBOW = 0, 
            FILTER_SWAP = 1, 
            FILTER_BLACKWHITE = 2,
            EDGE_DET_1 = 0, 
            EDGE_DET_2 = 1, 
            EDGE_DET_3 = 2;


        public ImageController(ImageModel source)
        {
            image = source;
            filterController = new FilterController();
            edgeDetectionController = new EdgeDetectionController();
        }

        // Returns the modified full quality image
        public ImageModel GetResultImage()
        {
            ImageModel result = image;
            result = ApplyFilters(result);
            result = ApplyEdgeDetection(result);
            return result;
        }

        // Gets result with filters
        public ImageModel GetResultImage(int canvasWidth = 0)
        {
            ImageModel result;

            // if canvas is set we generate a preview image
            if (canvasWidth > 0) result = CreatePreviewImage(canvasWidth);
            else result = image;

            result = ApplyFilters(result);
            result = ApplyEdgeDetection(result);
            return result;
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
        public ImageModel ApplyFilters(ImageModel result)
        {
            foreach(int filter in filters)
            {
                switch(filter)
                {
                    case FILTER_RAINBOW:        result = filterController.ApplyRainbowFilter(result);       break;
                    case FILTER_SWAP:           result = filterController.ApplySwapFilter(result);          break;
                    case FILTER_BLACKWHITE:     result = filterController.ApplyBlackWhiteFilter(result);    break;

                }
            }
            return result;
        }
        
        // Applys all edge detections in order
        public ImageModel ApplyEdgeDetection(ImageModel result)
        {
            foreach (int edgeDet in edgeDetections)
            {
                switch (edgeDet)
                {
                    case EDGE_DET_1:    result = edgeDetectionController.EdgeDet1(result);    break;
                    case EDGE_DET_2:    result = edgeDetectionController.EdgeDet2(result);    break;
                    case EDGE_DET_3:    result = edgeDetectionController.EdgeDet3(result);    break;
                }
            }
            return result;
        }

        // Creates a square bitmap for displaying in the app
        public ImageModel CreatePreviewImage(int width)
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
