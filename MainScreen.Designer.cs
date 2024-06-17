namespace DeejApp
{
    partial class MainScreen
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
            this.label_sesSeviyesi = new System.Windows.Forms.Label();
            this.label_masterVolume = new System.Windows.Forms.Label();
            this.trackBar_masterVolume = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_masterVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // label_sesSeviyesi
            // 
            this.label_sesSeviyesi.AutoSize = true;
            this.label_sesSeviyesi.Location = new System.Drawing.Point(12, 9);
            this.label_sesSeviyesi.Name = "label_sesSeviyesi";
            this.label_sesSeviyesi.Size = new System.Drawing.Size(73, 13);
            this.label_sesSeviyesi.TabIndex = 0;
            this.label_sesSeviyesi.Text = "Ses Seviyesi: ";
            // 
            // label_masterVolume
            // 
            this.label_masterVolume.AutoSize = true;
            this.label_masterVolume.Location = new System.Drawing.Point(81, 9);
            this.label_masterVolume.Name = "label_masterVolume";
            this.label_masterVolume.Size = new System.Drawing.Size(0, 13);
            this.label_masterVolume.TabIndex = 1;
            // 
            // trackBar_masterVolume
            // 
            this.trackBar_masterVolume.Location = new System.Drawing.Point(12, 36);
            this.trackBar_masterVolume.Name = "trackBar_masterVolume";
            this.trackBar_masterVolume.Size = new System.Drawing.Size(104, 45);
            this.trackBar_masterVolume.TabIndex = 2;
            this.trackBar_masterVolume.Scroll += new System.EventHandler(this.trackBar_masterVolume_Scroll);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.trackBar_masterVolume);
            this.Controls.Add(this.label_masterVolume);
            this.Controls.Add(this.label_sesSeviyesi);
            this.Name = "MainScreen";
            this.Text = "Deej App";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_masterVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_sesSeviyesi;
        private System.Windows.Forms.Label label_masterVolume;
        private System.Windows.Forms.TrackBar trackBar_masterVolume;
    }
}