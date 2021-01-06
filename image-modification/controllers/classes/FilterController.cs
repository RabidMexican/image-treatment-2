using System;
using System.Drawing;

namespace image_modification.controllers
{
    class FilterController : IFilterController
    {
        // Apply the rainbow filter
        public ImageModel ApplyRainbowFilter(ImageModel image)
        {
            Bitmap bmp = image.GetBitmapImage();
            Bitmap result = new Bitmap(bmp.Width, bmp.Height);
            int raz = bmp.Height / 4;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int x = 0; x < bmp.Height; x++)
                {
                    if (i < (raz))
                    {
                        result.SetPixel(i, x, Color.FromArgb(bmp.GetPixel(i, x).R / 5, bmp.GetPixel(i, x).G, bmp.GetPixel(i, x).B));
                    }
                    else if (i < (raz * 2))
                    {
                        result.SetPixel(i, x, Color.FromArgb(bmp.GetPixel(i, x).R, bmp.GetPixel(i, x).G / 5, bmp.GetPixel(i, x).B));
                    }
                    else if (i < (raz * 3))
                    {
                        result.SetPixel(i, x, Color.FromArgb(bmp.GetPixel(i, x).R, bmp.GetPixel(i, x).G, bmp.GetPixel(i, x).B / 5));
                    }
                    else if (i < (raz * 4))
                    {
                        result.SetPixel(i, x, Color.FromArgb(bmp.GetPixel(i, x).R / 5, bmp.GetPixel(i, x).G, bmp.GetPixel(i, x).B / 5));
                    }
                    else
                    {
                        result.SetPixel(i, x, Color.FromArgb(bmp.GetPixel(i, x).R / 5, bmp.GetPixel(i, x).G / 5, bmp.GetPixel(i, x).B / 5));
                    }
                }
            }

            return new ImageModel(result);
        }

        //apply filter that swaps all pixel colors
        public ImageModel ApplySwapFilter(ImageModel image)
        {
            Color c;
            Bitmap bmp = image.GetBitmapImage();

            for (int i = 0; i < bmp.Width; i++)
                for (int x = 0; x < bmp.Height; x++)
                {
                    c = bmp.GetPixel(i, x);
                    Color cLayer = Color.FromArgb(c.A, c.G, c.B, c.R);
                    bmp.SetPixel(i, x, cLayer);
                }

            return new ImageModel(bmp);
        }

        public ImageModel ApplyBlackWhiteFilter(ImageModel image)
        {
            Bitmap bmp = image.GetBitmapImage();
            int rgb;
            Color c;

            for (int y = 0; y < bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++)
                {
                    c = bmp.GetPixel(x, y);
                    rgb = ((c.R + c.G + c.B) / 3);
                    bmp.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
            return new ImageModel(bmp);
        }

    }
}
