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
    public class AdressesController : ApiController
    {
        private LenzerheideEntities db = new LenzerheideEntities();

        // GET: api/Adresses
        public IQueryable<Adresse> GetAdresse()
        {
            return db.Adresse;
        }

        // GET: api/Adresses/5
        [ResponseType(typeof(Adresse))]
        public async Task<IHttpActionResult> GetAdresse(int id)
        {
            Adresse adresse = await db.Adresse.FindAsync(id);
            if (adresse == null)
            {
                return NotFound();
            }

            return Ok(adresse);
        }

        // PUT: api/Adresses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdresse(int id, Adresse adresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adresse.Id)
            {
                return BadRequest();
            }

            db.Entry(adresse).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdresseExists(id))
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

        // POST: api/Adresses
        [ResponseType(typeof(Adresse))]
        public async Task<IHttpActionResult> PostAdresse(Adresse adresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Adresse.Add(adresse);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = adresse.Id }, adresse);
        }

        // DELETE: api/Adresses/5
        [ResponseType(typeof(Adresse))]
        public async Task<IHttpActionResult> DeleteAdresse(int id)
        {
            Adresse adresse = await db.Adresse.FindAsync(id);
            if (adresse == null)
            {
                return NotFound();
            }

            db.Adresse.Remove(adresse);
            await db.SaveChangesAsync();

            return Ok(adresse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdresseExists(int id)
        {
            return db.Adresse.Count(e => e.Id == id) > 0;
        }
    }
}