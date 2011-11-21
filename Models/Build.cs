using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace SC2Scrapbook.Models
{
    public class Build : IXmlSerializable
    {
        private string m_lowercaseName;

        public string Guid { get; set; }
        public Matchup Matchup { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// If we have hundreds of builds, this will save a tiny tiny tiny tiny bit of time while filtering.
        /// </summary>
        public string LowercaseName
        {
            get
            {
                if (string.IsNullOrEmpty(m_lowercaseName))
                    m_lowercaseName = Name.ToLower();

                return m_lowercaseName;
            }
        }

        public string Script { get; set; }
        public string Notes { get; set; }

        public Build()
        {

        }

        public Build(string name, string matchup, string script, string notes)
        {
            Name = name;
            Matchup = new Matchup(matchup);
            Script = script;
            Notes = notes;
            Guid = System.Guid.NewGuid().ToString();
        }

        #region IXmlSerializable Members

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public static Build ParseBase64(string b64)
        {
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream(Convert.FromBase64String(b64));
                System.IO.Compression.GZipStream gz = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Decompress);

                XmlSerializer buildSerializer = new XmlSerializer(typeof(Build));
                Build build = (Build)buildSerializer.Deserialize(gz);

                gz.Close();
                ms.Close();

                return build;
            }
            catch
            {
                return null;
            }
        }

        public string SaveBase64()
        {
            XmlWriterSettings xws = new XmlWriterSettings();
            xws.Indent = false;
            xws.NewLineHandling = NewLineHandling.Entitize;
            xws.CloseOutput = false;

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.IO.Compression.GZipStream gz = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Compress, true);
            XmlWriter w = XmlWriter.Create(gz, xws);
            XmlSerializer buildSerializer = new XmlSerializer(typeof(Build));

            buildSerializer.Serialize(w, this);

            w.Close();
            gz.Close();

            ms.Seek(0, System.IO.SeekOrigin.Begin);
            byte[] buffer = ms.ToArray();

            ms.Close();

            return Convert.ToBase64String(buffer);
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            XmlSerializer stringSerializer = new XmlSerializer(typeof(string));
            XmlSerializer matchupSerializer = new XmlSerializer(typeof(Matchup));



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
                    case "name":
                        Name = (string)stringSerializer.Deserialize(reader);
                        break;
                    case "script":
                        Script = (string)stringSerializer.Deserialize(reader);
                        break;
                    case "notes":
                        Notes = (string)stringSerializer.Deserialize(reader);
                        break;
                    case "matchup":
                        try
                        {
                            Matchup = (Matchup)matchupSerializer.Deserialize(reader);
                        }
                        catch (Exception ex)
                        {
                            ex = ex;
                        }
                        break;
                    case "guid":
                        Guid = (string)stringSerializer.Deserialize(reader);
                        break;
                    default:
                        reader.ReadInnerXml();
                        break;

                }
                reader.ReadEndElement();
                reader.MoveToContent();
            }

            reader.ReadEndElement();


            if (string.IsNullOrEmpty(Guid))
                Guid = System.Guid.NewGuid().ToString();
        }



        public void WriteXml(System.Xml.XmlWriter writer)
        {

            XmlSerializer stringSerializer = new XmlSerializer(typeof(string));
 
                XmlSerializer matchupSerializer = new XmlSerializer(typeof(Matchup));


            writer.WriteStartElement("Name");
            stringSerializer.Serialize(writer, Name);
            writer.WriteEndElement();

            writer.WriteStartElement("Matchup");
            matchupSerializer.Serialize(writer, Matchup);
            writer.WriteEndElement();

            writer.WriteStartElement("Script");
            stringSerializer.Serialize(writer, Script);
            writer.WriteEndElement();

            writer.WriteStartElement("Notes");
            stringSerializer.Serialize(writer, Notes);
            writer.WriteEndElement();

            writer.WriteStartElement("Guid");
            stringSerializer.Serialize(writer, Guid);
            writer.WriteEndElement();
        }

        #endregion
    }
}
