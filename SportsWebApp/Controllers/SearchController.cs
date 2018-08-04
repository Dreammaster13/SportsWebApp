using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsWebApp.Models;

namespace SportsWebApp.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // Results action method to process search request and display results
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;
            List<Dictionary<string, string>> sports = new List<Dictionary<string, string>>();

            if (string.IsNullOrEmpty(searchTerm))
            {
                return View("Index");
            }

            if (searchType.Equals("all"))
            {
                sports = SportData.FindByValue(searchTerm);
                ViewBag.sports = sports;
                return View("Index");
            }
            else
            {
                sports = SportData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.sports = sports;
                return View("Index");
            }

        }
    }
}