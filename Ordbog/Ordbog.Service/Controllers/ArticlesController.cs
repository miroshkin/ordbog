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
        public async Task <IActionResult> Post([FromBody] Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Add(article);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { Word = article.Word }, article);
        }

        // PUT api/articles/5
        [ApiVersion("1.0")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != article.ArticleId)
            {
                return BadRequest();
            }

            _context.Entry(article).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/articles/5
        [ApiVersion("1.0")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var article = await _context.Articles.SingleOrDefaultAsync(m => m.ArticleId == id);
            if (article == null)
            {
                return NotFound();
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();

            return Ok(article);
        }


        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.ArticleId == id);
        }
    }
}
