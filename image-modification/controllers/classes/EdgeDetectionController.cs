using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

using image_modification.controllers.classes;

namespace image_modification.controllers.classes
{
  public  class EdgeDetectionController : IEdgeDetectionController
    {
        public ImageModel ApplyLaplacian3x3(ImageModel sourceBitmap, bool grayscale = false)
        {
            return ConvolutionFilter(
                sourceBitmap, 
                ImageMatrix.Laplacian3x3,
                1.0, 0, grayscale);
        }

        public ImageModel ApplyPrewitt(ImageModel image, bool grayscale = false)
        {
            return ConvolutionFilter(
                image,
                ImageMatrix.Prewitt3x3Horizontal,
                ImageMatrix.Prewitt3x3Vertical,
                grayscale);
        }

        public ImageModel ApplyKirsch(ImageModel image, bool grayscale = false)
        {
            return ConvolutionFilter(
                image,
                ImageMatrix.Kirsch3x3Horizontal,
                ImageMatrix.Kirsch3x3Vertical,
                grayscale);
        }

        private ImageModel ConvolutionFilter(
            ImageModel source, 
            double[,] filterMatrix, 
            double factor = 1,
            int bias = 0,
            bool grayscale = false)
        {
            Bitmap sourceBitmap = source.GetBitmapImage();
            BitmapData sourceData = sourceBitmap.LockBits(
                new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);            

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            int filterWidth = filterMatrix.GetLength(1);
            int filterHeight = filterMatrix.GetLength(0);

            int filterOffset = (filterWidth - 1) / 2;

            for (int offsetY = filterOffset; offsetY <
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    double blue = 0;
                    double green = 0;
                    double red = 0;
                    int byteOffset = offsetY * sourceData.Stride + offsetX * 4;

                    for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
                        {
                            int calcOffset = byteOffset + (filterX * 4) + (filterY * sourceData.Stride);
                            blue += pixelBuffer[calcOffset] * filterMatrix[filterY + filterOffset, filterX + filterOffset];
                            green += pixelBuffer[calcOffset + 1] * filterMatrix[filterY + filterOffset, filterX + filterOffset];
                            red += pixelBuffer[calcOffset + 2] * filterMatrix[filterY + filterOffset, filterX + filterOffset];
                        }
                    }

                    blue    = factor * blue + bias;
                    green   = factor * green + bias;
                    red     = factor * red + bias;

                    blue    =   (blue > 255 ? 255 : blue < 0 ? 0 : blue);
                    green   =   (green > 255 ? 255 : green < 0 ? 0 : green);
                    red     =   (red > 255 ? 255 : red < 0 ? 0 : red);

                    resultBuffer[byteOffset] = (byte)(blue);
                    resultBuffer[byteOffset + 1] = (byte)(green);
                    resultBuffer[byteOffset + 2] = (byte)(red);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(
                new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);
            return new ImageModel(resultBitmap, source.name);
        }

        public static ImageModel ConvolutionFilter(
            ImageModel source,
            double[,] xFilterMatrix,
            double[,] yFilterMatrix,
            bool grayscale = false)
        {
            Bitmap sourceBitmap = source.GetBitmapImage();
            BitmapData sourceData = sourceBitmap.LockBits(
                new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            int filterOffset = 1;
            for (int offsetY = filterOffset; offsetY <
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    double blueX, greenX, redX;
                    blueX = greenX = redX = 0.0;

                    double blueY, greenY, redY;
                    blueY = greenY = redY = 0.0;

                    double blueTotal, greenTotal, redTotal;
                    int byteOffset = offsetY * sourceData.Stride + offsetX * 4;

                    for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
                        {
                            int calcOffset = byteOffset + (filterX * 4) + (filterY * sourceData.Stride);

                            blueX   += pixelBuffer[calcOffset]      * xFilterMatrix[filterY + filterOffset, filterX + filterOffset];
                            greenX  += pixelBuffer[calcOffset + 1]  * xFilterMatrix[filterY + filterOffset, filterX + filterOffset];
                            redX    += pixelBuffer[calcOffset + 2]  * xFilterMatrix[filterY + filterOffset, filterX + filterOffset];

                            blueY   += pixelBuffer[calcOffset]      * yFilterMatrix[filterY + filterOffset, filterX + filterOffset];
                            greenY  += pixelBuffer[calcOffset + 1]  * yFilterMatrix[filterY + filterOffset, filterX + filterOffset];
                            redY    += pixelBuffer[calcOffset + 2]  * yFilterMatrix[filterY + filterOffset, filterX + filterOffset];
                        }
                    }

                    blueTotal   =   Math.Sqrt((blueX * blueX) + (blueY * blueY));
                    greenTotal  =   Math.Sqrt((greenX * greenX) + (greenY * greenY));
                    redTotal    =   Math.Sqrt((redX * redX) + (redY * redY));

                    blueTotal   = (blueTotal > 255 ? 255 : blueTotal < 0 ? 0 : blueTotal);
                    greenTotal  = (greenTotal > 255 ? 255 : greenTotal < 0 ? 0 : greenTotal);
                    redTotal    = (redTotal > 255 ? 255 : redTotal < 0 ? 0 : redTotal);

                    resultBuffer[byteOffset]        = (byte)(blueTotal);
                    resultBuffer[byteOffset + 1]    = (byte)(greenTotal);
                    resultBuffer[byteOffset + 2]    = (byte)(redTotal);
                    resultBuffer[byteOffset + 3]    = 255;
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(
                new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return new ImageModel(resultBitmap, source.name);
        }
    }
}
