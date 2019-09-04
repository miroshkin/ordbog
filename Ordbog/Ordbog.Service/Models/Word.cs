using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Ordbog.Service.Models
{
    public class Article
    {
        public int ArticleId { get; set; }

        [Required]
        public string Word { get; set; }

        [Required]
        public string Transcription { get; set; }

        public ICollection<Translation> Translations { get; set; }
    }
}
