using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Ordbog.App.Models;
using Ordbog.Service.Models;

namespace Ordbog.App.Data
{
    public class ArticlesRepository
    {
        private List<Article> _list;

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
    }
}
