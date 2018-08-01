using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsWebApp.Controllers
{
    public class LeaguesController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public string NBA()
        {
            return "Default page for NBA...";
        }

        public string NHL()
        {
            return "Default page for NHL...";
        }

        public string MLB()
        {
            return "Default page for MLB...";
        }

        public string MLS()
        {
            return "Default page for MLS...";
        }
    }
}
