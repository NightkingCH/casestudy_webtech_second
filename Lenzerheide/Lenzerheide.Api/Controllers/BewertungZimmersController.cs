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
    public class BewertungZimmersController : ApiController
    {
        private LenzerheideEntities db = new LenzerheideEntities();

        // GET: api/BewertungZimmers
        public IQueryable<BewertungZimmer> GetBewertungZimmer()
        {
            return db.BewertungZimmer;
        }

        // GET: api/BewertungZimmers/5
        [ResponseType(typeof(BewertungZimmer))]
        public async Task<IHttpActionResult> GetBewertungZimmer(int id)
        {
            BewertungZimmer bewertungZimmer = await db.BewertungZimmer.FindAsync(id);
            if (bewertungZimmer == null)
            {
                return NotFound();
            }

            return Ok(bewertungZimmer);
        }

        // PUT: api/BewertungZimmers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBewertungZimmer(int id, BewertungZimmer bewertungZimmer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bewertungZimmer.Id)
            {
                return BadRequest();
            }

            db.Entry(bewertungZimmer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BewertungZimmerExists(id))
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

        // POST: api/BewertungZimmers
        [ResponseType(typeof(BewertungZimmer))]
        public async Task<IHttpActionResult> PostBewertungZimmer(BewertungZimmer bewertungZimmer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BewertungZimmer.Add(bewertungZimmer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bewertungZimmer.Id }, bewertungZimmer);
        }

        // DELETE: api/BewertungZimmers/5
        [ResponseType(typeof(BewertungZimmer))]
        public async Task<IHttpActionResult> DeleteBewertungZimmer(int id)
        {
            BewertungZimmer bewertungZimmer = await db.BewertungZimmer.FindAsync(id);
            if (bewertungZimmer == null)
            {
                return NotFound();
            }

            db.BewertungZimmer.Remove(bewertungZimmer);
            await db.SaveChangesAsync();

            return Ok(bewertungZimmer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BewertungZimmerExists(int id)
        {
            return db.BewertungZimmer.Count(e => e.Id == id) > 0;
        }
    }
}