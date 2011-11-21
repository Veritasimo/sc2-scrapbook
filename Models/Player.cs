using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Drawing;

namespace SC2Scrapbook.Models
{
    public class Player : IXmlSerializable
    {

        public class PortraitData
        {
            public string Filename { get; set; }
            public Rectangle Position { get; set; }

            public PortraitData()
            {
            }

            public PortraitData(string filename, Rectangle position)
            {
                Filename = filename;
                Position = position;
            }

            public PortraitData(string filename, int x, int y, int width, int height) : this(filename, new Rectangle(x, y, width, height)) { }
        }

        private string m_lowercaseName;

        public Matchup.Races Race {get;set;}
        public Leagues League { get; set; }
        public string Name { get; set; }
        public int Place { get; set; }
        public int Points { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }

        public PortraitData Portrait { get; set; }

        public enum Leagues
        {
            None,
            Bronze,
            Silver,
            Gold,
            Platinum,
            Diamond,
            Master,
            Grandmaster
        }

        static Leagues LeagueFromString(string league)
        {
            Leagues ret = Leagues.None;
            league = league.ToLower();

            if (league == null)
                ret = Leagues.None;
            else
            {
                if ((league == "bronze") || (league == "bronzie") || (league == "bronzer") || league.StartsWith("b")) {
                    ret = Leagues.Bronze;
                }
                else if ((league == "silver") || league.StartsWith("s"))
                {
                    ret = Leagues.Silver;
                }
                else if ((league == "gold") || league.StartsWith("go"))
                {
                    ret = Leagues.Gold;
                }
                else if ((league == "platinum") || (league == "plat") ||  league.StartsWith("p"))
                {
                    ret = Leagues.Platinum;
                }
                else if ((league == "diamond") || league.StartsWith("d"))
                {
                    ret = Leagues.Diamond;
                }
                else if ((league == "master") || (league == "masters") || league.StartsWith("m"))
                {
                    ret = Leagues.Master;
                }
                else if ((league == "grandmaster") || (league == "grand master") || (league == "gm") || (league == "grandmasters") || league.StartsWith("gr"))
                {
                    ret = Leagues.Grandmaster;
                }
            }

            return ret;
        }



        public Player()
        {

        }

        public Player(string name, string race, string league, int place, int points, int wins, int losses, PortraitData portrait)
        {
            Name = name;
            Place = place;
            Race = Matchup.RaceFromString(race);
            League = LeagueFromString(league);
            Points = points;
            Portrait = portrait;
            Wins = wins;
            Losses = losses;
        }

        #region IXmlSerializable Members

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }



        public void ReadXml(System.Xml.XmlReader reader)
        {
            XmlSerializer stringSerializer = new XmlSerializer(typeof(string));
            XmlSerializer intSerializer = new XmlSerializer(typeof(int));


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
                    case "league":
                        League = (Leagues)intSerializer.Deserialize(reader);
                        break;
                    case "race":
                        Race = (Matchup.Races)intSerializer.Deserialize(reader);
                        break;
                    case "points":
                        Points = (int)intSerializer.Deserialize(reader);
                        break;
                    case "place":
                        Place = (int)intSerializer.Deserialize(reader);
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

            XmlSerializer stringSerializer = new XmlSerializer(typeof(string));
            XmlSerializer intSerializer = new XmlSerializer(typeof(int));

            writer.WriteStartElement("Name");
            stringSerializer.Serialize(writer, Name);
            writer.WriteEndElement();

            writer.WriteStartElement("Place");
            intSerializer.Serialize(writer, Place);
            writer.WriteEndElement();

            writer.WriteStartElement("Points");
            intSerializer.Serialize(writer, Points);
            writer.WriteEndElement();

            writer.WriteStartElement("Race");
            stringSerializer.Serialize(writer, (int)Race);
            writer.WriteEndElement();

            writer.WriteStartElement("League");
            stringSerializer.Serialize(writer, (int)League);
            writer.WriteEndElement();
        }

        #endregion
    }
}
