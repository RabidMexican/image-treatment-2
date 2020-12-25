
namespace image_modification.views
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.previewImage = new System.Windows.Forms.PictureBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.panelLoadImage = new System.Windows.Forms.Panel();
            this.labelStep1 = new System.Windows.Forms.Label();
            this.panelDesignImage = new System.Windows.Forms.Panel();
            this.labelTipps1 = new System.Windows.Forms.Label();
            this.labelTipps2 = new System.Windows.Forms.Label();
            this.labelTipps = new System.Windows.Forms.Label();
            this.labelStep4 = new System.Windows.Forms.Label();
            this.labelStep3 = new System.Windows.Forms.Label();
            this.labelStep2 = new System.Windows.Forms.Label();
            this.panelEdgeDetections = new System.Windows.Forms.Panel();
            this.checkBoxEdgePrewitt = new System.Windows.Forms.CheckBox();
            this.checkBoxEdgeLaplacian = new System.Windows.Forms.CheckBox();
            this.checkBoxEdgeKirsh = new System.Windows.Forms.CheckBox();
            this.labelEdgeDetections = new System.Windows.Forms.Label();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.checkboxFiltersDone = new System.Windows.Forms.CheckBox();
            this.checkboxBlackWhiteFilter = new System.Windows.Forms.CheckBox();
            this.checkboxSwapFilter = new System.Windows.Forms.CheckBox();
            this.checkboxRainbowFilter = new System.Windows.Forms.CheckBox();
            this.labelFilters = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.previewImage)).BeginInit();
            this.panelLoadImage.SuspendLayout();
            this.panelDesignImage.SuspendLayout();
            this.panelEdgeDetections.SuspendLayout();
            this.panelFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // previewImage
            // 
            this.previewImage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.previewImage.Location = new System.Drawing.Point(78, 42);
            this.previewImage.Margin = new System.Windows.Forms.Padding(4);
            this.previewImage.Name = "previewImage";
            this.previewImage.Size = new System.Drawing.Size(600, 600);
            this.previewImage.TabIndex = 1;
            this.previewImage.TabStop = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(158, 698);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(143, 39);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save Image";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.OnbuttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoad.Location = new System.Drawing.Point(304, 698);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(143, 39);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Load Image";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.OnButtonLoadClick);
            // 
            // panelLoadImage
            // 
            this.panelLoadImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.panelLoadImage.Controls.Add(this.labelStep1);
            this.panelLoadImage.Controls.Add(this.panelDesignImage);
            this.panelLoadImage.Controls.Add(this.previewImage);
            this.panelLoadImage.Controls.Add(this.buttonLoad);
            this.panelLoadImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLoadImage.Location = new System.Drawing.Point(0, 0);
            this.panelLoadImage.Name = "panelLoadImage";
            this.panelLoadImage.Size = new System.Drawing.Size(1407, 775);
            this.panelLoadImage.TabIndex = 3;
            this.panelLoadImage.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLoadImage_Paint);
            // 
            // labelStep1
            // 
            this.labelStep1.AutoSize = true;
            this.labelStep1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStep1.ForeColor = System.Drawing.Color.White;
            this.labelStep1.Location = new System.Drawing.Point(250, 698);
            this.labelStep1.Name = "labelStep1";
            this.labelStep1.Size = new System.Drawing.Size(47, 39);
            this.labelStep1.TabIndex = 1;
            this.labelStep1.Text = "1)";
            // 
            // panelDesignImage
            // 
            this.panelDesignImage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelDesignImage.Controls.Add(this.labelTipps1);
            this.panelDesignImage.Controls.Add(this.labelTipps2);
            this.panelDesignImage.Controls.Add(this.labelTipps);
            this.panelDesignImage.Controls.Add(this.labelStep4);
            this.panelDesignImage.Controls.Add(this.labelStep3);
            this.panelDesignImage.Controls.Add(this.labelStep2);
            this.panelDesignImage.Controls.Add(this.panelEdgeDetections);
            this.panelDesignImage.Controls.Add(this.buttonSave);
            this.panelDesignImage.Controls.Add(this.panelFilters);
            this.panelDesignImage.Location = new System.Drawing.Point(767, 0);
            this.panelDesignImage.Name = "panelDesignImage";
            this.panelDesignImage.Size = new System.Drawing.Size(473, 775);
            this.panelDesignImage.TabIndex = 4;
            // 
            // labelTipps1
            // 
            this.labelTipps1.AutoSize = true;
            this.labelTipps1.Location = new System.Drawing.Point(17, 67);
            this.labelTipps1.Name = "labelTipps1";
            this.labelTipps1.Size = new System.Drawing.Size(437, 17);
            this.labelTipps1.TabIndex = 9;
            this.labelTipps1.Text = "- You can uncheck the validation if you want to edit your filters again";
            // 
            // labelTipps2
            // 
            this.labelTipps2.AutoSize = true;
            this.labelTipps2.Location = new System.Drawing.Point(17, 50);
            this.labelTipps2.Name = "labelTipps2";
            this.labelTipps2.Size = new System.Drawing.Size(410, 17);
            this.labelTipps2.TabIndex = 8;
            this.labelTipps2.Text = "- You have to validate your filters before to add edge detections";
            // 
            // labelTipps
            // 
            this.labelTipps.AutoSize = true;
            this.labelTipps.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipps.Location = new System.Drawing.Point(16, 25);
            this.labelTipps.Name = "labelTipps";
            this.labelTipps.Size = new System.Drawing.Size(67, 20);
            this.labelTipps.TabIndex = 9;
            this.labelTipps.Text = "Tipps :";
            // 
            // labelStep4
            // 
            this.labelStep4.AutoSize = true;
            this.labelStep4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStep4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.labelStep4.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.labelStep4.Location = new System.Drawing.Point(104, 698);
            this.labelStep4.Name = "labelStep4";
            this.labelStep4.Size = new System.Drawing.Size(47, 39);
            this.labelStep4.TabIndex = 8;
            this.labelStep4.Text = "4)";
            // 
            // labelStep3
            // 
            this.labelStep3.AutoSize = true;
            this.labelStep3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStep3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.labelStep3.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.labelStep3.Location = new System.Drawing.Point(13, 412);
            this.labelStep3.Name = "labelStep3";
            this.labelStep3.Size = new System.Drawing.Size(47, 39);
            this.labelStep3.TabIndex = 7;
            this.labelStep3.Text = "3)";
            // 
            // labelStep2
            // 
            this.labelStep2.AutoSize = true;
            this.labelStep2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStep2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.labelStep2.Location = new System.Drawing.Point(13, 135);
            this.labelStep2.Name = "labelStep2";
            this.labelStep2.Size = new System.Drawing.Size(47, 39);
            this.labelStep2.TabIndex = 6;
            this.labelStep2.Text = "2)";
            // 
            // panelEdgeDetections
            // 
            this.panelEdgeDetections.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.panelEdgeDetections.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEdgeDetections.Controls.Add(this.checkBoxEdgePrewitt);
            this.panelEdgeDetections.Controls.Add(this.checkBoxEdgeLaplacian);
            this.panelEdgeDetections.Controls.Add(this.checkBoxEdgeKirsh);
            this.panelEdgeDetections.Controls.Add(this.labelEdgeDetections);
            this.panelEdgeDetections.Location = new System.Drawing.Point(66, 412);
            this.panelEdgeDetections.Name = "panelEdgeDetections";
            this.panelEdgeDetections.Size = new System.Drawing.Size(341, 161);
            this.panelEdgeDetections.TabIndex = 5;
            this.panelEdgeDetections.Paint += new System.Windows.Forms.PaintEventHandler(this.panelEdgeDetections_Paint);
            // 
            // checkBoxEdgePrewitt
            // 
            this.checkBoxEdgePrewitt.AutoSize = true;
            this.checkBoxEdgePrewitt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxEdgePrewitt.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.checkBoxEdgePrewitt.Location = new System.Drawing.Point(75, 117);
            this.checkBoxEdgePrewitt.Name = "checkBoxEdgePrewitt";
            this.checkBoxEdgePrewitt.Size = new System.Drawing.Size(157, 24);
            this.checkBoxEdgePrewitt.TabIndex = 9;
            this.checkBoxEdgePrewitt.Text = "Edge Prewitt 3x3";
            this.checkBoxEdgePrewitt.UseVisualStyleBackColor = true;
            this.checkBoxEdgePrewitt.CheckedChanged += new System.EventHandler(this.checkBoxEdgePrewitt_CheckedChanged);
            // 
            // checkBoxEdgeLaplacian
            // 
            this.checkBoxEdgeLaplacian.AutoSize = true;
            this.checkBoxEdgeLaplacian.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxEdgeLaplacian.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.checkBoxEdgeLaplacian.Location = new System.Drawing.Point(75, 87);
            this.checkBoxEdgeLaplacian.Name = "checkBoxEdgeLaplacian";
            this.checkBoxEdgeLaplacian.Size = new System.Drawing.Size(177, 24);
            this.checkBoxEdgeLaplacian.TabIndex = 8;
            this.checkBoxEdgeLaplacian.Text = "Edge Laplacian 3x3";
            this.checkBoxEdgeLaplacian.UseVisualStyleBackColor = true;
            this.checkBoxEdgeLaplacian.CheckedChanged += new System.EventHandler(this.checkBoxEdgeLaplacian_CheckedChanged);
            // 
            // checkBoxEdgeKirsh
            // 
            this.checkBoxEdgeKirsh.AutoSize = true;
            this.checkBoxEdgeKirsh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxEdgeKirsh.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.checkBoxEdgeKirsh.Location = new System.Drawing.Point(75, 57);
            this.checkBoxEdgeKirsh.Name = "checkBoxEdgeKirsh";
            this.checkBoxEdgeKirsh.Size = new System.Drawing.Size(122, 24);
            this.checkBoxEdgeKirsh.TabIndex = 7;
            this.checkBoxEdgeKirsh.Text = "Edge Kirsch";
            this.checkBoxEdgeKirsh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxEdgeKirsh.UseVisualStyleBackColor = true;
            this.checkBoxEdgeKirsh.CheckedChanged += new System.EventHandler(this.checkBoxEdgeKirsh_CheckedChanged);
            // 
            // labelEdgeDetections
            // 
            this.labelEdgeDetections.AutoSize = true;
            this.labelEdgeDetections.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEdgeDetections.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelEdgeDetections.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelEdgeDetections.Location = new System.Drawing.Point(86, 10);
            this.labelEdgeDetections.Name = "labelEdgeDetections";
            this.labelEdgeDetections.Size = new System.Drawing.Size(167, 25);
            this.labelEdgeDetections.TabIndex = 0;
            this.labelEdgeDetections.Text = "Edge detections";
            this.labelEdgeDetections.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelFilters
            // 
            this.panelFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.panelFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilters.Controls.Add(this.checkboxFiltersDone);
            this.panelFilters.Controls.Add(this.checkboxBlackWhiteFilter);
            this.panelFilters.Controls.Add(this.checkboxSwapFilter);
            this.panelFilters.Controls.Add(this.checkboxRainbowFilter);
            this.panelFilters.Controls.Add(this.labelFilters);
            this.panelFilters.Location = new System.Drawing.Point(66, 138);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(341, 187);
            this.panelFilters.TabIndex = 4;
            // 
            // checkboxFiltersDone
            // 
            this.checkboxFiltersDone.AutoSize = true;
            this.checkboxFiltersDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxFiltersDone.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.checkboxFiltersDone.Location = new System.Drawing.Point(13, 158);
            this.checkboxFiltersDone.Name = "checkboxFiltersDone";
            this.checkboxFiltersDone.Size = new System.Drawing.Size(91, 24);
            this.checkboxFiltersDone.TabIndex = 9;
            this.checkboxFiltersDone.Text = "Validate";
            this.checkboxFiltersDone.UseVisualStyleBackColor = true;
            this.checkboxFiltersDone.CheckedChanged += new System.EventHandler(this.checkboxFiltersDone_CheckedChanged);
            // 
            // checkboxBlackWhiteFilter
            // 
            this.checkboxBlackWhiteFilter.AutoSize = true;
            this.checkboxBlackWhiteFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxBlackWhiteFilter.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.checkboxBlackWhiteFilter.Location = new System.Drawing.Point(75, 111);
            this.checkboxBlackWhiteFilter.Name = "checkboxBlackWhiteFilter";
            this.checkboxBlackWhiteFilter.Size = new System.Drawing.Size(191, 24);
            this.checkboxBlackWhiteFilter.TabIndex = 8;
            this.checkboxBlackWhiteFilter.Text = "Black and White filter";
            this.checkboxBlackWhiteFilter.UseVisualStyleBackColor = true;
            this.checkboxBlackWhiteFilter.CheckedChanged += new System.EventHandler(this.checkboxBlackWhiteFilter_CheckedChanged);
            // 
            // checkboxSwapFilter
            // 
            this.checkboxSwapFilter.AutoSize = true;
            this.checkboxSwapFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxSwapFilter.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.checkboxSwapFilter.Location = new System.Drawing.Point(75, 81);
            this.checkboxSwapFilter.Name = "checkboxSwapFilter";
            this.checkboxSwapFilter.Size = new System.Drawing.Size(110, 24);
            this.checkboxSwapFilter.TabIndex = 7;
            this.checkboxSwapFilter.Text = "Swap filter";
            this.checkboxSwapFilter.UseVisualStyleBackColor = true;
            this.checkboxSwapFilter.CheckedChanged += new System.EventHandler(this.checkboxSwapFilter_CheckedChanged);
            // 
            // checkboxRainbowFilter
            // 
            this.checkboxRainbowFilter.AutoSize = true;
            this.checkboxRainbowFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxRainbowFilter.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.checkboxRainbowFilter.Location = new System.Drawing.Point(75, 51);
            this.checkboxRainbowFilter.Name = "checkboxRainbowFilter";
            this.checkboxRainbowFilter.Size = new System.Drawing.Size(133, 24);
            this.checkboxRainbowFilter.TabIndex = 6;
            this.checkboxRainbowFilter.Text = "Rainbow filter";
            this.checkboxRainbowFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkboxRainbowFilter.UseVisualStyleBackColor = true;
            this.checkboxRainbowFilter.CheckedChanged += new System.EventHandler(this.checkboxRainbowFilter_CheckedChanged);
            // 
            // labelFilters
            // 
            this.labelFilters.AutoSize = true;
            this.labelFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFilters.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelFilters.Location = new System.Drawing.Point(128, 10);
            this.labelFilters.Name = "labelFilters";
            this.labelFilters.Size = new System.Drawing.Size(71, 25);
            this.labelFilters.TabIndex = 0;
            this.labelFilters.Text = "Filters";
            this.labelFilters.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 775);
            this.Controls.Add(this.panelLoadImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "Image Modification - Group 19";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.previewImage)).EndInit();
            this.panelLoadImage.ResumeLayout(false);
            this.panelLoadImage.PerformLayout();
            this.panelDesignImage.ResumeLayout(false);
            this.panelDesignImage.PerformLayout();
            this.panelEdgeDetections.ResumeLayout(false);
            this.panelEdgeDetections.PerformLayout();
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox previewImage;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Panel panelLoadImage;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label labelFilters;
        private System.Windows.Forms.Panel panelDesignImage;
        private System.Windows.Forms.Panel panelEdgeDetections;
        private System.Windows.Forms.Label labelEdgeDetections;
        private System.Windows.Forms.CheckBox checkboxBlackWhiteFilter;
        private System.Windows.Forms.CheckBox checkboxSwapFilter;
        private System.Windows.Forms.CheckBox checkboxRainbowFilter;
        private System.Windows.Forms.CheckBox checkboxFiltersDone;
        private System.Windows.Forms.Label labelStep1;
        private System.Windows.Forms.Label labelStep3;
        private System.Windows.Forms.Label labelStep2;
        private System.Windows.Forms.Label labelStep4;
        private System.Windows.Forms.CheckBox checkBoxEdgePrewitt;
        private System.Windows.Forms.CheckBox checkBoxEdgeLaplacian;
        private System.Windows.Forms.CheckBox checkBoxEdgeKirsh;
        private System.Windows.Forms.Label labelTipps1;
        private System.Windows.Forms.Label labelTipps;
        private System.Windows.Forms.Label labelTipps2;
    }
}

