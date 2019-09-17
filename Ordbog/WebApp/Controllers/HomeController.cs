using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ordbog.App.Data;
using Ordbog.App.Models;
using Ordbog.Service.Models;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        ArticlesRepository _articlesRepository = new ArticlesRepository();
        public IActionResult Index()
        {
            SearchModel sm = new SearchModel();
            return View();
        }

        [HttpPost]
        public IActionResult Index(SearchModel model)
        {
            var searchString = model.SearchString;

            if (String.IsNullOrEmpty(model.SearchString))
            {
                model.SearchResult = new Article[0];
            }
            else
            {
                model.SearchResult = _articlesRepository.GetArticles(model.SearchString).ToList();
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
