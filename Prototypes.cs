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
        public UInt64 ID = (UInt64)DateTime.Now.ToBinary();
        public String Name        = "";
        public String Description = "";

        // Load

        virtual public bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (parameterName == "Name")
                Name = new String(stream.ReadChars(valueLength));
            else if (parameterName == "Description")
                Description = new String(stream.ReadChars(valueLength));
            else if (valueLength == 8 && parameterName == "ID")
                ID = stream.ReadUInt64();
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
            if (fileName == "")
            {
                var dlg = new OpenFileDialog();
                if (dlg.ShowDialog() == DialogResult.Cancel)
                    return;
                fileName = dlg.FileName;
            }
            try
            {
                using (var file = File.OpenRead(fileName))
                {
                    using (var stream = new BinaryReader(file))
                    {
                        ReadParameters(stream);
                    }
                }
                FileName = fileName;
            }
            catch (Exception e)
            {
                MessageBox.Show(options.LangCur.mErrorsOccurred + "" + e.Message, options.LangCur.dFileLoading);
            }
        }

        public void SaveToFile(String fileName)//Ok
        {
            if (fileName == "")
            {
                var dlg = new SaveFileDialog();
                if (dlg.ShowDialog() == DialogResult.Cancel)
                    return;
                fileName = dlg.FileName;
            }
            try
            {
                using (var file = File.OpenWrite(fileName))
                {
                    using (var stream = new BinaryWriter(file))
                    {
                        WriteParameters(stream);
                    }
                }
                FileName = fileName;
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
        public bool     isPrototype;

        public override bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (parameterName == "NodeName")
                NodeName = new String(stream.ReadChars(valueLength));
            else if (valueLength == 8 && parameterName == "Revision")
                Revision = DateTime.FromBinary(stream.ReadInt64());
            else if (valueLength == 1 && parameterName == "IsPrototype")
                isPrototype = stream.ReadBoolean();
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
            stream.Write("IsPrototype");
            stream.Write(1);
            stream.Write(isPrototype);
            // Upper class body
            base.WriteParameters(stream);
        }
    }

    public class xDot : xBlock
    {
        protected xPObject PObject { get; }
        public short X = 0;
        public short Y = 0;

        public xDot(xPObject owner)
        {
            PObject = owner;
        }

        override public bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (valueLength == 2 && parameterName == "X")
                X = stream.ReadInt16();
            else if (valueLength == 2 && parameterName == "Y")
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
        public ImageTypes   ImageType     = ImageTypes.Image;
        public String       ImagePath     = "";
        public bool         UseAlphaColor = false;
        public Color        AlphaColor    = options.DEFAULT_OBJECT_APLHA_COLOR;
        public ImageBPPs    ImageBPP      = ImageBPPs.b32argb;
        public Color        BackColor     = options.DEFAULT_OBJECT_IMAGE_COLOR;
        public List<xDot>   Dots          = new List<xDot>();
        public Bitmap       ImageCanva    = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
        bool MustClearDots = false;
        
        public xPObject()
        {
            Dots.Add(new xDot(this) { Name = "", Description = "", X = 0, Y = 0 });
            MustClearDots = true;
        }

        public override bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (valueLength == 1 && parameterName == "ImageType")
                ImageType = (ImageTypes)stream.ReadByte();
            else if (parameterName == "ImagePath")
                ImagePath = StreamReadString(stream, valueLength);
            else if (parameterName == "Image")
                ImageCanva = Share.StreamImageOut(stream, valueLength, ref ImageBPP);
            else if (valueLength == 4 && parameterName == "AlphaColor")
                AlphaColor = Color.FromArgb(stream.ReadInt32());
            else if (valueLength == 4 && parameterName == "BackColor")
                BackColor = Color.FromArgb(stream.ReadInt32());
            else if (parameterName == "Dot")
            {
                var Dot = new xDot(this);
                Dot.ReadParameters(stream);
                if (MustClearDots)
                {
                    Dots.Clear();
                    MustClearDots = false;
                }
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
            StreamWriteString("ImagePath", stream, ImagePath);
            stream.Write("Image");
            Share.StreamImageIn(stream, ImageCanva, ImageBPP);
            stream.Write("AlphaColor");
            stream.Write(4);
            stream.Write(AlphaColor.ToArgb());
            stream.Write("BackColor");
            stream.Write(4);
            stream.Write(BackColor.ToArgb());
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

        public void DeleteDot(xDot Dot)
        {
            Dots.Remove(Dot);
            if (Dots.Count < 1)
                Dots.Add(new xDot(this));
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
            if (valueLength == 1 && parameterName == "Thick")
                LineThick = stream.ReadByte();
            else if (valueLength == 4 && parameterName == "LineColor")
                LineColor = Color.FromArgb(stream.ReadInt32());
            else if (valueLength == 1 && parameterName == "LineStyle")
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
        public BoxTypes     BoxType   = BoxTypes.Text;
        public String       Text      = "";
        public AlignTypes   TextAlign = AlignTypes.TopLeft;
        public Font         TextFont  = options.DEFAULT_BOX_FONT;
        public Color        TextColor = options.DEFAULT_BOX_TEXT_COLOR;

        public override bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (valueLength == 1 && parameterName == "BoxType")
                BoxType = (BoxTypes)stream.ReadByte();
            else if (valueLength == 4 && parameterName == "LineColor")
                LineColor = Color.FromArgb(stream.ReadInt32());
            else if (valueLength == 1 && parameterName == "TextAlign")
                TextAlign = (AlignTypes)stream.ReadByte();
            else if (parameterName == "FontName")
                TextFont = new Font(new String(stream.ReadChars(valueLength)), TextFont.Size, TextFont.Style);
            else if (valueLength == 4 && parameterName == "FontSize")
                TextFont = new Font(TextFont.Name, stream.ReadSingle(), TextFont.Style);
            else if (valueLength == 1 && parameterName == "FontStyle")
                TextFont = new Font(TextFont.Name, TextFont.Size, (FontStyle)stream.ReadByte());
            else if (valueLength == 4 && parameterName == "TextColor")
                TextColor = Color.FromArgb(stream.ReadInt32());
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
            stream.Write("TextColor");
            stream.Write(4);
            stream.Write(TextColor.ToArgb());
            // Upper class body
            base.WriteParameters(stream);
        }
    }

    // Exemplars

    public abstract class xExemplar : xBlock
    {
        protected xMap Map { get; }
        public xPrototype Prototype;
        public UInt64     PrototypeID;
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
            else if (valueLength == 8 && parameterName == "PrototypeID")
                PrototypeID = stream.ReadUInt64();
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

        public bool BondParent(object Prototypes)//Ok
        {
            Prototype = (Prototypes as List<xPrototype>).Find(xP => xP.ID == PrototypeID);
            return (Prototype == null);
        }

        virtual public void Check()
        {
        }
    }

    public class xIP : xBlock
    {
        xObject Object { get; }
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
            else if (valueLength == 4 && parameterName == "Period")
                Period = stream.ReadInt32();
            else if (valueLength == 4 && parameterName == "TimeOutGreen")
                TimeOutGreen = stream.ReadInt32();
            else if (valueLength == 4 && parameterName == "TimeOutYellow")
                TimeOutYellow = stream.ReadInt32();
            else if (valueLength == 4 && parameterName == "TimeOutRed")
                TimeOutRed = stream.ReadInt32();
            else if (valueLength == 1 && parameterName == "Onn")
                Onn = stream.ReadBoolean();
            else if (valueLength == 8 && parameterName == "TimeLast")
                TimeLast = DateTime.FromBinary(stream.ReadInt64());
            else if (valueLength == 8 && parameterName == "TimeNext")
                TimeNext = DateTime.FromBinary(stream.ReadInt64());
            else if (valueLength == 4 && parameterName == "PingTime")
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
            stream.Write(4);
            stream.Write(Period);
            stream.Write("TimeOutGreen");
            stream.Write(4);
            stream.Write(TimeOutGreen);
            stream.Write("TimeOutYellow");
            stream.Write(4);
            stream.Write(TimeOutYellow);
            stream.Write("TimeOutRed");
            stream.Write(4);
            stream.Write(TimeOutRed);
            stream.Write("Onn");
            stream.Write(1);
            stream.Write(Onn);
            stream.Write("TimeLast");
            stream.Write(8);
            stream.Write(TimeLast.ToBinary());
            stream.Write("TimeNext");
            stream.Write(8);
            stream.Write(TimeNext.ToBinary());
            for (int i = 0; i < PingTimeArray.Length; i++)
            {
                if (PingTimeArray[i] < 0)
                    break;
                stream.Write("PingTime");
                stream.Write(4);
                stream.Write(PingTimeArray[i]);
            }
            // Upper class body
            base.WriteParameters(stream);
        }

        public void Delete()
        {
            Object.DeleteIP(this);
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
            if (valueLength == 4 && parameterName == "X")
                X = stream.ReadInt32();
            else if (valueLength == 4 && parameterName == "Y")
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

        public void ClearIPs()
        {
            for (int i = IPs.Count - 1; 0 <= i; i--)
                DeleteIP(IPs[i]);
        }

        public void DeleteIP(xIP IP)
        {
            IP.lvItem = null;
            Map.DeleteIP(IP);
            IPs.Remove(IP);
        }

        public void Delete()
        {
            Map.DeleteObject(this);
        }
    }

    public class xLink : xExemplar
    {
        public UInt64 ObjectAID, DotAID;
        public UInt64 ObjectBID, DotBID;
        public xObject ObjectA = null;
        public xObject ObjectB = null;
        public xDot DotA = null;
        public xDot DotB = null;
        public int XA, YA;
        public int XB, YB;

        public xLink(xMap owner) : base(owner) { }

        override public bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (valueLength == 8 && parameterName == "ObjectAID")
                ObjectAID = stream.ReadUInt64();
            else if (valueLength == 8 && parameterName == "DotAID")
                DotAID = stream.ReadUInt64();
            else if (valueLength == 8 && parameterName == "ObjectBID")
                ObjectBID = stream.ReadUInt64();
            else if (valueLength == 8 && parameterName == "DotBID")
                DotBID = stream.ReadUInt64();
            else if (valueLength == 4 && parameterName == "YB")
                YB = stream.ReadInt32();
            else if (valueLength == 4 && parameterName == "XA")
                XA = stream.ReadInt32();
            else if (valueLength == 4 && parameterName == "YA")
                YA = stream.ReadInt32();
            else if (valueLength == 4 && parameterName == "XB")
                XB = stream.ReadInt32();
            else if (valueLength == 4 && parameterName == "YB")
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

        public void Delete()
        {
            Map.DeleteLink(this);
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
            else if (valueLength == 4 && parameterName == "Left")
                Left = stream.ReadInt32();
            else if (valueLength == 4 && parameterName == "Top" )
                Top  = stream.ReadInt32();
            else if (valueLength == 4 && parameterName == "Width" )
                Width  = stream.ReadInt32();
            else if (valueLength == 4 && parameterName == "Height")
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

        public void Delete()
        {
            Map.DeleteBox(this);
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
            Snap     = false;
        public GridStyles
            Style = options.DEFAULT_GRID_STYLE;
        public Int16
            StepX = options.DEFAULT_GRID_STEP,
            StepY = options.DEFAULT_GRID_STEP,
            Thick =  1;
        public Color
            Color;
    }

    public enum BackgroundStyles
    {
        Color,
        ImageAlign,
        ImageTile,
        ImageStrech,
        ImageZInner,
        ImageZOutter
    }

    public class xBackground
    {
        public bool
            StoreOwn = false,
            Float = false,
            BuildIn = false;
        public BackgroundStyles Style = options.DEFAULT_BACK_STYLE;
        public Color            Color = options.DEFAULT_BACK_COLOR;
        public AlignTypes       Align = options.DEFAULT_BACK_ALIGN;
        public ImageBPPs        BPP   = ImageBPPs.b32argb;
        public String           Path  = "";
        public Bitmap           Image = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
    }

    public class xMap : xSaveLoad
    {
        public bool Changed = false;
        public List<xPObject> PObjects = new List<xPObject>();
        public List<xPLink>   PLinks   = new List<xPLink>();
        public List<xPBox>    PBoxes   = new List<xPBox>();
        public List<xObject>  Objects  = new List<xObject>();
        public List<xLink>    Links    = new List<xLink>();
        public List<xBox>     Boxes    = new List<xBox>();
        public List<xIP>      IPs      = new List<xIP>();
        xExemplar Selected = null;
        xLink     LinkAdding = null;
        public xBackground Back;
        public xGrid Grid;
        public int
            ScrollX = 0,
            ScrollY = 0,
            Width  = 1,
            Height = 1;
        public bool AutoSize = false;
        public Bitmap Canvas = new Bitmap(1, 1, PixelFormat.Format24bppRgb);

        public void AddPObject(xPObject PObject)//Ok
        {
            xPObject uPObject = options.PObjects.Find(PO => (PO.ID == PObject.ID) && (PO.Revision >= PObject.Revision));
            if (uPObject == null)
                uPObject = PObject;
            PObjects.Add(uPObject);
        }

        public void AddPLink(xPLink PLink)//Ok
        {
            xPLink uPLink = options.PLinks.Find(PL => (PL.ID == PLink.ID) && (PL.Revision >= PLink.Revision));
            if (uPLink == null)
                uPLink = PLink;
            PLinks.Add(uPLink);
        }

        public void AddPBox(xPBox PBox)//Ok
        {
            xPBox uPBox = options.PBoxes.Find(PB => (PB.ID == PBox.ID) && (PB.Revision >= PBox.Revision));
            if (uPBox == null)
                uPBox = PBox;
            PBoxes.Add(uPBox);
        }

        public void DeletePObject(xPObject PObject)//Ok
        {
            if (!Objects.Exists(O => O.Prototype.ID == PObject.ID))
                PObjects.Remove(PObject);
        }

        public void DeletePLink(xPLink PLink)//Ok
        {
            if (!Links.Exists(L => L.Prototype.ID == PLink.ID))
                PLinks.Remove(PLink);
        }

        public void DeletePBox(xPBox PBox)//Ok
        {
            if (!Boxes.Exists(B => B.Prototype.ID == PBox.ID))
                PBoxes.Remove(PBox);
        }

        public void DeleteObject(xObject obj)//O
        {
            if (obj == null)
                return;
            // Remove all IPs
            obj.ClearIPs();
            // Remove all links to this object
            for (int i = Links.Count - 1; 0 <= i; i--)
                if (Links[i].ObjectA == obj || Links[i].ObjectB == obj)
                    Links.RemoveAt(i);
            // Try to remove it's prototype
            DeletePObject(obj.Prototype as xPObject);
            // Remove object
            Objects.Remove(obj);
        }

        public void DeleteLink(xLink link)//Ok
        {
            // Try to remove it's prototype
            DeletePLink(link.Prototype as xPLink);
            // Remove object
            Links.Remove(link);
        }

        public void DeleteBox(xBox box)//Ok
        {
            // Try to remove it's prototype
            DeletePBox(box.Prototype as xPBox);
            // Remove object
            Boxes.Remove(box);
        }

        public void AddIP(xIP IP)//
        {
            if (!IPs.Contains(IP))
                IPs.Add(IP);
            if (!options.IPs.Contains(IP))
                options.IPs.Add(IP);
        }

        public void DeleteIP(xIP IP)//
        {
            options.IPs.Remove(IP);
            IPs.Remove(IP);
        }
        
        override public bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (valueLength == 1 && parameterName == "AutoSize")
                AutoSize = stream.ReadBoolean();
            else if (valueLength == 4 && parameterName == "Width")
                Width = stream.ReadInt32();
            else if (valueLength == 4 && parameterName == "Height")
                Height = stream.ReadInt32();
            else if (valueLength == 4 && parameterName == "ScrollX")
                ScrollX = stream.ReadInt32();
            else if (valueLength == 4 && parameterName == "ScrollY")
                ScrollY = stream.ReadInt32();
            // Grid
            else if (valueLength == 1 && parameterName == "GridStoreOwn")
                Grid.StoreOwn = stream.ReadBoolean();
            else if (valueLength == 1 && parameterName == "GridStyle")
                Grid.Style = (GridStyles)stream.ReadByte();
            else if (valueLength == 4 && parameterName == "GridColor")
                Grid.Color = Color.FromArgb(stream.ReadInt32());
            else if (valueLength == 2 && parameterName == "GridStepX")
                Grid.StepX = stream.ReadInt16();
            else if (valueLength == 2 && parameterName == "GridStepY")
                Grid.StepY = stream.ReadInt16();
            else if (valueLength == 1 && parameterName == "GridSnap")
                Grid.Snap = stream.ReadBoolean();
            // Backgruod
            else if (valueLength == 1 && parameterName == "BackgroundStoreOwn")
                Back.StoreOwn = stream.ReadBoolean();
            else if (valueLength == 1 && parameterName == "BackgroundStyle")
                Back.Style = (BackgroundStyles)stream.ReadByte();
            else if (valueLength == 4 && parameterName == "BackgroundColor")
                Back.Color = Color.FromArgb(stream.ReadInt32());
            else if (parameterName == "BackgroundPath")
                Back.Path = StreamReadString(stream, valueLength);
            else if (valueLength == 1 && parameterName == "BackgroundFloat")
                Back.Float = stream.ReadBoolean();
            else if (valueLength == 1 && parameterName == "BackgroundAlign")
                Back.Align = (AlignTypes)stream.ReadByte();
            else if (valueLength == 1 && parameterName == "BackgroundBuildIn")
                Back.BuildIn = stream.ReadBoolean();
            else if (parameterName == "BackgroundImage")
                Back.Image = Share.StreamImageOut(stream, valueLength, ref Back.BPP);

            #region Prototype
            // PObjects
            else if (parameterName == "PObject")
            {
                var PObject = new xPObject();
                PObject.ReadParameters(stream);
                AddPObject(PObject);
            }
            // PLinks
            else if (parameterName == "PLink")
            {
                var PLink = new xPLink();
                PLink.ReadParameters(stream);
                AddPLink(PLink);
            }
            // PBoxes
            else if (parameterName == "PBox")
            {
                var PBox = new xPBox();
                PBox.ReadParameters(stream);
                AddPBox(PBox);
            }
            #endregion

            #region Exemplars
            // Objects
            else if (parameterName == "Object")
            {
                var Object = new xObject(this);
                Object.ReadParameters(stream);
                Object.BondParent(PObjects);
                Objects.Add(Object);
            }
            // Links
            else if (parameterName == "Link")
            {
                var Link = new xLink(this);
                Link.ReadParameters(stream);
                Link.BondParent(PLinks);
                Link.BondEnds(Objects);
                Links.Add(Link);
            }
            // Boxes
            else if (parameterName == "Box")
            {
                var Box = new xBox(this);
                Box.ReadParameters(stream);
                Box.BondParent(PBoxes);
                Boxes.Add(Box);
            }
            #endregion
            // Pass unprocessed data up
            else
                return base.ReadParameter(stream, parameterName, valueLength);
            return true;
        }

        override public void WriteParameters(BinaryWriter stream)//Ok
        {
            // Write local part of body
            stream.Write("AutoSize");
            stream.Write(1);
            stream.Write(AutoSize);
            stream.Write("Width");
            stream.Write(4);
            stream.Write(Width);
            stream.Write("Height");
            stream.Write(4);
            stream.Write(Height);
            stream.Write("ScrollX");
            stream.Write(4);
            stream.Write(ScrollX);
            stream.Write("ScrollY");
            stream.Write(4);
            stream.Write(ScrollY);

            // Grid
            stream.Write("GridStoreOwn");
            stream.Write(1);
            stream.Write(Grid.StoreOwn);
            stream.Write("GridStyle");
            stream.Write(1);
            stream.Write((byte)Grid.Style);
            stream.Write("GridColor");
            stream.Write(4);
            stream.Write(Grid.Color.ToArgb());
            stream.Write("GridStepX");
            stream.Write(2);
            stream.Write(Grid.StepX);
            stream.Write("GridStepY");
            stream.Write(2);
            stream.Write(Grid.StepY);
            stream.Write("GridSnap");
            stream.Write(1);
            stream.Write(Grid.Snap);

            // Backgruod
            stream.Write("BackgroundStoreOwn");
            stream.Write(1);
            stream.Write(Back.StoreOwn);
            stream.Write("BackgroundStyle");
            stream.Write(1);
            stream.Write((byte)Back.Style);
            stream.Write("BackgroundColor");
            stream.Write(4);
            stream.Write(Back.Color.ToArgb());
            StreamWriteString("BackgroundPath", stream, Back.Path);
            stream.Write("BackgroundFloat");
            stream.Write(1);
            stream.Write(Back.Float);
            stream.Write("BackgroundAlign");
            stream.Write(1);
            stream.Write((byte)Back.Align);
            stream.Write("BackgroundBuildIn");
            stream.Write(1);
            stream.Write(Back.BuildIn);
            if (Back.BuildIn)
            {
                stream.Write("BackgroundImage");
                Share.StreamImageIn(stream, Back.Image, Back.BPP);
            }

            int pos = 0;
            #region Prototype
            // PObjects
            foreach (var PObject in PObjects)
            {
                stream.Write("PObject");
                pos = (int)stream.Seek(0, SeekOrigin.Current);
                PObject.WriteParameters(stream);
                WriteStream_CloseBlock(stream, pos);
            }
            // PLinks
            foreach (var PLink in Links)
            {
                stream.Write("PLink");
                pos = (int)stream.Seek(0, SeekOrigin.Current);
                PLink.WriteParameters(stream);
                WriteStream_CloseBlock(stream, pos);
            }
            // PBoxes
            foreach (var PBox in PBoxes)
            {
                stream.Write("PBox");
                pos = (int)stream.Seek(0, SeekOrigin.Current);
                PBox.WriteParameters(stream);
                WriteStream_CloseBlock(stream, pos);
            }
            #endregion

            #region Exemplars
            // Objects
            foreach (var Object in Objects)
            {
                stream.Write("Object");
                pos = (int)stream.Seek(0, SeekOrigin.Current);
                Object.WriteParameters(stream);
                WriteStream_CloseBlock(stream, pos);
            }
            // Links
            foreach (var Link in Links)
            {
                stream.Write("Link");
                pos = (int)stream.Seek(0, SeekOrigin.Current);
                Link.WriteParameters(stream);
                WriteStream_CloseBlock(stream, pos);
            }
            // Boxes
            foreach (var Box in Boxes)
            {
                stream.Write("Box");
                pos = (int)stream.Seek(0, SeekOrigin.Current);
                Box.WriteParameters(stream);
                WriteStream_CloseBlock(stream, pos);
            }
            #endregion

            // Upper class body
            base.WriteParameters(stream);
        }

        //...
    }
}
