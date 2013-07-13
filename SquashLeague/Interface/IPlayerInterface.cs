using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using SquashLegaue.Models;

namespace SquashLegaue.Interface
{
    public interface ISiteRepository
    {
        void ClearCache();
        List<Player> GetPlayers();
        List<LeagueResultType> GetLeageResultTypes();
    }

}
