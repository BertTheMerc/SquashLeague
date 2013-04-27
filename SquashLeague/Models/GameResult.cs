using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SquashLegaue.Models
{
    public class GameResult
    {
        public int ID { get; set; }
        
        [Required]
        [Display(Name = "Date of the game")]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfGame { get; set; }

        [Required]
        [Display(Name = "Player 1")]
        public string Player1 { get; set; }

        [Required]
        [Display(Name = "Player 2")]
        public string Player2 { get; set; }

        [Required]
        [Display(Name = "Player 1 score")]
        public int Player1Score { get; set; }

        [Required]
        [Display(Name = "Player 2 score")]
        public int Player2Score { get; set; }
    }
}