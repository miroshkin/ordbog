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
    public class EditorController : Controller
    {
        ArticlesRepository _articlesRepository = new ArticlesRepository();
        public IActionResult Add()
        {
            EditorModel sm = new EditorModel();
            return View();
        }

        [HttpPost]
        public IActionResult Add(EditorModel model)
        {
            model.Article = new Article(){Word = model.Word, Transcription = model.Transcription, Translations = new List<Translation>(){new Translation(){Text = model.Translation}}};
            var articleToAdd = model.Article;
            model.Article = _articlesRepository.AddArticle(model.Article);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
