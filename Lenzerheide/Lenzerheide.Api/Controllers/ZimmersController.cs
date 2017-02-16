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
    public class ZimmersController : ApiController
    {
        private LenzerheideEntities db = new LenzerheideEntities();

        // GET: api/Zimmers
        public IQueryable<Zimmer> GetZimmer()
        {
            return db.Zimmer;
        }

        // GET: api/Zimmers/5
        [ResponseType(typeof(Zimmer))]
        public async Task<IHttpActionResult> GetZimmer(int id)
        {
            Zimmer zimmer = await db.Zimmer.FindAsync(id);
            if (zimmer == null)
            {
                return NotFound();
            }

            return Ok(zimmer);
        }

        // PUT: api/Zimmers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutZimmer(int id, Zimmer zimmer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zimmer.Id)
            {
                return BadRequest();
            }

            db.Entry(zimmer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZimmerExists(id))
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

        // POST: api/Zimmers
        [ResponseType(typeof(Zimmer))]
        public async Task<IHttpActionResult> PostZimmer(Zimmer zimmer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Zimmer.Add(zimmer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = zimmer.Id }, zimmer);
        }

        // DELETE: api/Zimmers/5
        [ResponseType(typeof(Zimmer))]
        public async Task<IHttpActionResult> DeleteZimmer(int id)
        {
            Zimmer zimmer = await db.Zimmer.FindAsync(id);
            if (zimmer == null)
            {
                return NotFound();
            }

            db.Zimmer.Remove(zimmer);
            await db.SaveChangesAsync();

            return Ok(zimmer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZimmerExists(int id)
        {
            return db.Zimmer.Count(e => e.Id == id) > 0;
        }
    }
}