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
            while (GLViewRight.IsIdle || GLViewLeft.IsIdle)
            {
                displayFPS();

                GLViewRight.Invalidate();
                GLViewLeft.Invalidate();
            }
        }

        private void displayFPS()
        {
            if (DateTime.Now >= NextFPSUpdate)
            {
                this.Text = String.Format("FPS={0}", FrameCount);
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
            Globals.GLView = new OpenTK.GLControl[2];
            Globals.Explorer = new VolumeExplorer[2];

            Globals.GLView[0] = GLViewLeft;
            Globals.GLView[1] = GLViewRight;

            Globals.Explorer[0] = new VolumeExplorer(Globals.GLView[0].Width, Globals.GLView[0].Height);
            Globals.Explorer[1] = new VolumeExplorer(Globals.GLView[1].Width, Globals.GLView[1].Height);

            Globals.Explorer[0].SetDrawMode(VolumeExplorer.DRAWMODE.Texture);
            Globals.Explorer[1].SetDrawMode(VolumeExplorer.DRAWMODE.Texture);

            Application.Idle += ApplicationIdle;
        }

        private void GLViewLeft_Paint(object sender, PaintEventArgs e)
        {
            GLViewLeft.MakeCurrent();
            Globals.Explorer[0].InitView(Globals.GLView[0].Width, Globals.GLView[0].Height);
            Globals.Explorer[0].Explore(hScroll.Value);
            GLViewLeft.SwapBuffers();
        }

        private void GLViewRight_Paint(object sender, PaintEventArgs e)
        {
            GLViewRight.MakeCurrent();
            Globals.Explorer[1].InitView(Globals.GLView[1].Width, Globals.GLView[1].Height);
            Globals.Explorer[1].Explore(hScroll.Value);
            GLViewRight.SwapBuffers();
        }

        private void hScroll_Scroll(object sender, ScrollEventArgs e)
        {
            GLViewLeft.Invalidate();
            GLViewRight.Invalidate();
        }

        private void densityMin_TextChanged(object sender, EventArgs e)
        {
            char[] rule = { '-', '+' };
            if (densityMin.Text.All(char.IsDigit) || densityMin.Text.IndexOfAny(rule) >= 0)
            {
                Globals.Explorer[0].OutputMin = (short)Math.Max(Math.Min(Convert.ToInt32(densityMin.Text), 32767), -32768);
                Globals.Explorer[1].OutputMin = (short)Math.Max(Math.Min(Convert.ToInt32(densityMin.Text), 32767), -32768);

                Globals.Explorer[0].DropTexture();
                Globals.Explorer[1].DropTexture();

                GLViewLeft.Invalidate();
                GLViewRight.Invalidate();
            }
        }

        private void densityMax_TextChanged(object sender, EventArgs e)
        {
            char[] rule = { '-', '+' };
            if (densityMax.Text.All(char.IsDigit) || densityMax.Text.IndexOfAny(rule) >= 0)
            {
                Globals.Explorer[0].OutputMax = (short)Math.Max(Math.Min(Convert.ToInt32(densityMax.Text), 32767), -32768);
                Globals.Explorer[1].OutputMax = (short)Math.Max(Math.Min(Convert.ToInt32(densityMax.Text), 32767), -32768);

                Globals.Explorer[0].DropTexture();
                Globals.Explorer[1].DropTexture();

                GLViewLeft.Invalidate();
                GLViewRight.Invalidate();
            }
        }

        private void radioDrawSwitcher(object sender, EventArgs e)
        {
            var checkedButton = drawModeGroup.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            switch(checkedButton.Name)
            {
                case "radioDrawQuads":
                    {
                        Globals.Explorer[0].SetDrawMode(VolumeExplorer.DRAWMODE.Quads);
                        Globals.Explorer[1].SetDrawMode(VolumeExplorer.DRAWMODE.Quads);
                    }; break;
                case "radioQuadsStrip":
                    {
                        Globals.Explorer[0].SetDrawMode(VolumeExplorer.DRAWMODE.QuadStrip);
                        Globals.Explorer[1].SetDrawMode(VolumeExplorer.DRAWMODE.QuadStrip);
                    }; break;
                case "radioTexture":
                    {
                        Globals.Explorer[0].SetDrawMode(VolumeExplorer.DRAWMODE.Texture);
                        Globals.Explorer[1].SetDrawMode(VolumeExplorer.DRAWMODE.Texture);
                    }; break;
                default: return;
            }
        }

        public bool[] isLoaded = new bool[2];

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog[] fileRequest = new OpenFileDialog[2];

            fileRequest[0] = new OpenFileDialog();
            fileRequest[1] = new OpenFileDialog();

            if (fileRequest[0].ShowDialog() == DialogResult.OK && fileRequest[1].ShowDialog() == DialogResult.OK)
            {
                isLoaded[0] = Globals.Explorer[0].LoadBinary(fileRequest[0].FileName);
                isLoaded[1] = Globals.Explorer[1].LoadBinary(fileRequest[1].FileName);

                filepathLeft.Text = fileRequest[0].FileName;
                filepathRight.Text = fileRequest[1].FileName;

                loadData();
            }

            fileRequest[0].Dispose();
            fileRequest[1].Dispose();
        }

        private void openLeft(object sender, EventArgs e)
        {
            OpenFileDialog fileRequest = new OpenFileDialog();
            if (fileRequest.ShowDialog() == DialogResult.OK)
            {
                isLoaded[0] = Globals.Explorer[0].LoadBinary(fileRequest.FileName);

                if (isLoaded[0])
                {
                    filepathLeft.Text = fileRequest.FileName;

                    loadData();
                }
            }

            fileRequest.Dispose();
        }

        private void openRight(object sender, EventArgs e)
        {
            OpenFileDialog fileRequest = new OpenFileDialog();
            if (fileRequest.ShowDialog() == DialogResult.OK)
            {
                isLoaded[1] = Globals.Explorer[1].LoadBinary(fileRequest.FileName);

                if (isLoaded[1])
                {
                    filepathRight.Text = fileRequest.FileName;

                    loadData();
                }
            }

            fileRequest.Dispose();
        }

        private void loadData()
        {
            if (isLoaded[0] && isLoaded[1])
            {
                (short min_0, short max_0) = Globals.Explorer[0].GetBounds();
                (short min_1, short max_1) = Globals.Explorer[1].GetBounds();

                densityMin.Text = Math.Min(min_0, min_1).ToString();
                densityMax.Text = Math.Max(max_0, max_1).ToString();

                hScroll.Minimum = 0;
                hScroll.Maximum = Math.Min(Globals.Explorer[0].Depth, Globals.Explorer[1].Depth);
            }

            display.Enabled = isLoaded[0] && isLoaded[1];
        }
    }
}
