using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DawaAPI.Extensions;
using DawaAPI.Models;
using DawaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace DawaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SurahController : ControllerBase
    {
        private IDbContextService dbService;
        private IDistributedCache dbCache;

        public SurahController(IDbContextService context, IDistributedCache cache)
        {
            dbService = context;
            dbCache = cache;
        }

        // GET: api/Surah
        [HttpGet]
        public async Task<ActionResult<List<Surah>>> GetSurah()
        {

            List<Surah> suwar = await dbCache.GetRecordAsync<List<Surah>>("suwar");

            if(suwar == null)
            {
                suwar = await dbService.getSuwar();
                await dbCache.SetRecordAsync<List<Surah>>("suwar",suwar);
            }

            return suwar;
        }

        // GET: api/Surah/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Surah>> GetSurah(int id)
        {

            Surah surah = await dbCache.GetRecordAsync<Surah>($"surah{id}");
            
            if (surah == null)
            {
                surah = await dbService.getSurah(id);
                surah.isCached = false;
                await dbCache.SetRecordAsync<Surah>($"surah{id}", surah);
            }
            else
            {
                surah.isCached = true; 
            }


            try
            {
                surah.times = Data.Audio.Times.times[id - 1];
            }
            catch (Exception e) { }

            if (surah == null)
            {
                return NotFound();
            }

            return surah;
        }

        private bool SurahExists(int id)
        {
            return dbService.getDbContext().Surah.Any(e => e.id == id);
        }
    }
}
