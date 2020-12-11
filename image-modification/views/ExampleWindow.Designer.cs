
namespace image_modification.views
{
    partial class ExampleWindow
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
            this.debugTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // debugTextBox
            // 
            this.debugTextBox.Location = new System.Drawing.Point(345, 220);
            this.debugTextBox.Name = "debugTextBox";
            this.debugTextBox.Size = new System.Drawing.Size(100, 20);
            this.debugTextBox.TabIndex = 0;
            this.debugTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ExampleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.debugTextBox);
            this.Name = "ExampleWindow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ExampleWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox debugTextBox;
    }
}

