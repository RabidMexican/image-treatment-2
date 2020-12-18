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

            // If image is selected 
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                BitmapImage image = new BitmapImage(ofd.FileName);
                IImageController ic = new ImageController(image);

                Bitmap myBitmap = ic.getPreviewImage(PREVIEW_WIDTH).getImage();
                previewImage.Image = myBitmap;
            }
        }
    }
}
