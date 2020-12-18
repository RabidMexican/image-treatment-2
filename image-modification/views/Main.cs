using System;
using System.Drawing;
using System.Windows.Forms;
using image_modification.controllers.classes;

namespace image_modification.views
{
    public partial class Main : Form
    {
        private const int PREVIEW_WIDTH = 400;
        private ImageController imageController;

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
                imageController = new ImageController(image);

                Bitmap myBitmap = imageController.getPreviewImage(PREVIEW_WIDTH).getImage();

                imageController.AddFilter(0);
                imageController.AddFilter(1);
                imageController.AddFilter(2);

                imageController.AddEdgeDetection(2);
                imageController.AddEdgeDetection(1);
                imageController.AddEdgeDetection(0);

                imageController.applyFilters();
                imageController.applyEdgeDetection();

                previewImage.Image = myBitmap;
            }
        }
    }
}
