using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using SportsWebApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsWebApp.Controllers
{
    public class ListController : Controller
    {
        internal static Dictionary<string, string> columnChoices = new Dictionary<string, string>();

        // This is a "static constructor" which can be used
        // to initialize static members of a class
        static ListController()
        {

            columnChoices.Add("name", "Name");            
            columnChoices.Add("employer", "Employer");
            columnChoices.Add("location", "Location");
            columnChoices.Add("position type", "Position Type");
            columnChoices.Add("jersey number", "Jersey Number");
            columnChoices.Add("all", "All");
        }

        public IActionResult Index()
        {
            ViewBag.columns = columnChoices;
            return View();
        }

        public IActionResult Values(string column)
        {
            if (column.Equals("all"))
            {
                List<Dictionary<string, string>> sports = SportData.FindAll();
                ViewBag.title = "All Sports";
                ViewBag.sports = sports;
                return View("Sports");
            }
            else
            {
                List<string> items = SportData.FindAll(column);
                ViewBag.title = "All " + columnChoices[column] + " Values";
                ViewBag.column = column;
                ViewBag.items = items;
                return View();
            }
        }

        public IActionResult Jobs(string column, string value)
        {
            List<Dictionary<String, String>> sports = SportData.FindByColumnAndValue(column, value);
            ViewBag.title = "Sports with " + columnChoices[column] + ": " + value;
            ViewBag.sports = sports;

            return View();
        }
    }
}
