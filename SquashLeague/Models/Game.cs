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
        private List<Player> players;
        private int _player1ID;
        private int _player2ID;

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
        public int Player1SelectedItemId {

            get { return _player1ID; }
            set { 
                    if (_player1ID != value)
                    {
                        _player1ID = value;
                        Player1 = players.Single(x => x.Id == _player1ID);
                    }
            }
        }

        [Required]
        [Display(Name = "Player 2")]
        public int Player2SelectedItemId
        {

            get { return _player2ID; }
            set
            {
                if (_player2ID != value)
                {
                    _player2ID = value;
                    Player2 = players.Single(x => x.Id == _player2ID);
                }
            }
        }

        public string TwitterScheduled
        {
            get
            { 
                return string.Format("SCHEDULE: {0} to play {1} on the {2}", Player1.Nickname, Player2.Nickname, DateOfGame.ToLongDateString());
            }
        }

        public string TwitterEdited
        {
            get 
            {
                return string.Format("SCHEDULE UPDATE: {0} to play {1} on the {3}", Player1.Nickname, Player2.Nickname, DateOfGame.ToLongDateString());
            }
        }

        public string TwitterDelete
        {
            get
            {
                return string.Format("SCHEDULE UPDATE: Game with {0} & {1} on the {2} has been cancelled.", Player1.Nickname, Player2.Nickname, DateOfGame.ToLongDateString());
            }
        }

        private void SetPlayerNames()
        {
           
            Player2 = players.Single(x => x.Id == Player2SelectedItemId);
        }

        public IEnumerable<SelectListItem> PlayerList
        {
            get { return new SelectList(players, "Id", "Name"); }
        }

        public Game()
        {
            var cache = new SiteCache();
            this.players = cache.GetPlayers();
        }
    }
}