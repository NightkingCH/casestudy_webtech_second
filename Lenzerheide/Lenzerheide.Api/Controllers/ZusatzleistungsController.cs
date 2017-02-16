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
    public class ZusatzleistungsController : ApiController
    {
        private LenzerheideEntities db = new LenzerheideEntities();

        // GET: api/Zusatzleistungs
        public IQueryable<Zusatzleistung> GetZusatzleistung()
        {
            return db.Zusatzleistung;
        }

        // GET: api/Zusatzleistungs/5
        [ResponseType(typeof(Zusatzleistung))]
        public async Task<IHttpActionResult> GetZusatzleistung(int id)
        {
            Zusatzleistung zusatzleistung = await db.Zusatzleistung.FindAsync(id);
            if (zusatzleistung == null)
            {
                return NotFound();
            }

            return Ok(zusatzleistung);
        }

        // PUT: api/Zusatzleistungs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutZusatzleistung(int id, Zusatzleistung zusatzleistung)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zusatzleistung.Id)
            {
                return BadRequest();
            }

            db.Entry(zusatzleistung).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZusatzleistungExists(id))
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

        // POST: api/Zusatzleistungs
        [ResponseType(typeof(Zusatzleistung))]
        public async Task<IHttpActionResult> PostZusatzleistung(Zusatzleistung zusatzleistung)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Zusatzleistung.Add(zusatzleistung);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = zusatzleistung.Id }, zusatzleistung);
        }

        // DELETE: api/Zusatzleistungs/5
        [ResponseType(typeof(Zusatzleistung))]
        public async Task<IHttpActionResult> DeleteZusatzleistung(int id)
        {
            Zusatzleistung zusatzleistung = await db.Zusatzleistung.FindAsync(id);
            if (zusatzleistung == null)
            {
                return NotFound();
            }

            db.Zusatzleistung.Remove(zusatzleistung);
            await db.SaveChangesAsync();

            return Ok(zusatzleistung);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZusatzleistungExists(int id)
        {
            return db.Zusatzleistung.Count(e => e.Id == id) > 0;
        }
    }
}