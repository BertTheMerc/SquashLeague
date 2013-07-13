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
    public class SiteCache : ISiteRepository
    {
        protected List<Player> players { get; private set; }
        protected List<LeagueResultType> resultTypes { get; private set; }

        public ICacheProvider Cache { get; set; }

        public SiteCache() : this(new DefaultCacheProvider())
        {
        }

        public SiteCache(ICacheProvider cacheProvider)
        {
            this.players = Repo.PlayerRepo.GetList();
            this.resultTypes = Repo.LeagueTableRepo.ResultTypes();
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

        public List<LeagueResultType> GetLeageResultTypes()
        {
            // First, check the cache
            IEnumerable resultTypesData = Cache.Get("resultTypes") as IEnumerable;

            // If it's not in the cache, we need to read it from the repository
            if (resultTypesData == null)
            {
                // Get the repository data
                resultTypesData = Repo.LeagueTableRepo.ResultTypes();

                // Put this data into the cache for 30 minutes
                Cache.Set("resultTypes", resultTypesData, 30);
            }

            return this.resultTypes;
        }

        public void ClearCache()
        {
            Cache.Invalidate("players");
            Cache.Invalidate("resultTypes");
        }
    }

}