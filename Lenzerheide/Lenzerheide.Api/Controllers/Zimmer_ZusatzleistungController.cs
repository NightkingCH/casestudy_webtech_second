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
    public class Zimmer_ZusatzleistungController : ApiController
    {
        private LenzerheideEntities db = new LenzerheideEntities();

        // GET: api/Zimmer_Zusatzleistung
        public IQueryable<Zimmer_Zusatzleistung> GetZimmer_Zusatzleistung()
        {
            return db.Zimmer_Zusatzleistung;
        }

        // GET: api/Zimmer_Zusatzleistung/5
        [ResponseType(typeof(Zimmer_Zusatzleistung))]
        public async Task<IHttpActionResult> GetZimmer_Zusatzleistung(int id)
        {
            Zimmer_Zusatzleistung zimmer_Zusatzleistung = await db.Zimmer_Zusatzleistung.FindAsync(id);
            if (zimmer_Zusatzleistung == null)
            {
                return NotFound();
            }

            return Ok(zimmer_Zusatzleistung);
        }

        // PUT: api/Zimmer_Zusatzleistung/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutZimmer_Zusatzleistung(int id, Zimmer_Zusatzleistung zimmer_Zusatzleistung)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zimmer_Zusatzleistung.Id)
            {
                return BadRequest();
            }

            db.Entry(zimmer_Zusatzleistung).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Zimmer_ZusatzleistungExists(id))
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

        // POST: api/Zimmer_Zusatzleistung
        [ResponseType(typeof(Zimmer_Zusatzleistung))]
        public async Task<IHttpActionResult> PostZimmer_Zusatzleistung(Zimmer_Zusatzleistung zimmer_Zusatzleistung)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Zimmer_Zusatzleistung.Add(zimmer_Zusatzleistung);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = zimmer_Zusatzleistung.Id }, zimmer_Zusatzleistung);
        }

        // DELETE: api/Zimmer_Zusatzleistung/5
        [ResponseType(typeof(Zimmer_Zusatzleistung))]
        public async Task<IHttpActionResult> DeleteZimmer_Zusatzleistung(int id)
        {
            Zimmer_Zusatzleistung zimmer_Zusatzleistung = await db.Zimmer_Zusatzleistung.FindAsync(id);
            if (zimmer_Zusatzleistung == null)
            {
                return NotFound();
            }

            db.Zimmer_Zusatzleistung.Remove(zimmer_Zusatzleistung);
            await db.SaveChangesAsync();

            return Ok(zimmer_Zusatzleistung);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Zimmer_ZusatzleistungExists(int id)
        {
            return db.Zimmer_Zusatzleistung.Count(e => e.Id == id) > 0;
        }
    }
}