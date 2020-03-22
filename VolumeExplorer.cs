using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
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
        private bool DrawMode;

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

        public void DrawQuads(int index)
        {
            if (ErrorInfo()) {
                index = Math.Max(0, Math.Min(Depth - 1, index));

                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                GL.Begin(PrimitiveType.Quads);

                int offset;
                int offset_x;
                for (int x = 0; x < Width - 1; x++)
                {
                    offset_x = Width * Height * index;
                    for (int y = 0; y < Height - 1; y++)
                    {
                        offset = offset_x + Width * y + x;
                        GL.Color3(TColor(mData[offset]));
                        GL.Vertex2(x, y);

                        offset += 1;
                        GL.Color3(TColor(mData[offset]));
                        GL.Vertex2(x + 1, y);

                        offset += Width - 1;
                        GL.Color3(TColor(mData[offset]));
                        GL.Vertex2(x, y + 1);

                        offset += 1;
                        GL.Color3(TColor(mData[offset]));
                        GL.Vertex2(x + 1, y + 1);
                    }
                }

                GL.End();
            }
        }

    }
}
