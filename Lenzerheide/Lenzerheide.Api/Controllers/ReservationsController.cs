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
    public class ReservationsController : ApiController
    {
        private LenzerheideEntities db = new LenzerheideEntities();

        // GET: api/Reservations
        public IQueryable<Reservation> GetReservation()
        {
            return db.Reservation;
        }

        // GET: api/Reservations/5
        [ResponseType(typeof(Reservation))]
        public async Task<IHttpActionResult> GetReservation(int id)
        {
            Reservation reservation = await db.Reservation.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        // PUT: api/Reservations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReservation(int id, Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reservation.Id)
            {
                return BadRequest();
            }

            db.Entry(reservation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
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

        // POST: api/Reservations
        [ResponseType(typeof(Reservation))]
        public async Task<IHttpActionResult> PostReservation(Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reservation.Add(reservation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = reservation.Id }, reservation);
        }

        // DELETE: api/Reservations/5
        [ResponseType(typeof(Reservation))]
        public async Task<IHttpActionResult> DeleteReservation(int id)
        {
            Reservation reservation = await db.Reservation.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            db.Reservation.Remove(reservation);
            await db.SaveChangesAsync();

            return Ok(reservation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReservationExists(int id)
        {
            return db.Reservation.Count(e => e.Id == id) > 0;
        }
    }
}