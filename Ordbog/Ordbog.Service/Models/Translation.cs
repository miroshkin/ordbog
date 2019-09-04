using System.ComponentModel.DataAnnotations;

namespace Ordbog.Service.Models
{
    public class Translation
    {
        public int TranslationId { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
