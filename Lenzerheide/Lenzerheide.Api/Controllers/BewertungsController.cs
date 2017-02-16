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
using Lenzerheide.Data;

namespace Lenzerheide.Api.Controllers
{
    public class BewertungsController : ApiController
    {
        private LenzerheideEntities db = new LenzerheideEntities();

        // GET: api/Bewertungs
        public IQueryable<Bewertung> GetBewertung()
        {
            return db.Bewertung;
        }

        // GET: api/Bewertungs/5
        [ResponseType(typeof(Bewertung))]
        public async Task<IHttpActionResult> GetBewertung(int id)
        {
            Bewertung bewertung = await db.Bewertung.FindAsync(id);
            if (bewertung == null)
            {
                return NotFound();
            }

            return Ok(bewertung);
        }

        // PUT: api/Bewertungs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBewertung(int id, Bewertung bewertung)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bewertung.Id)
            {
                return BadRequest();
            }

            db.Entry(bewertung).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BewertungExists(id))
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

        // POST: api/Bewertungs
        [ResponseType(typeof(Bewertung))]
        public async Task<IHttpActionResult> PostBewertung(Bewertung bewertung)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bewertung.Add(bewertung);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bewertung.Id }, bewertung);
        }

        // DELETE: api/Bewertungs/5
        [ResponseType(typeof(Bewertung))]
        public async Task<IHttpActionResult> DeleteBewertung(int id)
        {
            Bewertung bewertung = await db.Bewertung.FindAsync(id);
            if (bewertung == null)
            {
                return NotFound();
            }

            db.Bewertung.Remove(bewertung);
            await db.SaveChangesAsync();

            return Ok(bewertung);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BewertungExists(int id)
        {
            return db.Bewertung.Count(e => e.Id == id) > 0;
        }
    }
}