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

    public class Game
    {
        private readonly List<Player> players = PlayerRepo.GetList();

        public int ID { get; set; }
        
        [Required]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfGame { get; set; }

        [Display(Name = "Player 1 Name")]
        public string Player1 { get; set; }

        [Display(Name = "Player 2 Name")]
        public string Player2 { get; set; }

        [Required]
        [Display(Name = "Player 1")]
        public int Player1SelectedItemId { get; set; }
        
        [Required]
        [Display(Name = "Player 2")]
        public int Player2SelectedItemId { get; set; }
        
        public IEnumerable<SelectListItem> PlayerList
        {
            get { return new SelectList(players, "Id", "Name"); }
        }
    }
}