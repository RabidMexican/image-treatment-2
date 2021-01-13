using image_modification;
using image_modification.controllers;
using image_modification.controllers.classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.IO;

namespace image_modification_test
{

    [TestClass]
    public class ImageControllerTest
    {
        private ImageController imageController;

        // Test saving image
        [TestMethod]
        public void SaveImage()
        {
            string path = @"C:\Tests\Smiley.png";

            // Create substitutes for interfaces
            var filterRepository = Substitute.For<IFilterController>();
            var edgeDetRepository = Substitute.For<IEdgeDetectionController>();
            imageController = new ImageController(filterRepository, edgeDetRepository);

            // Get resource images
            ImageModel original = new ImageModel(
                Properties.Resources.Smiley,
                nameof(Properties.Resources.Smiley));

            // Save and recouperate the image
            imageController.image = original;
            imageController.SaveImage(path);
            imageController.LoadImage(path);

            // Get hash of images
            string originalHash = TestFunctions.GetImageHash(original);
            string testHash = TestFunctions.GetImageHash(imageController.image);

            // Comparison
            Assert.AreEqual(originalHash, testHash);
        }

        // Test loading of image
        [TestMethod]
        public void LoadImage()
        {
      
            string path = @"C:\Tests\Smiley.png";

            // Create substitutes for interfaces
            var filterRepository = Substitute.For<IFilterController>();
            var edgeDetRepository = Substitute.For<IEdgeDetectionController>();
            imageController = new ImageController(filterRepository, edgeDetRepository);

            // Get resource images
            ImageModel original = new ImageModel(
                Properties.Resources.Smiley,
                nameof(Properties.Resources.Smiley));

            imageController.LoadImage(path);

            // Get hash of images
            string originalHash = TestFunctions.GetImageHash(original);
            string testHash= TestFunctions.GetImageHash(imageController.image);

            // Comparison
            Assert.AreEqual(originalHash, testHash);
        }

        // Test image result
        [TestMethod]
        public void GetResultImage()
        {
            Assert.IsTrue(false);
        }

        // Test additon of filter
        [TestMethod]
        public void AddFilter()
        {
            // Create substitutes for interfaces
            var filterRepository = Substitute.For<IFilterController>();
            var edgeDetRepository = Substitute.For<IEdgeDetectionController>();

            imageController = new ImageController(filterRepository, edgeDetRepository);

            // Execute test
            imageController.AddFilter(1);

            // Check result 
            Assert.IsTrue(imageController.filters[0] == 1);
        }

        // Test removal of filter
        [TestMethod]
        public void RemoveFilter()
        {
            // Create substitutes for interfaces
            var filterRepository = Substitute.For<IFilterController>();
            var edgeDetRepository = Substitute.For<IEdgeDetectionController>();

            // Create controller
            imageController = new ImageController(filterRepository, edgeDetRepository);

            // Execute
            imageController.AddFilter(1);
            imageController.AddFilter(2);
            imageController.AddFilter(3);
            imageController.RemoveFilter(1);

            // Create test data
            List<int> testList = new List<int> { 1, 2, 3 };
            testList.RemoveAt(1);

            // Compare
            // TODO : improve
            Assert.IsTrue(imageController.filters.Count == testList.Count);
        }

        // Test additon of edge detection
        [TestMethod]
        public void AddEdgeDetection()
        {
            // Create substitutes for interfaces
            var filterRepository = Substitute.For<IFilterController>();
            var edgeDetRepository = Substitute.For<IEdgeDetectionController>();

            imageController = new ImageController(filterRepository, edgeDetRepository);

            // Execute test
            imageController.AddEdgeDetection(1);

            // Check result 
            Assert.IsTrue(imageController.edgeDetections[0] == 1);
        }

        // Test removal of edge detection
        [TestMethod]
        public void RemoveEdgeDetection()
        {
            // Create substitutes for interfaces
            var filterRepository = Substitute.For<IFilterController>();
            var edgeDetRepository = Substitute.For<IEdgeDetectionController>();

            // Create controller
            imageController = new ImageController(filterRepository, edgeDetRepository);

            // Execute
            imageController.AddEdgeDetection(1);
            imageController.AddEdgeDetection(2);
            imageController.AddEdgeDetection(3);
            imageController.RemoveEdgeDetection(1);

            // Create test data
            List<int> testList = new List<int> { 1, 2, 3 };
            testList.RemoveAt(1);

            // Compare
            // TODO : improve
            Assert.IsTrue(imageController.edgeDetections.Count == testList.Count);
        }

        // Test application of filters
        [TestMethod()]
        public void ApplyFilters()
        {
            // Create substitutes for interfaces
            var filterRepository = Substitute.For<IFilterController>();
            var edgeDetRepository = Substitute.For<IEdgeDetectionController>();

            // Create controller
            imageController = new ImageController(filterRepository, edgeDetRepository);
            imageController.AddFilter(1);

            // Get resource images
            ImageModel original = new ImageModel(
                Properties.Resources.Smiley,
                nameof(Properties.Resources.Smiley));

            ImageModel result = new ImageModel(
                Properties.Resources.SmileySwap,
                nameof(Properties.Resources.Smiley));

            // Force result of filter so we don't have to calculate it
            filterRepository.ApplySwapFilter(original).Returns<ImageModel>(result);

            // Execute test
            ImageModel testImage = imageController.ApplyFilters(original);

            // Get hash of images
            string originalHash = TestFunctions.GetImageHash(result);
            string testHash = TestFunctions.GetImageHash(testImage);

            // Comparison
            Assert.AreEqual(originalHash, testHash);
        }

        // Test application of edge detections
        [TestMethod]
        public void ApplyEdgeDetection()
        {
            // Create substitutes for interfaces
            var filterRepository = Substitute.For<IFilterController>();
            var edgeDetRepository = Substitute.For<IEdgeDetectionController>();

            // Create controller
            imageController = new ImageController(filterRepository, edgeDetRepository);
            imageController.AddEdgeDetection(0);

            // Get resource images
            ImageModel original = new ImageModel(
                Properties.Resources.Smiley,
                nameof(Properties.Resources.Smiley));

            ImageModel result = new ImageModel(
                Properties.Resources.SmileyEdgeLaplacian,
                nameof(Properties.Resources.SmileyEdgeLaplacian));

            // Force result of edgeDetection so we don't have to calculate it
            edgeDetRepository.ApplyLaplacian3x3(original).Returns<ImageModel>(result);

            // Execute test
            ImageModel testImage = imageController.ApplyEdgeDetection(original);

            // Get hash of images
            string resultImageHash = TestFunctions.GetImageHash(result);
            string realResultImageHash = TestFunctions.GetImageHash(testImage);

            // Comparison
            Assert.AreEqual(resultImageHash, realResultImageHash);
        }

        // Test preview image
        [TestMethod]
        public void GetPreviewImage()
        {
            int PREVIEW_IMAGE_SIZE = 500;

            // Create substitutes for interfaces
            var filterRepository = Substitute.For<IFilterController>();
            var edgeDetRepository = Substitute.For<IEdgeDetectionController>();

            // Create controller
            imageController = new ImageController(filterRepository, edgeDetRepository);

            // Get resource images
            ImageModel original = new ImageModel(
                Properties.Resources.Smiley,
                nameof(Properties.Resources.Smiley));

            // Perform test
            imageController.image = original;
            ImageModel testImage = imageController.GetPreviewImage(PREVIEW_IMAGE_SIZE);

            // Check rendered preview image is the correct size
            Assert.IsTrue(testImage.width == PREVIEW_IMAGE_SIZE);
        }
    }
}
