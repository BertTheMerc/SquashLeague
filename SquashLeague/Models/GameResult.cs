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

        [Display(Name = "Comments")]
        public string Comments { get; set; }

        public string Player1ScoreImage
        {
            get { return "<img src='/images/" + Player1Score + ".png'>"; }
        }

        public string Player2ScoreImage
        {
            get { return "<img src='/images/" + Player2Score + ".png'>"; }
        }

        public string TwitterResult 
        {
            get
            {
                return string.Format("GAME RESULT: Result of the Game play on {4} with {0} & {1} is {2}-{3}.", Player1.Nickname, Player2.Nickname, Player1Score, Player2Score, DateOfGame.ToLongDateString());
            }
        }

        public string TwitterCompleteScheduledGame
        {
            get
            {
                return string.Format("GAME RESULT: Result of the {4} game with {0} & {1} is {2}-{3}.", Player1.Nickname, Player2.Nickname, Player1Score, Player2Score, GameTypeDisplay);
            }
        }

        public GameResult() : base() 
        {
        }
    }
}