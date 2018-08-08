using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static System.Environment;
using System.ComponentModel.DataAnnotations;

namespace SportsWebApp.Models
{
    public class Player 
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Stats { get; set; }
        public string Awards { get; set; }

        public IEnumerable<string> StatsList
        {
            get { return (Stats ?? string.Empty).Split(NewLine); }
        }

        public IEnumerable<string> AwardsList
        {
            get { return (Awards ?? string.Empty).Split(NewLine); }
        }

    
    }
}
