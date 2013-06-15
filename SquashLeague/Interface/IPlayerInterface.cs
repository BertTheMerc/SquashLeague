using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using SquashLegaue.Models;

namespace SquashLegaue.Interface
{
    public interface IPlayerRepository
    {
        void ClearCache();
        List<Player> GetPlayers();
    }

}
