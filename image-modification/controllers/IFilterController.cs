namespace image_modification
{
    interface IFilterController
    {
        ImageModel ApplyRainbowFilter(ImageModel image);
        ImageModel ApplySwapFilter(ImageModel image);
        ImageModel ApplyBlackWhiteFilter(ImageModel image);
    }
}
