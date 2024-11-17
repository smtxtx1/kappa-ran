namespace Kappa
{
    partial class Form3
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
            pictureBoxRadar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRadar).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxRadar
            // 
            pictureBoxRadar.BackColor = Color.Black;
            pictureBoxRadar.Location = new Point(12, 12);
            pictureBoxRadar.Name = "pictureBoxRadar";
            pictureBoxRadar.Size = new Size(454, 320);
            pictureBoxRadar.TabIndex = 0;
            pictureBoxRadar.TabStop = false;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 344);
            Controls.Add(pictureBoxRadar);
            Name = "Form3";
            Text = "Form3";
            TopMost = true;
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxRadar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxRadar;
    }
}