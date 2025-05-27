namespace FractalCreator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox FernPictureBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.FernPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FernPictureBox)).BeginInit();
            this.SuspendLayout();

            // FernPictureBox
            this.FernPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FernPictureBox.Location = new System.Drawing.Point(0, 0);
            this.FernPictureBox.Name = "FernPictureBox";
            this.FernPictureBox.Size = new System.Drawing.Size(800, 600);
            this.FernPictureBox.TabIndex = 0;
            this.FernPictureBox.TabStop = false;

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.FernPictureBox);
            this.Name = "Form1";
            this.Text = "FractalCreator - Sierpinsky triangle";

            ((System.ComponentModel.ISupportInitialize)(this.FernPictureBox)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
