using image_modification;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;

namespace image_modification_test
{
    class TestFunctions
    {
        public static string GetImageHash(ImageModel source)
        {
            // Init of variables
            List<byte> colorList = new List<byte>();
            string hash;
            int i, j;

            // Create new image with 16x16 pixels
            Bitmap bmpMin = new Bitmap(source.GetBitmapImage(), new Size(16, 16));

            // Loop through the 16x16 image and add each pixel to the list
            for (j = 0; j < bmpMin.Height; j++)
            {
                for (i = 0; i < bmpMin.Width; i++)
                {
                    colorList.Add(bmpMin.GetPixel(i, j).R);
                }
            }

            // Convert the pixel list into a SHA1 hash
            SHA1Managed sha = new SHA1Managed();
            byte[] checksum = sha.ComputeHash(colorList.ToArray());
            hash = BitConverter.ToString(checksum).Replace("-", string.Empty);

            // Get rid of the old resources
            sha.Dispose();
            bmpMin.Dispose();

            // Return the hash
            return hash;
        }
    }
}
