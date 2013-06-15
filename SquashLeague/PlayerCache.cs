using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Caching;
using System.Collections;

using SquashLegaue.Interface;
using SquashLegaue.Models;
using SquashLegaue.Repo;

namespace SquashLegaue
{
    public class PlayerCache : IPlayerRepository
    {
        protected List<Player> players { get; private set; }

        public ICacheProvider Cache { get; set; }

        public PlayerCache() : this(new DefaultCacheProvider())
        {
        }

        public PlayerCache(ICacheProvider cacheProvider)
        {
            this.players = Repo.PlayerRepo.GetList();
            this.Cache = cacheProvider;
        }

        public List<Player> GetPlayers()
        {
            // First, check the cache
            IEnumerable playerData = Cache.Get("players") as IEnumerable;
 
            // If it's not in the cache, we need to read it from the repository
            if (playerData == null)
            {
              // Get the repository data
              playerData = Repo.PlayerRepo.GetList();
 
               // Put this data into the cache for 30 minutes
               Cache.Set("players", playerData, 30);
            }
 
            return this.players;
        }

        public void ClearCache()
        {
            Cache.Invalidate("players");
        }
    }

}