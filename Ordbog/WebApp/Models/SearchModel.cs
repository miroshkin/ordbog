using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ordbog.Service.Models;

namespace Ordbog.App.Models
{
    public class SearchModel
    {
        [Required]
        public string SearchString { get; set; }
        public IEnumerable<Article> SearchResult { get; internal set; }
    }
}
