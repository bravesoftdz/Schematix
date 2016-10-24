﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
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
            if (parameterName == "ImageType")
                Enum.TryParse(StreamReadString(stream, valueLength), out ImageType);
            else if (valueLength == 4 && parameterName == "AlphaColor")
                AlphaColor = Color.FromArgb(stream.ReadInt32());
            else if (parameterName == "ImagePath")
            {
                ImagePath = StreamReadString(stream, valueLength);
                if (ImageType == ImageTypes.Link)
                    if (File.Exists(ImagePath))
                    {
                        var bmap = new Bitmap(ImagePath);
                        ImageCanva = new Bitmap(bmap.Width, bmap.Height, PixelFormat.Format32bppArgb);
                        Graphics.FromImage(ImageCanva).DrawImageUnscaled(bmap, 0, 0);
                    }
            }
            else if (parameterName == "Image")
                Share.StreamGetImage(stream, valueLength, ref ImageBPP, ref ImageCanva);
            else if (valueLength == 0 && parameterName == "UseAlphaColor")
            {
                UseAlphaColor = true;
                ImageCanva.MakeTransparent(AlphaColor);
            }
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
            StreamWriteString("ImageType", stream, ImageType.ToString());
            stream.Write("AlphaColor");
            stream.Write(4);
            stream.Write(AlphaColor.ToArgb());
            StreamWriteString("ImagePath", stream, ImagePath);
            if (ImageType == ImageTypes.Image)
            {
                stream.Write("Image");
                Share.StreamPutImage(stream, ImageCanva, ImageBPP);
            }
            if (UseAlphaColor)
            {
                stream.Write("UseAlphaColor");
                stream.Write(0);
            }
            stream.Write("BackColor");
            stream.Write(4);
            stream.Write(BackColor.ToArgb());
            if (ImageType != ImageTypes.None)
            {
                stream.Write("InitializeImage");
                stream.Write(0);
            }
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
    
    public class xPLink : xPrototype
    {
        public Pen Pen = new Pen(options.DEFAULT_LINK_LINE_COLOR, 1);

        public override bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (valueLength == 4 && parameterName == "Thick")
                Pen.Width = stream.ReadSingle();
            else if (valueLength == 4 && parameterName == "LineColor")
                Pen.Color = Color.FromArgb(stream.ReadInt32());
            else if (parameterName == "LineStyle")
            {
                DashStyle ds;
                Enum.TryParse(StreamReadString(stream, valueLength), out ds);
                Pen.DashStyle = ds;
                if (ds == DashStyle.Custom)
                    Pen.DashPattern = new float[] { 5, 2, 1, 3 };
            }
            // Pass unprocessed data up
            else
                return base.ReadParameter(stream, parameterName, valueLength);
            return true;
        }

        public override void WriteParameters(BinaryWriter stream)//Ok
        {
            // Write local part of body
            stream.Write("Thick");
            stream.Write(4);
            stream.Write(Pen.Width);
            stream.Write("LineColor");
            stream.Write(4);
            stream.Write(Pen.Color.ToArgb());
            StreamWriteString("LineStyle", stream, Pen.DashStyle.ToString());
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
                Enum.TryParse(StreamReadString(stream, valueLength), out BoxType);
            else if (parameterName == "Text")
                Text = StreamReadString(stream, valueLength);
            else if (valueLength == 1 && parameterName == "TextAlign")
                Enum.TryParse(stream.ReadByte().ToString(), out TextAlign);
            else if (parameterName == "FontName")
                TextFont = new Font(StreamReadString(stream, valueLength), TextFont.Size, TextFont.Style);
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
            StreamWriteString("BoxType", stream, BoxType.ToString());
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
            StepY = options.DEFAULT_GRID_STEP;
        public Pen
            Pen = new Pen(options.DEFAULT_GRID_COLOR, 1);
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
            BuildIn = false,
            UseAlphaColor = false;
        public BackgroundStyles Style      = options.DEFAULT_BACK_STYLE;
        public Color            Color      = options.DEFAULT_BACK_COLOR;
        public Color            AlphaColor = options.DEFAULT_BACK_COLOR;
        public AlignTypes       Align      = options.DEFAULT_BACK_ALIGN;
        public ImageBPPs        BPP        = ImageBPPs.b32argb;
        public String           Path       = "";
        public Bitmap           Image      = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
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
        public xBackground Back;
        public xGrid Grid;
        public int
            ScrollX = 0,
            ScrollY = 0,
            Width  = 1,
            Height = 1;
        public bool AutoSize = false;
        public Bitmap Canvas = new Bitmap(1, 1, PixelFormat.Format24bppRgb);
        Graphics graphics;
        public xExemplar Selected = null;
        public xLink LinkAdding = null;

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
            if (valueLength == 8 && parameterName == "Size")
            {
                Width = stream.ReadInt32();
                Height = stream.ReadInt32();
            }
            else if (valueLength == 8 && parameterName == "Scroll")
            {
                ScrollX = stream.ReadInt32();
                ScrollY = stream.ReadInt32();
            }
            else if (valueLength == 0 && parameterName == "AutoSize")
                AutoSize = true;
            // Grid
            else if (valueLength == 0 && parameterName == "GridStoreOwn")
                Grid.StoreOwn = true;
            else if (parameterName == "GridStyle")
                Enum.TryParse(StreamReadString(stream, valueLength), out Grid.Style);
            else if (valueLength == 4 && parameterName == "GridColor")
                Grid.Pen.Color = Color.FromArgb(stream.ReadInt32());
            else if (valueLength == 2 && parameterName == "GridStepX")
                Grid.StepX = stream.ReadInt16();
            else if (valueLength == 2 && parameterName == "GridStepY")
                Grid.StepY = stream.ReadInt16();
            else if (valueLength == 4 && parameterName == "GridThick")
                Grid.Pen.Width = stream.ReadSingle();
            else if (valueLength == 0 && parameterName == "GridSnap")
                Grid.Snap = true;
            // Backgruod
            else if (valueLength == 0 && parameterName == "BackgroundStoreOwn")
                Back.StoreOwn = true;
            else if (parameterName == "BackgroundStyle")
                Enum.TryParse(StreamReadString(stream, valueLength), out Back.Style);
            else if (valueLength == 4 && parameterName == "BackgroundColor")
                Back.Color = Color.FromArgb(stream.ReadInt32());
            else if (parameterName == "BackgroundPath")
            {
                Back.Path = StreamReadString(stream, valueLength);
                if (Back.Style != BackgroundStyles.Color)
                    if (File.Exists(Back.Path))
                    {
                        var bmap = new Bitmap(Back.Path);
                        Back.Image = new Bitmap(bmap.Width, bmap.Height, PixelFormat.Format32bppArgb);
                        Graphics.FromImage(Back.Image).DrawImageUnscaled(bmap, 0, 0);
                    }
            }
            else if (valueLength == 0 && parameterName == "BackgroundFloat")
                Back.Float = true;
            else if (valueLength == 4 && parameterName == "BackgroundAlphaColor")
                Back.AlphaColor = Color.FromArgb(stream.ReadInt32());
            else if (valueLength == 1 && parameterName == "BackgroundAlign")
                Enum.TryParse(stream.ReadByte().ToString(), out Back.Align);
            else if (parameterName == "BackgroundImage")
            {
                Back.BuildIn = true;
                Share.StreamGetImage(stream, valueLength, ref Back.BPP, ref Back.Image);
            }
            else if (valueLength == 0 && parameterName == "BackgroundUseAlphaColor")
            {
                Back.UseAlphaColor = true;
                Back.Image.MakeTransparent(Back.AlphaColor);
            }

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
            stream.Write("Size");
            stream.Write(8);
            stream.Write(Width);
            stream.Write(Height);
            stream.Write("Scroll");
            stream.Write(8);
            stream.Write(ScrollX);
            stream.Write(ScrollY);
            if (AutoSize)
            {
                stream.Write("AutoSize");
                stream.Write(0);
            }

            // Grid
            if (Grid.StoreOwn)
            {
                stream.Write("GridStoreOwn");
                stream.Write(0);
            }
            StreamWriteString("GridStyle", stream, Grid.Style.ToString());
            stream.Write("GridColor");
            stream.Write(4);
            stream.Write(Grid.Pen.Color.ToArgb());
            stream.Write("GridStepX");
            stream.Write(2);
            stream.Write(Grid.StepX);
            stream.Write("GridStepY");
            stream.Write(2);
            stream.Write(Grid.StepY);
            stream.Write("GridThick");
            stream.Write(4);
            stream.Write(Grid.Pen.Width);
            if (Grid.Snap)
            {
                stream.Write("GridSnap");
                stream.Write(0);
            }

            // Backgruod
            if (Back.StoreOwn)
            {
                stream.Write("BackgroundStoreOwn");
                stream.Write(0);
            }
            StreamWriteString("BackgroundStyle", stream, Back.Style.ToString());
            stream.Write("BackgroundColor");
            stream.Write(4);
            stream.Write(Back.Color.ToArgb());
            StreamWriteString("BackgroundPath", stream, Back.Path);
            if (Back.Float)
            {
                stream.Write("BackgroundFloat");
                stream.Write(0);
            }
            stream.Write("BackgroundAlphaColor");
            stream.Write(4);
            stream.Write(Back.AlphaColor.ToArgb());
            stream.Write("BackgroundAlign");
            stream.Write(1);
            stream.Write((byte)Back.Align);
            if (Back.BuildIn)
            {
                stream.Write("BackgroundImage");
                Share.StreamPutImage(stream, Back.Image, Back.BPP);
            }
            if (Back.UseAlphaColor)
            {
                stream.Write("BackgroundUseAlphaColor");
                stream.Write(0);
            }

            int pos;
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

        public void AlignToGridAll(int sx = 0, int sy = 0)//Ok
        {
            if (sx == 0)
                sx = Grid.StepX;
            if (sy == 0)
                sy = Grid.StepY;
            foreach (var Object in Objects)
            {
                AlignToGrid(ref Object.X, ref Object.Y);
                Object.Check();
            }
            foreach (var Link in Links)
            {
                if (Link.ObjectA == null)
                    AlignToGrid(ref Link.XA, ref Link.YA);
                if (Link.ObjectB == null)
                    AlignToGrid(ref Link.XB, ref Link.YB);
                Link.Check();
            }
        }

        public void AlignToGrid(ref int x, ref int y)//Ok
        {
            x = (int)((float)x / Grid.StepX) * Grid.StepX;
            y = (int)((float)y / Grid.StepY) * Grid.StepY;
        }
        
        public void DoAutoSize(int minWidth, int minHeight)
        {
            if (!AutoSize)
                return;
            int w = minWidth,
                h = minHeight;
            // Look for bigger values
            foreach (var Object in Objects)
            {
                if (w < Object.Right)
                    w = Object.Right;
                if (h < Object.Bottom)
                    h = Object.Bottom;
            }
            foreach (var Link in Links)
            {
                if (w < Link.Right)
                    w = Link.Right;
                if (h < Link.Bottom)
                    h = Link.Bottom;
            }
            foreach (var Box in Boxes)
            {
                if (w < Box.Right)
                    w = Box.Right;
                if (h < Box.Bottom)
                    h = Box.Bottom;
            }
            // Apply
            ReSize(w, h);
        }

        public void ReSize(int width, int height)
        {
            if (width < Width || height < Height)
            {
                // Look for out of border elements
                foreach (var Object in Objects)
                {
                    if (width  < Object.Right )
                        Object.X = (width  < Object.Width ) ? 0 : width  - Object.Width;
                    if (height < Object.Bottom)
                        Object.Y = (height < Object.Height) ? 0 : height - Object.Height;
                    Object.Check();
                }
                foreach (var Link in Links)
                {
                    if (Link.ObjectA == null)
                    {
                        if (width  < Link.XA)
                            Link.XA = width;
                        if (height < Link.YA)
                            Link.YA = height;
                    }
                    if (Link.ObjectB == null)
                    {
                        if (width  < Link.XB)
                            Link.XB = width;
                        if (height < Link.YB)
                            Link.YB = height;
                    }
                    Link.Check();
                }
                foreach (var Box in Boxes)
                {
                    if (width  < Box.Right )
                        Box.Left = (width  < Box.Width ) ? 0 : width  - Box.Width;
                    if (height < Box.Bottom)
                        Box.Top  = (height < Box.Height) ? 0 : height - Box.Height;
                    Box.Check();
                }
            }
            // Apply
            Width  = width;
            Height = height;
            // Canvas
            Canvas = new Bitmap(width, height);
            graphics = Graphics.FromImage(Canvas);
            ReDraw();
        }

        public void ReDraw(int x = 0, int y = 0, int width = 0, int height = 0)
        {
            // Get area
            if (width  < 1)
                width  = Width;
            if (height < 1)
                height = Height;
            // Clear area
            graphics.Clip = new Region(new Rectangle(x, y, width, height));
            graphics.Clear(Back.Color);

            // Variables
            int iX, startX, endX, 
                iY, startY, endY;

            #region Backgruond
            int pX = 0,
                pY = 0,
                pW = Width,
                pH = Height;
            if (Back.Float)
            {
                pX = ScrollX;
                pY = ScrollY;
                pW = options.WindowW;
                pH = options.WindowH;
            }
            int imgW = Back.Image.Width,
                imgH = Back.Image.Height;
            int imgOffsetX,
                imgOffsetY;
            switch (Back.Style)
            {
                case BackgroundStyles.Color:
                    // Skip
                    break;

                case BackgroundStyles.ImageAlign:
                    // Calculate offset
                    imgOffsetX = ((pW - imgW) * (int)Back.Align % 3) / 2;
                    imgOffsetY = ((pH - imgH) * (int)Back.Align / 3) / 2;
                    // Fill
                    graphics.DrawImageUnscaled(Back.Image,
                        pX - imgOffsetX,
                        pY - imgOffsetY);
                    break;

                case BackgroundStyles.ImageTile:
                    startX = x / imgW;
                    startY = y / imgW;
                    endX = (x + width ) / imgW + 1;
                    endY = (y + height) / imgH + 1;
                    // Colum/row oscillation for float style
                    pX = pX % imgW;
                    pY = pY % imgH;
                    // Calculate align offset
                    imgOffsetX = ((imgW - pW % imgW) * (int)Back.Align % 3) / 2;
                    imgOffsetY = ((imgH - pH % imgH) * (int)Back.Align / 3) / 2;
                    // Fill
                    for (iY = startX; iY <= endX; iY++)
                        for (iX = startY; iX <= endY; iX++)
                            graphics.DrawImageUnscaled(Back.Image,
                                pX + iX * imgW - imgOffsetX,
                                pY + iY * imgH - imgOffsetY);
                    break;

                case BackgroundStyles.ImageStrech:
                    graphics.DrawImage(Back.Image, pX, pY, pW, pH);
                    break;

                case BackgroundStyles.ImageZInner:
                    int imgZiW,
                        imgZiH;
                    // Find most "tight" side
                    if (imgW * pH <= imgH * pW)
                    {
                        imgZiW = pW;
                        imgZiH = (int)(imgH * ((double)pW / imgW));
                    }
                    else
                    {
                        imgZiW = (int)(imgW * ((double)pH / imgH));
                        imgZiH = pH;
                    }
                    imgOffsetX = ((pW - imgZiW) * (int)Back.Align % 3) / 2;
                    imgOffsetY = ((pH - imgZiH) * (int)Back.Align / 3) / 2;
                    graphics.DrawImage(Back.Image, imgOffsetX, imgOffsetY, imgZiW, imgZiH);
                    break;

                case BackgroundStyles.ImageZOutter:
                    int imgZoW,
                        imgZoH;
                    // Find most "tight" side
                    if (imgW * pH <= imgH * pW)
                    {
                        imgZoW = (int)(imgW * ((double)pH / imgH));
                        imgZoH = pH;
                    }
                    else
                    {
                        imgZoW = pW;
                        imgZoH = (int)(imgH * ((double)pW / imgW));
                    }
                    imgOffsetX = ((imgZoW - pW) * (int)Back.Align % 3) / 2;
                    imgOffsetY = ((imgZoH - pH) * (int)Back.Align / 3) / 2;
                    graphics.DrawImage(Back.Image, imgOffsetX, imgOffsetY, imgZoW, imgZoH);
                    break;
            }
            #endregion

            #region Grid
            endX = x / Grid.StepX;
            endY = y / Grid.StepY;
            startX = (x + width ) / Grid.StepX + 1;
            startY = (y + height) / Grid.StepY + 1;
            switch (Grid.Style)
            {
                case GridStyles.None:
                    break;
                case GridStyles.Dots:
                    for (iX = startX; endX <= iX; iX--)
                        for (iY = startY; endY <= iY; iY--)
                            graphics.DrawLine(Grid.Pen, iX * Grid.StepX, iY * Grid.StepY, iX * Grid.StepX, iY * Grid.StepY);
                    break;
                case GridStyles.Corners:
                    int halfW = Grid.StepX / 2,
                        halfH = Grid.StepY / 2;
                    for (iX = startX; endX <= iX; iX--)
                        for (iY = startY; endY <= iY; iY--)
                        {
                            graphics.DrawLine(Grid.Pen,
                                iX * Grid.StepX,         iY * Grid.StepY,
                                iX * Grid.StepX + halfW, iY * Grid.StepY);
                            graphics.DrawLine(Grid.Pen,
                                iX * Grid.StepX,         iY * Grid.StepY,
                                iX * Grid.StepX,         iY * Grid.StepY + halfH);
                        }
                    break;
                case GridStyles.Crosses:
                    int quadW,
                        quadH;
                    quadW = Grid.StepX / 2;
                    quadH = Grid.StepY / 2;
                    for (iX = startX; endX <= iX; iX--)
                        for (iY = startY; endY <= iY; iY--)
                        {
                            graphics.DrawLine(Grid.Pen,
                                iX * Grid.StepX - quadW, iY * Grid.StepY,
                                iX * Grid.StepX + quadW, iY * Grid.StepY);
                            graphics.DrawLine(Grid.Pen,
                                iX * Grid.StepX,         iY * Grid.StepY - quadH,
                                iX * Grid.StepX,         iY * Grid.StepY + quadH);
                        }
                    break;
                case GridStyles.Grid:
                    for (iX = startX; endX <= iX; iX--)
                        graphics.DrawLine(Grid.Pen, iX * Grid.StepX, y, iX * Grid.StepX, y + height);
                    for (iY = startY; endY <= iY; iY--)
                        graphics.DrawLine(Grid.Pen, x, iY * Grid.StepY, x + width, iY * Grid.StepY);
                    break;
            }
            #endregion

            // Draw Boxes

            // Draw Links

            // Draw Objects

        }

        public xExemplar SelectAt(int x, int y)//
        {
            Selected = Objects.Find(O => O.isOver(x, y));
            if (Selected == null)
                Selected = Links.Find(L => L.isOver(x, y));
            if (Selected == null)
                Selected = Boxes.Find(B => B.isOver(x, y));
            return Selected;
        }

        //...
    }
}
