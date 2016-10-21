using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Schematix
{
    public abstract class xRecord
    {
        public String Name        = "";
        public String Description = "";

        // Load

        virtual public bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (parameterName == "Name")
                Name = new String(stream.ReadChars(valueLength));
            else if (parameterName == "Description")
                Description = new String(stream.ReadChars(valueLength));
            // Skip unknown data
            else
            {
                stream.ReadBytes(valueLength);
                return false;
            }
            return true;
        }

        public String StreamReadString(BinaryReader stream, int length)//?Ok
        {
            return Encoding.UTF8.GetString(stream.ReadBytes(length));
        }

        // Save
        
        virtual public void WriteParameters(BinaryWriter stream)//Ok
        {
            StreamWriteString("Name", stream, Name);
            StreamWriteString("Description", stream, Description);
            // Mark the end
            stream.Write("END");
        }

        public void StreamWriteString(String parameterName, BinaryWriter stream, String value)//Ok
        {
            stream.Write(parameterName);
            byte[] b = Encoding.UTF8.GetBytes(value);
            stream.Write(b.Length);
            stream.Write(b);
        }
    }

    public abstract class xBlock : xRecord
    {
        virtual public void ReadParameters(BinaryReader stream)//Ok
        {
            while (stream.PeekChar() > -1)
            {
                String parameterName = stream.ReadString();
                // Check for record's end
                if (parameterName == "END")
                    return;
                int valueLength = stream.ReadInt32();
                // Load(/skip) parameters
                ReadParameter(stream, parameterName, valueLength);
                return;
            }
        }

        public void WriteStream_CloseBlock(BinaryWriter stream, int start)//Ok
        {
            // Jump back and fill size value
            int pos = (int)stream.Seek(0, SeekOrigin.Current);
            stream.Seek(start, SeekOrigin.Begin);
            stream.Write(pos - start);
            stream.Seek(pos, SeekOrigin.Begin);
        }
    }

    public abstract class xSaveLoad : xBlock
    {
        public void LoadFromFile(String fileName)//Ok
        {
            try
            {
                using (var file = File.OpenRead(fileName))
                {
                    using (var stream = new BinaryReader(file))
                    {
                        ReadParameters(stream);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(options.LangCur.mErrorsOccurred + "" + e.Message, options.LangCur.dFileLoading);
            }
        }

        public void SaveToFile(String fileName)//Ok
        {
            try
            {
                using (var file = File.OpenWrite(fileName))
                {
                    using (var stream = new BinaryWriter(file))
                    {
                        WriteParameters(stream);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(options.LangCur.mErrorsOccurred + "" + e.Message, options.LangCur.dFileSaving);
            }
        }
    }

    // Prototypes

    public abstract class xPrototype : xSaveLoad
    {
        public String   NodeName = "";
        public String   ID       = "";
        public DateTime Revision = DateTime.Now;
        public bool     Prototype;

        public override bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (parameterName == "NodeName")
                NodeName = new String(stream.ReadChars(valueLength));
            else if (parameterName == "ID")
                ID = new String(stream.ReadChars(valueLength));
            else if (parameterName == "Revision" && valueLength == 8)
                Revision = DateTime.FromBinary(stream.ReadInt64());
            else if (parameterName == "Prototype" && valueLength == 1)
                Prototype = stream.ReadBoolean();
            // Pass unprocessed data up
            else
                return base.ReadParameter(stream, parameterName, valueLength);
            return true;
        }

        public override void WriteParameters(BinaryWriter stream)//Ok
        {
            // Write local part of body
            StreamWriteString("NodeName", stream, NodeName);
            StreamWriteString("ID", stream, ID);
            stream.Write("Revision");
            stream.Write(8);
            stream.Write(Revision.ToBinary());
            stream.Write("Prototype");
            stream.Write(1);
            stream.Write(Prototype);
            // Upper class body
            base.WriteParameters(stream);
        }
    }

    public class xDot : xBlock
    {
        public short X = 0;
        public short Y = 0;
        
        override public bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (parameterName == "X" && valueLength == 2)
                X = stream.ReadInt16();
            else if (parameterName == "Y" && valueLength == 2)
                Y = stream.ReadInt16();
            // Pass unprocessed data up
            else
                return base.ReadParameter(stream, parameterName, valueLength);
            return true;
        }

        override public void WriteParameters(BinaryWriter stream)//Ok
        {
            // Write local part of body
            stream.Write("X");
            stream.Write(2);
            stream.Write(X);
            stream.Write("Y");
            stream.Write(2);
            stream.Write(Y);
            // Upper class body
            base.WriteParameters(stream);
        }
    }

    public enum ImageTypes
    {
        None,
        Image,
        Link
    }

    public enum ImageBPPs
    {
        b32argb,
        b24rgb,
        b16a1r5g5b5,
        b16r5g6b5,
        b8,
        b4,
    }
    
    public class xPObject : xPrototype
    {
        public ImageTypes   ImageType  = ImageTypes.Image;
        public String       ImagePath  = "";
        public Color        ImageColor = options.DEFAULT_OBJECT_IMAGE_COLOR;
        public Color        AlphaColor = options.DEFAULT_OBJECT_APLHA_COLOR;
        public ImageBPPs    ImageBPP   = ImageBPPs.b32argb;
        public List<xDot>   Dots       = new List<xDot>() { new xDot() { Name = "", Description = "", X = 0, Y = 0 } };
        public Bitmap       ImageCanva = new Bitmap(1, 1, PixelFormat.Format32bppArgb);

        public override bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (parameterName == "ImageType" && valueLength == 1)
                ImageType = (ImageTypes)stream.ReadByte();
            else if (parameterName == "ImageColor" && valueLength == 4)
                ImageColor = Color.FromArgb(stream.ReadInt32());
            else if (parameterName == "ImagePath")
                ImagePath = StreamReadString(stream, valueLength);
            else if (parameterName == "Image")
                ImageCanva = Share.StreamImageOut(stream, valueLength, ref ImageBPP);
            else if (parameterName == "AlphaColor" && valueLength == 4)
                AlphaColor = Color.FromArgb(stream.ReadInt32());
            else if (parameterName == "Dot")
            {
                var Dot = new xDot();
                Dot.ReadParameters(stream);
                Dots.Add(Dot);
            }
            // Pass unprocessed data up
            else
                return base.ReadParameter(stream, parameterName, valueLength);
            return true;
        }

        public override void WriteParameters(BinaryWriter stream)//Ok
        {
            // Write local part of body
            stream.Write("ImageType");
            stream.Write(1);
            stream.Write((byte)ImageType);
            stream.Write("ImageColor");
            stream.Write(4);
            stream.Write(ImageColor.ToArgb());
            StreamWriteString("ImagePath", stream, ImagePath);
            stream.Write("Image");
            Share.StreamImageIn(stream, ImageCanva, ImageBPP);
            stream.Write("AlphaColor");
            stream.Write(4);
            stream.Write(AlphaColor.ToArgb());
            // Dots
            int pos = 0;
            foreach (var Dot in Dots)
            {
                stream.Write("Dot");
                pos = (int)stream.Seek(0, SeekOrigin.Current);
                Dot.WriteParameters(stream);
                WriteStream_CloseBlock(stream, pos);
            }
            // Upper class body
            base.WriteParameters(stream);
        }
    }

    public enum LineStyles
    {
        Solid,
        Dashed,
        Doted,
        DotDash,
        DotDashDash,
        DotDotDash
    }

    public class xPLink : xPrototype
    {
        public int        LineThick = 1;
        public Color      LineColor = options.DEFAULT_LINK_LINE_COLOR;
        public LineStyles LineStyle = LineStyles.Solid;

        public override bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (parameterName == "Thick" && valueLength == 1)
                LineThick = stream.ReadByte();
            else if (parameterName == "LineColor" && valueLength == 4)
                LineColor = Color.FromArgb(stream.ReadInt32());
            else if (parameterName == "LineStyle" && valueLength == 1)
                LineStyle = (LineStyles)stream.ReadByte();
            // Pass unprocessed data up
            else
                return base.ReadParameter(stream, parameterName, valueLength);
            return true;
        }

        public override void WriteParameters(BinaryWriter stream)//Ok
        {
            // Write local part of body
            stream.Write("Thick");
            stream.Write(1);
            stream.Write((byte)LineThick);
            stream.Write("LineColor");
            stream.Write(4);
            stream.Write(LineColor.ToArgb());
            stream.Write("LineStyle");
            stream.Write(1);
            stream.Write((byte)LineStyle);
            // Upper class body
            base.WriteParameters(stream);
        }
    }

    public enum BoxTypes
    {
        Text,
        Rectangle,
        Ellipse
    }

    public enum AlignTypes
    {
        TopLeft,
        Top,
        TopRight,
        Left,
        Center,
        Right,
        BottomLeft,
        Bottom,
        BottomRight
    }

    public class xPBox : xPLink
    {
        public BoxTypes     BoxType     = BoxTypes.Text;
        public String       Text        = "";
        public AlignTypes   TextAlign   = AlignTypes.TopLeft;
        public Font         TextFont    = options.DEFAULT_BOX_FONT;

        public override bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (parameterName == "BoxType" && valueLength == 1)
                BoxType = (BoxTypes)stream.ReadByte();
            else if (parameterName == "LineColor")
                Text = new String(stream.ReadChars(valueLength));
            else if (parameterName == "TextAlign" && valueLength == 1)
                TextAlign = (AlignTypes)stream.ReadByte();
            else if (parameterName == "FontName")
                TextFont = new Font(new String(stream.ReadChars(valueLength)), TextFont.Size, TextFont.Style);
            else if (parameterName == "FontSize" && valueLength == 4)
                TextFont = new Font(TextFont.Name, stream.ReadSingle(), TextFont.Style);
            else if (parameterName == "FontStyle" && valueLength == 1)
                TextFont = new Font(TextFont.Name, TextFont.Size, (FontStyle)stream.ReadByte());
            // Pass unprocessed data up
            else
                return base.ReadParameter(stream, parameterName, valueLength);
            return true;
        }

        public override void WriteParameters(BinaryWriter stream)//Ok
        {
            // Write local part of body
            stream.Write("BoxType");
            stream.Write(1);
            stream.Write((byte)BoxType);
            StreamWriteString("Text", stream, Text);
            stream.Write("TextAlign");
            stream.Write(1);
            stream.Write((byte)TextAlign);
            StreamWriteString("FontName", stream, TextFont.Name);
            stream.Write("FontSize");
            stream.Write(4);
            stream.Write(TextFont.Size);
            stream.Write("FontStyle");
            stream.Write(1);
            stream.Write((byte)TextFont.Style);
            // Upper class body
            base.WriteParameters(stream);
        }
    }

    // Exemplars

    public abstract class xExemplar : xBlock
    {
        public int ID;
        public xPrototype Prototype;
        public String     FileName = "";
        public String     Reference = "";
        public int Left  = 0, Top    = 0;
        public int Right = 0, Bottom = 0;
        public int Width = 0, Height = 0;

        override public bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (parameterName == "Reference")
                Reference = StreamReadString(stream, valueLength);
            else if (parameterName == "ID" && valueLength == 4)
                ID = stream.ReadInt32();
            // Pass unprocessed data up
            else
                return base.ReadParameter(stream, parameterName, valueLength);
            return true;
        }

        override public void WriteParameters(BinaryWriter stream)//Ok
        {
            // Write local part of body
            StreamWriteString("Reference", stream, Reference);
            stream.Write("ID");
            stream.Write(4);
            stream.Write(ID);
            // Upper class body
            base.WriteParameters(stream);
        }

        virtual public void BoxRenew()//Ok
        {
            Right  = Left + Width;
            Bottom = Top  + Height;
        }

        virtual public bool isOver(int x, int y, byte padding = 0)//Ok
        {
            return (Left <= x + padding) && (x <= Right + padding) && (Top <= y + padding) && (y <= Bottom + padding);
        }

        public void BondParent(String parentID, List<xPrototype> parents, xPrototype parentDefault)//Ok
        {
            Prototype = parents.Find(xP => xP.ID == parentID);
            if (Prototype == null)
                Prototype = parentDefault;
        }

        virtual public void Check()
        {
        }
    }

    public class xIP : xBlock
    {
        public String   Address         = "";
        public int      Period          = options.DEFAULT_PING_PERIOD;
        public int      TimeOutGreen    = options.DEFAULT_PING_TIMEOUT_GREEN;
        public int      TimeOutYellow   = options.DEFAULT_PING_TIMEOUT_YELLOW;
        public int      TimeOutRed      = options.DEFAULT_PING_TIMEOUT_RED;
        public bool     Onn             = options.DEFAULT_PING_ONN;
        public DateTime TimeNext        = DateTime.Now;
        public int[]    PingTimeArray   = new int[options.DEFAULT_PING_ARRAY];
        protected int   PingTimeCount   = 0;

        public xIP()//Ok
        {
            PingClearValues();
        }

        public void PingClearValues()//Ok
        {
            for (int i = PingTimeArray.Length - 1; 0 <= i; i--)
                PingTimeArray[i] = -1;
            PingTimeCount = 0;
        }

        public void PingPushNewValue(int v)//Ok
        {
            if (PingTimeArray.Length < PingTimeCount)
                PingTimeCount = PingTimeArray.Length;
            for (int i = PingTimeCount - 1; 0 < i; i--)
                PingTimeArray[i] = PingTimeArray[i - 1];
            PingTimeArray[0] = v;
            if (PingTimeCount < PingTimeArray.Length)
                PingTimeCount++;
        }

        override public bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (parameterName == "Address")
                Address = new String(stream.ReadChars(valueLength));
            else if (parameterName == "Period" && valueLength == 4)
                Period = stream.ReadInt32();
            else if (parameterName == "TimeOutGreen" && valueLength == 4)
                TimeOutGreen = stream.ReadInt32();
            else if (parameterName == "TimeOutYellow" && valueLength == 4)
                TimeOutYellow = stream.ReadInt32();
            else if (parameterName == "TimeOutRed" && valueLength == 4)
                TimeOutRed = stream.ReadInt32();
            else if (parameterName == "Onn" && valueLength == 1)
                Onn = stream.ReadBoolean();
            else if (parameterName == "TimeNext" && valueLength == 8)
                TimeNext = DateTime.FromBinary(stream.ReadInt64());
            else if (parameterName == "PingTime" && valueLength == 4)
                PingPushNewValue(stream.ReadInt32());
            // Pass unprocessed data up
            else
                return base.ReadParameter(stream, parameterName, valueLength);
            return true;
        }
        
        override public void WriteParameters(BinaryWriter stream)//Ok
        {
            // Write local part of body
            StreamWriteString("Address", stream, Address);
            stream.Write("Period");
            stream.Write(Marshal.SizeOf(Period));
            stream.Write(Period);
            stream.Write("TimeOutGreen");
            stream.Write(Marshal.SizeOf(TimeOutGreen));
            stream.Write(TimeOutGreen);
            stream.Write("TimeOutYellow");
            stream.Write(Marshal.SizeOf(TimeOutYellow));
            stream.Write(TimeOutYellow);
            stream.Write("TimeOutRed");
            stream.Write(Marshal.SizeOf(TimeOutRed));
            stream.Write(TimeOutRed);
            stream.Write("Onn");
            stream.Write(Marshal.SizeOf(Onn));
            stream.Write(Onn);
            stream.Write("TimeNext");
            stream.Write(Marshal.SizeOf(TimeNext.ToBinary()));
            stream.Write(TimeNext.ToBinary());
            for (int i = 0; i < PingTimeArray.Length; i++)
            {
                if (PingTimeArray[i] < 0)
                    break;
                stream.Write("PingTime");
                stream.Write(Marshal.SizeOf(PingTimeArray[0]));
                stream.Write(PingTimeArray[i]);
            }
            // Upper class body
            base.WriteParameters(stream);
        }
    }

    public class xObject : xExemplar
    {
        public int X;
        public int Y;
        public List<xIP> IPs = new List<xIP>();

        override public bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (parameterName == "X" && valueLength == 4)
                X = stream.ReadInt32();
            else if (parameterName == "Y" && valueLength == 4)
                Y  = stream.ReadInt32();
            else if (parameterName == "IP")
            {
                var IP = new xIP();
                IP.ReadParameters(stream);
                IPs.Add(IP);
            }
            // Pass unprocessed data up
            else
                return base.ReadParameter(stream, parameterName, valueLength);
            return true;
        }

        override public void WriteParameters(BinaryWriter stream)//Ok
        {
            // Write local part of body
            stream.Write("X");
            stream.Write(4);
            stream.Write(X);
            stream.Write("Y");
            stream.Write(4);
            stream.Write(Y);
            // Dots
            int pos = 0;
            foreach (var IP in IPs)
            {
                stream.Write("IP");
                pos = (int)stream.Seek(0, SeekOrigin.Current);
                IP.WriteParameters(stream);
                WriteStream_CloseBlock(stream, pos);
            }
            // Upper class body
            base.WriteParameters(stream);
        }

        override public void Check()
        {
            Left = X - (Prototype as xPObject).Dots[0].X;
            Top  = Y - (Prototype as xPObject).Dots[0].Y;
            Width  = (Prototype as xPObject).ImageCanva.Width;
            Height = (Prototype as xPObject).ImageCanva.Height;
        }
    }

    public class xLink : xExemplar
    {
        public int ObjectAID;
        public int ObjectBID;
        public xExemplar ObjectA = null;
        public xExemplar ObjectB = null;
        public int DotA, XA, YA;
        public int DotB, XB, YB;

        override public bool isOver(int x, int y, byte padding = 0)//Ok
        {
            if (base.isOver(x, y, padding))
            {
                double rx = x;
                double ry = y;
                // Find point on line:
                if (Width < Height)
                    // Vertical
                    ry = Math.Round(Top  + (double)(Height *(Top  - x)) / Height);
                else if (0 < Width)
                    // Horizontal
                    rx = Math.Round(Left + (double)(Left   *(Left - y)) / Width);
                // Check if point near line +/-3
                return (Math.Abs(x - rx) <= padding) && (Math.Abs(y - ry) <= padding);
            }
            return false;
        }

        public void BondEnds(List<xExemplar> Objects)
        {
            if (ObjectAID != 0)
                ObjectA = Objects.Find(xE => xE.ID == ObjectAID);
            if (ObjectBID != 0)
                ObjectB = Objects.Find(xE => xE.ID == ObjectBID);
        }

        override public void Check()
        {
            List<xDot> Dots;
            if (ObjectA != null)
            {
                Dots = (ObjectA.Prototype as xPObject).Dots;
                if (Dots.Count <= DotA)
                    DotA = 0;
                XA = ObjectA.Left - Dots[0].X + Dots[DotA].X;
                YA = ObjectA.Top  - Dots[0].Y + Dots[DotA].Y;
            }
            if (ObjectB != null)
            {
                Dots = (ObjectB.Prototype as xPObject).Dots;
                if (Dots.Count <= DotB)
                    DotB = 0;
                XB = ObjectB.Left - Dots[0].X + Dots[DotB].X;
                YB = ObjectB.Top  - Dots[0].Y + Dots[DotB].Y;
            }
            Width  = Math.Abs(XB - XA);
            Height = Math.Abs(YB - YA);
            Left = ((XA < XB) ? XA : XB);
            Top  = ((YA < YB) ? YA : YB);
        }
    }

    public class xBox : xExemplar
    {
        public String Text = "";
        public int TextX;
        public int TextY;

        override public bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (parameterName == "Text")
                Text = StreamReadString(stream, valueLength);
            else if (parameterName == "Left" && valueLength == 4)
                Left = stream.ReadInt32();
            else if (parameterName == "Top"  && valueLength == 4)
                Top  = stream.ReadInt32();
            else if (parameterName == "Width"  && valueLength == 4)
                Width  = stream.ReadInt32();
            else if (parameterName == "Height" && valueLength == 4)
                Height = stream.ReadInt32();
            // Pass unprocessed data up
            else
                return base.ReadParameter(stream, parameterName, valueLength);
            return true;
        }

        override public void WriteParameters(BinaryWriter stream)//Ok
        {
            // Write local part of body
            StreamWriteString("Text", stream, Text);
            stream.Write("Left");
            stream.Write(4);
            stream.Write(Left);
            stream.Write("Top");
            stream.Write(4);
            stream.Write(Top);
            stream.Write("Width");
            stream.Write(4);
            stream.Write(Width);
            stream.Write("Height");
            stream.Write(4);
            stream.Write(Height);
            // Upper class body
            base.WriteParameters(stream);
        }

        override public void Check()
        {
            Graphics g = Graphics.FromImage(new Bitmap(1,1));
            SizeF textSize = g.MeasureString(Text, (Prototype as xPBox).TextFont);
            if ((Prototype as xPBox).BoxType == BoxTypes.Ellipse)
            {
                double m  = (1 - Math.Sqrt(2)) / 4;
                switch ((Prototype as xPBox).TextAlign)
                {
                    case AlignTypes.TopLeft:
                        TextX = (int)(Left +  Width  * m);
                        TextY = (int)(Top  +  Height * m);
                        break;
                    case AlignTypes.Top:
                        TextX = (int)(Left + (Width - textSize.Width) / 2);
                        TextY = Top;
                        break;
                    case AlignTypes.TopRight:
                        TextX = (int)(Left +  Width  * (1 - m) - textSize.Width );
                        TextY = (int)(Top  +  Height * m);
                        break;
                    case AlignTypes.Left:
                        TextX = Left;
                        TextY = (int)(Top  + (Height - textSize.Height) / 2);
                        break;
                    case AlignTypes.Center:
                        TextX = (int)(Left + (Width  - textSize.Width ) / 2);
                        TextY = (int)(Top  + (Height - textSize.Height) / 2);
                        break;
                    case AlignTypes.Right:
                        TextX = (int)(Left + Width  - textSize.Width);
                        TextY = (int)(Top + (Height - textSize.Height) / 2);
                        break;
                    case AlignTypes.BottomLeft:
                        TextX = (int)(Left +  Width  * m);
                        TextY = (int)(Top  +  Height * (1 - m) - textSize.Height);
                        break;
                    case AlignTypes.Bottom:
                        TextX = (int)(Left + (Width  - textSize.Width ) / 2);
                        TextY = (int)(Top  +  Height - textSize.Height);
                        break;
                    case AlignTypes.BottomRight:
                        TextX = (int)(Left +  Width  * (1 - m) - textSize.Width );
                        TextY = (int)(Top  +  Height * (1 - m) - textSize.Height);
                        break;
                }
            }
            else
            {
                TextX = Left;
                TextY = Top;
                if ((Prototype as xPBox).BoxType == BoxTypes.Rectangle)
                    switch ((Prototype as xPBox).TextAlign)
                    {
                        case AlignTypes.Top:
                            TextX = (int)(Left + (Width - textSize.Width) / 2);
                            break;
                        case AlignTypes.TopRight:
                            TextX = (int)(Left + Width - textSize.Width);
                            break;
                        case AlignTypes.Left:
                            TextY = (int)(Top + (Height - textSize.Height) / 2);
                            break;
                        case AlignTypes.Center:
                            TextX = (int)(Left + (Width - textSize.Width) / 2);
                            TextY = (int)(Top + (Height - textSize.Height) / 2);
                            break;
                        case AlignTypes.Right:
                            TextX = (int)(Left + Width - textSize.Width);
                            TextY = (int)(Top + (Height - textSize.Height) / 2);
                            break;
                        case AlignTypes.BottomLeft:
                            TextY = (int)(Top + Height - textSize.Height);
                            break;
                        case AlignTypes.Bottom:
                            TextX = (int)(Left + (Width - textSize.Width) / 2);
                            TextY = (int)(Top + Height - textSize.Height);
                            break;
                        case AlignTypes.BottomRight:
                            TextX = (int)(Left + Width - textSize.Width);
                            TextY = (int)(Top + Height - textSize.Height);
                            break;
                    }
                else
                {
                    Width  = (int)textSize.Width;
                    Height = (int)textSize.Height;
                }
            }
        }
    }

    public class xMap : xSaveLoad
    {
        //...
    }
}
