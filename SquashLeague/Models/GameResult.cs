using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace SquashLegaue.Models
{
    using SquashLegaue.Repo;

    public class GameResult : Game
    {
        [Required]
        [Display(Name = "Player 1 score")]
        public int Player1Score { get; set; }

        [Required]
        [Display(Name = "Player 2 score")]
        public int Player2Score { get; set; }
    }
}