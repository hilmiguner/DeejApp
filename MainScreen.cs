using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeejApp
{
    public partial class MainScreen : Form
    {
        private MMDeviceEnumerator deviceEnumerator;
        private MMDevice audioDevice;
        public MainScreen()
        {
            InitializeComponent();
            deviceEnumerator = new MMDeviceEnumerator();
            audioDevice = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            trackBar_masterVolume.Minimum = 0;
            trackBar_masterVolume.Maximum = 100;
            trackBar_masterVolume.Value = (int)(audioDevice.AudioEndpointVolume.MasterVolumeLevelScalar * 100);
            label_masterVolume.Text = trackBar_masterVolume.Value.ToString();
            trackBar_masterVolume.Scroll += trackBar_masterVolume_Scroll;
        }

        private void trackBar_masterVolume_Scroll(object sender, EventArgs e)
        {
            float volume = trackBar_masterVolume.Value / 100.0f;
            if (volume == 0.0f)
            {
                this.audioDevice.AudioEndpointVolume.Mute = true;
            }
            else
            {
                if (this.audioDevice.AudioEndpointVolume.Mute == true) this.audioDevice.AudioEndpointVolume.Mute = false;
            }
            audioDevice.AudioEndpointVolume.MasterVolumeLevelScalar = volume;
            label_masterVolume.Text = trackBar_masterVolume.Value.ToString();
        }
    }
}
