using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace SC2Scrapbook.Models
{
    public class Matchup : IXmlSerializable
    {
        public enum Races
        {
            Terran,
            Zerg,
            Protoss,
            Random
        }

        public Races PlayerRace { get; set; }
        public Races OpponentRace { get; set; }

        static Races RaceFromChar(char race)
        {
            Races ret = Races.Random;

            if (race == null)
                ret = Races.Random;
            else
            {
                switch (race)
                {
                    case 'p':
                    case 'P':
                        ret = Races.Protoss;
                        break;
                    case 't':
                    case 'T':
                        ret = Races.Terran;
                        break;
                    case 'z':
                    case 'Z':
                        ret = Races.Zerg;
                        break;
                    default:
                        ret = Races.Random;
                        break;
                }
            }

            return ret;
        }

        public static char CharFromRace(Races race)
        {
            switch (race)
            {
                case Races.Random:
                    return 'X';
                case Races.Terran:
                    return 'T';
                case Races.Protoss:
                    return 'P';
                case Races.Zerg:
                    return 'Z';
                default:
                    return 'X';
            }
        }

        public static System.Drawing.Image ImageFromRace(Races race)
        {
            switch (race)
            {
                case Races.Random:
                    return Properties.Resources.random;
                case Races.Terran:
                    return Properties.Resources.terran;
                case Races.Protoss:
                    return Properties.Resources.protoss;
                case Races.Zerg:
                    return Properties.Resources.zerg;
                default:
                    return Properties.Resources.random;
            }
        }

        public static System.Drawing.Image LargeImageFromRace(Races race)
        {
            switch (race)
            {
                case Races.Random:
                    return Properties.Resources.RandomIcon;
                case Races.Terran:
                    return Properties.Resources.TerranIcon;
                case Races.Protoss:
                    return Properties.Resources.ProtossIcon;
                case Races.Zerg:
                    return Properties.Resources.zergicon;
                default:
                    return Properties.Resources.RandomIcon;
            }
        }

        public static System.Drawing.Image SnapshotImageFromRace(Races race)
        {
            switch (race)
            {
                case Races.Random:
                    return Properties.Resources.snapshot_random;
                case Races.Terran:
                    return Properties.Resources.snapshot_terran;
                case Races.Protoss:
                    return Properties.Resources.snapshot_protoss;
                case Races.Zerg:
                    return Properties.Resources.snapshot_zerg;
                default:
                    return Properties.Resources.snapshot_random;
            }
        }

        public static Races RaceFromString(string race)
        {
            Races ret = Races.Random;

            if (string.IsNullOrEmpty(race))
                ret = Races.Random;
            else
            {
                return RaceFromChar(race[0]);
            }

            return ret;
        }

        private void FromString(string matchup)
        {
            if ((matchup.Length == 3) && (matchup[1] == 'v')) // XvX
            {
                PlayerRace = RaceFromChar(matchup[0]);
                OpponentRace = RaceFromChar(matchup[2]);
            }
        }

        public override string ToString()
        {
            return string.Format("{0}v{1}", CharFromRace(PlayerRace), CharFromRace(OpponentRace));
        }

        public Matchup() {
            FromString("XvX");
        }

        public Matchup(string matchup)
        {
            FromString(matchup);
        }

        public Matchup(Races player, Races opponent)
        {
            PlayerRace = player;
            OpponentRace = opponent;
        }

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            FromString(reader.ReadInnerXml());
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(ToString());
        }
    }
}
