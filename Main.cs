using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MP3Player
{
	public partial class Main : Form
	{
		private Mp3Player _player;

		public Main()
		{
			InitializeComponent();
			_player = new Mp3Player();
			_player.MediaStarted += new EventHandler<MediaStartedEventArgs>(_player_MediaStarted);
		}

		void _player_MediaStarted(object sender, MediaStartedEventArgs e)
		{
			labelMedia.Text = e.MediaName;
		}

		private void btnPlay_Click(object sender, EventArgs e)
		{
			if (!_player.IsPlaying)
			{
				btnPlay.Text = "Pause";
				_player.Play();
			}
			else
			{
				btnPlay.Text = "Play";
				_player.Pause();
			}

			btnStop.Enabled = true;
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			_player.Stop();
			btnStop.Enabled = false;
			btnPlay.Text = "Play";
			btnPlay.Enabled = true;
		}

		private void btnPrev_Click(object sender, EventArgs e)
		{
			_player.Previous();
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			_player.Next();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			OpenFileDialog openDialog = new OpenFileDialog();
			openDialog.Title = "Open MP3 File(s)";
			openDialog.Filter = "MP3 files (.mp3)|*.mp3";
			openFileDialog1.Multiselect = true;
			openDialog.InitialDirectory = @"C:\";

			DialogResult result = openFileDialog1.ShowDialog();

			if (result != DialogResult.OK)
				return;

			foreach (string file in openFileDialog1.FileNames)
				_player.Enqueue(file);

			btnPlay.Enabled = true;
			btnPrev.Enabled = true;
			btnNext.Enabled = true;
		}
	}
}
