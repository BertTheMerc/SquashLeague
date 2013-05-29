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
        private readonly List<Player> players;

        public int ID { get; set; }
        
        [Required]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DateOfGame { get; set; }

        [Display(Name = "Player 1 Name")]
        public Player Player1 { get; set; }

        [Display(Name = "Player 2 Name")]
        public Player Player2 { get; set; }

        [Required]
        [Display(Name = "Player 1")]
        public int Player1SelectedItemId { get; set; }
        
        [Required]
        [Display(Name = "Player 2")]
        public int Player2SelectedItemId { get; set; }

        [Required]
        [Display(Name = "Game Type [L=League & F=Friendly]")]
        public string GameType { get; set; }

        public string GameTypeDisplay 
        {
            get 
            {
                switch (GameType)
                {
                    case "L" : return "League"; 
                    case "F" : return "Friendly";
                }

                return GameType;
            }
        }

        public string TwitterScheduled
        {
            get
            { 
                SetPlayerNames();
                return string.Format("SCHEDULE: {0} to play {1} as a {2} game on the {3}", Player1.Nickname, Player2.Nickname, GameTypeDisplay, DateOfGame.ToLongDateString());
            }
        }

        public string TwitterEdited
        {
            get 
            {
                SetPlayerNames();
                return string.Format("SCHEDULE UPDATE: {0} to play {1} as a {2} game on the {3}", Player1.Nickname, Player2.Nickname, GameTypeDisplay, DateOfGame.ToLongDateString());
            }
        }

        public string TwitterDelete
        {
            get
            {
                SetPlayerNames();
                return string.Format("SCHEDULE UPDATE: Game with {0} & {1} on the {2} has been cancelled.", Player1.Nickname, Player2.Nickname, DateOfGame.ToLongDateString());
            }
        }

        public IEnumerable<SelectListItem> PlayerList
        {
            get { return new SelectList(players, "Id", "Name"); }
        }

        protected void SetPlayerNames()
        {
            Player1 = players.Single(x => x.Id == Player1SelectedItemId);
            Player2 = players.Single(x => x.Id == Player2SelectedItemId);
        }

        public Game(List<Player> playerList) 
        {
            players = playerList;
        }
    }
}