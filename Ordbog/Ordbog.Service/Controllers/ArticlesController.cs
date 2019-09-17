using System;
using System.Collections.Generic;
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
        [HttpGet]
        public ActionResult<IEnumerable<Article>> Get()
        {
            return _context.Articles;
        }

        // GET api/articles/{searchKey}
        [HttpGet("{word}")]
        public async Task <ActionResult<Article>> Get(string word)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var articles = _context.Articles.Where(a => a.Word.StartsWith(word)).ToList();
            
            foreach (var article in articles)
            {
                article.Translations = _context.Translations.Where(t => t.ArticleId == article.ArticleId).ToList();
            }


            if (articles.Count == 0)
            {
                return NotFound();
            }
            
            return Ok(articles);
        }

        // POST api/articles
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/articles/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/articles/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
