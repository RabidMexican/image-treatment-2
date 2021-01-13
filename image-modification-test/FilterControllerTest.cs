using Microsoft.VisualStudio.TestTools.UnitTesting;
using image_modification;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Drawing;
using image_modification.controllers.classes;

namespace image_modification_test
{
    [TestClass]
    public class FilterControllerTest
    {
        //controller to call filter methods
        FilterController controller = new FilterController();

        // Test rainbow filter
        [TestMethod]
        public void ApplyRainbowFilter()
        {
       

            //get images from Resources
            ImageModel testImage = new ImageModel(image_modification_test.Properties.Resources.Smiley);
            ImageModel realResult = new ImageModel(image_modification_test.Properties.Resources.SmileyRainbow);

            //apply filter on test image
            ImageModel result = controller.ApplyRainbowFilter(testImage);


            //get Hash from images
            String resultImageHash = GetImageHash(result);
            String realResultImageHash = GetImageHash(realResult);


            //comparison
            Assert.AreEqual(resultImageHash, realResultImageHash);
        }

        // Test swap filter
        [TestMethod]
        public void ApplySwapFilter()
        {
            Assert.IsTrue(false);
        }

        // Test black & white filter
        [TestMethod]
        public void ApplyBlackWhiteFilter()
        {
            Assert.IsTrue(false);
        }


        private string GetImageHash(ImageModel bmpSourceImage)
        {
            Bitmap bmpSource = bmpSourceImage.GetBitmapImage();
            List<byte> colorList = new List<byte>();
            string hash;

            colorList.Clear();
            int i, j;
            Bitmap bmpMin = new Bitmap(bmpSource, new Size(16, 16)); //create new image with 16x16 pixel
            for (j = 0; j < bmpMin.Height; j++)
            {
                for (i = 0; i < bmpMin.Width; i++)
                {
                    colorList.Add(bmpMin.GetPixel(i, j).R);
                }
            }
            SHA1Managed sha = new SHA1Managed();
            byte[] checksum = sha.ComputeHash(colorList.ToArray());
            hash = BitConverter.ToString(checksum).Replace("-", String.Empty);
            sha.Dispose();
            bmpMin.Dispose();
            return hash;
        }
    }
}
