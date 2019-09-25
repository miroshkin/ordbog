using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ordbog.Service.Models;

namespace Ordbog.App.Models
{
    public class EditorModel
    {
        public Article Article { get; set; }

        public string Word { get; set; }

        public string Transcription { get; set; }

        public string Translation { get; set; }
    }
}
