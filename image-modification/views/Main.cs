using System;
using System.Drawing;
using System.Windows.Forms;
using image_modification.controllers.classes;

namespace image_modification.views
{
    public partial class Main : Form
    {
        private const int PREVIEW_WIDTH = 400;
        private const int
                    FILTER_RAINBOW = 0,
                    FILTER_SWAP = 1,
                    FILTER_BLACKWHITE = 2,
                    EDGE_DET_1 = 0,
                    EDGE_DET_2 = 1,
                    EDGE_DET_3 = 2;

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

                imageController.AddFilter(FILTER_SWAP);
                imageController.AddFilter(FILTER_RAINBOW);

                imageController.AddEdgeDetection(EDGE_DET_1);
                imageController.AddEdgeDetection(EDGE_DET_2);
                imageController.AddEdgeDetection(EDGE_DET_3);

                previewImage.Image = imageController.GetResultImage(PREVIEW_WIDTH).getImage();
            }
        }
    }
}
