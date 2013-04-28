using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SquashLegaue.Models
{
    using SquashLegaue.Repo;

    public class PlayerList
    {
        public Dictionary<int, Player> Players = new Dictionary<int, Player>();

        public PlayerList()
        {
            foreach (Player p in PlayerRepo.GetList())
            {
                Players.Add(p.Id, p);
            }
        }
    }
}