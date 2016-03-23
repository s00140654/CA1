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
    public class FixturesController : ApiController
    {
        private Ca1_RAD_302Context db = new Ca1_RAD_302Context();

        // GET: api/Fixtures
        public IQueryable<Fixture> GetFixtures()
        {
            return db.Fixtures;
        }

        // GET: api/Fixtures/5
        [ResponseType(typeof(Fixture))]
        public async Task<IHttpActionResult> GetFixture(int id)
        {
            Fixture fixture = await db.Fixtures.FindAsync(id);
            if (fixture == null)
            {
                return NotFound();
            }

            return Ok(fixture);
        }

        // PUT: api/Fixtures/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFixture(int id, Fixture fixture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fixture.Id)
            {
                return BadRequest();
            }

            db.Entry(fixture).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FixtureExists(id))
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

        // POST: api/Fixtures
        [ResponseType(typeof(Fixture))]
        public async Task<IHttpActionResult> PostFixture(Fixture fixture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fixtures.Add(fixture);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = fixture.Id }, fixture);
        }

        // DELETE: api/Fixtures/5
        [ResponseType(typeof(Fixture))]
        public async Task<IHttpActionResult> DeleteFixture(int id)
        {
            Fixture fixture = await db.Fixtures.FindAsync(id);
            if (fixture == null)
            {
                return NotFound();
            }

            db.Fixtures.Remove(fixture);
            await db.SaveChangesAsync();

            return Ok(fixture);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FixtureExists(int id)
        {
            return db.Fixtures.Count(e => e.Id == id) > 0;
        }
    }
}