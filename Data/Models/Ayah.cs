using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuranKareem.Data.Models
{
    public class Ayah
    {

        public int id { get; set; }
        public int idInSurah { get; set; }
        public string text { get; set; }
        public int pageNumber { get; set; }
        public string text_For_Html { get; set; }
        public string text_Emlaey { get; set; }
        public int surahId { get; set; }
        [NotMapped]
        public virtual List<string> words { get; set; } = new List<string>();

    }
}
