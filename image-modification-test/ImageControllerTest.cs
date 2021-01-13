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

        private ImageModel original         = new ImageModel(Properties.Resources.Smiley, nameof(Properties.Resources.Smiley));
        private ImageModel original_swap    = new ImageModel(Properties.Resources.SmileySwap, nameof(Properties.Resources.SmileySwap));
        private ImageModel original_black   = new ImageModel(Properties.Resources.SmileyBlackAndWhite, nameof(Properties.Resources.SmileyBlackAndWhite));
        private ImageModel original_rainbow = new ImageModel(Properties.Resources.SmileyRainbow, nameof(Properties.Resources.SmileyRainbow));
        private ImageModel original_kirsh   = new ImageModel(Properties.Resources.SmileyEdgeKirsh, nameof(Properties.Resources.SmileyEdgeKirsh));
        private ImageModel original_lap     = new ImageModel(Properties.Resources.SmileyEdgeLaplacian, nameof(Properties.Resources.SmileyEdgeLaplacian));
        private ImageModel original_prewitt = new ImageModel(Properties.Resources.SmileyEdgePrewitt, nameof(Properties.Resources.SmileyEdgePrewitt));

        private ImageModel original_high = new ImageModel(Properties.Resources.bag, nameof(Properties.Resources.bag));
        private ImageModel original_bmp = new ImageModel(Properties.Resources.pikachu, nameof(Properties.Resources.pikachu));

        // Test saving image
        [TestMethod]
        public void SaveImage()
        {
            string path = @"C:\Tests\Smiley.png";

            // Create substitutes for interfaces
            var filterRepository = Substitute.For<IFilterController>();
            var edgeDetRepository = Substitute.For<IEdgeDetectionController>();
            imageController = new ImageController(filterRepository, edgeDetRepository);

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

        [TestMethod]
        public void SaveImage_Exception_DirectoryNotFound()
        {
            string path = @"Z:\Tests\Smiley.png";

            // Create substitutes for interfaces
            var filterRepository = Substitute.For<IFilterController>();
            var edgeDetRepository = Substitute.For<IEdgeDetectionController>();

            imageController = new ImageController(filterRepository, edgeDetRepository);
            imageController.image = original;

            // Check that Save Image does not throw an exception
            try
            {
                imageController.SaveImage(path);
            }
            catch(DirectoryNotFoundException e)
            {
                Assert.Fail();
            }
            // If no exception was thrown the test passes
            Assert.IsTrue(true);
        }

        // Test loading of image
        [TestMethod]
        public void LoadImage()
        {
            string path = @"C:\Tests\Smiley.png";

            // Create substitutes for interfaces
            var filterRepository = Substitute.For<IFilterController>();
            var edgeDetRepository = Substitute.For<IEdgeDetectionController>();

            // Create controller
            imageController = new ImageController(filterRepository, edgeDetRepository);
            imageController.LoadImage(path);

            // Get hash of images
            string originalHash = TestFunctions.GetImageHash(original);
            string testHash= TestFunctions.GetImageHash(imageController.image);

            // Comparison
            Assert.AreEqual(originalHash, testHash);
        }

        // Test loading of image
        [TestMethod]
        public void LoadImage_Exception()
        {
            string path = @"Z:\Tests\Smiley.png";

            // Create substitutes for interfaces
            var filterRepository = Substitute.For<IFilterController>();
            var edgeDetRepository = Substitute.For<IEdgeDetectionController>();

            imageController = new ImageController(filterRepository, edgeDetRepository);
            bool test = true;

            // Create controller
            try
            {
                test = imageController.LoadImage(path);
            } 
            catch (DirectoryNotFoundException)
            {
                Assert.Fail();
            }
            Assert.AreEqual(test, false);
        }

        // Test image result
        [TestMethod]
        public void GetResultImage_Preview()
        {
            // Create substitutes for interfaces
            var filterRepository = Substitute.For<IFilterController>();
            var edgeDetRepository = Substitute.For<IEdgeDetectionController>();

            // Create controller
            imageController = new ImageController(filterRepository, edgeDetRepository);
            imageController.image = original;

            // Exectute test
            ImageModel previewImage = imageController.GetPreviewImage(500);
            ImageModel testImage = imageController.GetResultImage(500);

            // Compare
            string originalHash = TestFunctions.GetImageHash(previewImage);
            string testHash = TestFunctions.GetImageHash(testImage);
            Assert.AreEqual(originalHash, testHash);
        }

        [TestMethod]
        public void GetResultImage_Full()
        {
            // Create substitutes for interfaces
            var filterRepository = Substitute.For<IFilterController>();
            var edgeDetRepository = Substitute.For<IEdgeDetectionController>();

            // Create controller
            imageController = new ImageController(filterRepository, edgeDetRepository);
            imageController.image = original;

            // Exectute test
            ImageModel testImage = imageController.GetResultImage();

            // Compare
            string originalHash = TestFunctions.GetImageHash(original);
            string testHash = TestFunctions.GetImageHash(testImage);
            Assert.AreEqual(originalHash, testHash);
        }

        // Test additon of filter
        [TestMethod]
        public void AddFilter()
        {
            // Create substitutes for interfaces
            var filterRepository = Substitute.For<IFilterController>();
            var edgeDetRepository = Substitute.For<IEdgeDetectionController>();

            // Execute test
            imageController = new ImageController(filterRepository, edgeDetRepository);
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
        [TestMethod]
        public void ApplyFilters_Rainbow()
        {
            // Create substitutes for interfaces
            var filterRepository = Substitute.For<IFilterController>();
            var edgeDetRepository = Substitute.For<IEdgeDetectionController>();

            // Create controller
            imageController = new ImageController(filterRepository, edgeDetRepository);
            imageController.AddFilter(0);

            // Force result of filter so we don't have to calculate it
            filterRepository.ApplyRainbowFilter(original).Returns(original_rainbow);

            // Execute test
            ImageModel testImage = imageController.ApplyFilters(original);

            // Get hash of images
            string originalHash = TestFunctions.GetImageHash(original_rainbow);
            string testHash = TestFunctions.GetImageHash(testImage);

            // Comparison
            Assert.AreEqual(originalHash, testHash);
        }

        // Test application of filters
        [TestMethod]
        public void ApplyFilters_Swap()
        {
            // Create substitutes for interfaces
            var filterRepository = Substitute.For<IFilterController>();
            var edgeDetRepository = Substitute.For<IEdgeDetectionController>();

            // Create controller
            imageController = new ImageController(filterRepository, edgeDetRepository);
            imageController.AddFilter(1);

            // Force result of filter so we don't have to calculate it
            filterRepository.ApplySwapFilter(original).Returns(original_swap);

            // Execute test
            ImageModel testImage = imageController.ApplyFilters(original);

            // Get hash of images
            string originalHash = TestFunctions.GetImageHash(original_swap);
            string testHash = TestFunctions.GetImageHash(testImage);

            // Comparison
            Assert.AreEqual(originalHash, testHash);
        }

        // Test application of filters
        [TestMethod]
        public void ApplyFilters_BlackAndWhite()
        {
            // Create substitutes for interfaces
            var filterRepository = Substitute.For<IFilterController>();
            var edgeDetRepository = Substitute.For<IEdgeDetectionController>();

            // Create controller
            imageController = new ImageController(filterRepository, edgeDetRepository);
            imageController.AddFilter(2);

            // Force result of filter so we don't have to calculate it
            filterRepository.ApplyBlackWhiteFilter(original).Returns(original_black);

            // Execute test
            ImageModel testImage = imageController.ApplyFilters(original);

            // Get hash of images
            string originalHash = TestFunctions.GetImageHash(original_black);
            string testHash = TestFunctions.GetImageHash(testImage);

            // Comparison
            Assert.AreEqual(originalHash, testHash);
        }

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
            imageController.image = original;

            // Perform test
            ImageModel testImage = imageController.GetPreviewImage(PREVIEW_IMAGE_SIZE);

            // Check rendered preview image is the correct size
            Assert.IsTrue(testImage.width == PREVIEW_IMAGE_SIZE);
        }

        [TestMethod]
        public void GetPreviewImage_High()
        {
            int PREVIEW_IMAGE_SIZE = 500;

            // Create substitutes for interfaces
            var filterRepository = Substitute.For<IFilterController>();
            var edgeDetRepository = Substitute.For<IEdgeDetectionController>();

            // Create controller
            imageController = new ImageController(filterRepository, edgeDetRepository);
            imageController.image = original_high;

            // Perform test
            ImageModel testImage = imageController.GetPreviewImage(PREVIEW_IMAGE_SIZE);

            // Check rendered preview image is the correct size
            Assert.IsTrue(testImage.height == PREVIEW_IMAGE_SIZE);
        }
    }
}
