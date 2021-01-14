using image_modification;
using image_modification.controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace image_modification_test.ImageControllerTests
{
    [TestClass]
    public class ApplyEdgeDetectionsTests
    {
        private ImageController imageController;

        private ImageModel original         = new ImageModel(Properties.Resources.Smiley, nameof(Properties.Resources.Smiley));
        private ImageModel original_kirsh   = new ImageModel(Properties.Resources.SmileyEdgeKirsh, nameof(Properties.Resources.SmileyEdgeKirsh));
        private ImageModel original_lap     = new ImageModel(Properties.Resources.SmileyEdgeLaplacian, nameof(Properties.Resources.SmileyEdgeLaplacian));
        private ImageModel original_prewitt = new ImageModel(Properties.Resources.SmileyEdgePrewitt, nameof(Properties.Resources.SmileyEdgePrewitt));

        // Test application of edge detections
        [TestMethod]
        public void ApplyEdgeDetection_Laplacian()
        {
            // Create substitutes for interfaces
            var filterRepository = Substitute.For<IFilterController>();
            var edgeDetRepository = Substitute.For<IEdgeDetectionController>();

            // Create controller
            imageController = new ImageController(filterRepository, edgeDetRepository);
            imageController.AddEdgeDetection(0);

            // Force result of edgeDetection so we don't have to calculate it
            edgeDetRepository.ApplyLaplacian3x3(original).Returns(original_lap);

            // Execute test
            ImageModel testImage = imageController.ApplyEdgeDetection(original);

            // Get hash of images
            string resultImageHash = TestFunctions.GetImageHash(original_lap);
            string realResultImageHash = TestFunctions.GetImageHash(testImage);

            // Comparison
            Assert.AreEqual(resultImageHash, realResultImageHash);
        }

        // Test application of edge detections
        [TestMethod]
        public void ApplyEdgeDetection_Prewitt()
        {
            // Create substitutes for interfaces
            var filterRepository = Substitute.For<IFilterController>();
            var edgeDetRepository = Substitute.For<IEdgeDetectionController>();

            // Create controller
            imageController = new ImageController(filterRepository, edgeDetRepository);
            imageController.AddEdgeDetection(1);

            // Force result of edgeDetection so we don't have to calculate it
            edgeDetRepository.ApplyPrewitt(original).Returns(original_prewitt);

            // Execute test
            ImageModel testImage = imageController.ApplyEdgeDetection(original);

            // Get hash of images
            string resultImageHash = TestFunctions.GetImageHash(original_prewitt);
            string realResultImageHash = TestFunctions.GetImageHash(testImage);

            // Comparison
            Assert.AreEqual(resultImageHash, realResultImageHash);
        }

        // Test application of edge detections
        [TestMethod]
        public void ApplyEdgeDetection_Kirsch()
        {
            // Create substitutes for interfaces
            var filterRepository = Substitute.For<IFilterController>();
            var edgeDetRepository = Substitute.For<IEdgeDetectionController>();

            // Create controller
            imageController = new ImageController(filterRepository, edgeDetRepository);
            imageController.AddEdgeDetection(2);

            // Force result of edgeDetection so we don't have to calculate it
            edgeDetRepository.ApplyKirsch(original).Returns(original_kirsh);

            // Execute test
            ImageModel testImage = imageController.ApplyEdgeDetection(original);

            // Get hash of images
            string resultImageHash = TestFunctions.GetImageHash(original_kirsh);
            string realResultImageHash = TestFunctions.GetImageHash(testImage);

            // Comparison
            Assert.AreEqual(resultImageHash, realResultImageHash);
        }
    }
}
