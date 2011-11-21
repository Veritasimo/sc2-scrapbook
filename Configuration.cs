using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SC2Scrapbook
{
    [Serializable]
    public class Configuration : IXmlSerializable
    {

        public static Configuration Instance
        {
            get;
            set;
        }

        public int OverlayTop { get; set; }
        public int OverlayLeft { get; set; }
        public int MainTop { get; set; }
        public int MainLeft { get; set; }
        public int MainHeight { get; set; }
        public int MainWidth { get; set; }

        public string OverlayTitleFont { get; set; }
        public string OverlayContentFont { get; set; }
        public float OverlayTitleSize { get; set; }
        public float OverlayContentSize { get; set; }
        public Color OverlayTextColour { get; set; }
        public Color OverlayTextOutlineColour { get; set; }
        public int OverlayTextOutlineSize { get; set; }

        public bool FirstRun { get; set; }
        
        public bool UseAdvancedOptions { get; set; }
        public bool OpponentInfoOverlay { get; set; }
        public int OpponentInfoOverlayTimeout { get; set; }
        public bool BuildSelectionOverlay { get; set; }
        public bool SelectRandomBuild { get; set; }
        public bool AllowVsXBuilds { get; set; }

        public string MySC2Character { get; set; }

        public System.Windows.Forms.Keys ToggleOverlayKey { get; set; }
        public System.Windows.Forms.Keys ToggleOverlayModifier { get; set; }

        public bool SeenMinimizeNotification { get; set; }

        #region IXmlSerializable Members

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }



        public void ReadXml(System.Xml.XmlReader reader)
        {
            XmlSerializer intSerializer = new XmlSerializer(typeof(int));
            XmlSerializer boolSerializer = new XmlSerializer(typeof(bool));
            XmlSerializer floatSerializer = new XmlSerializer(typeof(float));
            XmlSerializer stringSerializer = new XmlSerializer(typeof(string));

            bool wasEmpty = reader.IsEmptyElement;
            reader.Read();

            if (wasEmpty)
                return;

            reader.MoveToContent();
            while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
            {
                string element = reader.Name.ToLower();

                reader.ReadStartElement();

                switch (element)
                {
                    case "overlayy":
                        OverlayTop = (int)intSerializer.Deserialize(reader);
                        break;
                    case "overlayx":
                        OverlayLeft = (int)intSerializer.Deserialize(reader);
                        break;
                    case "mainy":
                        MainTop = (int)intSerializer.Deserialize(reader);
                        break;
                    case "mainx":
                        MainLeft = (int)intSerializer.Deserialize(reader);
                        break;
                    case "mainh":
                        MainHeight = (int)intSerializer.Deserialize(reader);
                        break;
                    case "mainw":
                        MainWidth = (int)intSerializer.Deserialize(reader);
                        break;

                    case "overlaycontentfont":
                        OverlayContentFont = (string)stringSerializer.Deserialize(reader);
                        break;
                    case "overlaytitlefont":
                        OverlayTitleFont = (string)stringSerializer.Deserialize(reader);
                        break;
                    case "overlaytextcolour":
                        OverlayTextColour = ColorTranslator.FromHtml((string)stringSerializer.Deserialize(reader));
                        break;
                    case "overlaytextoutlinecolour":
                        OverlayTextOutlineColour = ColorTranslator.FromHtml((string)stringSerializer.Deserialize(reader));
                        break;
                    case "overlaytextoutlinesize":
                        OverlayTextOutlineSize = (int)intSerializer.Deserialize(reader);
                        break;
                    case "overlaycontentsize":
                        OverlayContentSize = (float)floatSerializer.Deserialize(reader);
                        break;
                    case "overlaytitlesize":
                        OverlayTitleSize = (float)floatSerializer.Deserialize(reader);
                        break;
                    case "useadvancedoptions":
                        UseAdvancedOptions = (bool)boolSerializer.Deserialize(reader);
                        break;
                    case "opponentinfooverlay":
                        OpponentInfoOverlay = (bool)boolSerializer.Deserialize(reader);
                        break;
                    case "buildselectionoverlay":
                        BuildSelectionOverlay = (bool)boolSerializer.Deserialize(reader);
                        break;
                    case "mysc2character":
                        MySC2Character = (string)stringSerializer.Deserialize(reader);
                        break;
                    case "selectrandombuild":
                        SelectRandomBuild = (bool)boolSerializer.Deserialize(reader);
                        break;
                    case "allowvsxbuilds":
                        AllowVsXBuilds = (bool)boolSerializer.Deserialize(reader);
                        break;
                    case "opponentinfooverlaytimeout":
                        OpponentInfoOverlayTimeout = (int)intSerializer.Deserialize(reader);
                        break;
                    case "seenminimizenotification":
                        SeenMinimizeNotification = (bool)boolSerializer.Deserialize(reader);
                        break;
                    default:
                        reader.ReadInnerXml();
                        break;

                }
                reader.ReadEndElement();
                reader.MoveToContent();
            }

            reader.ReadEndElement();

        }



        public void WriteXml(System.Xml.XmlWriter writer)
        {

            XmlSerializer intSerializer = new XmlSerializer(typeof(int));
            XmlSerializer floatSerializer = new XmlSerializer(typeof(float));
            XmlSerializer stringSerializer = new XmlSerializer(typeof(string));
            XmlSerializer boolSerializer = new XmlSerializer(typeof(bool));

            writer.WriteStartElement("MainX");
            intSerializer.Serialize(writer, MainLeft);
            writer.WriteEndElement();

            writer.WriteStartElement("MainY");
            intSerializer.Serialize(writer, MainTop);
            writer.WriteEndElement();

            writer.WriteStartElement("MainW");
            intSerializer.Serialize(writer, MainWidth);
            writer.WriteEndElement();

            writer.WriteStartElement("MainH");
            intSerializer.Serialize(writer, MainHeight);
            writer.WriteEndElement();

            writer.WriteStartElement("OverlayX");
            intSerializer.Serialize(writer, OverlayLeft);
            writer.WriteEndElement();

            writer.WriteStartElement("OverlayY");
            intSerializer.Serialize(writer, OverlayTop);
            writer.WriteEndElement();

            writer.WriteStartElement("OverlayContentFont");
            stringSerializer.Serialize(writer, OverlayContentFont);
            writer.WriteEndElement();

            writer.WriteStartElement("OverlayTitleFont");
            stringSerializer.Serialize(writer, OverlayTitleFont);
            writer.WriteEndElement();

            writer.WriteStartElement("OverlayTextColour");
            stringSerializer.Serialize(writer, ColorTranslator.ToHtml(OverlayTextColour));
            writer.WriteEndElement();

            writer.WriteStartElement("OverlayTextOutlineColour");
            stringSerializer.Serialize(writer, ColorTranslator.ToHtml(OverlayTextOutlineColour));
            writer.WriteEndElement();

            writer.WriteStartElement("OverlayContentSize");
            floatSerializer.Serialize(writer, OverlayContentSize);
            writer.WriteEndElement();

            writer.WriteStartElement("OverlayTitleSize");
            floatSerializer.Serialize(writer, OverlayTitleSize);
            writer.WriteEndElement();

            writer.WriteStartElement("OverlayTextOutlineSize");
            intSerializer.Serialize(writer, OverlayTextOutlineSize);
            writer.WriteEndElement();

            writer.WriteStartElement("UseAdvancedOptions");
            boolSerializer.Serialize(writer, UseAdvancedOptions);
            writer.WriteEndElement();

            writer.WriteStartElement("SeenMinimizeNotification");
            boolSerializer.Serialize(writer, SeenMinimizeNotification);
            writer.WriteEndElement();

            writer.WriteStartElement("OpponentInfoOverlay");
            boolSerializer.Serialize(writer, OpponentInfoOverlay);
            writer.WriteEndElement();

            writer.WriteStartElement("OpponentInfoOverlayTimeout");
            intSerializer.Serialize(writer, OpponentInfoOverlayTimeout);
            writer.WriteEndElement();

            writer.WriteStartElement("BuildSelectionOverlay");
            boolSerializer.Serialize(writer, BuildSelectionOverlay);
            writer.WriteEndElement();

            writer.WriteStartElement("SelectRandomBuild");
            boolSerializer.Serialize(writer, SelectRandomBuild);
            writer.WriteEndElement();

            writer.WriteStartElement("AllowVsXBuilds");
            boolSerializer.Serialize(writer, AllowVsXBuilds);
            writer.WriteEndElement();

            writer.WriteStartElement("MySC2Character");
            stringSerializer.Serialize(writer, MySC2Character);
            writer.WriteEndElement();
        }

        #endregion

    }
}
