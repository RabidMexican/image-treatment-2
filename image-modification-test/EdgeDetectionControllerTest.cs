using Microsoft.VisualStudio.TestTools.UnitTesting;
using image_modification;
using image_modification.controllers.classes;
using System;

namespace image_modification_test
{
    [TestClass]
    public class EdgeDetectionControllerTest
    {
        //controller to call edgeDetection methods
        EdgeDetectionController controller = new EdgeDetectionController();

        // Test Laplacian 3x3 filter
        [TestMethod]
        public void TestApplyLaplacian3x3()
        {
            // Get base image
            ImageModel testImage = new ImageModel(
                Properties.Resources.Smiley,
                nameof(Properties.Resources.Smiley));

            // Get filter result image
            ImageModel realResult = new ImageModel(
                Properties.Resources.SmileyEdgeLaplacian,
                nameof(Properties.Resources.SmileyEdgeLaplacian));

            // Apply filter on test image
            ImageModel result = controller.ApplyLaplacian3x3(testImage);

            // Get hash of images
            string resultImageHash = TestFunctions.GetImageHash(result);
            string realResultImageHash = TestFunctions.GetImageHash(realResult);

            // Comparison
            Assert.AreEqual(resultImageHash, realResultImageHash);
        }

        // Test Prewitt filter
        [TestMethod]
        public void TestApplyPrewitt()
        {
            // Get base image
            ImageModel testImage = new ImageModel(
                Properties.Resources.Smiley,
                nameof(Properties.Resources.Smiley));

            // Get filter result image
            ImageModel realResult = new ImageModel(
                Properties.Resources.SmileyEdgePrewitt,
                nameof(Properties.Resources.SmileyEdgePrewitt));

            // Apply filter on test image
            ImageModel result = controller.ApplyPrewitt(testImage);

            // Get hash of images
            string resultImageHash = TestFunctions.GetImageHash(result);
            string realResultImageHash = TestFunctions.GetImageHash(realResult);

            // Comparison
            Assert.AreEqual(resultImageHash, realResultImageHash);
        }

        // Test Kirsch filter
        [TestMethod]
        public void TestApplyKirsch()
        {
            // Get base image
            ImageModel testImage = new ImageModel(
                Properties.Resources.Smiley,
                nameof(Properties.Resources.Smiley));

            // Get filter result image
            ImageModel realResult = new ImageModel(
                Properties.Resources.SmileyEdgeKirsh,
                nameof(Properties.Resources.SmileyEdgeKirsh));

            // Apply filter on test image
            ImageModel result = controller.ApplyKirsch(testImage);

            // Get hash of images
            string resultImageHash = TestFunctions.GetImageHash(result);
            string realResultImageHash = TestFunctions.GetImageHash(realResult);

            // Comparison
            Assert.AreEqual(resultImageHash, realResultImageHash);
        }
    }
}
