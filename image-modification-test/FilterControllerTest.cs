﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using image_modification;
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
            // Get base image
            ImageModel testImage = new ImageModel(
                Properties.Resources.Smiley,
                nameof(Properties.Resources.Smiley));

            // Get filter result image
            ImageModel realResult = new ImageModel(
                Properties.Resources.SmileyRainbow,
                nameof(Properties.Resources.SmileyRainbow));

            // Apply filter on test image
            ImageModel result = controller.ApplyRainbowFilter(testImage);

            // Get hash of images
            string resultImageHash = TestFunctions.GetImageHash(result);
            string realResultImageHash = TestFunctions.GetImageHash(realResult);

            // Comparison
            Assert.AreEqual(resultImageHash, realResultImageHash);
        }

        [TestMethod]
        public void ApplyRainbowFilter_Exception_NullReference()
        {
            // Create an invalid image
            ImageModel testImage = null;

            // Apply filter on test image
            ImageModel result = controller.ApplyRainbowFilter(testImage);

            Assert.AreEqual(result, null);
        }

        // Test swap filter
        [TestMethod]
        public void ApplySwapFilter()
        {
            // Get base image
            ImageModel testImage = new ImageModel(
                Properties.Resources.Smiley,
                nameof(Properties.Resources.Smiley));

            // Get filter result image
            ImageModel realResult = new ImageModel(
                Properties.Resources.SmileySwap,
                nameof(Properties.Resources.SmileySwap));

            // Apply filter on test image
            ImageModel result = controller.ApplySwapFilter(testImage);

            // Get hash of images
            string resultImageHash = TestFunctions.GetImageHash(result);
            string realResultImageHash = TestFunctions.GetImageHash(realResult);

            // Comparison
            Assert.AreEqual(resultImageHash, realResultImageHash);
        }

        // Test black & white filter
        [TestMethod]
        public void ApplyBlackWhiteFilter()
        {
            // Get base image
            ImageModel testImage = new ImageModel(
                Properties.Resources.Smiley,
                nameof(Properties.Resources.Smiley));

            // Get filter result image
            ImageModel realResult = new ImageModel(
                Properties.Resources.SmileyBlackAndWhite,
                nameof(Properties.Resources.SmileyBlackAndWhite));

            // Apply filter on test image
            ImageModel result = controller.ApplyBlackWhiteFilter(testImage);

            // Get hash of images
            string resultImageHash = TestFunctions.GetImageHash(result);
            string realResultImageHash = TestFunctions.GetImageHash(realResult);

            // Comparison
            Assert.AreEqual(resultImageHash, realResultImageHash);
        }

    }
}
