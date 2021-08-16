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

        private ushort Min;
        private ushort Max;

        public ushort OutputMin;
        public ushort OutputMax;

        private ushort[] mData;
        private double ColorStep;

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

                    int length = height * width * (sgn * sgn) * (slope  * slope) * (offset * offset);

                    Min = ushort.MaxValue;
                    Max = ushort.MinValue;

                    mData = new ushort[length];

                    for (uint i = 0; i < length; i++)
                    {
                        mData[i] = reader.ReadUInt16();

                        Min = mData[i] < Min ? mData[i] : Min;
                        Max = mData[i] > Max ? mData[i] : Max;
                    }

                    OutputMin = Min;
                    OutputMax = Max;

                    ColorStep = 255.0 / (Max - Min);

                    reader.Close();
                    stream.Close();

                    return true;
                }

                stream.Close();
            }

            return false;
        }


        public (ushort, ushort) GetBounds(int sgn_o, int slope_o, int offset_o, int sgn_i, int slope_i, int offset_i)
        {
            int loffset = LOffset(sgn_o, slope_o, offset_o, sgn_i, slope_i, offset_i);
            ushort min = ushort.MaxValue;
            ushort max = ushort.MinValue;

            for (int xoffset, x = 0; x < width; x++)
            {
                xoffset = loffset + x * height;

                for (int y = 0; y < height; y++)
                {
                    min = Math.Min(min, mData[xoffset + y]);
                    max = Math.Max(max, mData[xoffset + y]);
                }
            }

            return (min, max);
        }


        public void InitView(int ViewWidth = 800, int ViewHeight = 600)
        {
            GL.ShadeModel(ShadingModel.Smooth);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, height, 0, width, -1, 1);
            GL.Viewport(0, 0, VWidth, VHeight);
        }


        public Color TColor(ushort value)
        {
            byte color = 0;
            byte alpha = (Math.Min(OutputMax, Max) < value || value < Math.Max(OutputMin, Min)) ? (byte)0 : (byte)255;

            if (alpha > 0)
            {
                color = Math.Max((byte)0, (byte)Math.Min((int)255, (int)((value - Min) * ColorStep)));
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
            return sgn_o        * ((sgn) * (slope * slope) * (offset * offset) * height * width)
                   + slope_o    * (sgn * slope * (offset * offset) * height * width)
                   + offset_o   * (sgn * slope * offset * height * width)
                   + sgn_i      * (slope * offset * height * width)
                   + slope_i    * (offset * height * width)
                   + offset_i   * (height * width);
        }


        public void RenderFrame(int loffset)
        {
            Bitmap original = new Bitmap(width, height);

            for (int xoffset, x = 0; x < width; x++)
            {
                xoffset = loffset + x * height;

                for (int y = 0; y < height; y++)
                {
                    original.SetPixel(x, y, TColor(mData[xoffset + y]));
                }
            }

            if (texture != null)
            {
                texture.Dispose();
            }

            texture = new Bitmap(original, new Size(VWidth, VHeight));
            original.Dispose();
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
