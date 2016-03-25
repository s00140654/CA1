using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Ca1_RAD_302.Models;

namespace Ca1_RAD_302.Controllers
{
    public class MatchesController : ApiController
    {
        private Ca1_RAD_302Context db = new Ca1_RAD_302Context();

        // GET: api/Matches
        public IQueryable<MatchDTO> GetMatches()
        {
           
            var matches = from m in db.Matches
                          select new MatchDTO()
                          {
                              Id = m.Id,
                              MatchTitle = m.MatchTitle,
                              CompetitionName = m.Fixture.Name
                              
                          };
            return matches;
        }

        // GET: api/Matches/5
        [ResponseType(typeof(Match))]
        public async Task<IHttpActionResult> GetMatch(int id)
        {

            var book = await db.Matches.Include(m => m.Fixture).Select(m =>
         new MatchDetailsDTO()
         {
             Id = m.Id,
             MatchTitle = m.MatchTitle,
             KickOff = m.KickOff,
             HomeTeam = m.HomeTeam,
             AwayTeam = m.AwayTeam,
             Draw = m.Draw,
             HomePrice = m.HomePrice,
             AwayPrice = m.AwayPrice,
             DrawPrice = m.DrawPrice,
             CompetitionName = m.Fixture.Name




         }).SingleOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
            
        }

        // PUT: api/Matches/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMatch(int id, Match match)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != match.Id)
            {
                return BadRequest();
            }

            db.Entry(match).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Matches
        [ResponseType(typeof(Match))]
        public async Task<IHttpActionResult> PostMatch(Match match)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Matches.Add(match);
            await db.SaveChangesAsync();

            db.Entry(match).Reference(x => x.Fixture).Load();

            var dto = new MatchDTO()
            {
                Id = match.Id,
                MatchTitle = match.MatchTitle,
                CompetitionName = match.Fixture.Name
            };

            return CreatedAtRoute("DefaultApi", new { id = match.Id }, match);
        }

        // DELETE: api/Matches/5
        [ResponseType(typeof(Match))]
        public async Task<IHttpActionResult> DeleteMatch(int id)
        {
            Match match = await db.Matches.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }

            db.Matches.Remove(match);
            await db.SaveChangesAsync();

            return Ok(match);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MatchExists(int id)
        {
            return db.Matches.Count(e => e.Id == id) > 0;
        }
    }
}