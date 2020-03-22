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
        int FrameCount;
        DateTime NextFPSUpdate = DateTime.Now.AddSeconds(1);
        private void ApplicationIdle(object sender, EventArgs e)
        {
            while(GLViewRight.IsIdle || GLViewLeft.IsIdle)
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

            Globals.Explorer[0] = new VolumeExplorer("D:\\Disk E\\GlazSegment_at_12_5_17\\GlazSegment\\GlazSegment\\bin\\Debug\\p1-before-left.bin", Globals.GLView[0].Width, Globals.GLView[0].Height);
            Globals.Explorer[1] = new VolumeExplorer("D:\\Disk E\\GlazSegment_at_12_5_17\\GlazSegment\\GlazSegment\\bin\\Debug\\p1-before-left.bin", Globals.GLView[1].Width, Globals.GLView[1].Height);

            trackBar1.Minimum = 0;
            trackBar1.Maximum = Globals.Explorer[0].Depth;

            Application.Idle += ApplicationIdle;
        }

        private void GLViewLeft_Paint(object sender, PaintEventArgs e)
        {
            GLViewLeft.MakeCurrent();
            Globals.Explorer[0].InitView(Globals.GLView[0].Width, Globals.GLView[0].Height);
            Globals.Explorer[0].DrawQuads(trackBar1.Value);
            GLViewLeft.SwapBuffers();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            GLViewLeft.Invalidate();
            GLViewRight.Invalidate();
        }

        private void GLViewRight_Paint(object sender, PaintEventArgs e)
        {
            GLViewRight.MakeCurrent();
            Globals.Explorer[1].InitView(Globals.GLView[1].Width, Globals.GLView[1].Height);
            Globals.Explorer[1].DrawQuads(trackBar1.Value);
            GLViewRight.SwapBuffers();
        }
    }
}
