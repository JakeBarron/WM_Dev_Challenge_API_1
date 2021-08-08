using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WM_Dev_Challenge_API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitlesController : ControllerBase
    {
        private readonly TitlesContext _context;

        public TitlesController(TitlesContext context)
        {
            _context = context;
        }

        // GET: api/Titles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Title>>> GetTitles()
        {
            return await _context.Titles.ToListAsync();
        }

        // GET: api/Titles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Title>> GetTitle(int id)
        {
            var title = await _context.Titles
                .Include(t => t.Awards)
                .Include(t => t.StoryLines)
                .Include(t => t.TitleGenres)
                .Include(t => t.OtherNames)
                .FirstOrDefaultAsync(t => t.TitleId == id);

            var relevantGenreNames = await _context.Genres.Where(genre => title.TitleGenres.Select(tg => tg.GenreId).Contains(genre.Id)).Select(g => g.Name).ToListAsync();

            title.GenreNames = relevantGenreNames;

            if (title == null)
            {
                return NotFound();
            }

            return title;
        }


        [HttpGet("search/{searchTerm}")]
        public async Task<ActionResult<IEnumerable<Title>>> SearchByTitleName(string searchTerm)
        {
            return await _context.Titles.Where(title => title.TitleName.Contains(searchTerm)).ToListAsync();
        }


        // PUT: api/Titles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitle(int id, Title title)
        {
            if (id != title.TitleId)
            {
                return BadRequest();
            }

            _context.Entry(title).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitleExists(id))
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


        // POST: api/Titles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Title>> PostTitle(Title title)
        {
            _context.Titles.Add(title);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TitleExists(title.TitleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTitle", new { id = title.TitleId }, title);
        }

        // DELETE: api/Titles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Title>> DeleteTitle(int id)
        {
            var title = await _context.Titles.FindAsync(id);
            if (title == null)
            {
                return NotFound();
            }

            _context.Titles.Remove(title);
            await _context.SaveChangesAsync();

            return title;
        }

        private bool TitleExists(int id)
        {
            return _context.Titles.Any(e => e.TitleId == id);
        }
    }
}
