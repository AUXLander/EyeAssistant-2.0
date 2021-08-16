using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;

namespace EyeAssistant
{
    public partial class MainForm : Form
    {
        long FrameCount;
        DateTime NextFPSUpdate = DateTime.Now.AddSeconds(1);
        private void ApplicationIdle(object sender, EventArgs e)
        {
            while (GLView.IsIdle)
            {
                displayFPS();

                GLView.Invalidate();
            }
        }


        private void displayFPS()
        {
            if (DateTime.Now >= NextFPSUpdate)
            {
                this.Text = String.Format("FPS={0} File = {1}", FrameCount, Globals.Explorer.filepath);
                NextFPSUpdate = DateTime.Now.AddSeconds(1);
                FrameCount = 0;
            }

            FrameCount++;
        }


        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            Globals.GLView = new OpenTK.GLControl();
            Globals.Explorer = new VolumeExplorer();

            Globals.GLView = GLView;

            Globals.Explorer = new VolumeExplorer(Globals.GLView.Width, Globals.GLView.Height);

            Application.Idle += ApplicationIdle;
        }


        private void GLViewLeft_Paint(object sender, PaintEventArgs e)
        {
            if (isLoaded)
            {
                int sgnI = trackSgnOffI.Value >= 0 ? 0 : 1;
                int sgnQ = trackSgnOffQ.Value >= 0 ? 0 : 1;

                int slpI = trackSlopeI.Value;
                int slpQ = trackSlopeQ.Value;

                int offI = Math.Abs(trackSgnOffI.Value + sgnI);
                int offQ = Math.Abs(trackSgnOffQ.Value + sgnQ);

                GLView.MakeCurrent();

                Globals.Explorer.InitView(Globals.GLView.Width, Globals.GLView.Height);
                Globals.Explorer.Explore(sgnI, slpI, offI, sgnQ, slpQ, offQ);

                (ushort min_0, ushort max_0) = Globals.Explorer.GetBounds(sgnI, slpI, offI, sgnQ, slpQ, offQ);

                densityMin.Text = min_0.ToString();
                densityMax.Text = max_0.ToString();

                GLView.SwapBuffers();
            }
        }

        //private void densityMin_TextChanged(object sender, EventArgs e)
        //{
        //    char[] rule = { '-', '+' };
        //    if (densityMin.Text.All(char.IsDigit) || densityMin.Text.IndexOfAny(rule) >= 0)
        //    {
        //        Globals.Explorer.OutputMin = (ushort)Math.Max(Math.Min(Convert.ToInt32(densityMin.Text), 32767), -32768);

        //        Globals.Explorer.DropTexture();

        //        GLView.Invalidate();
        //    }
        //}


        //private void densityMax_TextChanged(object sender, EventArgs e)
        //{
        //    char[] rule = { '-', '+' };
        //    if (densityMax.Text.All(char.IsDigit) || densityMax.Text.IndexOfAny(rule) >= 0)
        //    {
        //        Globals.Explorer.OutputMax = (ushort)Math.Max(Math.Min(Convert.ToInt32(densityMax.Text), 32767), -32768);

        //        Globals.Explorer.DropTexture();

        //        GLView.Invalidate();
        //    }
        //}

        public bool isLoaded = false;


        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileRequest = new OpenFileDialog();

            fileRequest = new OpenFileDialog();

            if (fileRequest.ShowDialog() == DialogResult.OK)
            {
                isLoaded = Globals.Explorer.LoadBinary(fileRequest.FileName);

                this.Text = fileRequest.FileName;

                display.Enabled = isLoaded;
            }

            fileRequest.Dispose();
        }

        private void vhScroll(object sender, EventArgs e)
        {
            GLView.Invalidate();
        }
    }
}
