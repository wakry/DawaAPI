using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DawaAPI.Data.HTML;
using DawaAPI.Data.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuranKareem.Data;
using QuranKareem.Data.Models;

namespace DawaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SurahController : ControllerBase
    {
        private QuranContext _context;

        public SurahController(QuranContext context)
        {
            _context = context;
        }

        // GET: api/Surah
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Surah>>> GetSurah()
        {
          //  QuranHTMLController htmlTable = new QuranHTMLController(_context);
            return await _context.getAllSuwar().ToListAsync();
        }

        // GET: api/Surah/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Surah>> GetSurah(int id)
        {

            var surah = await _context.getSurahWithId(id);

            try
            {
                surah.times = Data.Audio.Times.times[id - 1];
            }
            catch (Exception e) { }

            if (surah == null)
            {
                return NotFound();
            }

            //_context.styleAyahNumber(surah.ayat);
            return surah;
        }

        // GET: api/Surah/5
        [HttpGet("{id}w")]
        public async Task<ActionResult<Surah>> GetSurahWordByWord(int id)
        {

            var surah = await _context.getSurahWordByWord(id);
            try
            {
                surah.times = Data.Audio.Times.times[id - 1];
            }
            catch (Exception e) { }
         
            if (surah == null)
            {
                return NotFound();
            }

            //_context.styleAyahNumber(surah.ayat);
            return surah;
        }

        // PUT: api/Surah/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurah(int id, Surah surah)
        {
            if (id != surah.id)
            {
                return BadRequest();
            }

            _context.Entry(surah).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurahExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Surah
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Surah>> PostSurah(Surah surah)
        {
            _context.Surah.Add(surah);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSurah", new { id = surah.id }, surah);
        }

        // DELETE: api/Surah/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Surah>> DeleteSurah(int id)
        {
            var surah = await _context.Surah.FindAsync(id);
            if (surah == null)
            {
                return NotFound();
            }

            _context.Surah.Remove(surah);
            await _context.SaveChangesAsync();

            return surah;
        }

        private bool SurahExists(int id)
        {
            return _context.Surah.Any(e => e.id == id);
        }
    }
}
