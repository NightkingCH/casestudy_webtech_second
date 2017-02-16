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
    public class KundesController : ApiController
    {
        private LenzerheideEntities db = new LenzerheideEntities();

        // GET: api/Kundes
        public IQueryable<Kunde> GetKunde()
        {
            return db.Kunde;
        }

        // GET: api/Kundes/5
        [ResponseType(typeof(Kunde))]
        public async Task<IHttpActionResult> GetKunde(int id)
        {
            Kunde kunde = await db.Kunde.FindAsync(id);
            if (kunde == null)
            {
                return NotFound();
            }

            return Ok(kunde);
        }

        // PUT: api/Kundes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKunde(int id, Kunde kunde)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kunde.Id)
            {
                return BadRequest();
            }

            db.Entry(kunde).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KundeExists(id))
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

        // POST: api/Kundes
        [ResponseType(typeof(Kunde))]
        public async Task<IHttpActionResult> PostKunde(Kunde kunde)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kunde.Add(kunde);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = kunde.Id }, kunde);
        }

        // DELETE: api/Kundes/5
        [ResponseType(typeof(Kunde))]
        public async Task<IHttpActionResult> DeleteKunde(int id)
        {
            Kunde kunde = await db.Kunde.FindAsync(id);
            if (kunde == null)
            {
                return NotFound();
            }

            db.Kunde.Remove(kunde);
            await db.SaveChangesAsync();

            return Ok(kunde);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KundeExists(int id)
        {
            return db.Kunde.Count(e => e.Id == id) > 0;
        }
    }
}