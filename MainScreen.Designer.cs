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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.label_sesSeviyesi = new System.Windows.Forms.Label();
            this.label_masterVolume = new System.Windows.Forms.Label();
            this.trackBar_masterVolume = new System.Windows.Forms.TrackBar();
            this.comboBox_processOne = new System.Windows.Forms.ComboBox();
            this.pictureBox_processOne = new System.Windows.Forms.PictureBox();
            this.trackBar_processOne = new System.Windows.Forms.TrackBar();
            this.label_processOneVolumeLevel = new System.Windows.Forms.Label();
            this.label_sesSeviyesiProcessOne = new System.Windows.Forms.Label();
            this.label_applicationOne = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_masterVolume = new System.Windows.Forms.PictureBox();
            this.label_applicationTwo = new System.Windows.Forms.Label();
            this.label_processTwoVolumeLevel = new System.Windows.Forms.Label();
            this.label_sesSeviyesiProcessTwo = new System.Windows.Forms.Label();
            this.trackBar_processTwo = new System.Windows.Forms.TrackBar();
            this.pictureBox_processTwo = new System.Windows.Forms.PictureBox();
            this.comboBox_processTwo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_masterVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_processOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_processOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_masterVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_processTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_processTwo)).BeginInit();
            this.SuspendLayout();
            // 
            // label_sesSeviyesi
            // 
            this.label_sesSeviyesi.AutoSize = true;
            this.label_sesSeviyesi.Location = new System.Drawing.Point(23, 120);
            this.label_sesSeviyesi.Name = "label_sesSeviyesi";
            this.label_sesSeviyesi.Size = new System.Drawing.Size(73, 13);
            this.label_sesSeviyesi.TabIndex = 0;
            this.label_sesSeviyesi.Text = "Ses Seviyesi: ";
            // 
            // label_masterVolume
            // 
            this.label_masterVolume.AutoSize = true;
            this.label_masterVolume.Location = new System.Drawing.Point(92, 120);
            this.label_masterVolume.Name = "label_masterVolume";
            this.label_masterVolume.Size = new System.Drawing.Size(60, 13);
            this.label_masterVolume.TabIndex = 1;
            this.label_masterVolume.Text = "master_ses";
            // 
            // trackBar_masterVolume
            // 
            this.trackBar_masterVolume.Location = new System.Drawing.Point(26, 136);
            this.trackBar_masterVolume.Maximum = 100;
            this.trackBar_masterVolume.Name = "trackBar_masterVolume";
            this.trackBar_masterVolume.Size = new System.Drawing.Size(112, 45);
            this.trackBar_masterVolume.TabIndex = 2;
            this.trackBar_masterVolume.Scroll += new System.EventHandler(this.trackBar_masterVolume_Scroll);
            // 
            // comboBox_processOne
            // 
            this.comboBox_processOne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_processOne.FormattingEnabled = true;
            this.comboBox_processOne.Location = new System.Drawing.Point(174, 92);
            this.comboBox_processOne.Name = "comboBox_processOne";
            this.comboBox_processOne.Size = new System.Drawing.Size(112, 21);
            this.comboBox_processOne.TabIndex = 3;
            this.comboBox_processOne.SelectedIndexChanged += new System.EventHandler(this.comboBox_processOne_SelectedIndexChanged);
            // 
            // pictureBox_processOne
            // 
            this.pictureBox_processOne.Location = new System.Drawing.Point(204, 36);
            this.pictureBox_processOne.Name = "pictureBox_processOne";
            this.pictureBox_processOne.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_processOne.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_processOne.TabIndex = 4;
            this.pictureBox_processOne.TabStop = false;
            // 
            // trackBar_processOne
            // 
            this.trackBar_processOne.Location = new System.Drawing.Point(174, 136);
            this.trackBar_processOne.Maximum = 100;
            this.trackBar_processOne.Name = "trackBar_processOne";
            this.trackBar_processOne.Size = new System.Drawing.Size(112, 45);
            this.trackBar_processOne.TabIndex = 5;
            this.trackBar_processOne.Scroll += new System.EventHandler(this.trackBar_processOne_Scroll);
            // 
            // label_processOneVolumeLevel
            // 
            this.label_processOneVolumeLevel.AutoSize = true;
            this.label_processOneVolumeLevel.Location = new System.Drawing.Point(240, 120);
            this.label_processOneVolumeLevel.Name = "label_processOneVolumeLevel";
            this.label_processOneVolumeLevel.Size = new System.Drawing.Size(64, 13);
            this.label_processOneVolumeLevel.TabIndex = 7;
            this.label_processOneVolumeLevel.Text = "session_ses";
            // 
            // label_sesSeviyesiProcessOne
            // 
            this.label_sesSeviyesiProcessOne.AutoSize = true;
            this.label_sesSeviyesiProcessOne.Location = new System.Drawing.Point(171, 120);
            this.label_sesSeviyesiProcessOne.Name = "label_sesSeviyesiProcessOne";
            this.label_sesSeviyesiProcessOne.Size = new System.Drawing.Size(73, 13);
            this.label_sesSeviyesiProcessOne.TabIndex = 6;
            this.label_sesSeviyesiProcessOne.Text = "Ses Seviyesi: ";
            // 
            // label_applicationOne
            // 
            this.label_applicationOne.AutoSize = true;
            this.label_applicationOne.Location = new System.Drawing.Point(196, 9);
            this.label_applicationOne.Name = "label_applicationOne";
            this.label_applicationOne.Size = new System.Drawing.Size(68, 13);
            this.label_applicationOne.TabIndex = 8;
            this.label_applicationOne.Text = "Application 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Master Audio";
            // 
            // pictureBox_masterVolume
            // 
            this.pictureBox_masterVolume.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_masterVolume.Image")));
            this.pictureBox_masterVolume.Location = new System.Drawing.Point(57, 36);
            this.pictureBox_masterVolume.Name = "pictureBox_masterVolume";
            this.pictureBox_masterVolume.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_masterVolume.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_masterVolume.TabIndex = 10;
            this.pictureBox_masterVolume.TabStop = false;
            // 
            // label_applicationTwo
            // 
            this.label_applicationTwo.AutoSize = true;
            this.label_applicationTwo.Location = new System.Drawing.Point(344, 9);
            this.label_applicationTwo.Name = "label_applicationTwo";
            this.label_applicationTwo.Size = new System.Drawing.Size(68, 13);
            this.label_applicationTwo.TabIndex = 16;
            this.label_applicationTwo.Text = "Application 2";
            // 
            // label_processTwoVolumeLevel
            // 
            this.label_processTwoVolumeLevel.AutoSize = true;
            this.label_processTwoVolumeLevel.Location = new System.Drawing.Point(388, 120);
            this.label_processTwoVolumeLevel.Name = "label_processTwoVolumeLevel";
            this.label_processTwoVolumeLevel.Size = new System.Drawing.Size(64, 13);
            this.label_processTwoVolumeLevel.TabIndex = 15;
            this.label_processTwoVolumeLevel.Text = "session_ses";
            // 
            // label_sesSeviyesiProcessTwo
            // 
            this.label_sesSeviyesiProcessTwo.AutoSize = true;
            this.label_sesSeviyesiProcessTwo.Location = new System.Drawing.Point(319, 120);
            this.label_sesSeviyesiProcessTwo.Name = "label_sesSeviyesiProcessTwo";
            this.label_sesSeviyesiProcessTwo.Size = new System.Drawing.Size(73, 13);
            this.label_sesSeviyesiProcessTwo.TabIndex = 14;
            this.label_sesSeviyesiProcessTwo.Text = "Ses Seviyesi: ";
            // 
            // trackBar_processTwo
            // 
            this.trackBar_processTwo.Location = new System.Drawing.Point(322, 136);
            this.trackBar_processTwo.Maximum = 100;
            this.trackBar_processTwo.Name = "trackBar_processTwo";
            this.trackBar_processTwo.Size = new System.Drawing.Size(112, 45);
            this.trackBar_processTwo.TabIndex = 13;
            this.trackBar_processTwo.Scroll += new System.EventHandler(this.trackBar_processTwo_Scroll);
            // 
            // pictureBox_processTwo
            // 
            this.pictureBox_processTwo.Location = new System.Drawing.Point(352, 36);
            this.pictureBox_processTwo.Name = "pictureBox_processTwo";
            this.pictureBox_processTwo.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_processTwo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_processTwo.TabIndex = 12;
            this.pictureBox_processTwo.TabStop = false;
            // 
            // comboBox_processTwo
            // 
            this.comboBox_processTwo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_processTwo.FormattingEnabled = true;
            this.comboBox_processTwo.Location = new System.Drawing.Point(322, 92);
            this.comboBox_processTwo.Name = "comboBox_processTwo";
            this.comboBox_processTwo.Size = new System.Drawing.Size(112, 21);
            this.comboBox_processTwo.TabIndex = 11;
            this.comboBox_processTwo.SelectedIndexChanged += new System.EventHandler(this.comboBox_processTwo_SelectedIndexChanged);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_applicationTwo);
            this.Controls.Add(this.label_processTwoVolumeLevel);
            this.Controls.Add(this.label_sesSeviyesiProcessTwo);
            this.Controls.Add(this.trackBar_processTwo);
            this.Controls.Add(this.pictureBox_processTwo);
            this.Controls.Add(this.comboBox_processTwo);
            this.Controls.Add(this.pictureBox_masterVolume);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_applicationOne);
            this.Controls.Add(this.label_processOneVolumeLevel);
            this.Controls.Add(this.label_sesSeviyesiProcessOne);
            this.Controls.Add(this.trackBar_processOne);
            this.Controls.Add(this.pictureBox_processOne);
            this.Controls.Add(this.comboBox_processOne);
            this.Controls.Add(this.trackBar_masterVolume);
            this.Controls.Add(this.label_masterVolume);
            this.Controls.Add(this.label_sesSeviyesi);
            this.Name = "MainScreen";
            this.Text = "Deej App";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_masterVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_processOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_processOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_masterVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_processTwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_processTwo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_sesSeviyesi;
        private System.Windows.Forms.Label label_masterVolume;
        private System.Windows.Forms.TrackBar trackBar_masterVolume;
        private System.Windows.Forms.ComboBox comboBox_processOne;
        private System.Windows.Forms.PictureBox pictureBox_processOne;
        private System.Windows.Forms.TrackBar trackBar_processOne;
        private System.Windows.Forms.Label label_processOneVolumeLevel;
        private System.Windows.Forms.Label label_sesSeviyesiProcessOne;
        private System.Windows.Forms.Label label_applicationOne;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox_masterVolume;
        private System.Windows.Forms.Label label_applicationTwo;
        private System.Windows.Forms.Label label_processTwoVolumeLevel;
        private System.Windows.Forms.Label label_sesSeviyesiProcessTwo;
        private System.Windows.Forms.TrackBar trackBar_processTwo;
        private System.Windows.Forms.PictureBox pictureBox_processTwo;
        private System.Windows.Forms.ComboBox comboBox_processTwo;
    }
}