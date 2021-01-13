using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using image_modification.controllers;
using image_modification.controllers.classes;

namespace image_modification.views
{
    public partial class Main : Form
    {
        private const int PREVIEW_WIDTH = 450;
        private const int
                    FILTER_RAINBOW = 0,
                    FILTER_SWAP = 1,
                    FILTER_BLACKWHITE = 2,
                    EDGE_LAPLACIAN_3X3 = 0,
                    EDGE_PREWITT_3X3 = 1,
                    EDGE_KIRSCH = 2;

        private ImageController imageController = new ImageController(new FilterController(), new EdgeDetectionController());

        public Main()
        {
            InitializeComponent();
            ToggleEdgeDetections(false);
            ToggleFilters(false);
            buttonSave.Enabled = false;
            checkboxFiltersDone.Enabled = false;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Executes first, as soon as form is ready
        }
        
        // EDGE DETECTIONS

        //add or remove the edge detection Kirsh
        private void ToggleKirsch(object sender, EventArgs e)
        {
            if (checkBoxEdgeKirsh.Checked) imageController.AddEdgeDetection(EDGE_KIRSCH);
            else imageController.RemoveEdgeDetection(EDGE_KIRSCH);
            UpdatePreviewImage();
        }

        // Toggle Laplacian 3x3
        private void ToggleLaplacian3x3(object sender, EventArgs e)
        {
            if (checkBoxEdgeLaplacian.Checked) imageController.AddEdgeDetection(EDGE_LAPLACIAN_3X3);
            else imageController.RemoveEdgeDetection(EDGE_LAPLACIAN_3X3);
            UpdatePreviewImage();
        }

        //add or remove the edge detection Prewitt 3x3
        private void TogglePrewitt(object sender, EventArgs e)
        {
            if (checkBoxEdgePrewitt.Checked) imageController.AddEdgeDetection(EDGE_PREWITT_3X3);
            else imageController.RemoveEdgeDetection(EDGE_PREWITT_3X3);
            UpdatePreviewImage();
        }

        // Reset all edge detections
        private void ResetEdgeDetections()
        {
            imageController.RemoveEdgeDetection(EDGE_PREWITT_3X3);
            imageController.RemoveEdgeDetection(EDGE_LAPLACIAN_3X3);
            imageController.RemoveEdgeDetection(EDGE_KIRSCH);

            checkBoxEdgeKirsh.Checked = false;
            checkBoxEdgeLaplacian.Checked = false;
            checkBoxEdgePrewitt.Checked = false;
        }

        // Toggle all edge detections
        private void ToggleEdgeDetections(bool status)
        {
            checkBoxEdgeKirsh.Enabled = status;
            checkBoxEdgeLaplacian.Enabled = status;
            checkBoxEdgePrewitt.Enabled = status;
        }

        // FILTERS

        // Toggle Black & White filter
        private void ToggleBlackWhiteFilter(object sender, EventArgs e)
        {
            if (checkboxBlackWhiteFilter.Checked) imageController.AddFilter(FILTER_BLACKWHITE);
            else imageController.RemoveFilter(FILTER_BLACKWHITE);
            UpdatePreviewImage();
        }

        // Toggle Rainbow filter
        private void ToggleRainbowFilter(object sender, EventArgs e)
        {
            if (checkboxRainbowFilter.Checked) imageController.AddFilter(FILTER_RAINBOW);
            else imageController.RemoveFilter(FILTER_RAINBOW);
            UpdatePreviewImage();
        }

        // Toggle Swap filter
        private void ToggleSwapFilter(object sender, EventArgs e)
        {
            if (checkboxSwapFilter.Checked) imageController.AddFilter(FILTER_SWAP);
            else imageController.RemoveFilter(FILTER_SWAP);
            UpdatePreviewImage();
        }

        // Upates the preview image
        private void UpdatePreviewImage()
        {
            previewImage.Image = imageController.GetResultImage(PREVIEW_WIDTH).GetBitmapImage();
        }

        // Reset all filters
        private void ResetFilters()
        {
            imageController.RemoveFilter(FILTER_SWAP);
            imageController.RemoveFilter(FILTER_RAINBOW);
            imageController.RemoveFilter(FILTER_BLACKWHITE);
            checkboxSwapFilter.Checked = false;
            checkboxRainbowFilter.Checked = false;
            checkboxBlackWhiteFilter.Checked = false;
            checkboxFiltersDone.Checked = false;
        }

        // Toggle all filters
        private void ToggleFilters(bool status)
        {
            checkboxRainbowFilter.Enabled = status;
            checkboxBlackWhiteFilter.Enabled = status;
            checkboxSwapFilter.Enabled = status;
        }

        // Validate the filters
        private void ValidateFilters(object sender, EventArgs e)
        {
            if (checkboxFiltersDone.Checked)
            {
                ToggleFilters(false);
                ToggleEdgeDetections(true);
            }
            else
            {
                ToggleFilters(true);
                ToggleEdgeDetections(false);
                ResetEdgeDetections();
            }
            UpdatePreviewImage();
        }

        // Button to save the new image
        private void OnbuttonSave_Click(object sender, EventArgs e)
        {
            // Open file save dialog window 
            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "Specify a file name and file path",
                Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg|Bitmap Images(*.bmp)|*.bmp"
            };

            // If OK is clicked
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                imageController.SaveImage(sfd.FileName);
            }
                
        }
 
        // Button to load an image for treatment
        private void OnButtonLoadClick(object sender, EventArgs e)
        {
            // Open file explorer dialog to choose an image 
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Select an image file",
                Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg|Bitmap Images(*.bmp)|*.bmp"
            };

            // If OK is clicked
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Loads an image from the image controller
                bool imageLoaded = imageController.LoadImage(ofd.FileName);

                if (imageLoaded)
                {
                    // Reset filters and update image
                    ResetFilters();
                    ResetEdgeDetections();
                    UpdatePreviewImage();

                    //if image correctly loaded we can add filters or save the new picture
                    ToggleFilters(true);
                    buttonSave.Enabled = true;
                    checkboxFiltersDone.Enabled = true;
                }
            }

            
        }
    }
}
