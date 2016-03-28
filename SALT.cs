using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;

namespace SC2Scrapbook
{
    public class SALT
    {
        public class BuildStep
        {
            public enum StepType
            {
                Structure = 0,
                Unit = 1,
                Morph = 2,
                Upgrade = 3
            }

            public int Supply { get; private set; }
            public int Minute { get; private set; }
            public int Second { get; private set; }
            public StepType Type { get; private set; }
            public int Code { get; private set; }
            public string Name { get; private set; }

            public BuildStep(int supply, int minute, int second, StepType type, int code)
            {
                Supply = supply;
                Minute = minute;
                Second = second;
                Type = type;
                Code = code;

                switch(type)
                {
                    case StepType.Unit:
                        Name = SALT.GetUnit(code);
                        break;
                    case StepType.Structure:
                        Name = SALT.GetStructure(code);
                        break;
                    case StepType.Morph:
                        Name = SALT.GetMorph(code);
                        break;
                    case StepType.Upgrade:
                        Name = SALT.GetUpgrade(code);
                        break;
                    default:
                        Name = "Unknown";
                        break;
                }
            }
        }

        const string CHARACTERS = " !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";

        private static Dictionary<char, int> m_mapping;

        private int m_version;
        private string m_build;
        private List<BuildStep> m_steps;
        private int m_minimumSupply;


        public string Description { get; private set; }
        public string Author { get; private set; }
        public string Title { get; private set; }
        public ReadOnlyCollection<BuildStep> Steps { get
            {
                return m_steps.AsReadOnly();
            }
        }


        static SALT()
        {
            m_mapping = new Dictionary<char, int>();
            char[] chars = CHARACTERS.ToCharArray();
            
            // Initialize the character mapping
            for (var i = 0; i < chars.Length; i++)
            {
                m_mapping[chars[i]] = i;
            }
        }
        public static string GetStructure(int id)
        {
            switch (id)
            {
                case 00: return "Armory";
                case 01: return "Barracks";
                case 02: return "Bunker";
                case 03: return "Command Center";
                case 04: return "Engineering Bay";
                case 05: return "Factory";
                case 06: return "Fusion Core";
                case 07: return "Ghost Academy";
                case 08: return "Missile Turret";
                case 09: return "Reactor (Barracks)";
                case 10: return "Reactor (Factory)";
                case 11: return "Reactor (Starport)";
                case 12: return "Refinery";
                case 13: return "Sensor Tower";
                case 14: return "Starport";
                case 15: return "Supply Depot";
                case 16: return "Tech Lab (Barracks)";
                case 17: return "Tech Lab (Factory)";
                case 18: return "Tech Lab (Starport)";

                case 19: return "Assimilator";
                case 20: return "Cybernetics Core";
                case 21: return "Dark Shrine";
                case 22: return "Fleet Beacon";
                case 23: return "Forge";
                case 24: return "Gateway";
                case 25: return "Nexus";
                case 26: return "Photon Canon";
                case 27: return "Pylon";
                case 28: return "Robotics Bay";
                case 29: return "Robotics Facility";
                case 30: return "Stargate";
                case 31: return "Templar Archives";
                case 32: return "Twilight Council";

                case 33: return "Baneling Nest";
                case 46: return "Creep Tumor";
                case 34: return "Evolution Chamber";
                case 35: return "Extractor";
                case 36: return "Hatchery";
                case 37: return "Hydralisk Den";
                case 38: return "Infestation Pit";
                case 39: return "Nydus Network";
                case 40: return "Roach Warren";
                case 41: return "Spawning Pool";
                case 42: return "Spine Crawler";
                case 43: return "Spire";
                case 44: return "Spore Crawler";
                case 45: return "Ultralisk Cavern";
            }

            return "Unknown";
        }

        public static string GetUnit(int id)
        {
            switch(id)
            {
                case 00: return "Banshee";
                case 40: return "Battle Hellion";
                case 01: return "Battlecruiser";
                case 48: return "Cyclone";
                case 02: return "Ghost";
                case 03: return "Hellion";
                case 49: return "Liberator";
                case 04: return "Marauder";
                case 05: return "Marine";
                case 06: return "Medivac";
                case 07: return "Raven";
                case 08: return "Reaper";
                case 09: return "SCV";
                case 10: return "Siege Tank";
                case 11: return "Thor";
                case 41: return "Warhound";
                case 42: return "Widow Mine";
                case 12: return "Viking";

                case 51: return "Adepts";
                case 14: return "Carrier";
                case 15: return "Colossus";
                case 16: return "Dark Templar";
                case 50: return "Disruptor";
                case 17: return "High Templar";
                case 18: return "Immortal";
                case 19: return "Mothership";
                case 43: return "Mothership Core";
                case 20: return "Observer";
                case 44: return "Oracle";
                case 21: return "Phoenix";
                case 22: return "Probe";
                case 23: return "Sentry";
                case 24: return "Stalker";
                case 45: return "Tempest";
                case 25: return "Void Ray";
                case 39: return "Warp Prism";
                case 26: return "Zealot";

                case 27: return "Corruptor";
                case 28: return "Drone";
                case 29: return "Hydralisk";
                case 38: return "Infestor";
                case 30: return "Mutalisk";
                case 31: return "Overlord";
                case 32: return "Queen";
                case 33: return "Roach";
                case 46: return "Swarm Host";
                case 34: return "Ultralisk";
                case 47: return "Viper";
                case 35: return "Zergling";
            }

            return "Unknown";
        }

        public static string GetMorph(int id)
        {
            switch (id)
            {
                case 00: return "Orbital Command";
                case 01: return "Planetary Fortress";

                case 02: return "Warp Gate";
                case 13: return "Archon";

                case 03: return "Lair";
                case 04: return "Hive";
                case 05: return "Greater Spire";
                case 06: return "Brood Lord";
                case 07: return "Baneling";
                case 08: return "Overseer";

                case 09: return "Ravager";
                case 10: return "Lurker";
                case 12: return "Lurker Den";
            }

            return "Unknown";
        }

        public static string GetUpgrade(int id)
        {
            switch (id)
            {
                case 00: return "Terran Building Armor";
                case 01: return "Terran Infantry Armor";
                case 02: return "Terran Infantry Weapons";
                case 03: return "Terran Ship Plating";
                case 04: return "Terran Ship Weapons";
                case 05: return "Terran Vehicle Plating";
                case 06: return "Terran Vehicle Weapons";

                case 07: return "250mm Strike Cannons";
                case 08: return "Banshee - Cloaking";
                case 09: return "Ghost - Cloaking";
                case 10: return "Hellion - Pre-igniter";
                case 11: return "Marine - Stimpack";
                case 12: return "Raven - Seeker Missiles";
                case 13: return "Siege Tank - Siege Tech";
                case 46: return "Ghost - Moebius Reactor";
                case 14: return "Bunker - Neosteel Frame";
                case 15: return "Marauder - Concussive Shells";
                case 16: return "Marine - Combat Shields";
                case 17: return "Reaper Speed";
                case 51: return "Battlecruiser - Behemoth Reactor";
                case 52: return "Battlecruiser - Weapon Refit";
                case 53: return "Hi-Sec Auto Tracking";
                case 54: return "Medivac - Caduceus Reactor";
                case 55: return "Raven - Corvid Reactor";
                case 56: return "Raven - Durable Materials";
                case 57: return "Hellion - Transformation servos";
                case 66: return "Drilling claws";



                case 18: return "Protoss Ground Armor";
                case 19: return "Protoss Ground Weapons";
                case 20: return "Protoss Air Armor";
                case 21: return "Protoss Air Weapons";
                case 22: return "Protoss Shields";

                case 23: return "Sentry - Hallucination";
                case 24: return "High Templar - Psi Storm";
                case 25: return "Stalker - Blink";
                case 26: return "Warp Gate Tech";
                case 27: return "Zealot - Charge";
                case 47: return "Extended Thermal Lance";
                case 58: return "Carrier - Graviton Catapult";
                case 59: return "Observer - Gravatic Boosters";
                case 60: return "Warp Prrism - Gravatic Drive";
                case 61: return "Oracle - Bosonic Core";
                case 62: return "Tempest - Gravity Sling";
                case 67: return "Anion Pulse-Crystals";




                case 28: return "Zerg Ground Carapace";
                case 29: return "Zerg Melee Weapons";
                case 30: return "Zerg Flyer Carapace";
                case 31: return "Zerg Flyer Weapons";
                case 32: return "Zerg Missile Weapons";

                case 33: return "Hydralisk - Grooved Spines";
                case 34: return "Overlord - Pneumatized Carapace";
                case 35: return "Overlord - Ventral Sacs";
                case 36: return "Roach - Glial Reconstitution";
                case 38: return "Roach - Tunneling Claws";
                case 40: return "Ultralisk - Chitinous Plating";
                case 41: return "Zergling - Adrenal Glands";
                case 42: return "Zergling - Metabolic Boost";
                case 44: return "Burrow";
                case 45: return "Centrifugal Hooks";
                case 49: return "Neural Parasite";
                case 50: return "Pathogen Gland";
                case 64: return "Swarm Host - Evolve Enduring Locusts";
                case 65: return "Hydralisk - Muscular Augments";

                case 68: return "Flying Locusts";
                case 69: return "Seismic Spines";
                case 71: return "Targeting Optics";
                case 72: return "Advanced Ballistics";
                case 73: return "Resonating Glaives";
            }

            return "Unknown";
        }


        public SALT(string build)
        {
            m_build = build;
            StringReader reader = new StringReader(build);
            StringBuilder meta = new StringBuilder();
            m_version = m_mapping[(char)reader.Read()];
            m_steps = new List<BuildStep>();

            m_minimumSupply = 5;

            // Builds look like this:
            // [version]title|Author|description|~[supply][minutes][seconds][type][item id]...

            char c = (char)reader.Read();
            while (c != '~' && c != 65535 && c != -1)
            {
                meta.Append(c);
                c = (char)reader.Read();
            }

            var metaItems = meta.ToString().Split(new char[] { '|' });
            if (metaItems.Length != 4)
            {
                throw new ArgumentException("Expected 3 metadata items");
            }

            Title = metaItems[0];
            Author = metaItems[1];
            Description = metaItems[2];

            int read;
            char[] buffer = new char[5];

            read = reader.ReadBlock(buffer, 0, 5);

            while (read == 5)
            {
                // Supply of 0 is a blank
                int supply = m_mapping[buffer[0]];
                if (supply > 0)
                {
                    supply = supply + m_minimumSupply - 1;
                }

                var step = new BuildStep(supply, m_mapping[buffer[1]], m_mapping[buffer[2]], (BuildStep.StepType)m_mapping[buffer[3]], m_mapping[buffer[4]]);
                m_steps.Add(step);
                read = reader.ReadBlock(buffer, 0, 5);
            }
        }
    }
}
