using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Ordbog.App.Models;
using Ordbog.Service.Models;

namespace Ordbog.App.Data
{
    public class ArticlesRepository
    {
        private List<Article> _list;
        private Article _article;

        //public ArticlesRepository(string json)
        //{
        //    //Get dictionary articles from dictionary.json
        //    _list = JsonConvert.DeserializeObject<List<Article>>(json);
        //}

        public List<Article> GetArticles()
        {
            dynamic result;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://service.ordbog.ru/api");
                var responseTask = client.GetAsync("api/articles");

                responseTask.Wait();  
  
                //To store result of web api response.   
                result = responseTask.Result;
                result.EnsureSuccessStatusCode();
                string responseBody = result.Content.ReadAsStringAsync().Result;

                
                SearchModel sm = new SearchModel();
                _list = JsonConvert.DeserializeObject<List<Article>>(responseBody);
            }
            
            return _list.OrderBy(x => x.Word).ToList();


        }

        public List<Article> GetArticles(string word)
        {
            dynamic result;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://service.ordbog.ru/api");
                var responseTask = client.GetAsync($"api/articles/{word}");

                responseTask.Wait();  
  
                //To store result of web api response.   
                
                result = responseTask.Result;

                if (responseTask.Result.StatusCode == HttpStatusCode.NotFound)
                {
                    return new List<Article>();
                }

                result.EnsureSuccessStatusCode();
                string responseBody = result.Content.ReadAsStringAsync().Result;
                _list = JsonConvert.DeserializeObject<List<Article>>(responseBody);
            }
            
            return _list.OrderBy(x => x.Word).ToList();

        }

        public Article AddArticle(Article article)
        {
            dynamic result;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44310/api");
                //client.BaseAddress = new Uri("http://service.ordbog.ru/api");
                var stringContent = new StringContent(JsonConvert.SerializeObject(article), Encoding.UTF8, "application/json");

                var responseTask = client.PostAsync($"api/articles", stringContent);

                responseTask.Wait();  
  
                //To store result of web api response.   
                
                result = responseTask.Result;

                if (responseTask.Result.StatusCode == HttpStatusCode.NotFound)
                {
                    return new Article();
                }

                result.EnsureSuccessStatusCode();
                string responseBody = result.Content.ReadAsStringAsync().Result;
                _article = JsonConvert.DeserializeObject<Article>(responseBody);
            }
            
            return article;

        }
    }
}
