using System;
using System.Collections.Generic;

namespace DataModels
{
    public class Custom
    {
        public bool suppressor { get; set; }
        public bool gp30 { get; set; }
        public bool xm320 { get; set; }
        public bool masterkey { get; set; }
        public bool scope { get; set; }
        public bool sight { get; set; }
        public bool laser { get; set; }
        public bool lighthg { get; set; }
        public bool lightlg { get; set; }
        public bool grip { get; set; }
    }

    public class Data
    {
        public int players { get; set; }
        public List<Lobby> lobbies { get; set; }
    }

    public class Items
    {
        public bool envg { get; set; }
        public bool drum { get; set; }
    }

    public class LevelLimit
    {
        public bool enabled { get; set; }
        public int @base { get; set; }
        public int tolerance { get; set; }
    }

    public class Lobby
    {
        public int id { get; set; }
        public int lobbyId { get; set; }
        public string name { get; set; }
        public List<Player> players { get; set; }
        public int maxPlayers { get; set; }
        public bool locked { get; set; }
        public int currentGame { get; set; }
        public List<List<int>> games { get; set; }
        public string comment { get; set; }
        public string location { get; set; }
        public Settings settings { get; set; }
    }

    public class Player
    {
        public int id { get; set; }
        public string name { get; set; }
        public int rank { get; set; }
        public bool host { get; set; }
        public string emblem { get; set; }
    }

    public class Primary
    {
        public bool vz { get; set; }
        public bool p90 { get; set; }
        public bool mp5 { get; set; }
        public bool patriot { get; set; }
        public bool ak { get; set; }
        public bool m4 { get; set; }
        public bool mk17 { get; set; }
        public bool xm8 { get; set; }
        public bool g3a3 { get; set; }
        public bool svd { get; set; }
        public bool mosin { get; set; }
        public bool m14 { get; set; }
        public bool vss { get; set; }
        public bool dsr { get; set; }
        public bool m870 { get; set; }
        public bool saiga { get; set; }
        public bool m60 { get; set; }
        public bool shield { get; set; }
        public bool rpg { get; set; }
        public bool knife { get; set; }
    }

    public class Root
    {
        public bool success { get; set; }
        public Data data { get; set; }
    }

    public class Secondary
    {
        public bool gsr { get; set; }
        public bool mk2 { get; set; }
        public bool @operator { get; set; }
        public bool g18 { get; set; }
        public bool mk23 { get; set; }
        public bool de { get; set; }
    }

    public class Settings
    {
        public bool dedicated { get; set; }
        public int maxPlayers { get; set; }
        public int briefingTime { get; set; }
        public bool nonStat { get; set; }
        public bool friendlyFire { get; set; }
        public bool autoAim { get; set; }
        public Uniques uniques { get; set; }
        public bool enemyNametags { get; set; }
        public bool silentMode { get; set; }
        public bool autoAssign { get; set; }
        public bool teamsSwitch { get; set; }
        public bool ghosts { get; set; }
        public LevelLimit levelLimit { get; set; }
        public bool voiceChat { get; set; }
        public int teamKillKick { get; set; }
        public int idleKick { get; set; }
        public WeaponRestrictions weaponRestrictions { get; set; }
    }

    public class Support
    {
        public bool grenade { get; set; }
        public bool wp { get; set; }
        public bool stun { get; set; }
        public bool chaff { get; set; }
        public bool smoke { get; set; }
        public bool smoke_r { get; set; }
        public bool smoke_g { get; set; }
        public bool smoke_y { get; set; }
        public bool eloc { get; set; }
        public bool claymore { get; set; }
        public bool sgmine { get; set; }
        public bool c4 { get; set; }
        public bool sgsatchel { get; set; }
        public bool magazine { get; set; }
    }

    public class Uniques
    {
        public bool enabled { get; set; }
        public bool random { get; set; }
        public int red { get; set; }
        public int blue { get; set; }
    }

    public class WeaponRestrictions
    {
        public bool enabled { get; set; }
        public Primary primary { get; set; }
        public Secondary secondary { get; set; }
        public Support support { get; set; }
        public Custom custom { get; set; }
        public Items items { get; set; }
    }
}


