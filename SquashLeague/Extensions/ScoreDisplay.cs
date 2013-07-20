using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SquashLegaue.Extensions
{
    using System.Web.Mvc;
    using System.Text;

    using SquashLegaue.Models;
 
    public static class DisplayExtensions
    {
        public static MvcHtmlString Score(this HtmlHelper helper, int score, bool tiny)
        {
            var result = new StringBuilder();
            var imagesize = tiny ? "tiny" : "small";
            char[] digits = score.ToString().ToCharArray();
            foreach (char d in digits)
            {
                result.Append(String.Format("<img src='/Images/{0}_{1}.png' class='gamescore'>", d, imagesize));
            }

            return new MvcHtmlString(result.ToString());
        }
    }
}