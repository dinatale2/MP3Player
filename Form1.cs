using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mp3player
{
    public partial class Form1 : Form
    {
        WMPLib.WindowsMediaPlayer mp3;
        string file = @"C:\Users\Public\Music\Sample Music\Kalimba.mp3";
        bool paused = false;

        public Form1()
        {
            InitializeComponent(); 
            mp3 = new WMPLib.WindowsMediaPlayer();
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

            // not paused, so load the mp3 and play
            mp3.URL = file;
            mp3.controls.play();
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // choose kalimba
            file = @"C:\Users\Public\Music\Sample Music\Kalimba.mp3";
            mp3.controls.stop();
            paused = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // choose sleep away
            file = @"C:\Users\Public\Music\Sample Music\Sleep Away.mp3";
            mp3.controls.stop();
            paused = false;
        }
    }
}
