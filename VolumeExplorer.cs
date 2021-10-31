using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace EyeAssistant
{
    class VolumeExplorer
    {
        public int sgn;  // sign
        public int slope; // slope
        public int offset;  // offset

        public int height;
        public int width;

        private int VWidth;
        private int VHeight;

        private short Min;
        private short Max;

        private short MinL3;
        private short MaxL3;

        private int cellSize;

        private int drvVsign_I = 0;
        private int drvSlope_I = 0;
        private int drvOffset_I = 0;

        private int drvVsign_Q = 0;
        private int drvSlope_Q = 0;
        private int drvOffset_Q = 0;

        private int drvOffset;

        public short layer = 2;

        public bool drawGrid = true;

        private short[] mData;
        private double ColorStep;
        private double ColorStepL3;

        private bool hasDisplayedStatus = false;

        public string filepath;

        private Bitmap texture;
        private int VBOtexture;
        private long LoadedLayerIndex = -1;

        public VolumeExplorer(int ViewWidth = 800, int ViewHeight = 600)
        {
            VWidth = ViewWidth;
            VHeight = ViewHeight;
            InitView(VWidth, VHeight);
        }


        public VolumeExplorer(string filepath, int ViewWidth = 800, int ViewHeight = 600)
        {
            VWidth = ViewWidth;
            VHeight = ViewHeight;

            LoadBinary(filepath);
            InitView(VWidth, VHeight);
        }

        public bool LoadBinary(string __filepath)
        {
            filepath = __filepath;

            if (File.Exists(filepath))
            {
                FileStream stream = File.Open(filepath, FileMode.Open);

                if(stream.CanRead)
                {
                    BinaryReader reader = new BinaryReader(stream);
                    
                    sgn = reader.ReadUInt16();
                    slope = reader.ReadUInt16();
                    offset = reader.ReadUInt16();

                    height = reader.ReadUInt16();
                    width = reader.ReadUInt16();

                    cellSize = reader.ReadUInt16();

                    if (cellSize > 3)
                    {
                        MessageBox.Show("Unsupported legacy detected!");

                        filepath = null;

                        reader.Close();
                        stream.Close();

                        return false;
                    }

                    int length = cellSize * height * width * (sgn * sgn) * (slope  * slope) * (offset * offset);

                    Min = short.MaxValue;
                    Max = short.MinValue;

                    mData = new short[length];

                    for (uint i = 0; i < length; i++)
                    {
                        mData[i] = reader.ReadInt16();
                    }

                    MinL3 = short.MaxValue;
                    MaxL3 = short.MinValue;

                    for (uint i = 0; i < length; i += 3)
                    {
                        Min = Math.Min(mData[i + 0], Min);
                        Max = Math.Max(mData[i + 0], Max);

                        Min = Math.Min(mData[i + 1], Min);
                        Max = Math.Max(mData[i + 1], Max);

                        MinL3 = Math.Min(MinL3, mData[i + 2]);
                        MaxL3 = Math.Max(MaxL3, mData[i + 2]);
                    }

                    ColorStep = 255.0 / (Max - Min);
                    ColorStepL3 = 255.0 / (MaxL3 - MinL3);

                    reader.Close();
                    stream.Close();

                    return true;
                }

                stream.Close();
            }

            return false;
        }


        public (short, short) GetBounds(int sgn_o, int slope_o, int offset_o, int sgn_i, int slope_i, int offset_i)
        {
            int loffset = LOffset(sgn_o, slope_o, offset_o, sgn_i, slope_i, offset_i);
            short min = short.MaxValue;
            short max = short.MinValue;

            for (int xoffset, x = 0; x < width; x++)
            {
                xoffset = loffset + x * height * cellSize;

                for (int y = 0; y < height; y++)
                {
                    min = Math.Min(min, mData[xoffset + y * cellSize + layer]);
                    max = Math.Max(max, mData[xoffset + y * cellSize + layer]);
                }
            }

            return (min, max);
        }

        public short GetPoint(int vx, int vy)
        {
            int x = (short)Math.Round((width - 1) * vx / (float)VWidth) % width;
            int y = (short)Math.Round((height - 1) * vy / (float)VHeight) % height;

            if (LoadedLayerIndex >= 0)
            {
                int loffset = (int)LoadedLayerIndex;

                int xoffset = loffset + x * height * cellSize;

                return mData[xoffset + y * cellSize + layer];
            }

            return -1;
        }


        public void InitView(int ViewWidth = 800, int ViewHeight = 600)
        {
            GL.ShadeModel(ShadingModel.Smooth);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, height, 0, width, -1, 1);
            GL.Viewport(0, 0, VWidth, VHeight);
        }


        public void set_drv_slope_offs(bool component, int vsign, int slope, int offset)
        {
            if (component == true) // I
            {
                drvVsign_I = vsign;
                drvSlope_I = slope;
                drvOffset_I = offset;
            }
            else // Q
            {
                drvVsign_Q = vsign;
                drvSlope_Q = slope;
                drvOffset_Q = offset;
            }

            drvOffset = LOffset(drvVsign_I, drvSlope_I, drvOffset_I, drvVsign_Q, drvSlope_Q, drvOffset_Q);
        }


        public (int, int, int) FindSlopeC4(bool component)
        {
            int x = 64; // dco i
            int y = 64; // dco q

            Func<int, bool> setDco = (v) =>
            {
                if (component == true)
                {
                    y = 64;
                    x = v;

                    //m_trx->write(TRx::Regmap::tx_bb_q_dco, 64);
                    //m_trx->write(TRx::Regmap::tx_bb_i_dco, v);
                }
                else
                {
                    x = 64;
                    y = v;

                    //m_trx->write(TRx::Regmap::tx_bb_i_dco, 64);
                    //m_trx->write(TRx::Regmap::tx_bb_q_dco, v);
                }

                return true;
            };

            Func<bool, short> measureDiff = (_component) =>
            {
                int xoffset = drvOffset + (x / 8) * height * cellSize;

                if (_component == true) // I
                {
                    return mData[xoffset + (y / 8) * cellSize + 0];
                }
                else
                {
                    return mData[xoffset + (y / 8) * cellSize + 1];
                }
            };

            short bestDiff = 10000;

            int bestVsign = 0;
            int bestSlope = 0;
            int bestOffset = 0;

            bool settings_found = false;

            short leftDiff, rightDiff, midleDiff;

            short measurement_value;

            for (int slope = 0; (slope < 4) && (settings_found == false); slope++)
            {
                for (int sgn = 0; sgn < 2; sgn++)
                {
                    for (int offset = 0; offset < 4; offset++)
                    {
                        set_drv_slope_offs(component, sgn, slope, offset);

                        setDco(13);
                        measurement_value = measureDiff(component);

                        leftDiff = measurement_value;

                        setDco(0x40);
                        measurement_value = measureDiff(component);

                        midleDiff = Math.Abs(measurement_value);

                        setDco(115);
                        measurement_value = measureDiff(component);

                        rightDiff = measurement_value;

                        Console.WriteLine("Difference at dco (13): " + leftDiff.ToString() + " & dco (115): " + rightDiff.ToString() + '\n');

                        if (Math.Sign(leftDiff) != Math.Sign(rightDiff))
                        {
                            if (midleDiff < bestDiff)
                            {
                                bestDiff = midleDiff;

                                Console.WriteLine("Lower difference: " + bestDiff.ToString() + '\n');

                                bestVsign = sgn;
                                bestSlope = slope;
                                bestOffset = offset;

                                settings_found = true;
                            }
                        }
                    }
                }
            }

            if (settings_found == false)
            {
                Console.WriteLine("No TX DCO settings found!");
            }

            Console.WriteLine("best slope: " + bestSlope.ToString());
            Console.WriteLine("best vsign: " + bestVsign.ToString());
            Console.WriteLine("best offset: " + bestOffset.ToString());

            return (bestSlope, bestVsign, bestOffset);
        }


        public (int, int, int) FindSlopeC5(bool component) {

            int x = 64;
            int y = 64;

            Func<short> measureError = () =>
            {
                int xoffset = drvOffset + (x / 8) * height * cellSize;

                return mData[xoffset + (y / 8) * cellSize + 2];
            };

            double bestError = 1e6;

            int bestVsign = 0;
            int bestSlope = 0;
            int bestOffset = 0;

            double error = 1e6;

            bool sub_setting_found = false;

	        for (int slope = 3; (slope >= 0) && (sub_setting_found == false); slope--)
	        {
		        for (int vsign = 0; vsign< 2; vsign++)
		        {
			        for (int offset = 0; offset< 4; offset++)
			        {
				        set_drv_slope_offs(component, vsign, slope, offset);

                        error = (double)measureError();

				        if (error < bestError)
				        {
                            bestError = error;
                            bestVsign = vsign;
                            bestSlope = slope;
                            bestOffset = offset;

					        sub_setting_found = true;
                        }
                    }
		        }

		        if (sub_setting_found == true)
                {
                    double[] around = new double[5];

                    int index = 0;
                    for (int dcoI = 32; dcoI <= 96; dcoI += 64)
                    {
                        x = dcoI;

                        for (int dcoQ = 32; dcoQ <= 96; dcoQ += 64)
                        {
                            y = dcoQ;

                            around[index] = measureError();

                            index++;
                        }
                    }

                    x = 64;
                    y = 64;

                    around[4] = measureError();

                    int[] success_stages = { -1, -1 };

                    for (int in_slope = slope - 1; (in_slope >= 0) && ((success_stages[0] == -1) || (success_stages[1] == -1)); in_slope--)
                    {
                        int stage_index = (slope - 1) - in_slope;

                        set_drv_slope_offs(component, bestVsign, in_slope, bestOffset);

                        index = 0;
                        double err = 1e6;

                        for (int dcoI = 32; dcoI <= 96; dcoI += 64)
                        {
                            x = dcoI;

                            for (int dcoQ = 32; dcoQ <= 96; dcoQ += 64)
                            {
                                y = dcoQ;

                                err = measureError();

                                if (err <= (around[index] + 10))
                                {
                                    success_stages[stage_index]++;
                                }
                            }
                        }

                        x = 64;
                        y = 64;

                        err = measureError();

                        if (err <= (around[4] + 10))
                        {
                            success_stages[stage_index]++;
                        }

                        if (success_stages[stage_index] >= 2)
                        {
                            bestSlope = in_slope;
                        }
                    }

                    if ((success_stages[0] == -1) && (success_stages[1] == -1))
                    {
                        sub_setting_found = false;
                    }
                }
	        }

	        if (sub_setting_found == false)
            {
                Console.WriteLine("No TX DCO settings found!");
            }

            Console.WriteLine("best slope: " + bestSlope.ToString());
            Console.WriteLine("best vsign: " + bestVsign.ToString());
            Console.WriteLine("best offset: " + bestOffset.ToString());

            return (bestSlope, bestVsign, bestOffset);
        }


        public Color TColor(short value)
        {
            double step = 0;
            short min = 0, max = 0;

            switch(layer)
            {
                case 0:
                case 1:
                    min = Min;
                    max = Max;

                    step = ColorStep;

                    break;
                case 2:
                    min = MinL3;
                    max = MaxL3;

                    step = ColorStepL3;

                    break;
            }

            byte color = 0;
            byte alpha = ((max < value) || (value < min)) ? (byte)0 : (byte)255;

            if (alpha > 0)
            {
                color = Math.Max((byte)0, (byte)Math.Min((int)255, (int)((value - min) * step)));
            }

            return Color.FromArgb(alpha, color, color, color);
        }


        private void Load2DTexture()
        {
            GL.BindTexture(TextureTarget.Texture2D, VBOtexture);

            BitmapData data = texture.LockBits(new Rectangle(0, 0, texture.Width, texture.Height),
                                               ImageLockMode.ReadOnly,
                                               System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(
                TextureTarget.Texture2D,
                0,
                PixelInternalFormat.Rgba,
                data.Width,
                data.Height,
                0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra,
                PixelType.UnsignedByte,
                data.Scan0
            );

            texture.UnlockBits(data);

            GL.TexParameter(
                TextureTarget.Texture2D,
                TextureParameterName.TextureMinFilter,
                (int)TextureMinFilter.Linear
            );

            GL.TexParameter(
                TextureTarget.Texture2D,
                TextureParameterName.TextureMagFilter,
                (int)TextureMagFilter.Linear
            );

            ErrorCode e = GL.GetError();
            string str = e.ToString();
        }

        public int LOffset(int sgn_o, int slope_o, int offset_o, int sgn_i, int slope_i, int offset_i)
        {
            return sgn_o        * ((sgn) * (slope * slope) * (offset * offset) * height * width) * cellSize
                   + slope_o    * (sgn * slope * (offset * offset) * height * width) * cellSize
                   + offset_o   * (sgn * slope * offset * height * width) * cellSize
                   + sgn_i      * (slope * offset * height * width) * cellSize
                   + slope_i    * (offset * height * width) * cellSize
                   + offset_i   * (height * width) * cellSize;
        }


        public void RenderFrame(int loffset)
        {
            Bitmap original = new Bitmap(width, height);

            for (int xoffset, x = 0; x < width; x++)
            {
                xoffset = loffset + x * height * cellSize;

                for (int y = 0; y < height; y++)
                {
                    original.SetPixel(x, height - 1 - y, TColor(mData[xoffset + y * cellSize + layer]));
                }
            }

            if (texture != null)
            {
                texture.Dispose();
            }

            texture = new Bitmap(original, new Size(VWidth, VHeight));

            if (drawGrid == true)
            {
                for (float x = 0; x < (VWidth + 1); x += (float)VWidth / 15.0f)
                {
                    for (float y = 0; y < (VHeight + 1); y += (float)VHeight / 15.0f)
                    {
                        int xx = Math.Min(Math.Max(0, (int)x), VWidth - 1);
                        int yy = Math.Min(Math.Max(0, (int)y), VHeight - 1);

                        if ((x == 64f) && (y == 64f))
                        {
                            texture.SetPixel(xx, yy, Color.Red);
                        }
                        else
                        {
                            texture.SetPixel(xx, yy, Color.GreenYellow);
                        }
                    }
                }
            }

            original.Dispose();

            if (layer < 2)
            {
                List<PointF> points = new List<PointF>();

                for (int xoffset, x = 0; x < width; x++)
                {
                    xoffset = loffset + x * height * cellSize;

                    for (int y = 0; y < height; y++)
                    {
                        short v = mData[xoffset + y * cellSize + layer];

                        if (Math.Abs(v) < 100)
                        {
                            float xx = (VWidth / width) * x;
                            float yy = VHeight - 1 - (VHeight / height) * y;

                            points.Add(new PointF(xx, yy));
                        }
                    }
                }

                if (points.Count > 2)
                {
                    using (Graphics gr = Graphics.FromImage(texture))
                    {
                        Pen pen = new Pen(Color.Red, 3);

                        gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                        gr.DrawBeziers(pen, points.Take(points.Count - ((points.Count - 1) % 3)).ToArray());
                    }
                }
            }
        }


        //FPS = ~900
        private void DrawTexture(int sgn_o, int slope_o, int offset_o, int sgn_i, int slope_i, int offset_i)
        {
            int loffset = LOffset(sgn_o, slope_o, offset_o, sgn_i, slope_i, offset_i);

            if (LoadedLayerIndex != loffset)
            {
                RenderFrame(loffset);
                Load2DTexture();
                LoadedLayerIndex = loffset;
            }

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, VBOtexture);
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.White);
            GL.TexCoord2(0f, 0f);
            GL.Vertex2(0, 0);

            GL.TexCoord2(0f, 1f);
            GL.Vertex2(0, height);


            GL.TexCoord2(1f, 1f);
            GL.Vertex2(width, height);


            GL.TexCoord2(1f, 0f);
            GL.Vertex2(width, 0);

            GL.End();

            GL.Disable(EnableCap.Texture2D);
        }
        

        public void DropTexture()
        {
            LoadedLayerIndex = -1;
        }


        public void Explore(int sgn_o, int slope_o, int offset_o, int sgn_i, int slope_i, int offset_i)
        {
            DrawTexture(sgn_o, slope_o, offset_o, sgn_i, slope_i, offset_i);
        }
    }
}
