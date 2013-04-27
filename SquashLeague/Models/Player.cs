using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SquashLegaue.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Display(Name = "Player")]
        public string Name { get; set; }

        [Display(Name = "Nickname")]
        public string Nickname { get; set; }

    }
}