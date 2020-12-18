namespace image_modification
{
    interface IImageController
    {
        ImageModel getPreviewImage(int canvasSize);
        ImageModel getResultImage();
    }
}
