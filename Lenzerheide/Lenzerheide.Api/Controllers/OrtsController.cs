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
    public class OrtsController : ApiController
    {
        private LenzerheideEntities db = new LenzerheideEntities();

        // GET: api/Orts
        public IQueryable<Ort> GetOrt()
        {
            return db.Ort;
        }

        // GET: api/Orts/5
        [ResponseType(typeof(Ort))]
        public async Task<IHttpActionResult> GetOrt(int id)
        {
            Ort ort = await db.Ort.FindAsync(id);
            if (ort == null)
            {
                return NotFound();
            }

            return Ok(ort);
        }

        // PUT: api/Orts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrt(int id, Ort ort)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ort.Id)
            {
                return BadRequest();
            }

            db.Entry(ort).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrtExists(id))
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

        // POST: api/Orts
        [ResponseType(typeof(Ort))]
        public async Task<IHttpActionResult> PostOrt(Ort ort)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ort.Add(ort);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ort.Id }, ort);
        }

        // DELETE: api/Orts/5
        [ResponseType(typeof(Ort))]
        public async Task<IHttpActionResult> DeleteOrt(int id)
        {
            Ort ort = await db.Ort.FindAsync(id);
            if (ort == null)
            {
                return NotFound();
            }

            db.Ort.Remove(ort);
            await db.SaveChangesAsync();

            return Ok(ort);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrtExists(int id)
        {
            return db.Ort.Count(e => e.Id == id) > 0;
        }
    }
}