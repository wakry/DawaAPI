using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DawaAPI.Data.Audio;

namespace DawaAPI.Models
{
    public class Surah
    {
        public int id { get; set; }
        public string arabicName { get; set; }
        public string englishName { get; set; }
        public int juza { get; set; }
        public int numberOfPages { set; get; }
        [NotMapped]
        public bool isCached { get; set; } = true;
        public virtual ICollection<Ayah> ayat { get; set; }
        [NotMapped]
        public virtual List<string> words { get; set; } = new List<string>();
        [NotMapped]
        public virtual List<int> times { get; set; } = new List<int>(); 

    }
}
