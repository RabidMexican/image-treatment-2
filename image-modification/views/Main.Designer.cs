
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
            this.buttonLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.previewImage)).BeginInit();
            this.SuspendLayout();
            // 
            // previewImage
            // 
            this.previewImage.Location = new System.Drawing.Point(178, 10);
            this.previewImage.Name = "previewImage";
            this.previewImage.Size = new System.Drawing.Size(489, 303);
            this.previewImage.TabIndex = 1;
            this.previewImage.TabStop = false;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(416, 339);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Load Image";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.OnButtonLoadClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.previewImage);
            this.Name = "Main";
            this.Text = "Image Modification - Group 19";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.previewImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox previewImage;
        private System.Windows.Forms.Button buttonLoad;
    }
}

