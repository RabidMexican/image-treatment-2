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
            changeEnabledEdgeDetections(false);
            changeEnabledFilters(false);
            buttonSave.Enabled = false;
            checkboxFiltersDone.Enabled = false;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Executes first, as soon as form is ready
        }


        // Display the two main label


        private void panelEdgeDetections_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelLoadImage_Paint(object sender, PaintEventArgs e)
        {

        }

        //
        // Edge Detections
        //

        //add or remove the edge detection Kirsh
        private void checkBoxEdgeKirsh_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxEdgeKirsh.Checked)
            {
                imageController.AddEdgeDetection(EDGE_KIRSCH);
                previewImage.Image = imageController.GetResultImage(PREVIEW_WIDTH).getImage();
            }
            else
            {
                imageController.RemoveEdgeDetection(EDGE_KIRSCH);
                previewImage.Image = imageController.GetResultImage(PREVIEW_WIDTH).getImage();
            }
        }

        //add or remove the edge detection Laplacian 3x3
        private void checkBoxEdgeLaplacian_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxEdgeLaplacian.Checked)
            {
                imageController.AddEdgeDetection(EDGE_LAPLACIAN_3X3);
                previewImage.Image = imageController.GetResultImage(PREVIEW_WIDTH).getImage();
            }
            else
            {
                imageController.RemoveEdgeDetection(EDGE_LAPLACIAN_3X3);
                previewImage.Image = imageController.GetResultImage(PREVIEW_WIDTH).getImage();
            }

        }

        //add or remove the edge detection Prewitt 3x3
        private void checkBoxEdgePrewitt_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxEdgePrewitt.Checked)
            {
                imageController.AddEdgeDetection(EDGE_PREWITT_3X3);
                previewImage.Image = imageController.GetResultImage(PREVIEW_WIDTH).getImage();
            }
            else
            {
                imageController.RemoveEdgeDetection(EDGE_PREWITT_3X3);
                previewImage.Image = imageController.GetResultImage(PREVIEW_WIDTH).getImage();
            }
        }

        //
        // Disabled/Enabled edge detections
        //
        private void changeEnabledEdgeDetections(bool status)
        {
            checkBoxEdgeKirsh.Enabled = status;
            checkBoxEdgeLaplacian.Enabled = status;
            checkBoxEdgePrewitt.Enabled = status;

        }


        // Reset all edge detections panel actions
        private void resetEdgeDetections()
        {

            imageController.RemoveEdgeDetection(EDGE_PREWITT_3X3);
            imageController.RemoveEdgeDetection(EDGE_LAPLACIAN_3X3);
            imageController.RemoveEdgeDetection(EDGE_KIRSCH);
            checkBoxEdgeKirsh.Checked = false;
            checkBoxEdgeLaplacian.Checked = false;
            checkBoxEdgePrewitt.Checked = false;
        }

        //
        // Filters
        //

        //add or remove the filter black and white
        private void checkboxBlackWhiteFilter_CheckedChanged(object sender, EventArgs e)
        {

            if (checkboxBlackWhiteFilter.Checked)
            {
                imageController.AddFilter(FILTER_BLACKWHITE);
                previewImage.Image = imageController.GetResultImage(PREVIEW_WIDTH).getImage();
            }
            else
            {
                imageController.RemoveFilter(FILTER_BLACKWHITE);
                previewImage.Image = imageController.GetResultImage(PREVIEW_WIDTH).getImage();
            }

        }

        //add or remove the filter rainbow
        private void checkboxRainbowFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxRainbowFilter.Checked)
            {
                imageController.AddFilter(FILTER_RAINBOW);
                previewImage.Image = imageController.GetResultImage(PREVIEW_WIDTH).getImage();
            }
            else
            {
                imageController.RemoveFilter(FILTER_RAINBOW);
                previewImage.Image = imageController.GetResultImage(PREVIEW_WIDTH).getImage();
            }
        }

        //add or remove the filter swap
        private void checkboxSwapFilter_CheckedChanged(object sender, EventArgs e)
        {

            if (checkboxSwapFilter.Checked)
            {
                imageController.AddFilter(FILTER_SWAP);
                previewImage.Image = imageController.GetResultImage(PREVIEW_WIDTH).getImage();
            }
            else
            {
                imageController.RemoveFilter(FILTER_SWAP);
                previewImage.Image = imageController.GetResultImage(PREVIEW_WIDTH).getImage();
            }
        }





        // Reset all filters panel actions
        private void resetFilters()
        {

            imageController.RemoveFilter(FILTER_SWAP);
            imageController.RemoveFilter(FILTER_RAINBOW);
            imageController.RemoveFilter(FILTER_BLACKWHITE);
            checkboxSwapFilter.Checked = false;
            checkboxRainbowFilter.Checked = false;
            checkboxBlackWhiteFilter.Checked = false;
            checkboxFiltersDone.Checked = false;

        }

        // Disabled/Enabled the filters
        private void changeEnabledFilters(bool status)
        {
            checkboxRainbowFilter.Enabled = status;
            checkboxBlackWhiteFilter.Enabled = status;
            checkboxSwapFilter.Enabled = status;

        }
        //
        // Validate the filters
        //yes -> we can add edge detections but no more filters
        //false -> we can add filters but reset edge detection
        //
        private void checkboxFiltersDone_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxFiltersDone.Checked)
            {
                changeEnabledFilters(false);
                changeEnabledEdgeDetections(true);


            }
            else
            {
                changeEnabledFilters(true);
                changeEnabledEdgeDetections(false);
                resetEdgeDetections();
            }
            previewImage.Image = imageController.GetResultImage(PREVIEW_WIDTH).getImage();
        }



        
        // Button to save the new image
        private void OnbuttonSave_Click(object sender, EventArgs e)
        {

        }
 
        // Button to load an image for treatment
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

                
                resetFilters();
                resetEdgeDetections();

                previewImage.Image = imageController.GetResultImage(PREVIEW_WIDTH).getImage();

                //if image correctly loaded we can add filters or save the new picture
                changeEnabledFilters(true);
                buttonSave.Enabled = true;
                checkboxFiltersDone.Enabled = true;



            }
        }
    }
}
