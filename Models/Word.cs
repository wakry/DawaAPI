using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DawaAPI.Models
{
    public class Word
    {

        private Surah _surah;
        public Word(Surah surah)
        {
            _surah = surah;
        }

        public string word { get; set; }
        public string meaning { get; set; }

    }
}
