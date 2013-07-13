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
    public class LegaueTableResults
    {
        private List<LeagueResultType> resultTypes;
        
        public LeagueResultType LeagueType;

        [Display(Name = "Result display format")]
        public int SelectedResultTypeID {get; set;}

        [Display(Name = "Legaue Data?")]
        public bool LeagueData { get; set; }

        public LeagueResultType ActiveResultType
        {
            get
            {
                return this.resultTypes[this.SelectedResultTypeID-1];
            }
        }

        public List<LeagueTable> Results;


        public LegaueTableResults()
        {
            var cache = new SiteCache();
            this.resultTypes = cache.GetLeageResultTypes();
            this.LeagueType = this.resultTypes[0];
            this.SelectedResultTypeID = 1;
            this.LeagueData = true;
        }

        public IEnumerable<SelectListItem> LeagueResultTypes
        {
            get { return new SelectList(resultTypes, "ID", "Name"); }
        }


    }
}