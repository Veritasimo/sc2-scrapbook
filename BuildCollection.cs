using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SC2Scrapbook
{
    [Serializable]
    [XmlRoot("Builds")]
    public class BuildCollection : System.Collections.ObjectModel.ReadOnlyCollection<Models.Build>, IXmlSerializable
    {
        public object SyncRoot { get; private set; }

        internal BuildCollection()
            : base(new List<Models.Build>())
        {
            SyncRoot = new object();
        }

        #region IXmlSerializable Members

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            bool wasEmpty = reader.IsEmptyElement;
            reader.Read();

            if (wasEmpty)
                return;


            XmlSerializer serializer = new XmlSerializer(typeof(Models.Build));
            reader.MoveToContent();
            while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
            {
                reader.ReadStartElement("Build");
                reader.MoveToContent();

                Models.Build build = (Models.Build)serializer.Deserialize(reader);

                this.Add(build);

                reader.MoveToContent();
                reader.ReadEndElement();
                reader.MoveToContent();
            }

            reader.ReadEndElement();

        }



        public void WriteXml(System.Xml.XmlWriter writer)
        {

            foreach (Models.Build build in this)
            {
                XmlSerializer serializer = new XmlSerializer(build.GetType());

                writer.WriteStartElement("Build");

                serializer.Serialize(writer, build);

                writer.WriteEndElement();

                serializer = null;
            }
        }

        #endregion

        internal void Add(Models.Build item)
        {
            Items.Add(item);
        }

        public void Clear()
        {
            Items.Clear();
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        internal bool Remove(Models.Build item)
        {
            return Items.Remove(item);
        }

    }
}
