namespace MP3Player
{
	partial class Main
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
			this.btnPlay = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnPrev = new System.Windows.Forms.Button();
			this.labelMedia = new System.Windows.Forms.Label();
			this.btnAdd = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// btnPlay
			// 
			this.btnPlay.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnPlay.Enabled = false;
			this.btnPlay.Location = new System.Drawing.Point(28, 51);
			this.btnPlay.Name = "btnPlay";
			this.btnPlay.Size = new System.Drawing.Size(76, 40);
			this.btnPlay.TabIndex = 0;
			this.btnPlay.Text = "Play";
			this.btnPlay.UseVisualStyleBackColor = true;
			this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
			// 
			// btnStop
			// 
			this.btnStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnStop.Enabled = false;
			this.btnStop.Location = new System.Drawing.Point(110, 51);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(76, 40);
			this.btnStop.TabIndex = 1;
			this.btnStop.Text = "Stop";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// btnNext
			// 
			this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnNext.Enabled = false;
			this.btnNext.Location = new System.Drawing.Point(274, 51);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(76, 40);
			this.btnNext.TabIndex = 3;
			this.btnNext.Text = "Next";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnPrev
			// 
			this.btnPrev.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnPrev.Enabled = false;
			this.btnPrev.Location = new System.Drawing.Point(192, 51);
			this.btnPrev.Name = "btnPrev";
			this.btnPrev.Size = new System.Drawing.Size(76, 40);
			this.btnPrev.TabIndex = 2;
			this.btnPrev.Text = "Previous";
			this.btnPrev.UseVisualStyleBackColor = true;
			this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
			// 
			// labelMedia
			// 
			this.labelMedia.Location = new System.Drawing.Point(28, 24);
			this.labelMedia.Name = "labelMedia";
			this.labelMedia.Size = new System.Drawing.Size(404, 13);
			this.labelMedia.TabIndex = 6;
			this.labelMedia.Text = "No Media";
			this.labelMedia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnAdd.Location = new System.Drawing.Point(356, 51);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(76, 40);
			this.btnAdd.TabIndex = 7;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(456, 103);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.labelMedia);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnPrev);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.btnPlay);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Main";
			this.Text = "Mp3 Player";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnPlay;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnPrev;
		private System.Windows.Forms.Label labelMedia;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
	}
}

