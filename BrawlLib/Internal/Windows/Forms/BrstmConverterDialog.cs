using BrawlLib.Internal.Audio;
using BrawlLib.Internal.IO;
using BrawlLib.Internal.Windows.Controls;
using BrawlLib.SSBB.Types.Audio;
using BrawlLib.Wii.Audio;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BrawlLib.Internal.Windows.Forms
{
    public class BrstmConverterDialog : Form
    {
        internal class InitialStreamWrapper : IAudioStream
        {
            public readonly IAudioStream BaseStream;

            public InitialStreamWrapper(IAudioStream baseStream)
            {
                BaseStream = baseStream ?? throw new ArgumentNullException(nameof(baseStream));

                IsLooping = BaseStream.IsLooping;
                LoopStartSample = BaseStream.LoopStartSample;
                LoopEndSample = BaseStream.LoopEndSample;
            }

            public WaveFormatTag Format => BaseStream.Format;
            public int BitsPerSample => BaseStream.BitsPerSample;
            public int Samples => BaseStream.Samples;
            public int Channels => BaseStream.Channels;
            public int Frequency => BaseStream.Frequency;

            public bool IsLooping { get; set; }
            public int LoopStartSample { get; set; }
            public int LoopEndSample { get; set; }

            public int SamplePosition
            {
                get => BaseStream.SamplePosition;
                set => BaseStream.SamplePosition = value;
            }

            public unsafe int ReadSamples(VoidPtr destAddr, int numSamples) {
                if (BaseStream.Channels <= 2) {
                    return BaseStream.ReadSamples(destAddr, numSamples);
                } else {
                    int r = 0;
                    short* out_ptr = (short*)(void*)destAddr;
                    short[] buffer = new short[BaseStream.Channels];
                    fixed (short* buffer_ptr = buffer) {
                        while (r < numSamples) {
                            int q = BaseStream.ReadSamples(buffer_ptr, 1);
                            r += q;
                            *out_ptr++ = buffer[0];
                            *out_ptr++ = buffer[1];
                            if (q == 0) break;
                        }
                    }
                    return r;
                }
            }

            public void Wrap()
            {
                SamplePosition = LoopStartSample;
            }

            public void Dispose()
            {
            }
        }

        #region Designer

        private Button btnOkay;
        private Button btnCancel;
        private TextBox txtPath;
        private CustomTrackBar customTrackBar1;
        private GroupBox groupBox1;
        private Label lblText2;
        private Label lblText1;
        private Label lblPlayTime;
        private Button btnPlay;
        private Button btnRewind;
        private Panel pnlInfo;
        private Panel pnlEdit;
        private Panel pnlLoop;
        private Splitter spltEnd;
        private Panel pnlLoopEnd;
        private Splitter spltStart;
        private Panel pnlLoopStart;
        private Label lblStart;
        private Label lblEnd;
        private NumericUpDown numLoopEnd;
        private NumericUpDown numLoopStart;
        private GroupBox groupBox2;
        private Panel panel3;
        private Panel panel4;
        private GroupBox grpLoop;
        private CheckBox chkLoop;
        private CheckBox chkLoopEnable;
        private OpenFileDialog dlgOpen;
        private Timer tmrUpdate;
        private IContainer components;
        private Label lblSamples;
        private Label lblFrequency;
        private Button btnEndSet;
        private Button btnStartSet;
        private Button btnLoopRW;
        private Button btnFFwd;
        private Button btnSeekEnd;
        private GroupBox groupBox3;
        private ComboBox ddlEncoding;
        private Label label1;
		private CheckBox checkBox1;
		private NumericUpDown numericUpDownStartSeconds;
		private NumericUpDown numericUpDownEndSeconds;
		private Button btnBrowse;

        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.btnOkay = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblSamples = new System.Windows.Forms.Label();
			this.lblFrequency = new System.Windows.Forms.Label();
			this.lblText2 = new System.Windows.Forms.Label();
			this.lblText1 = new System.Windows.Forms.Label();
			this.lblPlayTime = new System.Windows.Forms.Label();
			this.btnPlay = new System.Windows.Forms.Button();
			this.btnRewind = new System.Windows.Forms.Button();
			this.pnlInfo = new System.Windows.Forms.Panel();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.ddlEncoding = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.pnlEdit = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnSeekEnd = new System.Windows.Forms.Button();
			this.btnLoopRW = new System.Windows.Forms.Button();
			this.btnFFwd = new System.Windows.Forms.Button();
			this.chkLoop = new System.Windows.Forms.CheckBox();
			this.pnlLoop = new System.Windows.Forms.Panel();
			this.spltEnd = new System.Windows.Forms.Splitter();
			this.pnlLoopEnd = new System.Windows.Forms.Panel();
			this.spltStart = new System.Windows.Forms.Splitter();
			this.pnlLoopStart = new System.Windows.Forms.Panel();
			this.customTrackBar1 = new BrawlLib.Internal.Windows.Controls.CustomTrackBar();
			this.grpLoop = new System.Windows.Forms.GroupBox();
			this.numericUpDownEndSeconds = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownStartSeconds = new System.Windows.Forms.NumericUpDown();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.btnEndSet = new System.Windows.Forms.Button();
			this.btnStartSet = new System.Windows.Forms.Button();
			this.numLoopStart = new System.Windows.Forms.NumericUpDown();
			this.numLoopEnd = new System.Windows.Forms.NumericUpDown();
			this.lblEnd = new System.Windows.Forms.Label();
			this.lblStart = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.chkLoopEnable = new System.Windows.Forms.CheckBox();
			this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
			this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
			this.groupBox1.SuspendLayout();
			this.pnlInfo.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.pnlEdit.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.pnlLoop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.customTrackBar1)).BeginInit();
			this.grpLoop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndSeconds)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartSeconds)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numLoopStart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numLoopEnd)).BeginInit();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOkay
			// 
			this.btnOkay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOkay.Enabled = false;
			this.btnOkay.Location = new System.Drawing.Point(3, 3);
			this.btnOkay.Name = "btnOkay";
			this.btnOkay.Size = new System.Drawing.Size(75, 23);
			this.btnOkay.TabIndex = 0;
			this.btnOkay.Text = "Okay";
			this.btnOkay.UseVisualStyleBackColor = true;
			this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(80, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// txtPath
			// 
			this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPath.Location = new System.Drawing.Point(0, 0);
			this.txtPath.Name = "txtPath";
			this.txtPath.ReadOnly = true;
			this.txtPath.Size = new System.Drawing.Size(292, 22);
			this.txtPath.TabIndex = 2;
			// 
			// btnBrowse
			// 
			this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowse.Location = new System.Drawing.Point(297, 0);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(25, 20);
			this.btnBrowse.TabIndex = 3;
			this.btnBrowse.Text = "...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblSamples);
			this.groupBox1.Controls.Add(this.lblFrequency);
			this.groupBox1.Controls.Add(this.lblText2);
			this.groupBox1.Controls.Add(this.lblText1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 62);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(158, 91);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "File Info";
			// 
			// lblSamples
			// 
			this.lblSamples.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSamples.Location = new System.Drawing.Point(84, 36);
			this.lblSamples.Name = "lblSamples";
			this.lblSamples.Size = new System.Drawing.Size(68, 20);
			this.lblSamples.TabIndex = 3;
			this.lblSamples.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblFrequency
			// 
			this.lblFrequency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblFrequency.Location = new System.Drawing.Point(84, 16);
			this.lblFrequency.Name = "lblFrequency";
			this.lblFrequency.Size = new System.Drawing.Size(68, 20);
			this.lblFrequency.TabIndex = 2;
			this.lblFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblText2
			// 
			this.lblText2.Location = new System.Drawing.Point(2, 36);
			this.lblText2.Name = "lblText2";
			this.lblText2.Size = new System.Drawing.Size(70, 20);
			this.lblText2.TabIndex = 1;
			this.lblText2.Text = "Samples:";
			this.lblText2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblText1
			// 
			this.lblText1.Location = new System.Drawing.Point(6, 16);
			this.lblText1.Name = "lblText1";
			this.lblText1.Size = new System.Drawing.Size(80, 20);
			this.lblText1.TabIndex = 0;
			this.lblText1.Text = "Frequency:";
			this.lblText1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblPlayTime
			// 
			this.lblPlayTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPlayTime.Location = new System.Drawing.Point(6, 63);
			this.lblPlayTime.Name = "lblPlayTime";
			this.lblPlayTime.Size = new System.Drawing.Size(314, 20);
			this.lblPlayTime.TabIndex = 6;
			this.lblPlayTime.Text = "0 / 0";
			this.lblPlayTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnPlay
			// 
			this.btnPlay.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnPlay.Location = new System.Drawing.Point(126, 86);
			this.btnPlay.Name = "btnPlay";
			this.btnPlay.Size = new System.Drawing.Size(75, 24);
			this.btnPlay.TabIndex = 7;
			this.btnPlay.Text = "Play";
			this.btnPlay.UseVisualStyleBackColor = true;
			this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
			// 
			// btnRewind
			// 
			this.btnRewind.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnRewind.Location = new System.Drawing.Point(70, 86);
			this.btnRewind.Name = "btnRewind";
			this.btnRewind.Size = new System.Drawing.Size(28, 24);
			this.btnRewind.TabIndex = 8;
			this.btnRewind.Text = "|<";
			this.btnRewind.UseVisualStyleBackColor = true;
			this.btnRewind.Click += new System.EventHandler(this.btnRewind_Click);
			// 
			// pnlInfo
			// 
			this.pnlInfo.Controls.Add(this.groupBox1);
			this.pnlInfo.Controls.Add(this.groupBox3);
			this.pnlInfo.Controls.Add(this.panel4);
			this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlInfo.Location = new System.Drawing.Point(326, 0);
			this.pnlInfo.Name = "pnlInfo";
			this.pnlInfo.Size = new System.Drawing.Size(158, 182);
			this.pnlInfo.TabIndex = 9;
			// 
			// groupBox3
			// 
			this.groupBox3.AutoSize = true;
			this.groupBox3.Controls.Add(this.ddlEncoding);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox3.Location = new System.Drawing.Point(0, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(158, 62);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Parameters";
			// 
			// ddlEncoding
			// 
			this.ddlEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlEncoding.FormattingEnabled = true;
			this.ddlEncoding.Location = new System.Drawing.Point(76, 17);
			this.ddlEncoding.Name = "ddlEncoding";
			this.ddlEncoding.Size = new System.Drawing.Size(70, 24);
			this.ddlEncoding.TabIndex = 14;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 20);
			this.label1.TabIndex = 13;
			this.label1.Text = "Encoding:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.btnOkay);
			this.panel4.Controls.Add(this.btnCancel);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel4.Location = new System.Drawing.Point(0, 153);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(158, 29);
			this.panel4.TabIndex = 6;
			// 
			// pnlEdit
			// 
			this.pnlEdit.Controls.Add(this.groupBox2);
			this.pnlEdit.Controls.Add(this.grpLoop);
			this.pnlEdit.Controls.Add(this.panel3);
			this.pnlEdit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlEdit.Location = new System.Drawing.Point(0, 0);
			this.pnlEdit.Name = "pnlEdit";
			this.pnlEdit.Size = new System.Drawing.Size(326, 182);
			this.pnlEdit.TabIndex = 10;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnSeekEnd);
			this.groupBox2.Controls.Add(this.btnLoopRW);
			this.groupBox2.Controls.Add(this.btnFFwd);
			this.groupBox2.Controls.Add(this.chkLoop);
			this.groupBox2.Controls.Add(this.lblPlayTime);
			this.groupBox2.Controls.Add(this.pnlLoop);
			this.groupBox2.Controls.Add(this.btnRewind);
			this.groupBox2.Controls.Add(this.btnPlay);
			this.groupBox2.Controls.Add(this.customTrackBar1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 65);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(326, 117);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Playback";
			// 
			// btnSeekEnd
			// 
			this.btnSeekEnd.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnSeekEnd.Location = new System.Drawing.Point(229, 86);
			this.btnSeekEnd.Name = "btnSeekEnd";
			this.btnSeekEnd.Size = new System.Drawing.Size(28, 24);
			this.btnSeekEnd.TabIndex = 13;
			this.btnSeekEnd.Text = ">|";
			this.btnSeekEnd.UseVisualStyleBackColor = true;
			this.btnSeekEnd.Click += new System.EventHandler(this.btnSeekEnd_Click);
			// 
			// btnLoopRW
			// 
			this.btnLoopRW.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnLoopRW.Enabled = false;
			this.btnLoopRW.Location = new System.Drawing.Point(99, 86);
			this.btnLoopRW.Name = "btnLoopRW";
			this.btnLoopRW.Size = new System.Drawing.Size(26, 24);
			this.btnLoopRW.TabIndex = 12;
			this.btnLoopRW.Text = "<";
			this.btnLoopRW.UseVisualStyleBackColor = true;
			this.btnLoopRW.Click += new System.EventHandler(this.btnLoopRW_Click);
			// 
			// btnFFwd
			// 
			this.btnFFwd.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnFFwd.Enabled = false;
			this.btnFFwd.Location = new System.Drawing.Point(202, 86);
			this.btnFFwd.Name = "btnFFwd";
			this.btnFFwd.Size = new System.Drawing.Size(26, 24);
			this.btnFFwd.TabIndex = 11;
			this.btnFFwd.Text = ">";
			this.btnFFwd.UseVisualStyleBackColor = true;
			this.btnFFwd.Click += new System.EventHandler(this.btnFFwd_Click);
			// 
			// chkLoop
			// 
			this.chkLoop.Enabled = false;
			this.chkLoop.Location = new System.Drawing.Point(10, 86);
			this.chkLoop.Name = "chkLoop";
			this.chkLoop.Size = new System.Drawing.Size(62, 20);
			this.chkLoop.TabIndex = 10;
			this.chkLoop.Text = "Loop";
			this.chkLoop.UseVisualStyleBackColor = true;
			this.chkLoop.CheckedChanged += new System.EventHandler(this.chkLoop_CheckedChanged);
			// 
			// pnlLoop
			// 
			this.pnlLoop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlLoop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.pnlLoop.Controls.Add(this.spltEnd);
			this.pnlLoop.Controls.Add(this.pnlLoopEnd);
			this.pnlLoop.Controls.Add(this.spltStart);
			this.pnlLoop.Controls.Add(this.pnlLoopStart);
			this.pnlLoop.Location = new System.Drawing.Point(18, 50);
			this.pnlLoop.Name = "pnlLoop";
			this.pnlLoop.Size = new System.Drawing.Size(290, 12);
			this.pnlLoop.TabIndex = 9;
			this.pnlLoop.Visible = false;
			// 
			// spltEnd
			// 
			this.spltEnd.BackColor = System.Drawing.Color.Red;
			this.spltEnd.Dock = System.Windows.Forms.DockStyle.Right;
			this.spltEnd.Location = new System.Drawing.Point(287, 0);
			this.spltEnd.MinExtra = 0;
			this.spltEnd.MinSize = 0;
			this.spltEnd.Name = "spltEnd";
			this.spltEnd.Size = new System.Drawing.Size(3, 12);
			this.spltEnd.TabIndex = 3;
			this.spltEnd.TabStop = false;
			// 
			// pnlLoopEnd
			// 
			this.pnlLoopEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.pnlLoopEnd.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlLoopEnd.Location = new System.Drawing.Point(290, 0);
			this.pnlLoopEnd.Name = "pnlLoopEnd";
			this.pnlLoopEnd.Size = new System.Drawing.Size(0, 12);
			this.pnlLoopEnd.TabIndex = 2;
			this.pnlLoopEnd.SizeChanged += new System.EventHandler(this.pnlLoopEnd_SizeChanged);
			// 
			// spltStart
			// 
			this.spltStart.BackColor = System.Drawing.Color.Yellow;
			this.spltStart.Location = new System.Drawing.Point(0, 0);
			this.spltStart.MinExtra = 0;
			this.spltStart.MinSize = 0;
			this.spltStart.Name = "spltStart";
			this.spltStart.Size = new System.Drawing.Size(3, 12);
			this.spltStart.TabIndex = 0;
			this.spltStart.TabStop = false;
			// 
			// pnlLoopStart
			// 
			this.pnlLoopStart.BackColor = System.Drawing.Color.YellowGreen;
			this.pnlLoopStart.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlLoopStart.Location = new System.Drawing.Point(0, 0);
			this.pnlLoopStart.Name = "pnlLoopStart";
			this.pnlLoopStart.Size = new System.Drawing.Size(0, 12);
			this.pnlLoopStart.TabIndex = 1;
			this.pnlLoopStart.SizeChanged += new System.EventHandler(this.pnlLoopStart_SizeChanged);
			// 
			// customTrackBar1
			// 
			this.customTrackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.customTrackBar1.Location = new System.Drawing.Point(6, 19);
			this.customTrackBar1.Name = "customTrackBar1";
			this.customTrackBar1.Size = new System.Drawing.Size(314, 56);
			this.customTrackBar1.TabIndex = 4;
			this.customTrackBar1.UserSeek += new System.EventHandler(this.customTrackBar1_UserSeek);
			this.customTrackBar1.ValueChanged += new System.EventHandler(this.customTrackBar1_ValueChanged);
			// 
			// grpLoop
			// 
			this.grpLoop.Controls.Add(this.numericUpDownEndSeconds);
			this.grpLoop.Controls.Add(this.numericUpDownStartSeconds);
			this.grpLoop.Controls.Add(this.checkBox1);
			this.grpLoop.Controls.Add(this.btnEndSet);
			this.grpLoop.Controls.Add(this.btnStartSet);
			this.grpLoop.Controls.Add(this.numLoopStart);
			this.grpLoop.Controls.Add(this.numLoopEnd);
			this.grpLoop.Controls.Add(this.lblEnd);
			this.grpLoop.Controls.Add(this.lblStart);
			this.grpLoop.Dock = System.Windows.Forms.DockStyle.Top;
			this.grpLoop.Enabled = false;
			this.grpLoop.Location = new System.Drawing.Point(0, 20);
			this.grpLoop.Name = "grpLoop";
			this.grpLoop.Size = new System.Drawing.Size(326, 45);
			this.grpLoop.TabIndex = 15;
			this.grpLoop.TabStop = false;
			this.grpLoop.Text = "Loop";
			// 
			// numericUpDownEndSeconds
			// 
			this.numericUpDownEndSeconds.DecimalPlaces = 5;
			this.numericUpDownEndSeconds.Enabled = false;
			this.numericUpDownEndSeconds.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
			this.numericUpDownEndSeconds.Location = new System.Drawing.Point(207, 19);
			this.numericUpDownEndSeconds.Name = "numericUpDownEndSeconds";
			this.numericUpDownEndSeconds.Size = new System.Drawing.Size(81, 22);
			this.numericUpDownEndSeconds.TabIndex = 13;
			this.numericUpDownEndSeconds.TabStop = false;
			this.numericUpDownEndSeconds.Visible = false;
			this.numericUpDownEndSeconds.ValueChanged += new System.EventHandler(this.numericUpDownEndSeconds_ValueChanged);
			this.numericUpDownEndSeconds.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_KeyDown);
			// 
			// numericUpDownStartSeconds
			// 
			this.numericUpDownStartSeconds.DecimalPlaces = 5;
			this.numericUpDownStartSeconds.Enabled = false;
			this.numericUpDownStartSeconds.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
			this.numericUpDownStartSeconds.Location = new System.Drawing.Point(59, 19);
			this.numericUpDownStartSeconds.Name = "numericUpDownStartSeconds";
			this.numericUpDownStartSeconds.Size = new System.Drawing.Size(81, 22);
			this.numericUpDownStartSeconds.TabIndex = 11;
			this.numericUpDownStartSeconds.TabStop = false;
			this.numericUpDownStartSeconds.Visible = false;
			this.numericUpDownStartSeconds.ValueChanged += new System.EventHandler(this.numericUpDownStartSeconds_ValueChanged);
			this.numericUpDownStartSeconds.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_KeyDown);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(146, -2);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(135, 21);
			this.checkBox1.TabIndex = 14;
			this.checkBox1.Text = "Input in Seconds";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// btnEndSet
			// 
			this.btnEndSet.Location = new System.Drawing.Point(289, 19);
			this.btnEndSet.Name = "btnEndSet";
			this.btnEndSet.Size = new System.Drawing.Size(15, 20);
			this.btnEndSet.TabIndex = 13;
			this.btnEndSet.Text = "*";
			this.btnEndSet.UseVisualStyleBackColor = true;
			this.btnEndSet.Click += new System.EventHandler(this.btnEndSet_Click);
			// 
			// btnStartSet
			// 
			this.btnStartSet.Location = new System.Drawing.Point(141, 19);
			this.btnStartSet.Name = "btnStartSet";
			this.btnStartSet.Size = new System.Drawing.Size(15, 20);
			this.btnStartSet.TabIndex = 4;
			this.btnStartSet.Text = "*";
			this.btnStartSet.UseVisualStyleBackColor = true;
			this.btnStartSet.Click += new System.EventHandler(this.btnStartSet_Click);
			// 
			// numLoopStart
			// 
			this.numLoopStart.Increment = new decimal(new int[] {
            14,
            0,
            0,
            0});
			this.numLoopStart.Location = new System.Drawing.Point(59, 19);
			this.numLoopStart.Name = "numLoopStart";
			this.numLoopStart.Size = new System.Drawing.Size(81, 22);
			this.numLoopStart.TabIndex = 10;
			this.numLoopStart.ValueChanged += new System.EventHandler(this.numLoopStart_ValueChanged);
			this.numLoopStart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_KeyDown);
			// 
			// numLoopEnd
			// 
			this.numLoopEnd.Increment = new decimal(new int[] {
            14,
            0,
            0,
            0});
			this.numLoopEnd.Location = new System.Drawing.Point(207, 19);
			this.numLoopEnd.Name = "numLoopEnd";
			this.numLoopEnd.Size = new System.Drawing.Size(81, 22);
			this.numLoopEnd.TabIndex = 12;
			this.numLoopEnd.ValueChanged += new System.EventHandler(this.numLoopEnd_ValueChanged);
			this.numLoopEnd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_KeyDown);
			// 
			// lblEnd
			// 
			this.lblEnd.Location = new System.Drawing.Point(160, 19);
			this.lblEnd.Name = "lblEnd";
			this.lblEnd.Size = new System.Drawing.Size(41, 20);
			this.lblEnd.TabIndex = 2;
			this.lblEnd.Text = "End:";
			this.lblEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblStart
			// 
			this.lblStart.Location = new System.Drawing.Point(13, 19);
			this.lblStart.Name = "lblStart";
			this.lblStart.Size = new System.Drawing.Size(40, 20);
			this.lblStart.TabIndex = 14;
			this.lblStart.Text = "Start:";
			this.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.txtPath);
			this.panel3.Controls.Add(this.btnBrowse);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(326, 20);
			this.panel3.TabIndex = 14;
			// 
			// chkLoopEnable
			// 
			this.chkLoopEnable.Location = new System.Drawing.Point(49, 18);
			this.chkLoopEnable.Name = "chkLoopEnable";
			this.chkLoopEnable.Size = new System.Drawing.Size(80, 20);
			this.chkLoopEnable.TabIndex = 13;
			this.chkLoopEnable.Text = "Enable";
			this.chkLoopEnable.UseVisualStyleBackColor = true;
			this.chkLoopEnable.CheckedChanged += new System.EventHandler(this.chkLoopEnable_CheckedChanged);
			// 
			// tmrUpdate
			// 
			this.tmrUpdate.Interval = 17;
			this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
			// 
			// BrstmConverterDialog
			// 
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(484, 182);
			this.Controls.Add(this.chkLoopEnable);
			this.Controls.Add(this.pnlEdit);
			this.Controls.Add(this.pnlInfo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(500, 216);
			this.Name = "BrstmConverterDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Brstm Import";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BrstmConverterDialog_KeyDown);
			this.groupBox1.ResumeLayout(false);
			this.pnlInfo.ResumeLayout(false);
			this.pnlInfo.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.pnlEdit.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.pnlLoop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.customTrackBar1)).EndInit();
			this.grpLoop.ResumeLayout(false);
			this.grpLoop.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndSeconds)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartSeconds)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numLoopStart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numLoopEnd)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private string _audioSource;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string AudioSource
        {
            get => _audioSource;
            set => _audioSource = value;
        }

        private FileMap _audioData;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FileMap AudioData
        {
            get => _audioData;
            set => _audioData = value;
        }

        private static WaveEncoding PreviousEncoding = WaveEncoding.ADPCM;

        private AudioProvider _provider;
        private AudioBuffer _buffer;

        private readonly IAudioStream _initialStream;
        private IAudioStream _sourceStream;

        private DateTime _sampleTime;
        private bool _playing;
        private bool _updating;

        private int secondsToSample(float seconds)
        {
            return (int)((seconds) * _sourceStream.Frequency);
        }
        private float sampleToSeconds(int sample)
        {
            return (float)((float)sample / _sourceStream.Frequency);
        }

        public BrstmConverterDialog()
        {
            InitializeComponent();
            ddlEncoding.Items.Clear();
            ddlEncoding.Items.Add(WaveEncoding.ADPCM);
            ddlEncoding.Items.Add(WaveEncoding.PCM16);
            ddlEncoding.SelectedItem = PreviousEncoding;
            tmrUpdate.Interval = 1000 / 60;
            dlgOpen.Filter = "PCM Audio (*.wav)|*.wav";
            MaximumSize = new System.Drawing.Size(this.Size.Width, this.Size.Height);
            MinimumSize = new System.Drawing.Size(this.Size.Width, this.Size.Height);
        }

        public BrstmConverterDialog(IAudioStream audioStream)
        {
            _initialStream = audioStream;
            Text = "Loop Point Definition";
            InitializeComponent();
            tmrUpdate.Interval = 1000 / 60;
            MaximumSize = new System.Drawing.Size(int.MaxValue, 216);
        }

        public new DialogResult ShowDialog(IWin32Window owner)
        {
            _audioData = null;
            DialogResult = DialogResult.Cancel;
            //try 
            //{ 
            return base.ShowDialog(owner);
            //}
            //catch (Exception x)
            //{
            //    DisposeProvider();  
            //    MessageBox.Show(x.ToString());
            //    return DialogResult.Cancel;
            //}
        }
        public bool doHeadlessLoad(string audioSourceIn = null)
        {
            bool result = false;

            if (audioSourceIn != null)
            {
                _audioSource = audioSourceIn;
            }

            if (_audioSource != null)
            {
                LoadAudio(AudioSource);
                btnOkay_Click(null, null);
                result = true;
            }

            return result;
        }
        protected override void OnShown(EventArgs e)
        {
            if (_provider == null)
            {
                _provider = AudioProvider.Create(null);
                if (_provider != null)
                {
                    _provider.Attach(this);
                }
                else
                {
                    btnPlay.Enabled = false;
                }
            }

            if (_initialStream != null)
            {
                LoadAudio("Internal audio");
                btnBrowse.Visible = false;
            }
            else if (_audioSource == null)
            {
                if (!LoadAudio())
                {
                    Close();
                    return;
                }
            }
            else if (!LoadAudio(_audioSource))
            {
                Close();
                return;
            }

            base.OnShown(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            DisposeProvider();
            base.OnClosed(e);
        }

        private void DisposeProvider()
        {
            DisposeSource();
            if (_provider != null)
            {
                _provider.Dispose();
                _provider = null;
            }
        }

        private void DisposeSource()
        {
            //Stop playback
            Stop();

            //Dispose buffer
            if (_buffer != null)
            {
                _buffer.Dispose();
                _buffer = null;
            }

            if (_initialStream != _sourceStream)
            {
                //Dispose stream
                if (_sourceStream != null)
                {
                    _sourceStream.Dispose();
                    _sourceStream = null;
                }

                chkLoopEnable.Checked = chkLoop.Checked = chkLoop.Enabled = false;
            }

            btnOkay.Enabled = false;
        }

        private bool LoadAudio()
        {
            if (dlgOpen.ShowDialog(this) != DialogResult.OK)
            {
                return false;
            }

            return LoadAudio(dlgOpen.FileName);
        }

        private bool LoadAudio(string path)
        {
            DisposeSource();

            //Get audio stream
            _sourceStream = _initialStream != null
                ? new InitialStreamWrapper(_initialStream)
                : WAV.FromFile(path);

            _audioSource = path;

            //Create buffer for stream
            if (_provider != null)
            {
                _buffer = _provider.CreateBuffer(_sourceStream);
                _buffer.Loop = chkLoop.Checked;
            }

            //Set controls
            _sampleTime = new DateTime((long) _sourceStream.Samples * 10000000 / _sourceStream.Frequency);

            txtPath.Text = _initialStream != null ? "Internal audio" : path;
            lblFrequency.Text = $"{_sourceStream.Frequency} Hz";
            lblSamples.Text = $"{_sourceStream.Samples}";

            customTrackBar1.Value = 0;
            customTrackBar1.TickStyle = TickStyle.None;
            customTrackBar1.Maximum = _sourceStream.Samples;
            customTrackBar1.TickFrequency = _sourceStream.Samples / 8;
            customTrackBar1.TickStyle = TickStyle.BottomRight;

            numLoopStart.Maximum = numLoopEnd.Maximum = _sourceStream.Samples;
            numericUpDownStartSeconds.Maximum = numericUpDownEndSeconds.Maximum =(decimal)sampleToSeconds((int)numLoopStart.Maximum);
            if (!_sourceStream.IsLooping)
            {
                numLoopStart.Value = 0;
                numLoopEnd.Value = _sourceStream.Samples;

                pnlLoopStart.Width = 0;
                pnlLoopEnd.Width = 0;
            }
            else
            {
                numLoopStart.Value = _sourceStream.LoopStartSample;
                numLoopEnd.Value = _sourceStream.LoopEndSample;
            }

            btnOkay.Enabled = true;

            if (_type == 0)
            {
                chkLoopEnable.Checked = true;
            }

            if (_type != 0)
            {
                groupBox3.Visible = false;
            }

            if (_initialStream != null)
            {
                groupBox3.Visible = false;
            }

            UpdateTimeDisplay();

            return true;
        }

        private void UpdateTimeDisplay()
        {
            if (_sourceStream != null)
            {
                DateTime t = new DateTime((long) customTrackBar1.Value * 10000000 / _sourceStream.Frequency);
                lblPlayTime.Text = $"{t:mm:ss.ff} / {_sampleTime:mm:ss.ff}";
            }
            else
            {
                lblPlayTime.Text = "";
            }
        }

        private void Play()
        {
            if (_playing || _buffer == null)
            {
                return;
            }

            _playing = true;

            if (customTrackBar1.Value == _sourceStream.Samples)
            {
                customTrackBar1.Value = 0;
            }

            _buffer.Seek(customTrackBar1.Value);

            tmrUpdate_Tick(null, null);
            tmrUpdate.Start();

            _buffer.Play();

            btnPlay.Text = "Stop";
        }

        private void Stop()
        {
            if (!_playing)
            {
                return;
            }

            _playing = false;

            tmrUpdate.Stop();

            _buffer?.Stop();

            btnPlay.Text = "Play";
        }

        private void Seek(int sample)
        {
            customTrackBar1.Value = sample;

            //Only seek the buffer when playing.
            if (_playing)
            {
                Stop();
                _buffer.Seek(sample);
                Play();
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (_playing)
            {
                Stop();
            }
            else
            {
                Play();
            }
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            if (_playing && _buffer != null)
            {
                _buffer.Fill();

                customTrackBar1.Value = _buffer.ReadSample;

                if (_buffer.ReadSample >= _sourceStream.Samples)
                {
                    Stop();
                }
            }
        }

        private void btnRewind_Click(object sender, EventArgs e)
        {
            Seek(0);
        }

        private void customTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            UpdateTimeDisplay();
        }

        private void customTrackBar1_UserSeek(object sender, EventArgs e)
        {
            Seek(customTrackBar1.Value);
        }

        private void pnlLoopStart_SizeChanged(object sender, EventArgs e)
        {
            if (_sourceStream == null || _updating)
            {
                return;
            }

            //Get approximate sample number from start of audio.
            float percent = (float) pnlLoopStart.Width / pnlLoop.Width;

            //Should we align to a chunk, or block?
            int startSample = (int) (_sourceStream.Samples * percent);

            _updating = true;
            numLoopStart.Value = startSample;
            _updating = false;
        }

        private void pnlLoopEnd_SizeChanged(object sender, EventArgs e)
        {
            if (_sourceStream == null || _updating)
            {
                return;
            }

            //Get approximate sample number from start of audio.
            float percent = 1.0f - (float) pnlLoopEnd.Width / pnlLoop.Width;

            //End sample doesn't need to be aligned
            int endSample = (int) (_sourceStream.Samples * percent);

            _updating = true;
            numLoopEnd.Value = endSample;
            _updating = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public int Type
        {
            get => _type;
            set
            {
                _type = value;
                Text = $"{(_type == 0 ? "Brstm" : "Wave")} Import";
            }
        }

        public int _type;

        private void btnOkay_Click(object sender, EventArgs e)
        {
            Stop();

            if (_sourceStream is InitialStreamWrapper w && w.BaseStream == _initialStream)
            {
                _initialStream.LoopStartSample = _sourceStream.LoopStartSample;
                _initialStream.LoopEndSample = _sourceStream.LoopEndSample;
                _initialStream.IsLooping = _sourceStream.IsLooping;
            }

            if (_initialStream == null)
            {
                using (ProgressWindow progress = new ProgressWindow(this,
                    $"{(_type == 0 ? "Brstm" : "Wave")} Converter", "Encoding, please wait...", false))
                {
                    switch (_type)
                    {
                        case 0:
                            WaveEncoding encoding = (WaveEncoding)ddlEncoding.SelectedItem;
                            PreviousEncoding = encoding;
                            _audioData = RSTMConverter.Encode(_sourceStream, progress, encoding);
                            break;
                        case 1:
                            _audioData = RSARWaveConverter.Encode(_sourceStream, progress);
                            break;
                        case 2:
                            _audioData = RWAVConverter.Encode(_sourceStream, progress);
                            break;
                    }
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void chkLoop_CheckedChanged(object sender, EventArgs e)
        {
            if (_buffer != null)
            {
                _buffer.Loop = chkLoop.Checked;
            }
        }

        private void chkLoopEnable_CheckedChanged(object sender, EventArgs e)
        {
            pnlLoop.Visible = grpLoop.Enabled =
                chkLoop.Enabled = btnFFwd.Enabled = btnLoopRW.Enabled = chkLoopEnable.Checked;
            if (!chkLoopEnable.Checked)
            {
                chkLoop.Checked = false;
            }

            if (_sourceStream != null)
            {
                if (chkLoopEnable.Checked)
                {
                    _sourceStream.IsLooping = true;
                    _sourceStream.LoopStartSample = (int) numLoopStart.Value;
                    _sourceStream.LoopEndSample = (int) numLoopEnd.Value;
                }
                else
                {
                    _sourceStream.IsLooping = false;
                    _sourceStream.LoopStartSample = 0;
                    _sourceStream.LoopEndSample = 0;
                }
            }
        }

        private void numLoopStart_ValueChanged(object sender, EventArgs e)
        {
            if (_sourceStream == null)
            {
                return;
            }

            if (!_updating)
            {
                float percent = (float) numLoopStart.Value / _sourceStream.Samples;

                _updating = true;
                pnlLoopStart.Width = (int) (pnlLoop.Width * percent);
                _updating = false;
            }

            if (_sourceStream.IsLooping)
            {
                _sourceStream.LoopStartSample = (int) numLoopStart.Value;
            }

            numericUpDownStartSeconds.Value = (decimal)(sampleToSeconds((int)numLoopStart.Value));
        }

        private void numLoopEnd_ValueChanged(object sender, EventArgs e)
        {
            if (_sourceStream == null)
            {
                return;
            }

            if (!_updating)
            {
                float percent = 1.0f - (float) numLoopEnd.Value / _sourceStream.Samples;

                _updating = true;
                pnlLoopEnd.Width = (int) (pnlLoop.Width * percent);
                _updating = false;
            }

            if (_sourceStream.IsLooping)
            {
                _sourceStream.LoopEndSample = (int) numLoopEnd.Value;
            }

            numericUpDownEndSeconds.Value = (decimal)(sampleToSeconds((int)numLoopEnd.Value));
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            LoadAudio();
        }

        private void btnStartSet_Click(object sender, EventArgs e)
        {
            numLoopStart.Value = customTrackBar1.Value;
        }

        private void btnEndSet_Click(object sender, EventArgs e)
        {
            numLoopEnd.Value = customTrackBar1.Value;
        }

        private void btnLoopRW_Click(object sender, EventArgs e)
        {
            Seek((int) numLoopStart.Value);
        }

        private void btnFFwd_Click(object sender, EventArgs e)
        {
            Seek((int) numLoopEnd.Value);
        }

        private void btnSeekEnd_Click(object sender, EventArgs e)
        {
            Seek(customTrackBar1.Maximum);
        }

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
            numericUpDownStartSeconds.Visible = numericUpDownStartSeconds.Enabled = numericUpDownStartSeconds.TabStop = checkBox1.Checked;
            numericUpDownEndSeconds.Visible = numericUpDownEndSeconds.Enabled = numericUpDownEndSeconds.TabStop = checkBox1.Checked;
            numLoopStart.Visible = numLoopStart.Enabled = numLoopStart.TabStop = !checkBox1.Checked;
            numLoopEnd.Visible = numLoopEnd.Enabled = numLoopEnd.TabStop = !checkBox1.Checked;
        }

		private void numericUpDownStartSeconds_ValueChanged(object sender, EventArgs e)
		{
            numLoopStart.Value = (decimal)(secondsToSample((float)numericUpDownStartSeconds.Value));
        }

		private void numericUpDownEndSeconds_ValueChanged(object sender, EventArgs e)
		{
            numLoopEnd.Value = (decimal)(secondsToSample((float)numericUpDownEndSeconds.Value));
        }

		private void numericUpDown_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter)
			{
                e.SuppressKeyPress = true;
			}
		}

		private void BrstmConverterDialog_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter)
			{
                if (!numLoopStart.Focused && !numLoopEnd.Focused &&
                    !numericUpDownStartSeconds.Focused && !numericUpDownEndSeconds.Focused)
                {
                    btnOkay_Click(this, EventArgs.Empty);
                }
            }
		}
	}
}