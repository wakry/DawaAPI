using Microsoft.EntityFrameworkCore;
using QuranKareem.Data.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using DawaAPI.Data.Xml;
using System.Text.RegularExpressions;
using System.Collections;
using System.Diagnostics;

namespace QuranKareem.Data
{
    public class QuranContext : DbContext
    {

        public QuranContext(DbContextOptions<QuranContext> options)
             : base(options)
        {
           // fillDatabase();
        }

        public DbSet<Surah> Surah { get; set; }
        public DbSet<Ayah> Ayah { get; set; }

        public IIncludableQueryable<Surah, ICollection<Ayah>> getAllSuwarWithAyat()
        {
            return Surah.Include(s => s.ayat);
        }

        public DbSet<Surah> getAllSuwar()
        {
            return Surah;
        }

        public Task<Surah> getSurahWithId(int id)
        {

            return Task.Run(() =>
            {

                Surah surah = Surah.Include(s => s.ayat).FirstOrDefault(s => s.id == id);

                foreach(Ayah ayah in surah.ayat)
                {
                    Debug.WriteLine(ayah.text_For_Html);
                    ayah.words = ayah.text_For_Html.Split(' ', ' ').ToList();
                }

                return surah;

            });

        }

    public Task<Surah> getSurahWordByWord(int id)
        {

            return Task.Run(() =>
            {
                Surah surah = Surah.Include(s => s.ayat).FirstOrDefault(s => s.id == id);
                foreach (Ayah ayah in surah.ayat)
                {
                    List<string> words = ayah.text_For_Html.Split(' ', ' ').ToList();
                    
                    foreach (string word in words)
                    {
                        surah.words.Add(word);
                    }
                }
                return surah;
            });
        }

        public void styleAyahNumber(ICollection<Ayah> ayat)
        {
            foreach (Ayah ayah in ayat) {
                 string number = Regex.Match(ayah.text, @"\d+$").Value;
                 ayah.text = ayah.text.Replace(number, $"ﰋ");
            }

        }

        public void fillDatabase()
        {
            QuranXMLController m = new QuranXMLController(this);
        }

    }
}
