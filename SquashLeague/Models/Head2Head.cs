using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SquashLegaue.Models
{ 
    using SquashLegaue.Repo;
    
    public class Head2Head
    {     
        private List<Player> players;

        private int _player1ID;
        private int _player2ID;

        [Display(Name = "Player 1 Name")]
        public Player Player1 { get; set; }

        [Display(Name = "Player 2 Name")]
        public Player Player2 { get; set; }

        [Display(Name = "Player 1")]
        public int Player1SelectedItemId
        {
            get { return _player1ID; }
            set
            {
                if (_player1ID != value)
                {
                    _player1ID = value;
                    Player1 = players.Single(x => x.Id == _player1ID);
                }
            }
        }

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

        public int NumberOfGames { get; set; }

        public int NumberOfDraws { get; set; }

        public int Player1Wins { get; set; }

        public int Player2Wins { get; set; }

        public int Player1GamesWon { get; set; }

        public int Player2GamesWon { get; set; }

        public List<GameResult> Games;

        public IEnumerable<SelectListItem> PlayerList
        {
            get { return new SelectList(players, "Id", "Name"); }
        }

        public Head2Head()
        {
            var cache = new SiteCache();
            this.players = cache.GetPlayers();
            this.Games = new List<GameResult>();
        }

    }
}