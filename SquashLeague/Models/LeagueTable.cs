using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SquashLegaue.Models
{
    public class LeagueTable
    {
        [Display(Name = "Player")]
        public string Name {get; set;}

        [Display(Name = "Matchs played")]
        public int Matchs { get; set; }

        [Display(Name = "Wins")]
        public int Win { get; set; }

        [Display(Name = "Draws")]
        public int Draw { get; set; }

        [Display(Name = "Losess")]
        public int Lost { get; set; }

        [Display(Name = "Games Won")]
        public int GamesWon { get; set; }

        [Display(Name = "Games Lost")]
        public int GamesLost { get; set; }

        [Display(Name = "Games +/-")]
        public int GamesDiff { get; set; }

        [Display(Name = "Points")]
        public int Points { get; set; }

        [Display(Name = "Win%")]
        public int WinPercentage { get; set; }
    }
}