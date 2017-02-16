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
    public class LoginsController : ApiController
    {
        private LenzerheideEntities db = new LenzerheideEntities();

        // GET: api/Logins
        public IQueryable<Login> GetLogin()
        {
            return db.Login;
        }

        // GET: api/Logins/5
        [ResponseType(typeof(Login))]
        public async Task<IHttpActionResult> GetLogin(int id)
        {
            Login login = await db.Login.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }

            return Ok(login);
        }

        // PUT: api/Logins/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLogin(int id, Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != login.Id)
            {
                return BadRequest();
            }

            db.Entry(login).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginExists(id))
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

        // POST: api/Logins
        [ResponseType(typeof(Login))]
        public async Task<IHttpActionResult> PostLogin(Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Login.Add(login);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = login.Id }, login);
        }

        // DELETE: api/Logins/5
        [ResponseType(typeof(Login))]
        public async Task<IHttpActionResult> DeleteLogin(int id)
        {
            Login login = await db.Login.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }

            db.Login.Remove(login);
            await db.SaveChangesAsync();

            return Ok(login);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LoginExists(int id)
        {
            return db.Login.Count(e => e.Id == id) > 0;
        }
    }
}