using image_modification;
using image_modification.controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace image_modification_test.ImageControllerTests
{
    [TestClass]
    public class ApplyFiltersTests
    {
        private ImageController imageController;

        private ImageModel original         = new ImageModel(Properties.Resources.Smiley, nameof(Properties.Resources.Smiley));
        private ImageModel original_swap    = new ImageModel(Properties.Resources.SmileySwap, nameof(Properties.Resources.SmileySwap));
        private ImageModel original_black   = new ImageModel(Properties.Resources.SmileyBlackAndWhite, nameof(Properties.Resources.SmileyBlackAndWhite));
        private ImageModel original_rainbow = new ImageModel(Properties.Resources.SmileyRainbow, nameof(Properties.Resources.SmileyRainbow));

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
        public void ApplyFilters_Rainbow_Exception_NullReference()
        {
            // Create substitutes for interfaces
            var filterRepository = Substitute.For<IFilterController>();
            var edgeDetRepository = Substitute.For<IEdgeDetectionController>();

            // Force throw Null Reference exception
            filterRepository
                .When(x => x.ApplyRainbowFilter(Arg.Any<ImageModel>()))
                .Do(x => { throw new NullReferenceException(); });

            // Create controller
            imageController = new ImageController(filterRepository, edgeDetRepository);
            imageController.AddFilter(0);

            // Default value for result
            ImageModel result = original;

            // Execute test
            try
            {
                result = imageController.ApplyFilters(original);
            }
            catch (NullReferenceException)
            {
                Assert.Fail("Failed because the filter controller threw an exception");
            }
            // Check that with an exception the result is changed to null
            Assert.AreEqual(result, null);
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
    }
}
