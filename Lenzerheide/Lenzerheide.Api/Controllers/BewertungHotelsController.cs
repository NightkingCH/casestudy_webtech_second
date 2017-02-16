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
    public class BewertungHotelsController : ApiController
    {
        private LenzerheideEntities db = new LenzerheideEntities();

        // GET: api/BewertungHotels
        public IQueryable<BewertungHotel> GetBewertungHotel()
        {
            return db.BewertungHotel;
        }

        // GET: api/BewertungHotels/5
        [ResponseType(typeof(BewertungHotel))]
        public async Task<IHttpActionResult> GetBewertungHotel(int id)
        {
            BewertungHotel bewertungHotel = await db.BewertungHotel.FindAsync(id);
            if (bewertungHotel == null)
            {
                return NotFound();
            }

            return Ok(bewertungHotel);
        }

        // PUT: api/BewertungHotels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBewertungHotel(int id, BewertungHotel bewertungHotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bewertungHotel.Id)
            {
                return BadRequest();
            }

            db.Entry(bewertungHotel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BewertungHotelExists(id))
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

        // POST: api/BewertungHotels
        [ResponseType(typeof(BewertungHotel))]
        public async Task<IHttpActionResult> PostBewertungHotel(BewertungHotel bewertungHotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BewertungHotel.Add(bewertungHotel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bewertungHotel.Id }, bewertungHotel);
        }

        // DELETE: api/BewertungHotels/5
        [ResponseType(typeof(BewertungHotel))]
        public async Task<IHttpActionResult> DeleteBewertungHotel(int id)
        {
            BewertungHotel bewertungHotel = await db.BewertungHotel.FindAsync(id);
            if (bewertungHotel == null)
            {
                return NotFound();
            }

            db.BewertungHotel.Remove(bewertungHotel);
            await db.SaveChangesAsync();

            return Ok(bewertungHotel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BewertungHotelExists(int id)
        {
            return db.BewertungHotel.Count(e => e.Id == id) > 0;
        }
    }
}