using DawaAPI.Data;
using DawaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DawaAPI.Services
{
    public class DbContextService : IDbContextService
    {

        public QuranContext DB { get; set; }

        public DbContextService(QuranContext db)
        {
            DB = db;
        }

        public Task<Surah> getSurah(int id)
        {
            return Task.Run(() =>
            {
                Surah surah = DB.Surah.Include(s => s.ayat).ThenInclude(a => a.Explanations).ThenInclude(e => e.Source).FirstOrDefault(s => s.id == id);

                foreach (Ayah ayah in surah.ayat)
                {
                    ayah.Words = ayah.TextForHtml.Split(' ', ' ').ToList();
                }

                return surah;

            });
        }

        public Task<List<Surah>> getSuwar()
        {
            return Task.Run(() =>
            {
                return DB.Surah.ToList();
            });
        }

        public QuranContext getDbContext()
        {
            return DB;
        }

    }
}
