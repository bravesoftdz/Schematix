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
        public Int64  ID = DateTime.Now.ToBinary();
        public String Name        = "";
        public String Description = "";

        // Load

        virtual public bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (parameterName == "Name")
                Name = new String(stream.ReadChars(valueLength));
            else if (parameterName == "Description")
                Description = new String(stream.ReadChars(valueLength));
            else if (parameterName == "ID" && valueLength == 8)
                ID = stream.ReadInt64();
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
            stream.Write("ID");
            stream.Write(8);
            stream.Write(ID);
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
        public String FileName = "";

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
        public DateTime Revision = DateTime.Now;
        public bool     Prototype;

        public override bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (parameterName == "NodeName")
                NodeName = new String(stream.ReadChars(valueLength));
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
        public xMap Map;
        public xPrototype Prototype;
        public Int64      PrototypeID;
        public String     Reference = "";
        public int Left  = 0, Top    = 0;
        public int Right = 0, Bottom = 0;
        public int Width = 0, Height = 0;

        public xExemplar(xMap owner)
        {
            Map = owner;
        }

        override public bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (parameterName == "Reference")
                Reference = StreamReadString(stream, valueLength);
            else if (parameterName == "PrototypeID" && valueLength == 8)
                PrototypeID = stream.ReadInt64();
            // Pass unprocessed data up
            else
                return base.ReadParameter(stream, parameterName, valueLength);
            return true;
        }

        override public void WriteParameters(BinaryWriter stream)//Ok
        {
            // Write local part of body
            StreamWriteString("Reference", stream, Reference);
            stream.Write("PrototypeID");
            stream.Write(8);
            stream.Write(PrototypeID);
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

        public bool BondParent(List<xPrototype> Prototypes)//Ok
        {
            Prototype = Prototypes.Find(xP => xP.ID == PrototypeID);
            return (Prototype == null);
        }

        virtual public void Check()
        {
        }
    }

    public class xIP : xBlock
    {
        public ListViewItem Map_lvItem      = null;
        public ListViewItem lvItem          = null;
        public String       Address         = "";
        public int          Period          = options.DEFAULT_PING_PERIOD;
        public int          TimeOutGreen    = options.DEFAULT_PING_TIMEOUT_GREEN;
        public int          TimeOutYellow   = options.DEFAULT_PING_TIMEOUT_YELLOW;
        public int          TimeOutRed      = options.DEFAULT_PING_TIMEOUT_RED;
        public bool         Onn             = options.DEFAULT_PING_ONN;
        public DateTime     TimeLast        = DateTime.Now;
        public DateTime     TimeNext        = DateTime.Now;
        public int[]        PingTimeArray   = new int[options.DEFAULT_PING_ARRAY];
        protected int       PingTimeCount   = 0;
        public xObject      Object { get; }

        public xIP(xObject owner)//Ok
        {
            Object = owner;
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
            else if (parameterName == "TimeLast" && valueLength == 8)
                TimeLast = DateTime.FromBinary(stream.ReadInt64());
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
            stream.Write("TimeLast");
            stream.Write(Marshal.SizeOf(TimeLast.ToBinary()));
            stream.Write(TimeLast.ToBinary());
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

        public xObject(xMap owner) : base(owner) { }

        override public bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (parameterName == "X" && valueLength == 4)
                X = stream.ReadInt32();
            else if (parameterName == "Y" && valueLength == 4)
                Y  = stream.ReadInt32();
            else if (parameterName == "IP")
            {
                var IP = new xIP(this);
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

        public void AddIP(xIP IP)
        {
            if (!IPs.Contains(IP))
                IPs.Add(IP);
            Map.AddIP(IP);
        }

        public void DeleteIP(xIP IP)
        {
            IPs.Remove(IP);
            Map.DeleteIP(IP);
        }
    }

    public class xLink : xExemplar
    {
        public Int64 ObjectAID, DotAID;
        public Int64 ObjectBID, DotBID;
        public xObject ObjectA = null;
        public xObject ObjectB = null;
        public xDot DotA = null;
        public xDot DotB = null;
        public int XA, YA;
        public int XB, YB;

        public xLink(xMap owner) : base(owner) { }

        override public bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (parameterName == "ObjectAID" && valueLength == 8)
                ObjectAID = stream.ReadInt64();
            else if (parameterName == "DotAID" && valueLength == 8)
                DotAID = stream.ReadInt64();
            else if (parameterName == "ObjectBID" && valueLength == 8)
                ObjectBID = stream.ReadInt64();
            else if (parameterName == "DotBID" && valueLength == 8)
                DotBID = stream.ReadInt64();
            else if (parameterName == "YB" && valueLength == 4)
                YB = stream.ReadInt32();
            else if (parameterName == "XA" && valueLength == 4)
                XA = stream.ReadInt32();
            else if (parameterName == "YA" && valueLength == 4)
                YA = stream.ReadInt32();
            else if (parameterName == "XB" && valueLength == 4)
                XB = stream.ReadInt32();
            else if (parameterName == "YB" && valueLength == 4)
                YB = stream.ReadInt32();
            // Pass unprocessed data up
            else
                return base.ReadParameter(stream, parameterName, valueLength);
            return true;
        }

        override public void WriteParameters(BinaryWriter stream)//Ok
        {
            // Write local part of body
            if (ObjectAID != 0)
            {
                stream.Write("ObjectAID");
                stream.Write(8);
                stream.Write(ObjectA.ID);
                if (DotAID != 0)
                    DotAID = (ObjectA.Prototype as xPObject).Dots[0].ID;
                stream.Write("DotAID");
                stream.Write(8);
                stream.Write(DotA.ID);
            }
            else
            {
                stream.Write("XA");
                stream.Write(4);
                stream.Write(XA);
                stream.Write("YA");
                stream.Write(4);
                stream.Write(YA);
            }
            if (ObjectBID != 0)
            {
                stream.Write("ObjectBID");
                stream.Write(8);
                stream.Write(ObjectBID);
                if (DotBID != 0)
                    DotBID = (ObjectB.Prototype as xPObject).Dots[0].ID;
                stream.Write("DotBID");
                stream.Write(8);
                stream.Write(DotBID);
            }
            else
            {            
                stream.Write("XB");
                stream.Write(4);
                stream.Write(XB);
                stream.Write("YB");
                stream.Write(4);
                stream.Write(YB);
            }
            // Upper class body
            base.WriteParameters(stream);
        }

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

        public void BondEnds(List<xObject> Objects)
        {
            if (ObjectAID != 0)
            {
                ObjectA = Objects.Find(xE => xE.ID == ObjectAID);
                if (ObjectA != null)
                {
                    DotA = (ObjectA.Prototype as xPObject).Dots.Find(xE => xE.ID == DotAID);
                    if (DotA == null)
                        DotA = (ObjectA.Prototype as xPObject).Dots[0];
                }
            }
            if (ObjectBID != 0)
            {
                ObjectB = Objects.Find(xE => xE.ID == ObjectBID);
                if (ObjectB != null)
                {
                    DotB = (ObjectB.Prototype as xPObject).Dots.Find(xE => xE.ID == DotBID);
                    if (DotB == null)
                        DotB = (ObjectB.Prototype as xPObject).Dots[0];
                }
            }
        }

        override public void Check()
        {
            List<xDot> Dots;
            int x;
            if (ObjectAID != 0)
            {
                try
                {
                    Dots = (ObjectA.Prototype as xPObject).Dots;
                    if (DotAID != 0)
                        try
                        {
                            x = DotA.X;
                        }
                        catch
                        {
                            DotA = Dots[0];
                            DotAID = DotA.ID;
                        }
                    XA = ObjectA.Left - Dots[0].X + DotA.X;
                    YA = ObjectA.Top  - Dots[0].Y + DotA.Y;
                }
                catch
                {
                    ObjectAID = 0;
                    ObjectA   = null;
                    DotAID = 0;
                    DotA   = null;
                }
            }
            if (ObjectBID != 0)
            {
                try
                {
                    Dots = (ObjectB.Prototype as xPObject).Dots;
                    if (DotBID != 0)
                        try
                        {
                            x = DotB.X;
                        }
                        catch
                        {
                            DotB = Dots[0];
                            DotBID = DotB.ID;
                        }
                    XB = ObjectB.Left - Dots[0].X + DotB.X;
                    YB = ObjectB.Top  - Dots[0].Y + DotB.Y;
                }
                catch
                {
                    ObjectBID = 0;
                    ObjectB = null;
                    DotBID = 0;
                    DotB = null;
                }
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

        public xBox(xMap owner) : base(owner) { }

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

    public enum GridStyles
    {
        None,
        Dots,
        Corners,
        Crosses,
        Grid
    }

    public class xGrid
    {
        public bool
            StoreOwn = false,
            Align    = false;
        public GridStyles
            Style = options.DEFAULT_GRID_STYLE;
        public int
            StepX = options.DEFAULT_GRID_STEP,
            StepY = options.DEFAULT_GRID_STEP,
            Thick =  1;
        public Color
            Color;
    }

    public enum BackStyles
    {
        Color,
        ImageAlign,
        ImageTile,
        ImageStrech,
        ImageZInner,
        ImageZOutter
    }

    public class xBack
    {
        public bool
            StoreOwn = false,
            Float = false,
            BuildIn = false;
        public BackStyles Style = options.DEFAULT_BACK_STYLE;
        public Color      Color = options.DEFAULT_BACK_COLOR;
        public AlignTypes Align = options.DEFAULT_BACK_ALIGN;
        public ImageBPPs  BPP   = ImageBPPs.b32argb;
        public String     Path  = "";
        public Bitmap     Image = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
    }

    public class xMap : xSaveLoad
    {
        public bool Changed = false;
        public List<xPObject> PObjects = new List<xPObject>();
        public List<xPLink>   PLinks   = new List<xPLink>();
        public List<xPBox>    PBoxes   = new List<xPBox>();
        public List<xObject>  Objects = new List<xObject>();
        public List<xLink>    Links   = new List<xLink>();
        public List<xBox>     Boxes   = new List<xBox>();
        public List<xIP>      IPs   = new List<xIP>();
        xExemplar Selected = null;
        xLink     LinkAdding = null;
        public xGrid Grid;
        public xBack Back;
        public int
            ScrollX = 0,
            ScrollY = 0,
            Width  = 1,
            Height = 1;
        public bool AutoSize = false;
        public Bitmap Canvas = new Bitmap(1, 1, PixelFormat.Format24bppRgb);

        //...

        public void DeleteObject(xObject obj)//!!!
        {
            if (obj == null)
                return;
            //...
            Objects.Remove(obj);
        }

        public void DeleteLink(xLink link)
        {
            if (link == null)
                return;
            Links.Remove(link);
        }

        public void DeleteBox(xBox box)
        {
            if (box == null)
                return;
            Boxes.Remove(box);
        }

        public void AddIP(xIP IP)
        {
            if (!IPs.Contains(IP))
                IPs.Add(IP);
            //...
            if (!options.IPs.Contains(IP))
                options.IPs.Add(IP);
        }

        public void DeleteIP(xIP IP)
        {
            IPs.Remove(IP);
            //...
            options.IPs.Remove(IP);
        }
    }
}
