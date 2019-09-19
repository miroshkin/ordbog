using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ordbog.Service.Data;
using Ordbog.Service.Models;

namespace Ordbog.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {

        private readonly OrdbogServiceContext _context;

        public ArticlesController (OrdbogServiceContext context)
        {
            _context = context;
        }

        // GET api/articles
        [ApiVersion("1.0")]
        [HttpGet]
        public ActionResult<IEnumerable<Article>> Get()
        {
            return _context.Articles;
        }

        // GET api/articles/{searchKey}
        [ApiVersion("1.0")]
        [HttpGet("{word}")]
        public async Task <ActionResult<Article>> Get(string word)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            var articles = _context.Articles.Where(p =>
                CultureInfo.CurrentCulture.CompareInfo.IndexOf(p.Word, word, CompareOptions.IgnoreCase) >= 0 && p.Word.StartsWith(word)).ToList();
            
            foreach (var article in articles)
            {
                article.Translations = _context.Translations.Where(t => t.ArticleId == article.ArticleId).ToList();
            }


            if (articles.Count == 0)
            {
                LogSearchWord(word);
                return NotFound();
            }

            return Ok(articles);
        }

        private void LogSearchWord(string word)
        {
            var searchedWord = _context.ArticlesLog.Where(al => al.Word == word).FirstOrDefaultAsync().Result;
            if (searchedWord == null)
            {
                _context.ArticlesLog.Add(new ArticleSearchLog() {Word = word, Frequency = 1});
            }
            else
            {
                searchedWord.Frequency += 1;
            }

            _context.SaveChanges();
        }

        // POST api/articles
        [ApiVersion("1.0")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/articles/5
        [ApiVersion("1.0")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/articles/5
        [ApiVersion("1.0")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
