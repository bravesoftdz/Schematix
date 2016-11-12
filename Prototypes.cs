using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace Schematix
{

    public abstract class xBase
    {
        // Load

        virtual protected void BeforeReadParameters()//Ok
        {
        }

        virtual protected void AfterReadParameters()//Ok
        {
        }

        virtual public void ReadParameters(BinaryReader stream)//Ok
        {
            BeforeReadParameters();
            while (stream.PeekChar() > -1)
            {
                String parameterName = stream.ReadString();
                // Check for record's end
                if (parameterName == "END")
                    break;
                int valueLength = stream.ReadInt32();
                // Load(/skip) parameters
                ReadParameter(stream, parameterName, valueLength);
            }
            AfterReadParameters();
        }

        virtual protected bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            stream.ReadBytes(valueLength);
            return false;
        }

        protected String ReadStreamString(BinaryReader stream, int length)//Ok
        {
            return Encoding.UTF8.GetString(stream.ReadBytes(length));
        }

        // Save
           
        virtual public void WriteParameters(BinaryWriter stream)//Ok
        {
            // Mark the end
            stream.Write("END");
        }

        protected void WriteStreamString(String parameterName, BinaryWriter stream, String text)//Ok
        {
            stream.Write(parameterName);
            byte[] b = Encoding.UTF8.GetBytes(text);
            stream.Write(b.Length);
            stream.Write(b);
        }

        protected void WriteStream_CloseBlock(BinaryWriter stream, int start)//Ok
        {
            // Jump back and fill size value
            int pos = (int)stream.Seek(0, SeekOrigin.Current);
            stream.Seek(start, SeekOrigin.Begin);
            stream.Write(pos - start);
            stream.Seek(pos, SeekOrigin.Begin);
        }
    }
    
    public abstract class xRecord : xBase
    {
        public UInt64 ID          = (UInt64)DateTime.Now.ToBinary();
        public String Name        = "";
        public String Description = "";
        public String FileName    = "";

        // Load
        
        public bool LoadFromFileCheck(ref String fileName)//Ok
        {
            if (fileName == "")
            {
                var dlg = new OpenFileDialog();
                dlg.Filter = Options.RECORD_EXTFILLTER_MAP;
                if (dlg.ShowDialog() == DialogResult.Cancel)
                    return false;
                using (var file = File.OpenRead(dlg.FileName)) { }
                fileName = dlg.FileName;
            }
            return true;
        }

        public bool LoadFromFile(String fileName)//Ok
        {
            if (!LoadFromFileCheck(ref fileName))
                return false;
            try
            {
                using (var file = File.OpenRead(fileName))
                {
                    using (var stream = new BinaryReader(file))
                    {
                        FileName = fileName;
                        ReadParameters(stream);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(Options.LangCur.mErrorsOccurred + "" + e.Message, Options.LangCur.dFileLoading);
                return false;
            }
            return true;
        }
        
        override protected bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (parameterName == "Name")
                Name = new String(stream.ReadChars(valueLength));
            else if (parameterName == "Description")
                Description = new String(stream.ReadChars(valueLength));
            else if (valueLength == 8 && parameterName == "ID")
                ID = stream.ReadUInt64();
            // Skip unknown data
            else
                return base.ReadParameter(stream, parameterName, valueLength);
            return true;
        }

        // Save

        public bool SaveToFileCheck(ref String fileName)//Ok
        {
            if (fileName == "")
            {
                var dlg = new SaveFileDialog();
                dlg.Filter = Options.RECORD_EXTFILLTER_MAP;
                if (dlg.ShowDialog() == DialogResult.Cancel)
                    return false;
                using (var file = File.OpenWrite(dlg.FileName)) { }
                fileName = dlg.FileName;
            }
            return true;
        }

        public bool SaveToFile(String fileName)//Ok
        {
            if (!SaveToFileCheck(ref fileName))
                return false;
            try
            {
                // Make temporary file
                using (var file = File.Create(fileName + ".tmp"))
                {
                    using (var stream = new BinaryWriter(file))
                    {
                        WriteParameters(stream);
                        FileName = fileName;
                    }
                }
                // Delete old backup file
                if (File.Exists(fileName + ".bak"))
                    File.Delete(fileName + ".bak");
                // Make current file as backup
                if (File.Exists(fileName))
                {
                    File.Move(fileName, fileName + ".bak");
                    File.SetAttributes(fileName + ".bak", FileAttributes.Hidden);
                }
                // Make temporary file as current
                File.Move(fileName + ".tmp", fileName);
            }
            catch (Exception e)
            {
                MessageBox.Show(Options.LangCur.mErrorsOccurred + "" + e.Message, Options.LangCur.dFileSaving);
                return false;
            }
            return true;
        }
        
        override public void WriteParameters(BinaryWriter stream)//Ok
        {
            WriteStreamString("Name", stream, Name);
            WriteStreamString("Description", stream, Description);
            stream.Write("ID");
            stream.Write(8);
            stream.Write(ID);
            base.WriteParameters(stream);
        }
    }
    
    // Prototypes

    public abstract class xPrototype : xRecord
    {
        public bool         isUsed;
        public bool         isPrototype;
        public String       NodeName;
        public Int64        Revision    = DateTime.Now.ToBinary();
        public ListViewItem lvItemUsed;
        public TreeNode     tvNode;
        public UInt64       NodeParent = 0;

        virtual public bool IsObject { get; }
        virtual public bool IsLink   { get; }
        virtual public bool IsBox    { get; }

        override protected bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (parameterName == "NodeName")
                NodeName = new String(stream.ReadChars(valueLength));
            else if (valueLength == 8 && parameterName == "Revision")
                Revision = stream.ReadInt64();
            else if (valueLength == 8 && parameterName == "NodeParent")
                NodeParent = stream.ReadUInt64();
            else if (valueLength == 1 && parameterName == "IsPrototype")
                isPrototype = stream.ReadBoolean();
            // Pass unprocessed data up
            else
                return base.ReadParameter(stream, parameterName, valueLength);
            return true;
        }

        override public void WriteParameters(BinaryWriter stream)//Ok
        {
            // Write local part of body
            WriteStreamString("NodeName", stream, NodeName);
            stream.Write("Revision");
            stream.Write(8);
            stream.Write(Revision);
            stream.Write("NodeParent");
            stream.Write(8);
            stream.Write(NodeParent);
            stream.Write("IsPrototype");
            stream.Write(1);
            stream.Write(isPrototype);
            // Upper class body
            base.WriteParameters(stream);
        }
    }

    public class xDot : xRecord
    {
        protected xPObject PObject { get; }
        public short X = 0;
        public short Y = 0;

        public xDot(xPObject owner)
        {
            PObject = owner;
        }

        override protected bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
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
        public Color        AlphaColor    = Options.DEFAULT_OBJECT_APLHA_COLOR;
        public ImageBPPs    ImageBPP      = ImageBPPs.b32argb;
        public Color        BackColor     = Options.DEFAULT_OBJECT_IMAGE_COLOR;
        public List<xDot>   Dots          = new List<xDot>();
        public Bitmap       Canvas        = Share.GetNoImage();
        bool MustClearDots = false;

        override public bool IsObject { get; } = true;

        public xPObject()
        {
            Dots.Add(new xDot(this) { Name = "", Description = "", X = 0, Y = 0 });
            MustClearDots = true;
        }

        override protected void BeforeReadParameters()
        {
            UseAlphaColor = false;
            MustClearDots = false;
            Dots = new List<xDot>();
        }

        override protected void AfterReadParameters()
        {
            if (ImageType == ImageTypes.None)
                Canvas = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
            if (ImageType == ImageTypes.Link)
                if (File.Exists(ImagePath))
                {
                    var bmap = new Bitmap(ImagePath);
                    Canvas = new Bitmap(bmap.Width, bmap.Height, PixelFormat.Format32bppArgb);
                    Graphics.FromImage(Canvas).DrawImageUnscaled(bmap, 0, 0);
                }
            if (UseAlphaColor)
                Canvas.MakeTransparent(AlphaColor);
        }

        override protected bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (parameterName == "ImageType")
                Enum.TryParse(ReadStreamString(stream, valueLength), out ImageType);
            else if (valueLength == 4 && parameterName == "AlphaColor")
                AlphaColor = Color.FromArgb(stream.ReadInt32());
            else if (parameterName == "ImagePath")
                ImagePath = ReadStreamString(stream, valueLength);
            else if (parameterName == "Image")
                Share.StreamGetImage(stream, valueLength, ref ImageBPP, ref Canvas);
            else if (valueLength == 0 && parameterName == "UseAlphaColor")
                UseAlphaColor = true;
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

        override public void WriteParameters(BinaryWriter stream)//Ok
        {
            // Write local part of body
            WriteStreamString("ImageType", stream, ImageType.ToString());
            stream.Write("AlphaColor");
            stream.Write(4);
            stream.Write(AlphaColor.ToArgb());
            WriteStreamString("ImagePath", stream, ImagePath);
            if (ImageType == ImageTypes.Image)
            {
                stream.Write("Image");
                Share.StreamPutImage(stream, Canvas, ImageBPP);
            }
            if (UseAlphaColor)
            {
                stream.Write("UseAlphaColor");
                stream.Write(0);
            }
            stream.Write("BackColor");
            stream.Write(4);
            stream.Write(BackColor.ToArgb());
            // Dots
            int pos = 0;
            foreach (var Dot in Dots)
            {
                stream.Write("Dot");
                pos = (int)stream.Seek(0, SeekOrigin.Current);
                stream.Write(pos);
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

        public xDot GetNearestDot(int x, int y)
        {
            double dotR = 9999, R, dx, dy;
            xDot dot = null;
            foreach (var Dot in Dots)
            {
                dx = x - Dot.X;
                dy = y - Dot.Y;
                R = Math.Sqrt((dx * dx) + (dy * dy));
                if (R < dotR)
                {
                    dotR = R;
                    dot = Dot;
                }
            }
            return dot;
        }
    }
    
    public class xPLink : xPrototype
    {
        public Pen Pen = new Pen(Options.DEFAULT_LINK_LINE_COLOR, 1);

        override public bool IsLink { get; } = true;

        override protected bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (valueLength == 4 && parameterName == "Thick")
                Pen.Width = stream.ReadSingle();
            else if (valueLength == 4 && parameterName == "LineColor")
                Pen.Color = Color.FromArgb(stream.ReadInt32());
            else if (parameterName == "LineStyle")
            {
                DashStyle ds;
                Enum.TryParse(ReadStreamString(stream, valueLength), out ds);
                Pen.DashStyle = ds;
                if (ds == DashStyle.Custom)
                    Pen.DashPattern = new float[] { 5, 2, 1, 3 };
            }
            // Pass unprocessed data up
            else
                return base.ReadParameter(stream, parameterName, valueLength);
            return true;
        }

        override public void WriteParameters(BinaryWriter stream)//Ok
        {
            // Write local part of body
            stream.Write("Thick");
            stream.Write(4);
            stream.Write(Pen.Width);
            stream.Write("LineColor");
            stream.Write(4);
            stream.Write(Pen.Color.ToArgb());
            WriteStreamString("LineStyle", stream, Pen.DashStyle.ToString());
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
        public String       Text      = "Text";
        public AlignTypes   TextAlign = AlignTypes.TopLeft;
        public Font         Font      = Options.DEFAULT_BOX_FONT;
        public Brush        Brush     = new SolidBrush(Options.DEFAULT_BOX_TEXT_COLOR);
               Color       _textColor = Options.DEFAULT_BOX_TEXT_COLOR;
        public Color        TextColor
        {
            set { Brush = new SolidBrush(_textColor = value); }
            get { return _textColor; }
        }

        override public bool IsBox { get; } = true;

        override protected bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (parameterName == "BoxType")
                Enum.TryParse(ReadStreamString(stream, valueLength), out BoxType);
            else if (parameterName == "Text")
                Text = ReadStreamString(stream, valueLength);
            else if (valueLength == 1 && parameterName == "TextAlign")
                Enum.TryParse(stream.ReadByte().ToString(), out TextAlign);
            else if (parameterName == "FontName")
                Font = new Font(ReadStreamString(stream, valueLength), Font.Size, Font.Style);
            else if (valueLength == 4 && parameterName == "FontSize")
                Font = new Font(Font.Name, stream.ReadSingle(), Font.Style);
            else if (valueLength == 1 && parameterName == "FontStyle")
                Font = new Font(Font.Name, Font.Size, (FontStyle)stream.ReadByte());
            else if (valueLength == 4 && parameterName == "TextColor")
                 TextColor = Color.FromArgb(stream.ReadInt32());
            // Pass unprocessed data up
            else
                return base.ReadParameter(stream, parameterName, valueLength);
            return true;
        }

        override public void WriteParameters(BinaryWriter stream)//Ok
        {
            // Write local part of body
            WriteStreamString("BoxType", stream, BoxType.ToString());
            WriteStreamString("Text", stream, Text);
            stream.Write("TextAlign");
            stream.Write(1);
            stream.Write((byte)TextAlign);
            WriteStreamString("FontName", stream, Font.Name);
            stream.Write("FontSize");
            stream.Write(4);
            stream.Write(Font.Size);
            stream.Write("FontStyle");
            stream.Write(1);
            stream.Write((byte)Font.Style);
            stream.Write("TextColor");
            stream.Write(4);
            stream.Write(TextColor.ToArgb());
            // Upper class body
            base.WriteParameters(stream);
        }
    }

    // Exemplars

    public abstract class xExemplar : xRecord
    {
        protected xMap Map { get; }
        public xPrototype Prototype;
        public UInt64     PrototypeID;
        public Int64      PrototypeRevision;
        public String     Reference = "";
        public int Left  = 0, Top    = 0;
        public int Right = 0, Bottom = 0;
        public int Width = 0, Height = 0;

        virtual public bool IsObject { get; }
        virtual public bool IsLink   { get; }
        virtual public bool IsBox    { get; }

        public xExemplar(xMap owner)
        {
            Map = owner;
        }

        override protected bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (parameterName == "Reference")
                Reference = ReadStreamString(stream, valueLength);
            else if (valueLength == 8 && parameterName == "PrototypeID")
                PrototypeID = stream.ReadUInt64();
            else if (valueLength == 8 && parameterName == "PrototypeRevision")
                PrototypeRevision = stream.ReadInt64();
            // Pass unprocessed data up
            else
                return base.ReadParameter(stream, parameterName, valueLength);
            return true;
        }

        override public void WriteParameters(BinaryWriter stream)//Ok
        {
            // Write local part of body
            WriteStreamString("Reference", stream, Reference);
            stream.Write("PrototypeID");
            stream.Write(8);
            stream.Write(PrototypeID);
            stream.Write("PrototypeRevision");
            stream.Write(8);
            stream.Write(PrototypeRevision);
            // Upper class body
            base.WriteParameters(stream);
        }

        virtual public bool isOver(int x, int y, byte padding = 0)//Ok
        {
            return (Left <= x + padding) && (x <= Right + padding) && (Top <= y + padding) && (y <= Bottom + padding);
        }

        virtual public void Check()//Ok
        {
            Right  = Left + Width;
            Bottom = Top  + Height;
        }

        virtual public void Delete()
        {
        }
    }

    public enum PingStates
    {
        NotSend,
        Send,
        Replayed,
        Cancelled
    }

    public class xPing : xBase
    {
        public PingStates State;
        public DateTime   SendTime = DateTime.Now;
        public IPStatus   Status;
        public String     Error = "";
        public int        TripTime;
        public String     Replayer = "";

        override protected bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (parameterName == "State")
                Enum.TryParse(ReadStreamString(stream, valueLength), out State);
            else if (valueLength == 2 && parameterName == "Status")
                Status = (IPStatus)stream.ReadInt16();
            else if (valueLength == 8 && parameterName == "SendTime")
                SendTime = DateTime.FromBinary(stream.ReadInt64());
            else if (parameterName == "Error")
                Error = ReadStreamString(stream, valueLength);
            else if (valueLength == 4 && parameterName == "TripTime")
                TripTime = stream.ReadInt32();
            else if (parameterName == "Replayer")
                Replayer = ReadStreamString(stream, valueLength);
            // Pass unprocessed data up
            else
                return base.ReadParameter(stream, parameterName, valueLength);
            return true;
        }

        override public void WriteParameters(BinaryWriter stream)//Ok
        {
            // Write local part of body
            WriteStreamString("State", stream, State.ToString());
            if (State != PingStates.NotSend)
            {
                stream.Write("Status");
                stream.Write(2);
                stream.Write((Int16)Status);
                stream.Write("SendTime");
                stream.Write(8);
                stream.Write(SendTime.ToBinary());
                if (Error != "")
                    WriteStreamString("Error", stream, Error);
                stream.Write("TripTime");
                stream.Write(4);
                stream.Write(TripTime);
                if (Replayer != "")
                    WriteStreamString("Replayer", stream, Replayer);
            }
            // Upper class body
            base.WriteParameters(stream);
        }
    }

    public class xIP : xRecord
    {
        xObject Object { get; }
        public ListViewItem Map_lvItem    = null;
        public ListViewItem Obj_lvItem    = null;
        public ListView     Pings_lv      = null;
        public String       Address       = "";
        public int          Period        = Options.DEFAULT_PING_PERIOD;
        public int          TimeOutGreen  = Options.DEFAULT_PING_TIMEOUT_GREEN;
        public int          TimeOutYellow = Options.DEFAULT_PING_TIMEOUT_YELLOW;
        public int          TimeOutRed    = Options.DEFAULT_PING_TIMEOUT_RED;
        public bool         Onn           = Options.DEFAULT_PING_ONN;
        public DateTime     TimeLast      = DateTime.Now;
        public DateTime     TimeNext      = DateTime.Now;
        public xPing[]      Pings         = new xPing[Options.DEFAULT_PING_ARRAY];
        int pingsCount = 0;

        public int PingsCount { get { return pingsCount; } }

        public xIP(xObject owner)//Ok
        {
            Object = owner;
        }

        public void ClearPings()//Ok
        {
            Pings = new xPing[Options.DEFAULT_PING_ARRAY];
            pingsCount = 0;
        }

        public void PushNewPing(xPing Ping)//Ok
        {
            if (Pings.Length < ++pingsCount)
                pingsCount = Pings.Length;
            for (int i = pingsCount - 1; 0 < i; i--)
                Pings[i] = Pings[i - 1];
            Pings[0] = Ping;
        }

        public bool AddPing(DateTime now)//Ok
        {
            if (now < TimeNext || !Onn)
                return false;
            TimeLast = now;
            TimeNext = now.AddMilliseconds(Period);
            PushNewPing(new xPing());
            Pings[0].State = PingStates.Send;
            Pings[0].SendTime = now;
            if(Pings_lv != null)
                Share.lvPings_Add(Pings_lv, this, Pings[0]);
            return true;
        }

        protected override void BeforeReadParameters() => ClearPings();//Ok

        override protected bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
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
            else if (parameterName == "Ping")
            {
                var Ping = new xPing();
                Ping.ReadParameters(stream);
                PushNewPing(Ping);
            }
            // Pass unprocessed data up
            else
                return base.ReadParameter(stream, parameterName, valueLength);
            return true;
        }
        
        override public void WriteParameters(BinaryWriter stream)//Ok
        {
            // Write local part of body
            WriteStreamString("Address", stream, Address);
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
            // Ping records
            int pos = 0;
            for (int i = pingsCount - 1; 0 <= i; i--)
                if (Pings[i] != null)
                    if (Pings[i].State != PingStates.NotSend)
                    {
                        stream.Write("Ping");
                        pos = (int)stream.Seek(0, SeekOrigin.Current);
                        stream.Write(pos);
                        Pings[i].WriteParameters(stream);
                        WriteStream_CloseBlock(stream, pos);
                    }
            // Upper class body
            base.WriteParameters(stream);
        }

        public void Delete() => Object.DeleteIP(this);//Ok
    }

    public class xObject : xExemplar
    {
        public int X;
        public int Y;
        public List<xIP> IPs = new List<xIP>();

        override public bool IsObject { get; } = true;

        public xObject(xMap owner) : base(owner) { }

        override protected bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
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
                stream.Write(pos);
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
            Width  = (Prototype as xPObject).Canvas.Width;
            Height = (Prototype as xPObject).Canvas.Height;
            base.Check();
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
            IP.Map_lvItem?.Remove();
            IP.Obj_lvItem?.Remove();
            Map.DeleteIP(IP);
            IPs.Remove(IP);
        }

        override public void Delete()
        {
            Map.DeleteObject(this);
        }

        public xDot GetNearestDot(int x, int y) => (Prototype as xPObject).GetNearestDot(x - Left, y - Top);
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

        override public bool IsLink { get; } = true;

        public xLink(xMap owner) : base(owner) { }

        override protected bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
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
                    rx = Math.Round(XA + (double)((XB - XA) * Math.Abs(y - YA)) / Height);
                else if (0 < Width)
                    // Horizontal
                    ry = Math.Round(YA + (double)((YB - YA) * Math.Abs(x - XA)) / Width);
                // Check if point near line +/-3
                return (Math.Abs(x - rx) <= padding) && (Math.Abs(y - ry) <= padding);
            }
            return false;
        }

        private void BondEnd(ref xObject eObject, ref UInt64 eObjectID, ref xDot eDot, ref UInt64 eDotID)//
        {
            if (eObjectID != 0)
            {
                UInt64 OID = eObjectID;
                eObject = Map?.Objects.Find(xE => xE.ID == OID) as xObject;
                if (eObject != null)
                {
                    UInt64 DID = eDotID;
                    eDot = (eObject.Prototype as xPObject).Dots.Find(xE => xE.ID == DID);
                    if (eDot == null)
                    {
                        eDot = (eObject.Prototype as xPObject).Dots[0];
                        eDotID = eDot.ID;
                    }
                }
                else
                {
                    eObjectID = 0;
                    eDotID = 0;
                }
            }
        }

        public void BondEnds()//Ok
        {
            BondEnd(ref ObjectA, ref ObjectAID, ref DotA, ref DotAID);
            BondEnd(ref ObjectB, ref ObjectBID, ref DotB, ref DotBID);
        }

        private void CheckEnd(ref xObject eObject, ref UInt64 eObjectID, ref xDot eDot, ref UInt64 eDotID, ref int eX, ref int eY)//
        {
            if (eObjectID != 0)
            {
                try
                {
                    xDot Dot = (eObject.Prototype as xPObject).Dots[0];
                    if (eDotID != 0)
                        try
                        {
                            int x = eDot.X;
                        }
                        catch
                        {
                            eDot = Dot;
                            eDotID = eDot.ID;
                        }
                    eX = eObject.Left + eDot.X;
                    eY = eObject.Top  + eDot.Y;
                }
                catch
                {
                    eObjectID = 0;
                    eObject = null;
                    eDotID = 0;
                    eDot = null;
                }
            }
        }

        override public void Check()//Ok
        {
            CheckEnd(ref ObjectA, ref ObjectAID, ref DotA, ref DotAID, ref XA, ref YA);
            CheckEnd(ref ObjectB, ref ObjectBID, ref DotB, ref DotBID, ref XB, ref YB);
            Width  = Math.Abs(XB - XA) + 1;
            Height = Math.Abs(YB - YA) + 1;
            Left = ((XA < XB) ? XA : XB);
            Top  = ((YA < YB) ? YA : YB);
            base.Check();
        }

        override public void Delete() => Map.DeleteLink(this);
    }

    public class xBox : xExemplar
    {
        public String Text = "";
        public int TextX;
        public int TextY;
        
        override public bool IsBox { get; } = true;

        public xBox(xMap owner) : base(owner) { }

        override protected bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            if (parameterName == "Text")
                Text = ReadStreamString(stream, valueLength);
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
            WriteStreamString("Text", stream, Text);
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
            if (Text != "")
            {
                Graphics g = Graphics.FromImage(new Bitmap(1, 1));
                SizeF textSize = g.MeasureString(Text, (Prototype as xPBox).Font);
                if ((Prototype as xPBox).BoxType == BoxTypes.Ellipse)
                {
                    double m = (1 - Math.Sqrt(2)) / 4;
                    switch ((Prototype as xPBox).TextAlign)
                    {
                        case AlignTypes.TopLeft:
                            TextX = (int)(Left + Width  * m);
                            TextY = (int)(Top  + Height * m);
                            break;
                        case AlignTypes.Top:
                            TextX = (int)(Left + (Width - textSize.Width) / 2);
                            TextY = Top;
                            break;
                        case AlignTypes.TopRight:
                            TextX = (int)(Left + Width  * (1 - m) - textSize.Width);
                            TextY = (int)(Top  + Height * m);
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
                            TextX = (int)(Left +  Width  - textSize.Width );
                            TextY = (int)(Top  + (Height - textSize.Height) / 2);
                            break;
                        case AlignTypes.BottomLeft:
                            TextX = (int)(Left +  Width * m);
                            TextY = (int)(Top  +  Height * (1 - m) - textSize.Height);
                            break;
                        case AlignTypes.Bottom:
                            TextX = (int)(Left + (Width  - textSize.Width ) / 2);
                            TextY = (int)(Top  +  Height - textSize.Height);
                            break;
                        case AlignTypes.BottomRight:
                            TextX = (int)(Left + Width  * (1 - m) - textSize.Width );
                            TextY = (int)(Top  + Height * (1 - m) - textSize.Height);
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
                                TextX = (int)(Left + (Width  - textSize.Width ) / 2);
                                break;
                            case AlignTypes.TopRight:
                                TextX = (int)(Left +  Width  - textSize.Width );
                                break;
                            case AlignTypes.Left:
                                TextY = (int)(Top  + (Height - textSize.Height) / 2);
                                break;
                            case AlignTypes.Center:
                                TextX = (int)(Left + (Width  - textSize.Width ) / 2);
                                TextY = (int)(Top  + (Height - textSize.Height) / 2);
                                break;
                            case AlignTypes.Right:
                                TextX = (int)(Left +  Width  - textSize.Width );
                                TextY = (int)(Top  + (Height - textSize.Height) / 2);
                                break;
                            case AlignTypes.BottomLeft:
                                TextY = (int)(Top  +  Height - textSize.Height);
                                break;
                            case AlignTypes.Bottom:
                                TextX = (int)(Left + (Width  - textSize.Width ) / 2);
                                TextY = (int)(Top  +  Height - textSize.Height);
                                break;
                            case AlignTypes.BottomRight:
                                TextX = (int)(Left +  Width  - textSize.Width );
                                TextY = (int)(Top  +  Height - textSize.Height);
                                break;
                        }
                    else
                    {
                        Width  = (int)textSize.Width;
                        Height = (int)textSize.Height;
                    }
                }
            }
            base.Check();
        }

        override public void Delete() => Map.DeleteBox(this);
    }

    // Map

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
            Style = Options.DEFAULT_GRID_STYLE;
        public Int16
            StepX = Options.DEFAULT_GRID_STEP,
            StepY = Options.DEFAULT_GRID_STEP;
        public Pen
            Pen = new Pen(Options.DEFAULT_GRID_COLOR, 1);
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
        public BackgroundStyles Style      = Options.DEFAULT_BACK_STYLE;
        public Color            Color      = Options.DEFAULT_BACK_COLOR;
        public Color            AlphaColor = Options.DEFAULT_BACK_ACOLOR;
        public AlignTypes       Align      = Options.DEFAULT_BACK_ALIGN;
        public ImageBPPs        BPP        = ImageBPPs.b32argb;
        public String           Path       = "";
        public Bitmap           Image      = Share.GetEmptyImage();
    }

    public class xMap : xRecord
    {
        public TabPage Tab;
        public bool Changed;
        public List<xPrototype> PObjects = new List<xPrototype>();
        public List<xPrototype> PLinks   = new List<xPrototype>();
        public List<xPrototype> PBoxes   = new List<xPrototype>();
        public List<xExemplar>  Objects  = new List<xExemplar>();
        public List<xExemplar>  Links    = new List<xExemplar>();
        public List<xExemplar>  Boxes    = new List<xExemplar>();
        public xBackground    Back     = new xBackground();
        public xGrid          Grid     = new xGrid();
        public int
            ScrollX = 0,
            ScrollY = 0,
            Width,
            Height;
        public bool      AutoSize = Options.DEFAULT_MAP_AUTOSIZE;
        public Bitmap    Canvas;
        Graphics         graphics;
        public xExemplar Selected;
        public ListView 
            lv_PObjects,
            lv_PLinks,
            lv_PBoxes;

        public xMap()
        {
            SetCanvas(Options.DEFAULT_MAP_WIDTH, Options.DEFAULT_MAP_HEIGHT);
        }

        public void UpdateTabName()
        {
            if (Tab == null)
                return;
            Tab.Text 
                = ((Name != "") ? Name 
                : (FileName != "") ? Path.GetFileNameWithoutExtension(FileName) 
                : "No name") 
                + (Changed ? " *" : "");
        }

        #region Prototypes
        public xPObject AddPObject(xPrototype Prototype) => (AddPrototype(Prototype, Options.PObjects, PObjects, lv_PObjects) as xPObject);//Ok
        public xPLink   AddPLink  (xPrototype Prototype) => (AddPrototype(Prototype, Options.PLinks,   PLinks,   lv_PLinks)   as xPLink);//Ok
        public xPBox    AddPBox   (xPrototype Prototype) => (AddPrototype(Prototype, Options.PBoxes,   PBoxes,   lv_PBoxes)   as xPBox);//Ok

        public xPrototype AddPrototype(xPrototype Prototype, List<xPrototype> LibPrototypes, List<xPrototype> Prototypes, ListView UsedListView)//Ok
        {
            // Search prototype in library catalog
            xPrototype uPrototype = LibPrototypes.Find(PO => (PO.ID == Prototype.ID) && (PO.Revision == Prototype.Revision));
            if (uPrototype != null)
                Prototype = uPrototype;
            // Search prototype in map catalog
            uPrototype = Prototypes.Find(PO => (PO.ID == Prototype.ID) && (PO.Revision == Prototype.Revision));
            if (uPrototype != null)
                Prototype = uPrototype;
            else
            {
                Prototypes.Add(Prototype);
                if (UsedListView != null)
                {
                    Prototype.lvItemUsed = UsedListView.Items.Add("");
                    Prototype.lvItemUsed.SubItems.Add("");
                    Prototype.lvItemUsed.SubItems.Add("");
                    Prototype.lvItemUsed.Tag = Prototype;
                    Share.Library_UpdateNodeName(Prototype);
                }
            }
            return Prototype;
        }

        public void RemovePObject(xPObject PObject) => RemovePrototype(PObject, PObjects, Objects);//Ok
        public void RemovePLink  (xPLink   PLink)   => RemovePrototype(PLink,   PLinks,   Links);//Ok
        public void RemovePBox   (xPBox    PBox)    => RemovePrototype(PBox,    PBoxes,   Boxes);//Ok

        public void RemovePrototype(xPrototype Prototype, List<xPrototype> Prototypes, List<xExemplar> Exemplars)//Ok
        {
            if (Prototype != null)
                if (!Exemplars.Exists(O => (O.Prototype.ID == Prototype.ID) && (O.Prototype.Revision == Prototype.Revision)))
                {
                    Prototype.lvItemUsed?.Remove();
                    Prototypes.Remove(Prototype);
                }
        }
        #endregion

        #region Exemplars
        public void SnapXY(ref int X, ref int Y)//Ok
        {
            xGrid grid = (Grid.StoreOwn) ? Grid : Options.Grid;
            if (grid.Snap)
            {
                X = (X + grid.StepX / 2) / grid.StepX * grid.StepX;
                Y = (Y + grid.StepY / 2) / grid.StepY * grid.StepY;
            }
        }

        public void AlignToGridAll(int sX = 0, int sY = 0)//Ok
        {
            if (sX == 0)
                sX = Grid.StepX;
            if (sY == 0)
                sY = Grid.StepY;
            foreach (xBox Box in Boxes)
            {
                SnapXY(ref Box.Left,  ref Box.Top);
                SnapXY(ref Box.Width, ref Box.Height);
                Box.Check();
            }
            foreach (xObject Object in Objects)
            {
                SnapXY(ref Object.X, ref Object.Y);
                Object.Check();
            }
            foreach (xLink Link in Links)
            {
                if (Link.ObjectA == null)
                    SnapXY(ref Link.XA, ref Link.YA);
                if (Link.ObjectB == null)
                    SnapXY(ref Link.XB, ref Link.YB);
                Link.Check();
            }
        }

        public void CheckLinksToObject(UInt64 ObjectID)//O
        {
            // Check all links to this object
            for (int i = Links.Count - 1; 0 <= i; i--)
                if ((Links[i] as xLink).ObjectAID == ObjectID || (Links[i] as xLink).ObjectBID == ObjectID)
                    Links[i].Check();
        }

        public void DeleteObject(xObject Object)//Ok
        {
            if (Object == null)
                return;
            // Remove all IPs
            Object.ClearIPs();
            // Remove all links to this object
            for (int i = Links.Count - 1; 0 <= i; i--)
                if ((Links[i] as xLink).ObjectA == Object || (Links[i] as xLink).ObjectB == Object)
                    Links.RemoveAt(i);
            // Remove
            DeleteExemplar(Object, Objects, PObjects);
        }

        public void DeleteLink(xLink Link) => DeleteExemplar(Link, Links, PLinks);//Ok

        public void DeleteBox (xBox Box)   => DeleteExemplar(Box,  Boxes, PBoxes);//Ok

        private void DeleteExemplar(xExemplar Exemplar, List<xExemplar> Exemplars, List<xPrototype> Prototypes)//Ok
        {
            // Unregister exemplar
            Exemplars.Remove(Exemplar);
            // Try to remove it's prototype
            RemovePrototype(Exemplar.Prototype, Prototypes, Exemplars);
        }

        public void AddIP   (xIP IP) => Options.AddIP(IP);//Ok
        public void DeleteIP(xIP IP) => Options.RemoveIP(IP);//Ok

        public void Clear()//Ok
        {
            for (int i = Boxes.Count - 1; 0 <= i; i--)
                DeleteBox(Boxes[i] as xBox);
            for (int i = Links.Count - 1; 0 <= i; i--)
                DeleteLink(Links[i] as xLink);
            for (int i = Objects.Count - 1; 0 <= i; i--)
                DeleteObject(Objects[i] as xObject);
        }
        #endregion

        #region Save/Load Map
        override protected void BeforeReadParameters()//Ok
        {
            Clear();
            Selected = null;
            AutoSize = false;
            Grid = new xGrid();
            Back = new xBackground();
        }

        override protected void AfterReadParameters()//Ok
        {
            if (Back.Style != BackgroundStyles.Color)
                if (File.Exists(Back.Path))
                {
                    var bmap = new Bitmap(Back.Path);
                    Back.Image = new Bitmap(bmap.Width, bmap.Height, PixelFormat.Format32bppArgb);
                    Graphics.FromImage(Back.Image).DrawImageUnscaled(bmap, 0, 0);
                }
            if (Back.UseAlphaColor)
                Back.Image.MakeTransparent(Back.AlphaColor);
            if (AutoSize)
                DoAutoSize();
            else
                SetSize(Width, Height);
            Changed = false;
            Draw();
        }

        private void ReadPrototype(BinaryReader stream, xPrototype Prototype, List<xPrototype> LibPrototypes, List<xPrototype> Prototypes, ListView UsedListView)//Ok
        {
            Prototype.ReadParameters(stream);
            AddPrototype(Prototype, LibPrototypes, Prototypes, UsedListView);
        }

        private void ReadExemplar(BinaryReader stream, xExemplar Exemplar, List<xExemplar> Exemplars, List<xPrototype> Prototypes, xPrototype DefaultPrototype)//Ok
        {
            Exemplar.ReadParameters(stream);
            Exemplar.Prototype = Prototypes.Find(xP => (xP.ID == Exemplar.PrototypeID) && (xP.Revision == Exemplar.PrototypeRevision));
            if (Exemplar.Prototype == null)
                Exemplar.Prototype = DefaultPrototype;
            if (Exemplar.IsLink)
                (Exemplar as xLink).BondEnds();
            Exemplars.Add(Exemplar);
            Exemplar.Check();
        }

        override protected bool ReadParameter(BinaryReader stream, String parameterName, int valueLength)//Ok
        {
            #region Map
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
                Enum.TryParse(ReadStreamString(stream, valueLength), out Grid.Style);
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
                Enum.TryParse(ReadStreamString(stream, valueLength), out Back.Style);
            else if (valueLength == 4 && parameterName == "BackgroundColor")
                Back.Color = Color.FromArgb(stream.ReadInt32());
            else if (parameterName == "BackgroundPath")
                Back.Path = ReadStreamString(stream, valueLength);
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
                Back.UseAlphaColor = true;
            #endregion

            #region Prototypes
            // PObjects
            else if (parameterName == "PObject")
                ReadPrototype(stream, new xPObject(), Options.PObjects, PObjects, lv_PObjects);
            // PLinks
            else if (parameterName == "PLink")
                ReadPrototype(stream, new xPLink(), Options.PLinks, PLinks, lv_PLinks);
            // PBoxes
            else if (parameterName == "PBox")
                ReadPrototype(stream, new xPBox(), Options.PBoxes, PBoxes, lv_PBoxes);
            #endregion

            #region Exemplars
            // Objects
            else if (parameterName == "Object")
                ReadExemplar(stream, new xObject(this), Objects, PObjects, Options.PObjects[0]);
            // Links
            else if (parameterName == "Link")
                ReadExemplar(stream, new xLink(this), Links, PLinks, Options.PLinks[0]);
            // Boxes
            else if (parameterName == "Box")
                ReadExemplar(stream, new xBox(this), Boxes, PBoxes, Options.PBoxes[0]);
            #endregion

            // Pass unprocessed data up
            else
                return base.ReadParameter(stream, parameterName, valueLength);
            return true;
        }

        override public void WriteParameters(BinaryWriter stream)//Ok
        {
            #region Map setings
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
            WriteStreamString("GridStyle", stream, Grid.Style.ToString());
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
            WriteStreamString("BackgroundStyle", stream, Back.Style.ToString());
            stream.Write("BackgroundColor");
            stream.Write(4);
            stream.Write(Back.Color.ToArgb());
            WriteStreamString("BackgroundPath", stream, Back.Path);
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
            #endregion

            int pos;
            #region Prototype
            // PObjects
            foreach (var PObject in PObjects)
            {
                stream.Write("PObject");
                pos = (int)stream.Seek(0, SeekOrigin.Current);
                stream.Write(pos);
                PObject.WriteParameters(stream);
                WriteStream_CloseBlock(stream, pos);
            }
            // PLinks
            foreach (var PLink in PLinks)
            {
                stream.Write("PLink");
                pos = (int)stream.Seek(0, SeekOrigin.Current);
                stream.Write(pos);
                PLink.WriteParameters(stream);
                WriteStream_CloseBlock(stream, pos);
            }
            // PBoxes
            foreach (var PBox in PBoxes)
            {
                stream.Write("PBox");
                pos = (int)stream.Seek(0, SeekOrigin.Current);
                stream.Write(pos);
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
                stream.Write(pos);
                Object.WriteParameters(stream);
                WriteStream_CloseBlock(stream, pos);
            }
            // Links
            foreach (var Link in Links)
            {
                stream.Write("Link");
                pos = (int)stream.Seek(0, SeekOrigin.Current);
                stream.Write(pos);
                Link.WriteParameters(stream);
                WriteStream_CloseBlock(stream, pos);
            }
            // Boxes
            foreach (var Box in Boxes)
            {
                stream.Write("Box");
                pos = (int)stream.Seek(0, SeekOrigin.Current);
                stream.Write(pos);
                Box.WriteParameters(stream);
                WriteStream_CloseBlock(stream, pos);
            }
            #endregion

            // Upper class body
            base.WriteParameters(stream);
        }
        #endregion

        #region Sizing/Drawing
        public bool DoAutoSize()
        {
            if (!AutoSize)
                return false;
            int width  = Options.PortW,
                height = Options.PortH;
            // Look for bigger values
            foreach (var Object in Objects)
            {
                if (width  < Object.Right)
                    width  = Object.Right;
                if (height < Object.Bottom)
                    height = Object.Bottom;
            }
            foreach (var Link in Links)
            {
                if (width  < Link.Right)
                    width  = Link.Right;
                if (height < Link.Bottom)
                    height = Link.Bottom;
            }
            foreach (var Box in Boxes)
            {
                if (width  < Box.Right)
                    width  = Box.Right;
                if (height < Box.Bottom)
                    height = Box.Bottom;
            }
            // Apply
            return SetCanvas(width, height);
        }

        public void SetSize(int width, int height)
        {
            if (width < Width || height < Height)
            {
                // Look for out of border elements
                foreach (xObject Object in Objects)
                {
                    if (width  < Object.Right )
                        Object.X = (width  < Object.Width ) ? 0 : width  - Object.Width;
                    if (height < Object.Bottom)
                        Object.Y = (height < Object.Height) ? 0 : height - Object.Height;
                    Object.Check();
                }
                foreach (xLink Link in Links)
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
                foreach (xBox Box in Boxes)
                {
                    if (width  < Box.Right )
                        Box.Left = (width  < Box.Width ) ? 0 : width  - Box.Width;
                    if (height < Box.Bottom)
                        Box.Top  = (height < Box.Height) ? 0 : height - Box.Height;
                    Box.Check();
                }
            }
            SetCanvas(width, height);
        }

        bool SetCanvas(int width, int height)
        {
            Width  = width;
            Height = height;
            if (Canvas != null)
                if (Canvas.Width == width && Canvas.Height == height)
                    return false;
            if (Canvas != null)
                Canvas.Dispose();
            Canvas = new Bitmap(Width, Height);
            graphics = Graphics.FromImage(Canvas);
            return true;
        }

        public void CheckAll()
        {
            foreach (var Object in Objects)
                Object.Check();
            foreach (var Link in Links)
                Link.Check();
            foreach (var Box in Boxes)
                Box.Check();
        }

        public void Draw(int drawX = 0, int drawY = 0, int drawW = 0, int drawH = 0)//
        {
            if (drawW < 1)
                drawW = Width;
            if (drawH < 1)
                drawH = Height;
            // Clear area
            graphics.Clip = new Region(new Rectangle(drawX, drawY, drawW, drawH));

            // Draw background
            var back = (Back.StoreOwn) ? Back : Options.Back;
            if (back.Float)
                Share.DrawBack(graphics,
                    back,
                    (Grid.StoreOwn) ? Grid : Options.Grid,
                    drawX, drawY, drawW, drawH,
                    ScrollX, ScrollY, Options.PortW, Options.PortH);
            else
                Share.DrawBack(graphics,
                    back,
                    (Grid.StoreOwn) ? Grid : Options.Grid,
                    drawX, drawY, drawW, drawH,
                    0, 0, Width, Height);
            graphics.DrawRectangle(new Pen(Color.FromArgb(255, back.Color.R ^ 128, back.Color.G ^ 128, back.Color.B ^ 128)), 0, 0, Width - 1, Height - 1);

            #region Exemplars
            int drawX2 = drawX + drawW,
                drawY2 = drawY + drawH;
            // Draw Boxes
            foreach (var Box in Boxes)
                if (Box.Left <= drawX2 && drawX <= Box.Right)
                    if (Box.Top <= drawY2 && drawY <= Box.Bottom)
                    {
                        switch ((Box.Prototype as xPBox).BoxType)
                        {
                            case BoxTypes.Rectangle:
                                graphics.DrawRectangle((Box.Prototype as xPBox).Pen, Box.Left, Box.Top, Box.Width, Box.Height);
                                break;
                            case BoxTypes.Ellipse:
                                graphics.DrawEllipse((Box.Prototype as xPBox).Pen, Box.Left, Box.Top, Box.Width, Box.Height);
                                break;
                        }
                        if ((Box as xBox).Text != "")
                            graphics.DrawString((Box as xBox).Text, (Box.Prototype as xPBox).Font, (Box.Prototype as xPBox).Brush, (Box as xBox).TextX, (Box as xBox).TextY);
                    }

            // Draw Links
            foreach (var Link in Links)
                if (Link.Left <= drawX2 && drawX <= Link.Right)
                    if (Link.Top <= drawY2 && drawY <= Link.Bottom)
                        graphics.DrawLine((Link.Prototype as xPLink).Pen, (Link as xLink).XA, (Link as xLink).YA, (Link as xLink).XB, (Link as xLink).YB);

            // Draw Objects
            foreach (var Object in Objects)
                if (Object.Left <= drawX2 && drawX <= Object.Right)
                    if (Object.Top <= drawY2 && drawY <= Object.Bottom)
                        graphics.DrawImageUnscaled((Object.Prototype as xPObject).Canvas, Object.Left, Object.Top);
            #endregion
        }
        #endregion

        #region Selection
        public xExemplar SelectAt(int x, int y) => Selected = AnythingAt(x, y);

        public xExemplar AnythingAt(int x, int y)//
        {
            xExemplar selected = ObjectAt(x, y);
            if (selected == null)
                selected = LinkAt(x, y);
            if (selected == null)
                selected = BoxAt(x, y);
            return selected;
        }

        public xExemplar ObjectAt(int x, int y) => Objects.Find(O => O.isOver(x, y));
        public xExemplar LinkAt  (int x, int y) => Links.Find(L => L.isOver(x, y, 3));
        public xExemplar BoxAt   (int x, int y) => Boxes.Find(B => B.isOver(x, y));
        #endregion
    }
}
