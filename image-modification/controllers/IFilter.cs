namespace image_modification
{
    interface IFilter
    {
        ImageModel Filter1(ImageModel image);
        ImageModel Filter2(ImageModel image);
        ImageModel Filter3(ImageModel image);
    }
}
