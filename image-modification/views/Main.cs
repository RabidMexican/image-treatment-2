using System;
using System.Drawing;
using System.Windows.Forms;
using image_modification.controllers.classes;

namespace image_modification.views
{
    public partial class Main : Form
    {
        private const int PREVIEW_WIDTH = 400;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Executes first, as soon as form is ready
        }

        private void OnButtonLoadClick(object sender, EventArgs e)
        {
            // Create and define parameters for image interface 
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select an image file";
            ofd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
            ofd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

            // If OK is clicked
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ImageModel image = new ImageModel(ofd.FileName);
                IImageController imageController = new ImageController(image);

                Bitmap myBitmap = imageController.getPreviewImage(PREVIEW_WIDTH).getImage();
                previewImage.Image = myBitmap;
            }
        }
    }
}
