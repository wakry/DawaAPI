using DawaAPI.Data;
using DawaAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DawaAPI.Services
{
    public interface IDbContextService
    {

        public QuranContext getDbContext();
        public Task<List<Surah>> getSuwar();
        public Task<Surah> getSurah(int id);
        public void fillDataBase();

    }
}
