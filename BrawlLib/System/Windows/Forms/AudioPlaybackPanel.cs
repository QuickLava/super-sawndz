using System;
using System.Audio;
using System.ComponentModel;

namespace System.Windows.Forms
{
    public class AudioPlaybackPanel : UserControl
    {
        #region Designer

        private CustomTrackBar trackBar1;
        private Button btnPlay;
        private Button btnRewind;
        private Label lblProgress;
        private Timer tmrUpdate;
        private System.ComponentModel.IContainer components;
        private CheckBox chkLoop;

        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.btnPlay = new System.Windows.Forms.Button();
			this.btnRewind = new System.Windows.Forms.Button();
			this.chkLoop = new System.Windows.Forms.CheckBox();
			this.lblProgress = new System.Windows.Forms.Label();
			this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
			this.trackBar1 = new System.Windows.Forms.CustomTrackBar();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnPlay
			// 
			this.btnPlay.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnPlay.Location = new System.Drawing.Point(231, 69);
			this.btnPlay.Name = "btnPlay";
			this.btnPlay.Size = new System.Drawing.Size(75, 27);
			this.btnPlay.TabIndex = 1;
			this.btnPlay.Text = "Play";
			this.btnPlay.UseVisualStyleBackColor = true;
			this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
			// 
			// btnRewind
			// 
			this.btnRewind.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnRewind.Location = new System.Drawing.Point(198, 69);
			this.btnRewind.Name = "btnRewind";
			this.btnRewind.Size = new System.Drawing.Size(27, 27);
			this.btnRewind.TabIndex = 2;
			this.btnRewind.Text = "|<";
			this.btnRewind.UseVisualStyleBackColor = true;
			this.btnRewind.Click += new System.EventHandler(this.btnRewind_Click);
			// 
			// chkLoop
			// 
			this.chkLoop.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.chkLoop.Location = new System.Drawing.Point(130, 69);
			this.chkLoop.Name = "chkLoop";
			this.chkLoop.Size = new System.Drawing.Size(62, 27);
			this.chkLoop.TabIndex = 3;
			this.chkLoop.Text = "Loop";
			this.chkLoop.UseVisualStyleBackColor = true;
			this.chkLoop.CheckedChanged += new System.EventHandler(this.chkLoop_CheckedChanged);
			// 
			// lblProgress
			// 
			this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblProgress.Location = new System.Drawing.Point(0, 31);
			this.lblProgress.Name = "lblProgress";
			this.lblProgress.Size = new System.Drawing.Size(536, 23);
			this.lblProgress.TabIndex = 4;
			this.lblProgress.Text = "0/0";
			this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tmrUpdate
			// 
			this.tmrUpdate.Interval = 10;
			this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
			// 
			// trackBar1
			// 
			this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trackBar1.Location = new System.Drawing.Point(0, 4);
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(536, 56);
			this.trackBar1.TabIndex = 0;
			this.trackBar1.TickFrequency = 2;
			this.trackBar1.UserSeek += new System.EventHandler(this.trackBar1_UserSeek);
			this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
			// 
			// AudioPlaybackPanel
			// 
			this.Controls.Add(this.lblProgress);
			this.Controls.Add(this.chkLoop);
			this.Controls.Add(this.btnRewind);
			this.Controls.Add(this.btnPlay);
			this.Controls.Add(this.trackBar1);
			this.Name = "AudioPlaybackPanel";
			this.Size = new System.Drawing.Size(536, 111);
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private bool _loop = false;
        private bool _isPlaying = false;
        private bool _isScrolling = false;
        //private int _currentSample;
        private DateTime _sampleTime;

        private IAudioStream _targetStream;
        //public IAudioStream TargetStream
        //{
        //    get { return _targetStream; }
        //    set { TargetChanged(value); }
        //}

        private IAudioSource _targetSource;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IAudioSource TargetSource
        {
            get { return _targetSource; }
            set { TargetChanged(value); }
        }

        private AudioProvider _provider;
        private AudioBuffer _buffer;

        public AudioPlaybackPanel() { InitializeComponent(); }

        protected override void Dispose(bool disposing)
        {
            Close();
            if (_provider != null)
            {
                _provider.Dispose();
                _provider = null;
            }
            base.Dispose(disposing);
        }

        private void Close()
        {
            //Stop playback
            Stop();

            //Dispose of buffer
            if (_buffer != null)
            {
                _buffer.Dispose();
                _buffer = null;
            }

            if (_targetStream != null)
            {
                _targetStream.Dispose();
                _targetStream = null;
            }

            _targetSource = null;

            //Reset fields
            chkLoop.Checked = false;

			lblProgress.Text = "0/0";
			btnPlay.Enabled = false;
        }

        private void TargetChanged(IAudioSource newTarget)
        {
            if (_targetSource == newTarget && _targetSource != null)
                return;

            Close();

			if( ( _targetSource = newTarget ) == null )
				return;
            if ((_targetStream = _targetSource.CreateStream()) == null)
                return;

            //Create provider
            if (_provider == null)
            {
                _provider = AudioProvider.Create(null);
                _provider.Attach(this);
            }

            chkLoop.Checked = false;
            chkLoop.Enabled = _targetStream.IsLooping;

            //Create buffer for stream
            _buffer = _provider.CreateBuffer(_targetStream);

            _sampleTime = new DateTime((long)_targetStream.Samples * 10000000 / _targetStream.Frequency);
            trackBar1.Value = 0;
            trackBar1.TickStyle = TickStyle.None;
            trackBar1.Maximum = _targetStream.Samples;
            trackBar1.TickFrequency = _targetStream.Samples / 8;
            trackBar1.TickStyle = TickStyle.BottomRight;

            UpdateTimeDisplay();
			btnPlay.Enabled = true;
        }

        private void UpdateTimeDisplay()
        {
            if (_targetStream == null)
                return;
            DateTime t = new DateTime((long)trackBar1.Value * 10000000 / _targetStream.Frequency);
            lblProgress.Text = String.Format("{0:mm:ss.ff} / {1:mm:ss.ff}", t, _sampleTime);
        }

        private void Seek(int sample)
        {
            trackBar1.Value = sample;

            //Only seek the buffer when playing.
            if (_isPlaying)
            {
                Stop();
                _buffer.Seek(sample);
                Play();
            }
        }

        public void Play()
        {
            if ((_isPlaying) || (_buffer == null))
                return;

            _isPlaying = true;

            //Start from beginning if at end
            if (trackBar1.Value == _targetStream.Samples)
                trackBar1.Value = 0;

            //Seek buffer to current sample
            _buffer.Seek(trackBar1.Value);

            //Fill initial buffer
            tmrUpdate_Tick(null, null);
            //Start timer
            tmrUpdate.Start();

            //Begin playback
            _buffer.Play();

            btnPlay.Text = "Stop";
        }
        public void Stop()
        {
            if (!_isPlaying)
                return;

            _isPlaying = false;

            //Stop timer
            tmrUpdate.Stop();

            //Stop device
            if (_buffer != null)
                _buffer.Stop();

            btnPlay.Text = "Play";
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            if ((_isPlaying) && (_buffer != null))
            {
                _buffer.Fill();
                //_currentSample = _buffer.ReadSample;

                trackBar1.Value = _buffer.ReadSample;

                if (_buffer.ReadSample >= _targetStream.Samples)
                    Stop();
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (_isPlaying)
                Stop();
            else
                Play();
        }

        private void chkLoop_CheckedChanged(object sender, EventArgs e)
        {
            _loop = chkLoop.Checked;
            if (_buffer != null)
                _buffer.Loop = _loop;
        }

        private void btnRewind_Click(object sender, EventArgs e) { Seek(0); }
        private void trackBar1_ValueChanged(object sender, EventArgs e) { UpdateTimeDisplay(); }
        private void trackBar1_UserSeek(object sender, EventArgs e) { Seek(trackBar1.Value); }
    }
}
