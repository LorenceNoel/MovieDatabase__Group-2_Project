using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Drawing;

namespace Movie_Database_Application.Forms
{
    public class MoviePlayerForm : Form
    {
        private TextBox txtFilePath;
        private Button btnOpenFile;
        private Button btnPlay;
        private Button btnOpenExternal;
        private Button btnClose;
        private Label lblInfo;
        private WmpHost wmpHost;

        public MoviePlayerForm(string suggestedTitle = null, string filePath = null)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(suggestedTitle))
                lblInfo.Text = $"Movie: {suggestedTitle}";

            if (!string.IsNullOrEmpty(filePath))
            {
                txtFilePath.Text = filePath;
                TryPlayInControl(filePath);
            }
        }

        private void InitializeComponent()
        {
            this.txtFilePath = new TextBox();
            this.btnOpenFile = new Button();
            this.btnPlay = new Button();
            this.btnOpenExternal = new Button();
            this.btnClose = new Button();
            this.wmpHost = new WmpHost();
            this.lblInfo = new Label();

            this.SuspendLayout();

            // txtFilePath
            this.txtFilePath.Location = new Point(12, 12);
            this.txtFilePath.Size = new Size(600, 27);
            this.txtFilePath.ReadOnly = true;

            // btnOpenFile
            this.btnOpenFile.Location = new Point(620, 10);
            this.btnOpenFile.Size = new Size(90, 30);
            this.btnOpenFile.Text = "Open...";
            this.btnOpenFile.Click += BtnOpenFile_Click;

            // btnPlay
            this.btnPlay.Location = new Point(720, 10);
            this.btnPlay.Size = new Size(70, 30);
            this.btnPlay.Text = "Play";
            this.btnPlay.Click += BtnPlay_Click;

            // btnOpenExternal
            this.btnOpenExternal.Location = new Point(800, 10);
            this.btnOpenExternal.Size = new Size(110, 30);
            this.btnOpenExternal.Text = "Open External";
            this.btnOpenExternal.Click += BtnOpenExternal_Click;

            // lblInfo
            this.lblInfo.Location = new Point(12, 45);
            this.lblInfo.Size = new Size(600, 25);
            this.lblInfo.Text = "";

            // wmpHost
            this.wmpHost.Location = new Point(12, 75);
            this.wmpHost.Size = new Size(900, 460);

            // btnClose
            this.btnClose.Location = new Point(824, 545);
            this.btnClose.Size = new Size(80, 30);
            this.btnClose.Text = "Close";
            this.btnClose.Click += (s, e) => this.Close();

            // MoviePlayerForm
            this.ClientSize = new Size(926, 587);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnOpenExternal);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.wmpHost);
            this.Controls.Add(this.btnClose);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Movie Player";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void BtnOpenFile_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Filter = "Video Files|*.mp4;*.mkv;*.avi;*.wmv;*.mov;*.mpg;*.mpeg|All Files|*.*";    //resricted to only file formats that support video
            ofd.Title = "Select a video file to play";
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                txtFilePath.Text = ofd.FileName;
                TryPlayInControl(ofd.FileName);
            }
        }

        private void BtnPlay_Click(object? sender, EventArgs e)
        {
            string path = txtFilePath.Text;
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                MessageBox.Show(this, "Please select a valid video file first.", "No File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TryPlayInControl(path);
        }

        private void BtnOpenExternal_Click(object? sender, EventArgs e)
        {
            string path = txtFilePath.Text;
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                MessageBox.Show(this, "Please select a valid video file first.", "No File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenExternal(path);
        }

        private void OpenExternal(string path)
        {
            try
            {
                var psi = new ProcessStartInfo(path)
                {
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Failed to open external player: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TryPlayInControl(string path)
        {
            if (!File.Exists(path)) return;

            try
            {
                wmpHost.Play(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Embedded playback failed: {ex.Message}\nTrying external player.", "Playback Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                OpenExternal(path);
            }
        }

        // Lightweight AxHost wrapper for Windows Media Player ActiveX control.
        // CLSID for Windows Media Player "6BF52A52-394A-11D3-B153-00C04F79FAA6"
        private class WmpHost : AxHost
        {
            public WmpHost() : base("6BF52A52-394A-11D3-B153-00C04F79FAA6") { }

            // Play a file by setting the URL on the underlying ActiveX control
            public void Play(string path)
            {
                if (string.IsNullOrEmpty(path)) return;

                object ocx = null;
                try
                {
                    ocx = this.GetOcx();
                }
                catch
                {
                    // GetOcx may throw if control not created yet; ensure created
                    CreateControl();
                    ocx = this.GetOcx();
                }

                if (ocx != null)
                {
                    try
                    {
                        dynamic player = ocx;
                        player.URL = path;
                        // ensure it plays
                        player.controls.play();
                    }
                    catch (Exception ex)
                    {
                        throw new InvalidOperationException("Failed to set URL on Windows Media Player control.", ex);
                    }
                }
                else
                {
                    throw new InvalidOperationException("Windows Media Player ActiveX control unavailable.");
                }
            }

            // Expose protected GetOcx via wrapper method if needed
            private object GetOcx()
            {
                return base.GetOcx();
            }
        }
    }
}
