using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SquashLegaue.Models
{
    using SquashLegaue.Repo;

    public class PlayerList
    {
        public Dictionary<int, Player> Players = new Dictionary<int, Player>();

        public PlayerList(List<Player> players)
        {
            foreach (Player p in players)
            {
                Players.Add(p.Id, p);
            }
        }
    }
}