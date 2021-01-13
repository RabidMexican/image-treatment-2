namespace image_modification
{
 public interface IFilterController
    {
        ImageModel ApplyRainbowFilter(ImageModel image);
        ImageModel ApplySwapFilter(ImageModel image);
        ImageModel ApplyBlackWhiteFilter(ImageModel image);
    }
}
