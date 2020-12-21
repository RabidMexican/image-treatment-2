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
                    EDGE_LAPLACIAN_3X3 = 0,
                    EDGE_PREWITT_3X3 = 1,
                    EDGE_KIRSCH = 2;

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

                // add some filters
                imageController.AddFilter(FILTER_SWAP);
                imageController.AddFilter(FILTER_RAINBOW);
                imageController.AddFilter(FILTER_BLACKWHITE);

                // remove some filters
                imageController.RemoveFilter(FILTER_BLACKWHITE);
                imageController.RemoveFilter(FILTER_SWAP);

                // add some edge detections
                imageController.AddEdgeDetection(EDGE_KIRSCH);
                imageController.AddEdgeDetection(EDGE_LAPLACIAN_3X3);
                imageController.AddEdgeDetection(EDGE_PREWITT_3X3);

                // remove some edge detections
                imageController.RemoveEdgeDetection(EDGE_LAPLACIAN_3X3);
                imageController.RemoveEdgeDetection(EDGE_KIRSCH);

                previewImage.Image = imageController.GetResultImage(PREVIEW_WIDTH).getImage();
            }
        }
    }
}
