using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace DeejApp
{
    public partial class MainScreen : Form
    {
        private MMDeviceEnumerator deviceEnumerator;
        private MMDevice audioDevice;
        private SessionItem[] currentSessions = new SessionItem[2];
        private ComboBox[] comboBoxes = new ComboBox[2];
        private TrackBar[] trackBars = new TrackBar[2];
        public MainScreen()
        {
            InitializeComponent();

            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Open Deej App", null, showApp);
            contextMenu.Items.Add("Close App", null, closeApp);
            notifyIcon.ContextMenuStrip = contextMenu;

            deviceEnumerator = new MMDeviceEnumerator();
            audioDevice = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            InitializeMasterVolumeSystem();
            InitializeComboBoxes();
            InitializeTrackBars();
            InitializeSessions();
        }
        
        private void InitializeMasterVolumeSystem()
        {
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

        private class SessionItem
        {
            public string name { get; set; }
            public AudioSessionControl controller { get; set; }
            public Icon icon { get; set; }
        }

        private List<SessionItem> getSessions()
        {
            List<SessionItem> sessionList = new List<SessionItem>();

            SessionCollection allSessions = this.audioDevice.AudioSessionManager.Sessions;
            for (int i = 0; i < allSessions.Count; i++)
            {
                AudioSessionControl sessionController = allSessions[i];
                var process = Process.GetProcessById((int)sessionController.GetProcessID);
                Icon icon = null;
                String name = null;
                if (sessionController.GetProcessID != 0)
                {
                    try
                    {
                        name = process.ProcessName;
                        icon = Icon.ExtractAssociatedIcon(process.MainModule.FileName);
                    }
                    catch (Exception ex)
                    {

                    }
                    sessionList.Add(new SessionItem { controller = sessionController, icon = icon, name = name });
                }
            }
            return sessionList;
        }

        private void InitializeComboBoxes()
        {
            comboBoxes[0] = this.comboBox_processOne;
            comboBoxes[1] = this.comboBox_processTwo;
        }

        private void InitializeTrackBars()
        {
            trackBars[0] = this.trackBar_processOne;
            trackBars[1] = this.trackBar_processTwo;
        }

        private void InitializeSessions()
        {
            foreach (ComboBox comboBox in comboBoxes)
            {
                List<SessionItem> sessionList = getSessions();
                comboBox.DataSource = sessionList;
                comboBox.DisplayMember = "name";
            }
        }

        private void updateTrackBarsByName(int parentIndex, String name, float volume)
        {
            int count = 0;
            foreach (var session in currentSessions)
            {
                if (session.name == name && count != parentIndex) 
                {
                   trackBars[count].Value = (int)(this.currentSessions[count].controller.SimpleAudioVolume.Volume * 100);
                }
                count++;
            }
        }

        private void updateLabels()
        {
            this.label_processOneVolumeLevel.Text = this.trackBar_processOne.Value.ToString();
            this.label_processTwoVolumeLevel.Text = this.trackBar_processTwo.Value.ToString();
        }

        private void comboBox_processOne_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.currentSessions[0] = this.comboBox_processOne.SelectedItem as SessionItem;
            this.pictureBox_processOne.Image = this.currentSessions[0].icon.ToBitmap();
            this.trackBar_processOne.Value = (int)(this.currentSessions[0].controller.SimpleAudioVolume.Volume * 100);
            label_processOneVolumeLevel.Text = trackBar_processOne.Value.ToString();
        }

        private void trackBar_processOne_Scroll(object sender, EventArgs e)
        {
            float volume = trackBar_processOne.Value / 100.0f;

            // Mute check BEGIN
            if (volume == 0.0f)
            {
                this.currentSessions[0].controller.SimpleAudioVolume.Mute = true;
            }
            else
            {
                if (this.currentSessions[0].controller.SimpleAudioVolume.Mute == true) this.currentSessions[0].controller.SimpleAudioVolume.Mute = false;
            }
            // Mute check END

            this.currentSessions[0].controller.SimpleAudioVolume.Volume = volume;
            updateTrackBarsByName(0, this.currentSessions[0].name, volume);
            updateLabels();
        }

        private void comboBox_processTwo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.currentSessions[1] = this.comboBox_processTwo.SelectedItem as SessionItem;
            this.pictureBox_processTwo.Image = this.currentSessions[1].icon.ToBitmap();
            this.trackBar_processTwo.Value = (int)(this.currentSessions[1].controller.SimpleAudioVolume.Volume * 100);
            label_processTwoVolumeLevel.Text = trackBar_processTwo.Value.ToString();
        }

        private void trackBar_processTwo_Scroll(object sender, EventArgs e)
        {
            float volume = trackBar_processTwo.Value / 100.0f;

            // Mute check BEGIN
            if (volume == 0.0f)
            {
                this.currentSessions[1].controller.SimpleAudioVolume.Mute = true;
            }
            else
            {
                if (this.currentSessions[1].controller.SimpleAudioVolume.Mute == true) this.currentSessions[1].controller.SimpleAudioVolume.Mute = false;
            }
            // Mute check END

            this.currentSessions[1].controller.SimpleAudioVolume.Volume = volume;
            updateTrackBarsByName(1, this.currentSessions[1].name, volume);
            updateLabels();
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                notifyIcon.Visible = true;
                this.Hide();
                e.Cancel = true;
            }
        }

        private void showApp(object sender, EventArgs e)
        { 
            this.Show();
        }

        private void closeApp(object sender, EventArgs e)
        {
            notifyIcon.Visible=false;
            Application.Exit();
        }
    }
}
