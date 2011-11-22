using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SC2Scrapbook
{
    public partial class frmBuildOverlay : Form
    {
        private static Dictionary<string, System.Drawing.Image> m_iconmap;
        private static Dictionary<string, System.Drawing.Image> m_buttonmap;

        private bool m_locked;
        private Models.Build m_build;

        public static readonly string[] RaceVariantIcons = { "gas", "minerals", "supply", "time" };
        public static Dictionary<string, System.Drawing.Image> IconMap
        {
            get
            {
                if (m_iconmap == null)
                    m_iconmap = new Dictionary<string, Image> { 
                        { "random", Properties.Resources.random },
                        { "protoss", Properties.Resources.ProtossIcon },
                        { "protoss_minerals", Properties.Resources.protoss_minerals },
                        { "protoss_gas", Properties.Resources.protoss_gas },
                        { "protoss_supply", Properties.Resources.protoss_supply },
                        { "protoss_time", Properties.Resources.protoss_time }, 
                        { "terran", Properties.Resources.TerranIcon },
                        { "terran_minerals", Properties.Resources.terran_minerals },
                        { "terran_gas", Properties.Resources.terran_gas },
                        { "terran_supply", Properties.Resources.terran_supply },
                        { "terran_time", Properties.Resources.terran_time }, 
                        { "zerg", Properties.Resources.zergicon },
                        { "zerg_minerals", Properties.Resources.zerg_minerals },
                        { "zerg_gas", Properties.Resources.zerg_gas },
                        { "zerg_supply", Properties.Resources.zerg_supply },
                        { "zerg_time", Properties.Resources.zerg_time }, 
                    };

                return m_iconmap;
            }
        }

        public static Dictionary<string, System.Drawing.Image> ButtonMap
        {
            get
            {
                if (m_buttonmap == null)
                    m_buttonmap = new Dictionary<string, Image> {
                        { "protoss_building_assimilator", Properties.Resources.btn_building_protoss_assimilator },
                        { "protoss_building_cyberneticscore", Properties.Resources.btn_building_protoss_cyberneticscore },
                        { "protoss_building_darkshrine", Properties.Resources.btn_building_protoss_darkshrine },
                        { "protoss_building_energycrystal", Properties.Resources.btn_building_protoss_energycrystal },
                        { "protoss_building_eyeofadun", Properties.Resources.btn_building_protoss_eyeofadun },
                        { "protoss_building_fleetbeacon", Properties.Resources.btn_building_protoss_fleetbeacon },
                        { "protoss_building_forge", Properties.Resources.btn_building_protoss_forge },
                        { "protoss_building_gateway", Properties.Resources.btn_building_protoss_gateway },
                        { "protoss_building_nexus", Properties.Resources.btn_building_protoss_nexus },
                        { "protoss_building_obelisk", Properties.Resources.btn_building_protoss_obelisk },
                        { "protoss_building_phasecannon", Properties.Resources.btn_building_protoss_phasecannon },
                        { "protoss_building_photoncannon", Properties.Resources.btn_building_protoss_photoncannon },
                        { "protoss_building_pylon", Properties.Resources.btn_building_protoss_pylon },
                        { "protoss_building_roboticsfacility", Properties.Resources.btn_building_protoss_roboticsfacility },
                        { "protoss_building_roboticssupportbay", Properties.Resources.btn_building_protoss_roboticssupportbay },
                        { "protoss_building_stargate", Properties.Resources.btn_building_protoss_stargate },
                        { "protoss_building_templararchives", Properties.Resources.btn_building_protoss_templararchives },
                        { "protoss_building_twilightcouncil", Properties.Resources.btn_building_protoss_twilightcouncil },
                        { "protoss_building_warpgate", Properties.Resources.btn_building_protoss_warpgate },
                        { "assimilator", Properties.Resources.btn_building_protoss_assimilator },
                        { "cyberneticscore", Properties.Resources.btn_building_protoss_cyberneticscore },
                        { "core", Properties.Resources.btn_building_protoss_cyberneticscore },
                        { "darkshrine", Properties.Resources.btn_building_protoss_darkshrine },
                        { "energycrystal", Properties.Resources.btn_building_protoss_energycrystal },
                        { "eyeofadun", Properties.Resources.btn_building_protoss_eyeofadun },
                        { "fleetbeacon", Properties.Resources.btn_building_protoss_fleetbeacon },
                        { "forge", Properties.Resources.btn_building_protoss_forge },
                        { "gateway", Properties.Resources.btn_building_protoss_gateway },
                        { "gate", Properties.Resources.btn_building_protoss_gateway },
                        { "nexus", Properties.Resources.btn_building_protoss_nexus },
                        { "obelisk", Properties.Resources.btn_building_protoss_obelisk },
                        { "cannon", Properties.Resources.btn_building_protoss_phasecannon },
                        { "phasecannon", Properties.Resources.btn_building_protoss_phasecannon },
                        { "photoncannon", Properties.Resources.btn_building_protoss_photoncannon },
                        { "pylon", Properties.Resources.btn_building_protoss_pylon },
                        { "roboticsfacility", Properties.Resources.btn_building_protoss_roboticsfacility },
                        { "robo", Properties.Resources.btn_building_protoss_roboticsfacility },
                        { "roboticssupportbay", Properties.Resources.btn_building_protoss_roboticssupportbay },
                        { "robobay", Properties.Resources.btn_building_protoss_roboticssupportbay },
                        { "stargate", Properties.Resources.btn_building_protoss_stargate },
                        { "templararchives", Properties.Resources.btn_building_protoss_templararchives },
                        { "twilightcouncil", Properties.Resources.btn_building_protoss_twilightcouncil },
                        { "council", Properties.Resources.btn_building_protoss_twilightcouncil },
                        { "warpgate", Properties.Resources.btn_building_protoss_warpgate },

                        { "terran_building_armory", Properties.Resources.btn_building_terran_armory },
                        { "terran_building_autoturret", Properties.Resources.btn_building_terran_autoturret },
                        { "terran_building_barracks", Properties.Resources.btn_building_terran_barracks },
                        { "terran_building_bunker", Properties.Resources.btn_building_terran_bunker },
                        { "terran_building_commandcenter", Properties.Resources.btn_building_terran_commandcenter },
                        { "terran_building_deepspacerelay", Properties.Resources.btn_building_terran_deepspacerelay },
                        { "terran_building_engineeringbay", Properties.Resources.btn_building_terran_engineeringbay },
                        { "terran_building_factory", Properties.Resources.btn_building_terran_factory },
                        { "terran_building_fusioncore", Properties.Resources.btn_building_terran_fusioncore },
                        { "terran_building_ghostacademy", Properties.Resources.btn_building_terran_ghostacademy },
                        { "terran_building_merccompound", Properties.Resources.btn_building_terran_merccompound },
                        { "terran_building_mercenaryport", Properties.Resources.btn_building_terran_mercenaryport },
                        { "terran_building_missileturret", Properties.Resources.btn_building_terran_missileturret },
                        { "terran_building_planetaryfortress", Properties.Resources.btn_building_terran_planetaryfortress },
                        { "terran_building_reactor", Properties.Resources.btn_building_terran_reactor },
                        { "terran_building_refinery", Properties.Resources.btn_building_terran_refinery },
                        { "terran_building_sensordome", Properties.Resources.btn_building_terran_sensordome },
                        { "terran_building_starport", Properties.Resources.btn_building_terran_starport },
                        { "terran_building_supplydepot", Properties.Resources.btn_building_terran_supplydepot },
                        { "terran_building_supplydepotlowered", Properties.Resources.btn_building_terran_supplydepotlowered },
                        { "terran_building_surveillancestation", Properties.Resources.btn_building_terran_surveillancestation },
                        { "terran_building_techlab", Properties.Resources.btn_building_terran_techlab },

                        { "armory", Properties.Resources.btn_building_terran_armory },
                        { "autoturret", Properties.Resources.btn_building_terran_autoturret },
                        { "barracks", Properties.Resources.btn_building_terran_barracks },
                        { "rax", Properties.Resources.btn_building_terran_barracks },
                        { "bunker", Properties.Resources.btn_building_terran_bunker },
                        { "commandcenter", Properties.Resources.btn_building_terran_commandcenter },
                        { "cc", Properties.Resources.btn_building_terran_commandcenter },
                        { "deepspacerelay", Properties.Resources.btn_building_terran_deepspacerelay },
                        { "engineeringbay", Properties.Resources.btn_building_terran_engineeringbay },
                        { "engibay", Properties.Resources.btn_building_terran_engineeringbay },
                        { "factory", Properties.Resources.btn_building_terran_factory },
                        { "fusioncore", Properties.Resources.btn_building_terran_fusioncore },
                        { "ghostacademy", Properties.Resources.btn_building_terran_ghostacademy },
                        { "academy", Properties.Resources.btn_building_terran_ghostacademy },
                        { "merccompound", Properties.Resources.btn_building_terran_merccompound },
                        { "mercenaryport", Properties.Resources.btn_building_terran_mercenaryport },
                        { "mercport", Properties.Resources.btn_building_terran_mercenaryport },
                        { "missileturret", Properties.Resources.btn_building_terran_missileturret },
                        { "turret", Properties.Resources.btn_building_terran_missileturret },
                        { "planetaryfortress", Properties.Resources.btn_building_terran_planetaryfortress },
                        { "pfort", Properties.Resources.btn_building_terran_planetaryfortress },
                        { "reactor", Properties.Resources.btn_building_terran_reactor },
                        { "refinery", Properties.Resources.btn_building_terran_refinery },
                        { "sensordome", Properties.Resources.btn_building_terran_sensordome },
                        { "sensortower", Properties.Resources.btn_building_terran_sensordome },
                        { "starport", Properties.Resources.btn_building_terran_starport },
                        { "supplydepot", Properties.Resources.btn_building_terran_supplydepot },
                        { "depot", Properties.Resources.btn_building_terran_supplydepot },
                        { "supplydepotlowered", Properties.Resources.btn_building_terran_supplydepotlowered },
                        { "lowdepot", Properties.Resources.btn_building_terran_supplydepotlowered },
                        { "surveillancestation", Properties.Resources.btn_building_terran_surveillancestation },
                        { "techlab", Properties.Resources.btn_building_terran_techlab },

                        { "zerg_building_banelingnest", Properties.Resources.btn_building_zerg_banelingnest },
                        { "zerg_building_creeptumor", Properties.Resources.btn_building_zerg_creeptumor },
                        { "zerg_building_evolutionchamber", Properties.Resources.btn_building_zerg_evolutionchamber },
                        { "zerg_building_extractor", Properties.Resources.btn_building_zerg_extractor },
                        { "zerg_building_greaterspire", Properties.Resources.btn_building_zerg_greaterspire },
                        { "zerg_building_hatchery", Properties.Resources.btn_building_zerg_hatchery },
                        { "zerg_building_hive", Properties.Resources.btn_building_zerg_hive },
                        { "zerg_building_hydraliskden", Properties.Resources.btn_building_zerg_hydraliskden },
                        { "zerg_building_infestationpit", Properties.Resources.btn_building_zerg_infestationpit },
                        { "zerg_building_infestorpit", Properties.Resources.btn_building_zerg_infestorpit },
                        { "zerg_building_lair", Properties.Resources.btn_building_zerg_lair },
                        { "zerg_building_lurkerden", Properties.Resources.btn_building_zerg_lurkerden },
                        { "zerg_building_nydusnetwork", Properties.Resources.btn_building_zerg_nydusnetwork },
                        { "zerg_building_nydusworm", Properties.Resources.btn_building_zerg_nydusworm },
                        { "zerg_building_roachwarren", Properties.Resources.btn_building_zerg_roachwarren },
                        { "zerg_building_spawningpool", Properties.Resources.btn_building_zerg_spawningpool },
                        { "zerg_building_spinecrawler", Properties.Resources.btn_building_zerg_spinecrawler },
                        { "zerg_building_spire", Properties.Resources.btn_building_zerg_spire },
                        { "zerg_building_sporecrawler", Properties.Resources.btn_building_zerg_sporecrawler },
                        { "zerg_building_ultraliskcavern", Properties.Resources.btn_building_zerg_ultraliskcavern },
                        { "banelingnest", Properties.Resources.btn_building_zerg_banelingnest },
                        { "creeptumor", Properties.Resources.btn_building_zerg_creeptumor },
                        { "tumor", Properties.Resources.btn_building_zerg_creeptumor },
                        { "evolutionchamber", Properties.Resources.btn_building_zerg_evolutionchamber },
                        { "echamber", Properties.Resources.btn_building_zerg_evolutionchamber },
                        { "evochamber", Properties.Resources.btn_building_zerg_evolutionchamber },
                        { "extractor", Properties.Resources.btn_building_zerg_extractor },
                        { "greaterspire", Properties.Resources.btn_building_zerg_greaterspire },
                        { "hatchery", Properties.Resources.btn_building_zerg_hatchery },
                        { "hatch", Properties.Resources.btn_building_zerg_hatchery },
                        { "hive", Properties.Resources.btn_building_zerg_hive },
                        { "hydraliskden", Properties.Resources.btn_building_zerg_hydraliskden },
                        { "hydraden", Properties.Resources.btn_building_zerg_hydraliskden },
                        { "infestationpit", Properties.Resources.btn_building_zerg_infestationpit },
                        { "infestorpit", Properties.Resources.btn_building_zerg_infestorpit },
                        { "lair", Properties.Resources.btn_building_zerg_lair },
                        { "lurkerden", Properties.Resources.btn_building_zerg_lurkerden },
                        { "nydusnetwork", Properties.Resources.btn_building_zerg_nydusnetwork },
                        { "nydusworm", Properties.Resources.btn_building_zerg_nydusworm },
                        { "roachwarren", Properties.Resources.btn_building_zerg_roachwarren },
                        { "warren", Properties.Resources.btn_building_zerg_roachwarren },
                        { "spawningpool", Properties.Resources.btn_building_zerg_spawningpool },
                        { "pool", Properties.Resources.btn_building_zerg_spawningpool },
                        { "spinecrawler", Properties.Resources.btn_building_zerg_spinecrawler },
                        { "spine", Properties.Resources.btn_building_zerg_spinecrawler },
                        { "spire", Properties.Resources.btn_building_zerg_spire },
                        { "sporecrawler", Properties.Resources.btn_building_zerg_sporecrawler },
                        { "spore", Properties.Resources.btn_building_zerg_sporecrawler },
                        { "ultraliskcavern", Properties.Resources.btn_building_zerg_ultraliskcavern },
                        { "ultracavern", Properties.Resources.btn_building_zerg_ultraliskcavern },

                        { "protoss_unit_archon", Properties.Resources.btn_unit_protoss_archon },
                        { "protoss_unit_carrier", Properties.Resources.btn_unit_protoss_carrier },
                        { "protoss_unit_colossus", Properties.Resources.btn_unit_protoss_colossus },
                        { "protoss_unit_darktemplar", Properties.Resources.btn_unit_protoss_darktemplar },
                        { "protoss_unit_hightemplar", Properties.Resources.btn_unit_protoss_hightemplar },
                        { "protoss_unit_immortal", Properties.Resources.btn_unit_protoss_immortal },
                        { "protoss_unit_interceptor", Properties.Resources.btn_unit_protoss_interceptor },
                        { "protoss_unit_mothership", Properties.Resources.btn_unit_protoss_mothership },
                        { "protoss_unit_nullifier", Properties.Resources.btn_unit_protoss_nullifier },
                        { "protoss_unit_observer", Properties.Resources.btn_unit_protoss_observer },
                        { "protoss_unit_phaseprism", Properties.Resources.btn_unit_protoss_phaseprism },
                        { "protoss_unit_phaseprismstationary", Properties.Resources.btn_unit_protoss_phaseprismstationary },
                        { "protoss_unit_phoenix", Properties.Resources.btn_unit_protoss_phoenix },
                        { "protoss_unit_probe", Properties.Resources.btn_unit_protoss_probe },
                        { "protoss_unit_sentry", Properties.Resources.btn_unit_protoss_sentry },
                        { "protoss_unit_stalker", Properties.Resources.btn_unit_protoss_stalker },
                        { "protoss_unit_warpprism", Properties.Resources.btn_unit_protoss_warpprism },
                        { "protoss_unit_warpprismstationary", Properties.Resources.btn_unit_protoss_warpprismstationary },
                        { "protoss_unit_warpray", Properties.Resources.btn_unit_protoss_warpray },
                        { "protoss_unit_zealot", Properties.Resources.btn_unit_protoss_zealot },

                        { "archon", Properties.Resources.btn_unit_protoss_archon },
                        { "carrier", Properties.Resources.btn_unit_protoss_carrier },
                        { "colossus", Properties.Resources.btn_unit_protoss_colossus },
                        { "darktemplar", Properties.Resources.btn_unit_protoss_darktemplar },
                        { "dt", Properties.Resources.btn_unit_protoss_darktemplar },
                        { "hightemplar", Properties.Resources.btn_unit_protoss_hightemplar },
                        { "templar", Properties.Resources.btn_unit_protoss_hightemplar },
                        { "immortal", Properties.Resources.btn_unit_protoss_immortal },
                        { "interceptor", Properties.Resources.btn_unit_protoss_interceptor },
                        { "mothership", Properties.Resources.btn_unit_protoss_mothership },
                        { "nullifier", Properties.Resources.btn_unit_protoss_nullifier },
                        { "observer", Properties.Resources.btn_unit_protoss_observer },
                        { "obs", Properties.Resources.btn_unit_protoss_observer },
                        { "phaseprism", Properties.Resources.btn_unit_protoss_phaseprism },
                        { "phaseprismstationary", Properties.Resources.btn_unit_protoss_phaseprismstationary },
                        { "phoenix", Properties.Resources.btn_unit_protoss_phoenix },
                        { "probe", Properties.Resources.btn_unit_protoss_probe },
                        { "sentry", Properties.Resources.btn_unit_protoss_sentry },
                        { "stalker", Properties.Resources.btn_unit_protoss_stalker },
                        { "warpprism", Properties.Resources.btn_unit_protoss_warpprism },
                        { "warpprismstationary", Properties.Resources.btn_unit_protoss_warpprismstationary },
                        { "warpprismdeployed", Properties.Resources.btn_unit_protoss_warpprism },
                        { "warpray", Properties.Resources.btn_unit_protoss_warpray },
                        { "zealot", Properties.Resources.btn_unit_protoss_zealot },

                        { "terran_unit_banshee", Properties.Resources.btn_unit_terran_banshee },
                        { "terran_unit_battlecruiser", Properties.Resources.btn_unit_terran_battlecruiser },
                        { "terran_unit_cobra", Properties.Resources.btn_unit_terran_cobra },
                        { "terran_unit_diamondback", Properties.Resources.btn_unit_terran_diamondback },
                        { "terran_unit_dropship", Properties.Resources.btn_unit_terran_dropship },
                        { "terran_unit_firebat", Properties.Resources.btn_unit_terran_firebat },
                        { "terran_unit_ghost", Properties.Resources.btn_unit_terran_ghost },
                        { "terran_unit_hellion", Properties.Resources.btn_unit_terran_hellion },
                        { "terran_unit_hurcules", Properties.Resources.btn_unit_terran_hurcules },
                        { "terran_unit_jackal", Properties.Resources.btn_unit_terran_jackal },
                        { "terran_unit_marauder", Properties.Resources.btn_unit_terran_marauder },
                        { "terran_unit_marine", Properties.Resources.btn_unit_terran_marine },
                        { "terran_unit_medivac", Properties.Resources.btn_unit_terran_medivac },
                        { "terran_unit_mule", Properties.Resources.btn_unit_terran_mule },
                        { "terran_unit_nomad", Properties.Resources.btn_unit_terran_nomad },
                        { "terran_unit_raven", Properties.Resources.btn_unit_terran_raven },
                        { "terran_unit_reaper", Properties.Resources.btn_unit_terran_reaper },
                        { "terran_unit_scv", Properties.Resources.btn_unit_terran_scv },
                        { "terran_unit_siegetank", Properties.Resources.btn_unit_terran_siegetank },
                        { "terran_unit_siegetanksiegemode", Properties.Resources.btn_unit_terran_siegetanksiegemode },
                        { "terran_unit_targetingdrone", Properties.Resources.btn_unit_terran_targetingdrone },
                        { "terran_unit_thor", Properties.Resources.btn_unit_terran_thor },
                        { "terran_unit_viking", Properties.Resources.btn_unit_terran_viking },
                        { "terran_unit_vikingassault", Properties.Resources.btn_unit_terran_vikingassault },
                        { "terran_unit_vikingfighter", Properties.Resources.btn_unit_terran_vikingfighter },
                        { "terran_unit_vulture", Properties.Resources.btn_unit_terran_vulture },
                        
                        { "banshee", Properties.Resources.btn_unit_terran_banshee },
                        { "battlecruiser", Properties.Resources.btn_unit_terran_battlecruiser },
                        { "bc", Properties.Resources.btn_unit_terran_battlecruiser },
                        { "cruiser", Properties.Resources.btn_unit_terran_battlecruiser },
                        { "cobra", Properties.Resources.btn_unit_terran_cobra },
                        { "diamondback", Properties.Resources.btn_unit_terran_diamondback },
                        { "dropship", Properties.Resources.btn_unit_terran_dropship },
                        { "firebat", Properties.Resources.btn_unit_terran_firebat },
                        { "ghost", Properties.Resources.btn_unit_terran_ghost },
                        { "hellion", Properties.Resources.btn_unit_terran_hellion },
                        { "hurcules", Properties.Resources.btn_unit_terran_hurcules },
                        { "jackal", Properties.Resources.btn_unit_terran_jackal },
                        { "marauder", Properties.Resources.btn_unit_terran_marauder },
                        { "marine", Properties.Resources.btn_unit_terran_marine },
                        { "medivac", Properties.Resources.btn_unit_terran_medivac },
                        { "mule", Properties.Resources.btn_unit_terran_mule },
                        { "nomad", Properties.Resources.btn_unit_terran_nomad },
                        { "raven", Properties.Resources.btn_unit_terran_raven },
                        { "reaper", Properties.Resources.btn_unit_terran_reaper },
                        { "scv", Properties.Resources.btn_unit_terran_scv },
                        { "siegetank", Properties.Resources.btn_unit_terran_siegetank },
                        { "siegedtank", Properties.Resources.btn_unit_terran_siegetanksiegemode },
                        { "targetingdrone", Properties.Resources.btn_unit_terran_targetingdrone },
                        { "pdd", Properties.Resources.btn_unit_terran_targetingdrone },
                        { "thor", Properties.Resources.btn_unit_terran_thor },
                        { "aviking", Properties.Resources.btn_unit_terran_vikingassault },
                        { "viking", Properties.Resources.btn_unit_terran_vikingfighter },
                        { "vulture", Properties.Resources.btn_unit_terran_vulture },

                        { "zerg_unit_baneling", Properties.Resources.btn_unit_zerg_baneling },
                        { "zerg_unit_broodlord", Properties.Resources.btn_unit_zerg_broodlord },
                        { "zerg_unit_changeling", Properties.Resources.btn_unit_zerg_changeling },
                        { "zerg_unit_corruptedmass", Properties.Resources.btn_unit_zerg_corruptedmass },
                        { "zerg_unit_corruptor", Properties.Resources.btn_unit_zerg_corruptor },
                        { "zerg_unit_drone", Properties.Resources.btn_unit_zerg_drone },
                        { "zerg_unit_egg", Properties.Resources.btn_unit_zerg_egg },
                        { "zerg_unit_hydralisk", Properties.Resources.btn_unit_zerg_hydralisk },
                        { "zerg_unit_infestedmarine", Properties.Resources.btn_unit_zerg_infestedmarine },
                        { "zerg_unit_infestor", Properties.Resources.btn_unit_zerg_infestor },
                        { "zerg_unit_larva", Properties.Resources.btn_unit_zerg_larva },
                        { "zerg_unit_lurker", Properties.Resources.btn_unit_zerg_lurker },
                        { "zerg_unit_mantalisk", Properties.Resources.btn_unit_zerg_mantalisk },
                        { "zerg_unit_mutalisk", Properties.Resources.btn_unit_zerg_mutalisk },
                        { "zerg_unit_omegalisk", Properties.Resources.btn_unit_zerg_omegalisk },
                        { "zerg_unit_overlord", Properties.Resources.btn_unit_zerg_overlord },
                        { "zerg_unit_overseer", Properties.Resources.btn_unit_zerg_overseer },
                        { "zerg_unit_queen", Properties.Resources.btn_unit_zerg_queen },
                        { "zerg_unit_roach", Properties.Resources.btn_unit_zerg_roach },
                        { "zerg_unit_symbiote", Properties.Resources.btn_unit_zerg_symbiote },
                        { "zerg_unit_ultralisk", Properties.Resources.btn_unit_zerg_ultralisk },
                        { "zerg_unit_zergling", Properties.Resources.btn_unit_zerg_zergling },
                        { "baneling", Properties.Resources.btn_unit_zerg_baneling },
                        { "bling", Properties.Resources.btn_unit_zerg_baneling },
                        { "broodlord", Properties.Resources.btn_unit_zerg_broodlord },
                        { "changeling", Properties.Resources.btn_unit_zerg_changeling },
                        { "corruptedmass", Properties.Resources.btn_unit_zerg_corruptedmass },
                        { "corruptor", Properties.Resources.btn_unit_zerg_corruptor },
                        { "drone", Properties.Resources.btn_unit_zerg_drone },
                        { "egg", Properties.Resources.btn_unit_zerg_egg },
                        { "hydralisk", Properties.Resources.btn_unit_zerg_hydralisk },
                        { "hydra", Properties.Resources.btn_unit_zerg_hydralisk },
                        { "infestedterran", Properties.Resources.btn_unit_zerg_infestedmarine },
                        { "infestor", Properties.Resources.btn_unit_zerg_infestor },
                        { "larva", Properties.Resources.btn_unit_zerg_larva },
                        { "lurker", Properties.Resources.btn_unit_zerg_lurker },
                        { "mantalisk", Properties.Resources.btn_unit_zerg_mantalisk },
                        { "mutalisk", Properties.Resources.btn_unit_zerg_mutalisk },
                        { "muta", Properties.Resources.btn_unit_zerg_mutalisk },
                        { "omegalisk", Properties.Resources.btn_unit_zerg_omegalisk },
                        { "overlord", Properties.Resources.btn_unit_zerg_overlord },
                        { "overseer", Properties.Resources.btn_unit_zerg_overseer },
                        { "queen", Properties.Resources.btn_unit_zerg_queen },
                        { "roach", Properties.Resources.btn_unit_zerg_roach },
                        { "broodling", Properties.Resources.btn_unit_zerg_symbiote },
                        { "ultralisk", Properties.Resources.btn_unit_zerg_ultralisk },
                        { "ultra", Properties.Resources.btn_unit_zerg_ultralisk },
                        { "zergling", Properties.Resources.btn_unit_zerg_zergling },
                        { "ling", Properties.Resources.btn_unit_zerg_zergling },

                        { "protoss_upgrade_airarmorlevel0", Properties.Resources.btn_upgrade_protoss_airarmorlevel0 },
                        { "protoss_upgrade_airarmorlevel1", Properties.Resources.btn_upgrade_protoss_airarmorlevel1 },
                        { "protoss_upgrade_airarmorlevel2", Properties.Resources.btn_upgrade_protoss_airarmorlevel2 },
                        { "protoss_upgrade_airarmorlevel3", Properties.Resources.btn_upgrade_protoss_airarmorlevel3 },
                        { "protoss_upgrade_airweaponslevel0", Properties.Resources.btn_upgrade_protoss_airweaponslevel0 },
                        { "protoss_upgrade_airweaponslevel1", Properties.Resources.btn_upgrade_protoss_airweaponslevel1 },
                        { "protoss_upgrade_airweaponslevel2", Properties.Resources.btn_upgrade_protoss_airweaponslevel2 },
                        { "protoss_upgrade_airweaponslevel3", Properties.Resources.btn_upgrade_protoss_airweaponslevel3 },
                        { "protoss_upgrade_extendedthermallance", Properties.Resources.btn_upgrade_protoss_extendedthermallance },
                        { "protoss_upgrade_fluxvanes", Properties.Resources.btn_upgrade_protoss_fluxvanes },
                        { "protoss_upgrade_graviticbooster", Properties.Resources.btn_upgrade_protoss_graviticbooster },
                        { "protoss_upgrade_graviticdrive", Properties.Resources.btn_upgrade_protoss_graviticdrive },
                        { "protoss_upgrade_gravitoncatapult", Properties.Resources.btn_upgrade_protoss_gravitoncatapult },
                        { "protoss_upgrade_groundarmorlevel0", Properties.Resources.btn_upgrade_protoss_groundarmorlevel0 },
                        { "protoss_upgrade_groundarmorlevel1", Properties.Resources.btn_upgrade_protoss_groundarmorlevel1 },
                        { "protoss_upgrade_groundarmorlevel2", Properties.Resources.btn_upgrade_protoss_groundarmorlevel2 },
                        { "protoss_upgrade_groundarmorlevel3", Properties.Resources.btn_upgrade_protoss_groundarmorlevel3 },
                        { "protoss_upgrade_groundweaponslevel0", Properties.Resources.btn_upgrade_protoss_groundweaponslevel0 },
                        { "protoss_upgrade_groundweaponslevel1", Properties.Resources.btn_upgrade_protoss_groundweaponslevel1 },
                        { "protoss_upgrade_groundweaponslevel2", Properties.Resources.btn_upgrade_protoss_groundweaponslevel2 },
                        { "protoss_upgrade_groundweaponslevel3", Properties.Resources.btn_upgrade_protoss_groundweaponslevel3 },
                        { "protoss_upgrade_khaydarinamulet", Properties.Resources.btn_upgrade_protoss_khaydarinamulet },
                        { "protoss_upgrade_shieldslevel0", Properties.Resources.btn_upgrade_protoss_shieldslevel0 },
                        { "protoss_upgrade_shieldslevel1", Properties.Resources.btn_upgrade_protoss_shieldslevel1 },
                        { "protoss_upgrade_shieldslevel2", Properties.Resources.btn_upgrade_protoss_shieldslevel2 },
                        { "protoss_upgrade_shieldslevel3", Properties.Resources.btn_upgrade_protoss_shieldslevel3 },
                        { "terran_upgrade_behemothreactor", Properties.Resources.btn_upgrade_terran_behemothreactor },
                        { "terran_upgrade_buildingarmor", Properties.Resources.btn_upgrade_terran_buildingarmor },
                        { "terran_upgrade_caduceusreactor", Properties.Resources.btn_upgrade_terran_caduceusreactor },
                        { "terran_upgrade_corvidreactor", Properties.Resources.btn_upgrade_terran_corvidreactor },
                        { "terran_upgrade_cloak", Properties.Resources.btn_upgrade_terran_cloak },
                        { "terran_upgrade_durablematerials", Properties.Resources.btn_upgrade_terran_durablematerials },
                        { "terran_upgrade_hisecautotracking", Properties.Resources.btn_upgrade_terran_hisecautotracking },
                        { "terran_upgrade_infantryarmorlevel0", Properties.Resources.btn_upgrade_terran_infantryarmorlevel0 },
                        { "terran_upgrade_infantryarmorlevel1", Properties.Resources.btn_upgrade_terran_infantryarmorlevel1 },
                        { "terran_upgrade_infantryarmorlevel2", Properties.Resources.btn_upgrade_terran_infantryarmorlevel2 },
                        { "terran_upgrade_infantryarmorlevel3", Properties.Resources.btn_upgrade_terran_infantryarmorlevel3 },
                        { "terran_upgrade_infantryweaponslevel0", Properties.Resources.btn_upgrade_terran_infantryweaponslevel0 },
                        { "terran_upgrade_infantryweaponslevel1", Properties.Resources.btn_upgrade_terran_infantryweaponslevel1 },
                        { "terran_upgrade_infantryweaponslevel2", Properties.Resources.btn_upgrade_terran_infantryweaponslevel2 },
                        { "terran_upgrade_infantryweaponslevel3", Properties.Resources.btn_upgrade_terran_infantryweaponslevel3 },
                        { "terran_upgrade_infernalpreigniter", Properties.Resources.btn_upgrade_terran_infernalpreigniter },
                        { "terran_upgrade_jotunboosters", Properties.Resources.btn_upgrade_terran_jotunboosters },
                        { "terran_upgrade_mobiusreactor", Properties.Resources.btn_upgrade_terran_mobiusreactor },
                        { "terran_upgrade_moebiusreactor", Properties.Resources.btn_upgrade_terran_moebiusreactor },
                        { "terran_upgrade_neosteelframe", Properties.Resources.btn_upgrade_terran_neosteelframe },
                        { "terran_upgrade_reapernitropacks", Properties.Resources.btn_upgrade_terran_reapernitropacks },
                        { "terran_upgrade_shipplatinglevel0", Properties.Resources.btn_upgrade_terran_shipplatinglevel0 },
                        { "terran_upgrade_shipplatinglevel1", Properties.Resources.btn_upgrade_terran_shipplatinglevel1 },
                        { "terran_upgrade_shipplatinglevel2", Properties.Resources.btn_upgrade_terran_shipplatinglevel2 },
                        { "terran_upgrade_shipplatinglevel3", Properties.Resources.btn_upgrade_terran_shipplatinglevel3 },
                        { "terran_upgrade_shipweaponslevel0", Properties.Resources.btn_upgrade_terran_shipweaponslevel0 },
                        { "terran_upgrade_shipweaponslevel1", Properties.Resources.btn_upgrade_terran_shipweaponslevel1 },
                        { "terran_upgrade_shipweaponslevel2", Properties.Resources.btn_upgrade_terran_shipweaponslevel2 },
                        { "terran_upgrade_shipweaponslevel3", Properties.Resources.btn_upgrade_terran_shipweaponslevel3 },
                        { "terran_upgrade_twinlinkedflamethrower", Properties.Resources.btn_upgrade_terran_twin_linkedflamethrower },
                        { "terran_upgrade_vehicleplatinglevel0", Properties.Resources.btn_upgrade_terran_vehicleplatinglevel0 },
                        { "terran_upgrade_vehicleplatinglevel1", Properties.Resources.btn_upgrade_terran_vehicleplatinglevel1 },
                        { "terran_upgrade_vehicleplatinglevel2", Properties.Resources.btn_upgrade_terran_vehicleplatinglevel2 },
                        { "terran_upgrade_vehicleplatinglevel3", Properties.Resources.btn_upgrade_terran_vehicleplatinglevel3 },
                        { "terran_upgrade_vehicleweaponslevel0", Properties.Resources.btn_upgrade_terran_vehicleweaponslevel0 },
                        { "terran_upgrade_vehicleweaponslevel1", Properties.Resources.btn_upgrade_terran_vehicleweaponslevel1 },
                        { "terran_upgrade_vehicleweaponslevel2", Properties.Resources.btn_upgrade_terran_vehicleweaponslevel2 },
                        { "terran_upgrade_vehicleweaponslevel3", Properties.Resources.btn_upgrade_terran_vehicleweaponslevel3 },
                        { "terran_upgrade_weaponrefit", Properties.Resources.btn_upgrade_terran_weaponrefit },
                        { "zerg_upgrade_adrenalglands", Properties.Resources.btn_upgrade_zerg_adrenalglands },
                        { "zerg_upgrade_airattackslevel0", Properties.Resources.btn_upgrade_zerg_airattacks_level0 },
                        { "zerg_upgrade_airattackslevel1", Properties.Resources.btn_upgrade_zerg_airattacks_level1 },
                        { "zerg_upgrade_airattackslevel2", Properties.Resources.btn_upgrade_zerg_airattacks_level2 },
                        { "zerg_upgrade_airattackslevel3", Properties.Resources.btn_upgrade_zerg_airattacks_level3 },
                        { "zerg_upgrade_anabolicsynthesis", Properties.Resources.btn_upgrade_zerg_anabolicsynthesis },
                        { "zerg_upgrade_buildingarmor", Properties.Resources.btn_upgrade_zerg_buildingarmor },
                        { "zerg_upgrade_centrifugalhooks", Properties.Resources.btn_upgrade_zerg_centrifugalhooks },
                        { "zerg_upgrade_chitinousplating", Properties.Resources.btn_upgrade_zerg_chitinousplating },
                        { "zerg_upgrade_enduringcorruption", Properties.Resources.btn_upgrade_zerg_enduringcorruption },
                        { "zerg_upgrade_flyercarapacelevel0", Properties.Resources.btn_upgrade_zerg_flyercarapace_level0 },
                        { "zerg_upgrade_flyercarapacelevel1", Properties.Resources.btn_upgrade_zerg_flyercarapace_level1 },
                        { "zerg_upgrade_flyercarapacelevel2", Properties.Resources.btn_upgrade_zerg_flyercarapace_level2 },
                        { "zerg_upgrade_flyercarapacelevel3", Properties.Resources.btn_upgrade_zerg_flyercarapace_level3 },
                        { "zerg_upgrade_glialreconstitution", Properties.Resources.btn_upgrade_zerg_glialreconstitution },
                        { "zerg_upgrade_groovedspines", Properties.Resources.btn_upgrade_zerg_groovedspines },
                        { "zerg_upgrade_groundcarapacelevel0", Properties.Resources.btn_upgrade_zerg_groundcarapace_level0 },
                        { "zerg_upgrade_groundcarapacelevel1", Properties.Resources.btn_upgrade_zerg_groundcarapace_level1 },
                        { "zerg_upgrade_groundcarapacelevel2", Properties.Resources.btn_upgrade_zerg_groundcarapace_level2 },
                        { "zerg_upgrade_groundcarapacelevel3", Properties.Resources.btn_upgrade_zerg_groundcarapace_level3 },
                        { "zerg_upgrade_meleeattacksleve3", Properties.Resources.btn_upgrade_zerg_meleeattacks_leve3 },
                        { "zerg_upgrade_meleeattackslevel0", Properties.Resources.btn_upgrade_zerg_meleeattacks_level0 },
                        { "zerg_upgrade_meleeattackslevel1", Properties.Resources.btn_upgrade_zerg_meleeattacks_level1 },
                        { "zerg_upgrade_meleeattackslevel2", Properties.Resources.btn_upgrade_zerg_meleeattacks_level2 },
                        { "zerg_upgrade_meleeattackslevel3", Properties.Resources.btn_upgrade_zerg_meleeattacks_level3 },
                        { "zerg_upgrade_metabolicboost", Properties.Resources.btn_upgrade_zerg_metabolicboost },
                        { "zerg_upgrade_missileattackslevel0", Properties.Resources.btn_upgrade_zerg_missileattacks_level0 },
                        { "zerg_upgrade_missileattackslevel1", Properties.Resources.btn_upgrade_zerg_missileattacks_level1 },
                        { "zerg_upgrade_missileattackslevel2", Properties.Resources.btn_upgrade_zerg_missileattacks_level2 },
                        { "zerg_upgrade_missileattackslevel3", Properties.Resources.btn_upgrade_zerg_missileattacks_level3 },
                        { "zerg_upgrade_muscularaugments", Properties.Resources.btn_upgrade_zerg_muscularaugments },
                        { "zerg_upgrade_organiccarapace", Properties.Resources.btn_upgrade_zerg_organiccarapace },
                        { "zerg_upgrade_pathogenglands", Properties.Resources.btn_upgrade_zerg_pathogenglands },
                        { "zerg_upgrade_peristalsis", Properties.Resources.btn_upgrade_zerg_peristalsis },
                        { "zerg_upgrade_pneumatizedcarapace", Properties.Resources.btn_upgrade_zerg_pneumatizedcarapace },
                        { "zerg_upgrade_seismicspines", Properties.Resources.btn_upgrade_zerg_seismicspines },
                        { "zerg_upgrade_tunnelingclaws", Properties.Resources.btn_upgrade_zerg_tunnelingclaws },
                        { "zerg_upgrade_ventralsacs", Properties.Resources.btn_upgrade_zerg_ventralsacs },
                    };

                return m_buttonmap;
            }
        }

        public static frmBuildOverlay Instance { get; set; }

        public frmBuildOverlay(Models.Build build, bool locked = false)
        {
            if (Instance != null)
            {
                Instance.Close();
                Instance = null;
            }
            Instance = this;
            InitializeComponent();
            m_locked = !locked;
            m_build = build;
        }

        public bool Locked
        {
            get
            {
                return m_locked;
            }
            set
            {
                if (m_locked == value)
                    return;

                m_locked = value;

                Win32.SetFormTransparency(this, m_locked);

                if (m_locked)
                {
                    //BackColor = Color.Fuchsia;
                    TransparencyKey = BackColor;
                    Opacity = .7;
                    lblFakeTitle.Visible = false;
                }
                else
                {
                    //BackColor = Color.DimGray;
                    TransparencyKey = Color.Red;
                    Opacity = .5;
                    lblFakeTitle.Visible = true;
                }

                Invalidate(this.ClientRectangle);
            }
        }

        private void frmOverlay_Load(object sender, EventArgs e)
        {
            Locked = !m_locked;

            if (!Configuration.Instance.FirstRun)
            {
                Top = Configuration.Instance.OverlayTop;
                Left = Configuration.Instance.OverlayLeft;

                
            }

            Configuration.Instance.FirstRun = false;
        }


        /*
        protected override void WndProc(ref Message m)
        {

            if (m.Msg == (int)0x0084) // WM_NCHITTEST 
            {
                if (!m_locked)
                {
                    m.Result = (IntPtr)(0x2); // HTCAPTION]
                    this.Invalidate();
                }
                else
                {
                    base.WndProc(ref m);
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }*/


        

        private void frmOverlay_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            if (!m_locked)
            {
                // Left
                e.Graphics.DrawLine(Pens.Black, new Point(0, 0), new Point(0, this.ClientRectangle.Bottom - 2));
                e.Graphics.DrawLine(Pens.Gray, new Point(1, 1), new Point(1, this.ClientRectangle.Bottom - 2));

                // Top
                e.Graphics.DrawLine(Pens.Black, new Point(0, 0), new Point(this.ClientRectangle.Width, 0));
                e.Graphics.DrawLine(Pens.Gray, new Point(1, 1), new Point(this.ClientRectangle.Width - 2, 1));

                // Right
                e.Graphics.DrawLine(Pens.Black, new Point(this.ClientRectangle.Right - 1, 0), new Point(this.ClientRectangle.Right - 1, this.ClientRectangle.Bottom));
                e.Graphics.DrawLine(Pens.Gray, new Point(this.ClientRectangle.Right - 2, 1), new Point(this.ClientRectangle.Right - 2, this.ClientRectangle.Bottom - 2));

                // Bottom
                e.Graphics.DrawLine(Pens.Black, new Point(0, this.ClientRectangle.Bottom - 1), new Point(this.ClientRectangle.Width, this.ClientRectangle.Bottom - 1));
                e.Graphics.DrawLine(Pens.Gray, new Point(1, this.ClientRectangle.Bottom - 2), new Point(this.ClientRectangle.Width - 2, this.ClientRectangle.Bottom - 2));
            }

            List<object[]> images = new List<object[]>();
            FontFamily fontFamily = new FontFamily(Configuration.Instance.OverlayContentFont);
            
            FontFamily titleFontFamily = new FontFamily(Configuration.Instance.OverlayTitleFont);
            StringFormat strformat = new StringFormat(StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoClip | StringFormatFlags.NoWrap);
            float pos = Configuration.Instance.OverlayTitleSize + Configuration.Instance.OverlayContentSize;
            lblFakeTitle.Height = (int)                Configuration.Instance.OverlayTitleSize;
            GraphicsPath path = new GraphicsPath();
            
            path.AddString(m_build.Name, fontFamily,
            (int)FontStyle.Regular, Configuration.Instance.OverlayTitleSize, new PointF(0, 0), strformat);
            

            string[] lines = m_build.Script.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            Regex regex = new Regex(@"\{([a-zA-Z0-9_]+)\}");
            float width = 0;
            for (int i=0; i <lines.Length;i++)
            {
                float x = 0;
                string line = lines[i];
                FontStyle modifier = FontStyle.Regular;

                if (line.StartsWith("#"))
                {
                    line = line.Substring(1);
                    modifier = FontStyle.Italic;
                }
                else if (line.StartsWith("*"))
                {
                    line = line.Substring(1);
                    modifier = FontStyle.Bold;
                }


                GraphicsPath tempPath = new GraphicsPath();
                
                Match match = null;
                float addedHeight = Configuration.Instance.OverlayContentSize;
                while ((match = regex.Match(line)).Success)
                {
                    
                    string iconCode = match.Groups[1].Value.ToLower().Trim();
                    if (RaceVariantIcons.Contains(iconCode))
                    {
                        string raceVariantIcon = string.Format("{0}_{1}", Models.Matchup.StringFromRace(m_build.Matchup.PlayerRace).ToLower(), iconCode);
                        if (IconMap.ContainsKey(raceVariantIcon))
                            iconCode = raceVariantIcon;
                    }



                    string prefix = line.Substring(0, match.Index);
                    line = line.Substring(match.Index + match.Length);


                    if (!IconMap.ContainsKey(iconCode) && (!ButtonMap.ContainsKey(iconCode)))
                    {
                        string output = string.Format(@"{0}{{{1}}}", prefix, iconCode);
                        tempPath.AddString(output, fontFamily, (int)modifier, Configuration.Instance.OverlayContentSize, new PointF(0, 0), strformat);

                        path.AddString(output, fontFamily, (int)modifier, Configuration.Instance.OverlayContentSize, new PointF(x, pos), strformat);
                        RectangleF size = tempPath.GetBounds();

                        x += size.X + size.Width + size.Left;
                        tempPath.Reset();
                    }
                    else if (IconMap.ContainsKey(iconCode))
                    {
                        // It refuses to measure whitespace.
                        tempPath.AddString(prefix.Replace(' ', '|'), fontFamily, (int)modifier, Configuration.Instance.OverlayContentSize, new PointF(0, pos), strformat);

                        path.AddString(prefix, fontFamily, (int)modifier, Configuration.Instance.OverlayContentSize, new PointF(x, pos), strformat);
                        RectangleF size = tempPath.GetBounds();
                        x += size.X + size.Width + size.Left;
                        tempPath.Reset();
                        Image image = IconMap[iconCode];

                        if (x == 0)
                            x = 3;
                        float ar = (float)image.Width / (float)image.Height;
                        int newWidth = (int)(Configuration.Instance.OverlayContentSize * ar);
                        images.Add(new object[] { image, x, pos, (int)newWidth, Configuration.Instance.OverlayContentSize });
                        x += newWidth;
                        if (addedHeight < Configuration.Instance.OverlayContentSize)
                            addedHeight = Configuration.Instance.OverlayContentSize;
                    }
                    else if (ButtonMap.ContainsKey(iconCode))
                    {
                        // It refuses to measure whitespace.
                        tempPath.AddString(prefix.Replace(' ', '|'), fontFamily, (int)modifier, Configuration.Instance.OverlayContentSize, new PointF(0, pos), strformat);

                        path.AddString(prefix, fontFamily, (int)modifier, Configuration.Instance.OverlayContentSize, new PointF(x, pos), strformat);
                        RectangleF size = tempPath.GetBounds();
                        x += size.X + size.Width + size.Left;
                        tempPath.Reset();
                        Image image = ButtonMap[iconCode];

                        if (x == 0)
                            x = 3;
                        float ar = (float)image.Width / (float)image.Height;

                        float scaledHeight = image.Height;
                        if (Configuration.Instance.OverlayImageScale > 0)
                            scaledHeight = Configuration.Instance.OverlayContentSize * Configuration.Instance.OverlayImageScale;
                        if (scaledHeight > image.Height) scaledHeight = image.Height;
                        int newWidth = (int)(scaledHeight * ar);
                        images.Add(new object[] { image, x, pos, (int)newWidth, scaledHeight });
                        x += newWidth;
                        if (addedHeight < scaledHeight)
                            addedHeight = scaledHeight;
                    }

                }

                tempPath.AddString(line, fontFamily, (int)modifier, Configuration.Instance.OverlayContentSize, new PointF(0, 0), strformat);
                RectangleF tsize = tempPath.GetBounds();
                
                path.AddString(line, fontFamily, (int)modifier, Configuration.Instance.OverlayContentSize, new PointF(x, pos), strformat);
                x += tsize.X + tsize.Width + tsize.Left;
                tempPath.Reset();
                pos += addedHeight + 2;
                if (x > width)
                    width = x;
            }

            pos += Configuration.Instance.OverlayContentSize;

            for (int i = 0; i < Configuration.Instance.OverlayTextOutlineSize; ++i)
            {
                Pen pen = new Pen(Configuration.Instance.OverlayTextOutlineColour, i + 1);
                pen.LineJoin = LineJoin.Round;
                e.Graphics.DrawPath(pen, path);
                pen.Dispose();
            }

            SolidBrush brush = new SolidBrush(Configuration.Instance.OverlayTextColour);
            e.Graphics.FillPath(brush, path);

            
            RectangleF bounds = path.GetBounds();
            this.Height = (int)pos;
            this.Width = (int)width + 6;

            foreach (object[] image in images)
            {
                try
                {
                    e.Graphics.DrawImage(image[0] as Image, (float)image[1], (float)image[2], (int)image[3], (float)(image[4]));
                }
                catch (Exception ex)
                {
                    ex = ex;
                }
            }

            path.Dispose();
            fontFamily.Dispose();
            brush.Dispose();
            e.Graphics.Dispose();

            
        }

        private void frmOverlay_MouseMove(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.ToString());
        }

        private void frmOverlay_DoubleClick(object sender, EventArgs e)
        {
            Locked = !Locked;
        }

        private void lblFakeTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Win32.ReleaseCapture();
                Win32.SendMessage(Handle, Win32.WM_NCLBUTTONDOWN,Win32.HT_CAPTION, 0);
            }
        }

        private void frmOverlay_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Close();
            }
        }

        private void frmOverlay_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmBuildOverlay.Instance = null;
        }

        private void frmOverlay_FormClosing(object sender, FormClosingEventArgs e)
        {
            Configuration.Instance.OverlayLeft = Left;
            Configuration.Instance.OverlayTop = Top;

            Program.SaveConfigurationXML();
        }


        /*protected override CreateParams CreateParams
        {
            get
            {
                CreateParams p = base.CreateParams;


                p.ExStyle |= (0x08000000);

                return p;
            }
        }*/
    }
}
