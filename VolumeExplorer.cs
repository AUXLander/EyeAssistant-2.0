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
        public enum STATUS
        {
            BadFile = -3,
            CannotRead = -2,
            BadPath = -1,
            NotInitialized = 0,
            OK = 1,
        }

        public int Depth;
        private int Width;
        private int Height;

        private int VWidth;
        private int VHeight;

        private int Length;

        private short Min;
        private short Max;

        private int XScale;
        private int YScale;
        private int ZScale;

        private short[] mData;
        private double ColorStep;
        private STATUS Status = STATUS.NotInitialized;

        private string _filepath;
        private byte DrawMode;

        private Bitmap texture;
        private int VBOtexture;
        private int LoadedLayerIndex = -1;

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


        public bool ErrorInfo(STATUS ST = STATUS.OK)
        {
            if(ST == STATUS.OK)
            {
                ST = Status;
            }
            switch (ST)
            {
                case STATUS.OK:
                    {
                        return true;
                    };
                case STATUS.BadFile:
                    {
                        MessageBox.Show("File's binary length is too short. File's target is missing or file has been damaged.");
                    };
                    break;
                case STATUS.BadPath:
                    {
                        MessageBox.Show("Cannot find file at \"" + _filepath + '\"');
                    };
                    break;
                case STATUS.CannotRead:
                    {
                        MessageBox.Show("File has been corrupted. Cannot read file at \"" + _filepath + '\"');
                    };
                    break;
                case STATUS.NotInitialized:
                    {
                        MessageBox.Show("File hasn't been uploaded.");
                    };
                    break;
                default:
                    {
                        MessageBox.Show("Unknown error");
                    };
                    break;
            }
            return false;
        }


        public void LoadBinary(string filepath)
        {
            _filepath = filepath;
            if (File.Exists(filepath))
            {
                FileStream Stream = File.Open(filepath, FileMode.Open);
                if(Stream.CanRead)
                {
                    if(Stream.Length > 3*4)
                    {
                        BinaryReader Reader = new BinaryReader(Stream);
                        Width = Reader.ReadInt32();
                        Height = Reader.ReadInt32();
                        Depth = Reader.ReadInt32();

                        XScale = Reader.ReadInt32();
                        YScale = Reader.ReadInt32();
                        ZScale = Reader.ReadInt32();

                        int length = Width * Height * Depth;
                        
                        if (Stream.Length > 3 * 4 + length * 2)
                        {
                            mData = new short[length];
                            
                            mData[0] = Reader.ReadInt16();

                            short min = mData[0];
                            short max = mData[0];

                            for (int i = 1; i < length; i++)
                            {
                                mData[i] = Reader.ReadInt16();
                                if(mData[i] < min)
                                {
                                    min = mData[i];
                                }
                                if(mData[i] > max)
                                {
                                    max = mData[i];
                                }
                            }

                            Min = min;
                            Max = max;

                            ColorStep = 255.0 / (max - min);

                            Status = STATUS.OK;
                        }
                        else
                        {
                            Status = STATUS.BadFile;
                            ErrorInfo();
                        }

                        Reader.Close();
                    }
                    else
                    {
                        Status = STATUS.BadFile;
                        ErrorInfo();
                    }
                }
                else
                {
                    Status = STATUS.CannotRead;
                    ErrorInfo();
                }

                Stream.Close();
            }
            else
            {
                Status = STATUS.BadPath;
                ErrorInfo();
            }
        }

        public void InitView(int ViewWidth = 800, int ViewHeight = 600)
        {
            GL.ShadeModel(ShadingModel.Smooth);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, Width, 0, Height, -1, 1);
            GL.Viewport(0, 0, VWidth, VHeight);
        }


        public Color TColor(short value)
        {
            byte channel = Math.Max((byte)0, (byte)Math.Min((int)255, (int)((value - Min) * ColorStep)));
            return Color.FromArgb(255, channel, channel, channel);
        }


        //FPS = ~40
        public void DrawQuads(int index)
        {
            if (ErrorInfo()) {
                index = Math.Max(0, Math.Min(Depth - 1, index));

                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                int offset;
                int offset_index;
                GL.Begin(PrimitiveType.Quads);
                for (int x = 0; x < Width - 1; x++)
                {
                    offset_index = Width * Height * index;
                    for (int y = 0; y < Height - 1; y++)
                    {
                        offset = offset_index + Width * y + x;
                        GL.Color3(TColor(mData[offset]));
                        GL.Vertex2(x, y);

                        offset += 1;
                        GL.Color3(TColor(mData[offset]));
                        GL.Vertex2(x + 1, y);

                        offset += Width;
                        GL.Color3(TColor(mData[offset]));
                        GL.Vertex2(x + 1, y + 1);

                        offset += -1;
                        GL.Color3(TColor(mData[offset]));
                        GL.Vertex2(x, y + 1);
                    }
                }
                GL.End();
            }
        }


        //FPS = ~70
        public void DrawQuadStrip(int index)
        {
            if (ErrorInfo())
            {
                index = Math.Max(0, Math.Min(Depth - 1, index));
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                int offset;
                int offset_index;
                for (int x = 0; x < Width - 1; x++)
                {
                    offset_index = Width * Height * index;
                    GL.Begin(PrimitiveType.QuadStrip);
                    offset = offset_index + x;
                    GL.Color3(TColor(mData[offset]));
                    GL.Vertex2(x, 0);

                    offset += 1;
                    GL.Color3(TColor(mData[offset]));
                    GL.Vertex2(x + 1, 0);

                    offset += Width;
                    GL.Color3(TColor(mData[offset]));
                    GL.Vertex2(x + 1, 1);

                    offset += -1;
                    GL.Color3(TColor(mData[offset]));
                    GL.Vertex2(x, 1);

                    for (int y = 1; y < Height - 1; y++)
                    {
                        offset = offset_index + Width * y + x;
                        GL.Color3(TColor(mData[offset]));
                        GL.Vertex2(x, y);

                        offset += 1;
                        GL.Color3(TColor(mData[offset]));
                        GL.Vertex2(x + 1, y);
                    }
                    GL.End();
                }
            }
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


        public void RenderFrame(int index)
        {
            int offset;
            int offset_index;
            texture = new Bitmap(Width, Height);
            for(int i = 0; i < Width - 1; i++)
            {
                offset_index = Width * Height * index;
                for (int j = 0; j < Height -1; j++)
                {
                    offset = offset_index + j * Width + i;
                    texture.SetPixel(i, j, TColor(mData[offset]));
                }
            }
        }

        //FPS = ~900
        public void DrawTexture(int index)
        {
            if (ErrorInfo())
            {
                if(LoadedLayerIndex != index)
                {
                    RenderFrame(index);
                    Load2DTexture();
                    LoadedLayerIndex = index;
                }
                
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                
                GL.Enable(EnableCap.Texture2D);
                GL.BindTexture(TextureTarget.Texture2D, VBOtexture);
                GL.Begin(PrimitiveType.Quads);
                GL.Color3(Color.White);
                GL.TexCoord2(0f, 0f);
                GL.Vertex2(0, 0);

                GL.TexCoord2(0f, 1f);
                GL.Vertex2(0, Height);


                GL.TexCoord2(1f, 1f);
                GL.Vertex2(Width, Height);


                GL.TexCoord2(1f, 0f);
                GL.Vertex2(Width, 0);

                GL.End();

                GL.Disable(EnableCap.Texture2D);
            }
        }

    }
}
