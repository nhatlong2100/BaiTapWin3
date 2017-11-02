using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization;
namespace myStruct
{
    [Serializable()]
    public class Structure : ISerializable
    {
        private string textChat;
        private Font myFont;
        private Color myColor;

        public string TextChat
        {
            get
            {
                return textChat;
            }

            set
            {
                textChat = value;
            }
        }

        public Font MyFont
        {
            get
            {
                return myFont;
            }

            set
            {
                myFont = value;
            }
        }

        public Color MyColor
        {
            get
            {
                return myColor;
            }

            set
            {
                myColor = value;
            }
        }

        public Structure()
        {
            this.TextChat = null;
            this.MyColor = Color.Red;
            this.MyFont = new Font("Arial", 9, FontStyle.Regular);
        }

        public Structure(string text, Font ft, Color cl)
        {
            this.TextChat = text;
            this.MyColor = cl;
            this.MyFont = ft;
        }

        public Structure(Structure str)
        {
            this.TextChat = str.TextChat;
            this.MyColor = str.MyColor;
            this.MyFont = str.MyFont;
        }

        public Structure(SerializationInfo info, StreamingContext strcxt)
        {
            this.TextChat = (string)info.GetValue("text", typeof(string));
            this.MyFont = (Font)info.GetValue("font", typeof(Font));
            this.MyColor = (Color)info.GetValue("color", typeof(Color));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext strcxt)
        {
            info.AddValue("text", this.TextChat);
            info.AddValue("font", this.MyFont);
            info.AddValue("color", this.MyColor);
        }
    }
}
