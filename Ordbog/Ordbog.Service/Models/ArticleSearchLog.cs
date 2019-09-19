using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Ordbog.Service.Models
{
    public class ArticleSearchLog
    {
        public int ArticleSearchLogId { get; set; }

        [Required]
        public string Word { get; set; }

        public int Frequency { get; set; }

    }
}
