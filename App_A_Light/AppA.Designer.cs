namespace App_A_Light
{
    partial class AppA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppA));
            this.pictureBoxLightOff = new System.Windows.Forms.PictureBox();
            this.pictureBoxLightOn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLightOff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLightOn)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxLightOff
            // 
            this.pictureBoxLightOff.Image = global::App_A_Light.Properties.Resources.lightOff;
            this.pictureBoxLightOff.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxLightOff.InitialImage")));
            this.pictureBoxLightOff.Location = new System.Drawing.Point(215, 22);
            this.pictureBoxLightOff.Name = "pictureBoxLightOff";
            this.pictureBoxLightOff.Size = new System.Drawing.Size(397, 397);
            this.pictureBoxLightOff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLightOff.TabIndex = 0;
            this.pictureBoxLightOff.TabStop = false;
            // 
            // pictureBoxLightOn
            // 
            this.pictureBoxLightOn.Image = global::App_A_Light.Properties.Resources.lightOn;
            this.pictureBoxLightOn.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxLightOn.InitialImage")));
            this.pictureBoxLightOn.Location = new System.Drawing.Point(224, 22);
            this.pictureBoxLightOn.Name = "pictureBoxLightOn";
            this.pictureBoxLightOn.Size = new System.Drawing.Size(397, 397);
            this.pictureBoxLightOn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLightOn.TabIndex = 1;
            this.pictureBoxLightOn.TabStop = false;
            this.pictureBoxLightOn.Visible = false;
            // 
            // AppA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 450);
            this.Controls.Add(this.pictureBoxLightOn);
            this.Controls.Add(this.pictureBoxLightOff);
            this.Name = "AppA";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.AppA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLightOff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLightOn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLightOff;
        private System.Windows.Forms.PictureBox pictureBoxLightOn;
    }
}

