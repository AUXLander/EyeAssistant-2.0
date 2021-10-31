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
                int sgnI = trackSgnOffI.Value >= 0 ? 1 : 0;
                int sgnQ = trackSgnOffQ.Value >= 0 ? 0 : 1;

                int slpI = trackSlopeI.Maximum - trackSlopeI.Value;
                int slpQ = trackSlopeQ.Value;

                int offI = Math.Abs(trackSgnOffI.Value) - 1 + sgnI;
                int offQ = Math.Abs(trackSgnOffQ.Value + sgnQ);

                GLView.MakeCurrent();

                Globals.Explorer.InitView(Globals.GLView.Width, Globals.GLView.Height);
                Globals.Explorer.Explore(sgnI, slpI, offI, sgnQ, slpQ, offQ);

                (short min, short max) = Globals.Explorer.GetBounds(sgnI, slpI, offI, sgnQ, slpQ, offQ);

                densityMin.Text = min.ToString();
                densityMax.Text = max.ToString();

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

            if (fileRequest.ShowDialog() == DialogResult.OK)
            {
                isLoaded = Globals.Explorer.LoadBinary(fileRequest.FileName);

                if (isLoaded == true)
                {
                    this.Text = fileRequest.FileName;

                    display.Enabled = isLoaded;
                }
            }

            fileRequest.Dispose();
        }

        private void vhScroll(object sender, EventArgs e)
        {
            GLView.Invalidate();
        }

        private void radioLayerCheckedChanged(object sender, EventArgs e)
        {
            if (radioLayer0.Checked == true)
            {
                Globals.Explorer.layer = 0;
            }
            else if (radioLayer1.Checked == true)
            {
                Globals.Explorer.layer = 1;
            }
            else if (radioLayer2.Checked == true)
            {
                Globals.Explorer.layer = 2;
            }

            Globals.Explorer.DropTexture();
            GLView.Invalidate();
        }

        private void radioGridCheckedChanged(object sender, EventArgs e)
        {
            if (radioGridEn.Checked == true)
            {
                Globals.Explorer.drawGrid = true;
            }
            else if (radioGridDis.Checked == true)
            {
                Globals.Explorer.drawGrid = false;
            }

            Globals.Explorer.DropTexture();
            GLView.Invalidate();
        }

        private void GLView_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            densityPoint.Text = Globals.Explorer.GetPoint(x, y).ToString();
        }

        private void btnFindSlope_Click(object sender, EventArgs e)
        {
            int VoffsetI;
            int VoffsetQ;

            int slopeI = 0, slopeQ = 0;
            int signI = 0, signQ = 0;
            int offsetI = 0, offsetQ = 0;

            if (cmbFind.SelectedItem != null)
            {
                const int repeats = 2;

                Globals.Explorer.set_drv_slope_offs(true, 0, 0, 0);
                Globals.Explorer.set_drv_slope_offs(false, 0, 0, 0);

                switch ((string)cmbFind.SelectedItem)
                {
                    case "C4":
                        {
                            for (int i = 0; i < repeats; i++)
                            {
                                (slopeI, signI, offsetI) = Globals.Explorer.FindSlopeC4(true);
                                (slopeQ, signQ, offsetQ) = Globals.Explorer.FindSlopeC4(false);
                            }
                        };
                        break;

                    case "C5":
                        {

                            for (int i = 0; i < repeats; i++)
                            {
                                (slopeI, signI, offsetI) = Globals.Explorer.FindSlopeC5(true);
                                (slopeQ, signQ, offsetQ) = Globals.Explorer.FindSlopeC5(false);
                            }
                        };
                        break;

                    default:

                        MessageBox.Show("Unknown algorithm!");

                        return;
                }

                VoffsetI = signI > 0 ? +1 * offsetI : -1 * offsetI;
                VoffsetQ = signQ > 0 ? -1 * offsetQ : +1 * offsetQ;

                trackSlopeI.Value = trackSlopeI.Maximum - slopeI;
                trackSlopeQ.Value = slopeI;

                trackSgnOffI.Value = VoffsetI - 1 + signI;
                trackSgnOffQ.Value = VoffsetQ;

                Console.WriteLine("best slope I: " + slopeI.ToString() + " Q: " + slopeQ.ToString());
                Console.WriteLine("best vsign I: " + signI.ToString() + " Q: " + signQ.ToString());
                Console.WriteLine("best offset I: " + offsetI.ToString() + " Q: " + offsetQ.ToString());
            }
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
