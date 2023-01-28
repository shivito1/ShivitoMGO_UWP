using System;
using System.Collections.Generic;

namespace DataModels
{
    class Player
    {
        public int id { get; set; }
        public string name { get; set; }
        public int rank { get; set; }
        public bool host { get; set; }
        public string emblem { get; set; }
    }

    class Lobby
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
    }

    class Data
    {
        public int players { get; set; }
        public List<Lobby> lobbies { get; set; }
    }

    class Root
    {
        public bool success { get; set; }
        public Data data { get; set; }
        public string message { get; set; }
    }
}


