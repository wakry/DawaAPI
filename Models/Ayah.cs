using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DawaAPI.Models
{
    public class Ayah
    {

        public int Id { get; set; }
        public int IdInSurah { get; set; }
        public string Text { get; set; }
        public int PageNumber { get; set; }
        public string TextForHtml{ get; set; }
        public string TextEmlaey { get; set; }
        public int SurahId { get; set; }
        public virtual List<Explanation> Explanations { get; set; } = new List<Explanation>();

        [NotMapped]
        public virtual List<string> Words { get; set; } = new List<string>();

    }
}
