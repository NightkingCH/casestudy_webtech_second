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
    public class Hotel_ZusatzleistungController : ApiController
    {
        private LenzerheideEntities db = new LenzerheideEntities();

        // GET: api/Hotel_Zusatzleistung
        public IQueryable<Hotel_Zusatzleistung> GetHotel_Zusatzleistung()
        {
            return db.Hotel_Zusatzleistung;
        }

        // GET: api/Hotel_Zusatzleistung/5
        [ResponseType(typeof(Hotel_Zusatzleistung))]
        public async Task<IHttpActionResult> GetHotel_Zusatzleistung(int id)
        {
            Hotel_Zusatzleistung hotel_Zusatzleistung = await db.Hotel_Zusatzleistung.FindAsync(id);
            if (hotel_Zusatzleistung == null)
            {
                return NotFound();
            }

            return Ok(hotel_Zusatzleistung);
        }

        // PUT: api/Hotel_Zusatzleistung/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHotel_Zusatzleistung(int id, Hotel_Zusatzleistung hotel_Zusatzleistung)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hotel_Zusatzleistung.Id)
            {
                return BadRequest();
            }

            db.Entry(hotel_Zusatzleistung).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Hotel_ZusatzleistungExists(id))
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

        // POST: api/Hotel_Zusatzleistung
        [ResponseType(typeof(Hotel_Zusatzleistung))]
        public async Task<IHttpActionResult> PostHotel_Zusatzleistung(Hotel_Zusatzleistung hotel_Zusatzleistung)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hotel_Zusatzleistung.Add(hotel_Zusatzleistung);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = hotel_Zusatzleistung.Id }, hotel_Zusatzleistung);
        }

        // DELETE: api/Hotel_Zusatzleistung/5
        [ResponseType(typeof(Hotel_Zusatzleistung))]
        public async Task<IHttpActionResult> DeleteHotel_Zusatzleistung(int id)
        {
            Hotel_Zusatzleistung hotel_Zusatzleistung = await db.Hotel_Zusatzleistung.FindAsync(id);
            if (hotel_Zusatzleistung == null)
            {
                return NotFound();
            }

            db.Hotel_Zusatzleistung.Remove(hotel_Zusatzleistung);
            await db.SaveChangesAsync();

            return Ok(hotel_Zusatzleistung);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Hotel_ZusatzleistungExists(int id)
        {
            return db.Hotel_Zusatzleistung.Count(e => e.Id == id) > 0;
        }
    }
}