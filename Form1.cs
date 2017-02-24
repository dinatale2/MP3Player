using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace mp3player
{
    public partial class Form1 : Form
    {
        WMPLib.WindowsMediaPlayer mp3;
        bool paused = false;
        bool mediaEnded = false;
        int playingIndex;

        public Form1()
        {
            InitializeComponent(); 
            mp3 = new WMPLib.WindowsMediaPlayer();
            mp3.PlayStateChange += Mp3_PlayStateChange;
            playingIndex = -1;

            mp3.settings.volume = 30;
            volumeControl.Value = 30;
        }

        private void Mp3_PlayStateChange(int NewState)
        {
            if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsMediaEnded) {
                mediaEnded = true;
            }

            if (mediaEnded == true && (WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsTransitioning)
            {
                mediaEnded = false;

                if (playlistBox.Items.Count <= 0 || playingIndex + 1 >= playlistBox.Items.Count)
                {
                    mp3.controls.stop();
                    return;
                }

                // not paused, so load the mp3 and play
                playingIndex++;
                mp3.URL = (string)playlistBox.Items[playingIndex];
                mp3.controls.play();
                paused = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // if paused, let's play
            if (paused == true)
            {
                mp3.controls.play();
                paused = false;
                return;
            }

            if (playingIndex < 0)
            {
                if (playlistBox.Items.Count == 0)
                    return;

                playingIndex = 0;
            }

            // not paused, so load the mp3 and play
            mp3.URL = (string)playlistBox.Items[playingIndex];
            mp3.controls.play();
            paused = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // stop button
            mp3.controls.stop();
            paused = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // pause button
            mp3.controls.pause();
            paused = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // add button
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "MP3 Files (*.mp3)|*.mp3";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in fd.FileNames)
                    playlistBox.Items.Add(file);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // remove button
            int index = playlistBox.SelectedIndex;
            if (index >= 0)
            {
                playlistBox.Items.RemoveAt(index);

                if (playingIndex >= 0 && index < playingIndex)
                    playingIndex--;
            }
        }

        private void playlistBox_DoubleClick(object sender, EventArgs e)
        {
            // double clicking an item on our playlist
            int index = playlistBox.SelectedIndex;
            if (index >= 0)
            {
                mp3.URL = (string)playlistBox.Items[index];
                paused = false;
                mp3.controls.play();
                playingIndex = index;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // previous button
            if (playingIndex <= 0)
                return;

            playingIndex--;
            mp3.URL = (string)playlistBox.Items[playingIndex];
            paused = false;
            mp3.controls.play();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // next button
            if (playingIndex >= playlistBox.Items.Count - 1)
                return;

            playingIndex++;
            mp3.URL = (string)playlistBox.Items[playingIndex];
            paused = false;
            mp3.controls.play();
        }

        private void volumeControl_ValueChanged(object sender, EventArgs e)
        {
            // volume slider
            mp3.settings.volume = volumeControl.Value;
        }
    }
}
