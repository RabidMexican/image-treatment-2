using System.Drawing;
using System.Drawing.Drawing2D;
using image_modification.controllers;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System;

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
            EDGE_LAPLACIAN_3X3 = 0,
            EDGE_PREWITT_3X3 = 1,
            EDGE_KIRSCH = 2;

        public ImageController(FilterController filterController, EdgeDetectionController edgeController)
        {
            this.filterController = filterController;
            this.edgeDetectionController = edgeController;
        }

        public void SaveImage(string destination)
        {
            if (image != null)
            {
                // Get result image
                Bitmap bitmapImage = GetResultImage().GetBitmapImage();

                // Set default file extension
                string fileExtension = Path.GetExtension(destination).ToUpper();
                ImageFormat imgFormat = ImageFormat.Png;

                // Check for new file extension
                switch (fileExtension)
                {
                    case "BMP": imgFormat = ImageFormat.Bmp; break;
                    case "JPG": imgFormat = ImageFormat.Jpeg; break;
                }

                try
                {
                    // Write image to disk and close the stream writer
                    StreamWriter streamWriter = new StreamWriter(destination, false);
                    bitmapImage.Save(streamWriter.BaseStream, imgFormat);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine("Error saving image " + destination + "! The directory was not found!");
                    Console.WriteLine(e);
                }
                
            }
        }

        public bool LoadImage(string source)
        {
            // Extract the filename with extension
            string name = Path.GetFileName(source);

            // Get image from source
            try
            {
                StreamReader streamReader = new StreamReader(source);
                Bitmap sourceImage = (Bitmap)Image.FromStream(streamReader.BaseStream);
                streamReader.Close();

                image = new ImageModel(sourceImage, name);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("WARNING : image " + name + " not found!");
                Console.WriteLine(e);
                return false;
            }

            // Checks image and returns if it has been initialised
            if (image != null) return true;
            return false;
        }

        // Gets result with filters
        public ImageModel GetResultImage(int canvasWidth = 0)
        {
            ImageModel result;

            // if canvas is set we generate a preview image
            if (canvasWidth > 0) result = GetPreviewImage(canvasWidth);
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

        // Remove a specific filter from the list
        public void RemoveFilter(int filter)
        {
            for(int i = 0; i < filters.Count; i++)
            {
                if (filters[i] == filter) filters.RemoveAt(i);
            }
        }

        // Add an edge detection to the list
        public void AddEdgeDetection(int edgeDet)
        {
            edgeDetections.Add(edgeDet);
        }

        // Remove a specific edge detection from the list
        public void RemoveEdgeDetection(int edgeDet)
        {
            for (int i = 0; i < edgeDetections.Count; i++)
            {
                if (edgeDetections[i] == edgeDet) edgeDetections.RemoveAt(i);
            }
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
                    case EDGE_LAPLACIAN_3X3:    result = edgeDetectionController.ApplyLaplacian3x3(result);     break;
                    case EDGE_PREWITT_3X3:      result = edgeDetectionController.ApplyPrewitt(result);          break;
                    case EDGE_KIRSCH:           result = edgeDetectionController.ApplyKirsch(result);           break;
                }
            }
            return result;
        }

        // Creates a square bitmap for displaying in the app
        public ImageModel GetPreviewImage(int width)
        {
            // TODO : replace this with something better?
            float ratio = 1.0f;
            int maxSide = image.GetBitmapImage().Width > image.GetBitmapImage().Height ?
                          image.GetBitmapImage().Width : image.GetBitmapImage().Height;

            ratio = (float)maxSide / (float)width;

            Bitmap bitmapResult = (
                image.GetBitmapImage().Width > image.GetBitmapImage().Height 
                    ? new Bitmap(width, (int)(image.GetBitmapImage().Height / ratio))
                    : new Bitmap((int)(image.GetBitmapImage().Width / ratio), width));

            using (Graphics graphicsResult = Graphics.FromImage(bitmapResult))
            {
                graphicsResult.CompositingQuality = CompositingQuality.HighQuality;
                graphicsResult.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsResult.PixelOffsetMode = PixelOffsetMode.HighQuality;

                graphicsResult.DrawImage(image.GetBitmapImage(),
                                        new Rectangle(0, 0,
                                            bitmapResult.Width, bitmapResult.Height),
                                        new Rectangle(0, 0,
                                            image.GetBitmapImage().Width, image.GetBitmapImage().Height),
                                            GraphicsUnit.Pixel);
                graphicsResult.Flush();
            }

            return new ImageModel(bitmapResult, image.name);
        }
    }
}
