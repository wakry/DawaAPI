using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using DawaAPI.Data.Xml;
using System.Text.RegularExpressions;
using DawaAPI.Data.HTML;
using DawaAPI.Data.Word;
using DawaAPI.Models;

namespace DawaAPI.Data
{
    public class QuranContext : DbContext
    {

        public QuranContext(DbContextOptions<QuranContext> options)
             : base(options)
        {
            //fillDatabase();
        }

        public DbSet<Surah> Surah { get; set; }
        public DbSet<Ayah> Ayah { get; set; }
        public DbSet<Explanation> Explanation { get; set; }
        public DbSet<ExplanationSource> ExplanationSource { get; set; }

        public void fillDatabase()
        {
            QuranXMLController m = new QuranXMLController(this);
            QuranHTMLController htmlTable = new QuranHTMLController(this);
            WordReader wr = new WordReader(this);

        }

    }
}
