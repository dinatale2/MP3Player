using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace MP3Player
{
	public class MediaLoadedEventArgs : EventArgs
	{
		public int Duration { get; protected set; }
		public string DurationString { get; protected set; }
		public string MediaName { get; protected set; }

		public MediaLoadedEventArgs(int duration, string durationString, string mediaName)
		{
			Duration = duration;
			DurationString = durationString;
			MediaName = mediaName;
		}
	}

	public class MediaStartedEventArgs : MediaLoadedEventArgs
	{
		public MediaStartedEventArgs(int duration, string durationString, string mediaName)
			: base(duration, durationString, mediaName)
		{
		}
	}

	public class Mp3Player
	{
		private WMPLib.WindowsMediaPlayer _player;
		private LinkedList<string> _enqueued_songs;
		private LinkedListNode<string> _current_song;

		public event EventHandler MediaLoadFailed;
		public event EventHandler<MediaLoadedEventArgs> MediaLoaded;
		public event EventHandler<MediaStartedEventArgs> MediaStarted;
		public event EventHandler MediaStopped;

		public bool IsPlaying { get; private set; }
		public bool IsPaused { get; private set; }

		public Mp3Player()
		{
			_player = new WMPLib.WindowsMediaPlayer();
			_player.MediaError += new WMPLib._WMPOCXEvents_MediaErrorEventHandler(_player_MediaError);
			_player.PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(_player_PlayStateChange);
			_enqueued_songs = new LinkedList<string>();
			_current_song = null;
			_player.settings.autoStart = false;

			// for now, lower the volume
			_player.settings.volume = 10;
		}

		void _player_PlayStateChange(int NewState)
		{
			if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsMediaEnded)
			{
				this.Next();
			}
			else if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsPlaying)
			{
				IsPlaying = true;
				IsPaused = false;

				if (MediaStarted != null)
					MediaStarted(this,
						new MediaStartedEventArgs((int)_player.currentMedia.duration, _player.currentMedia.durationString, _player.currentMedia.name));
			}
			else if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsStopped)
			{
				IsPlaying = false;
				IsPaused = false;
				if (MediaStopped != null)
					MediaStopped(this, EventArgs.Empty);
			}
			else if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsPaused)
			{
				IsPaused = true;
				IsPlaying = false;
			}
		}

		void _player_MediaError(object pMediaObject)
		{
			if (MediaLoadFailed != null)
				MediaLoadFailed(this, EventArgs.Empty);
		}

		private void LoadFile(string filepath)
		{
			if (!File.Exists(filepath))
				if (MediaLoadFailed != null)
					MediaLoadFailed(this, EventArgs.Empty);

			_player.close();
			_player.URL = filepath;

			if (MediaLoaded != null)
				MediaLoaded(this,
					new MediaLoadedEventArgs((int)_player.currentMedia.duration, _player.currentMedia.durationString, _player.currentMedia.name));
		}

		public void Play()
		{
			if (_current_song == null)
				return;

			_player.controls.play();
		}

		public void Pause()
		{
			_player.controls.pause();
		}

		public void Stop()
		{
			_player.controls.stop();
		}

		public void Enqueue(string filepath)
		{
			_enqueued_songs.AddLast(filepath);

			if (_current_song == null)
			{
				_current_song = _enqueued_songs.First;
				LoadFile(_current_song.Value);
			}
		}

		public void Next()
		{
			if (_current_song == null || _current_song.Next == null)
				return;

			_current_song = _current_song.Next;
			LoadFile(_current_song.Value);

			if (IsPlaying)
				this.Play();
		}

		public void Previous()
		{
			if (_current_song == null || _current_song.Previous == null)
				return;

			_current_song = _current_song.Previous;
			LoadFile(_current_song.Value);

			if (IsPlaying)
				this.Play();
		}
	}
}
