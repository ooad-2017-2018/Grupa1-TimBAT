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
using ASPBatNet.Models;

namespace ASPBatNet.Controllers
{
    public class NotifikacijeController : ApiController
    {
        private ASPBatNetModel db = new ASPBatNetModel();

        // GET: api/Notifikacije
        public IQueryable<Notifikacije> GetNotifikacije()
        {
            return db.Notifikacije;
        }

        // GET: api/Notifikacije/5
        [ResponseType(typeof(Notifikacije))]
        public async Task<IHttpActionResult> GetNotifikacije(string id)
        {
            Notifikacije notifikacije = await db.Notifikacije.FindAsync(id);
            if (notifikacije == null)
            {
                return NotFound();
            }

            return Ok(notifikacije);
        }

        // PUT: api/Notifikacije/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNotifikacije(string id, Notifikacije notifikacije)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notifikacije.id)
            {
                return BadRequest();
            }

            db.Entry(notifikacije).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotifikacijeExists(id))
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

        // POST: api/Notifikacije
        [ResponseType(typeof(Notifikacije))]
        public async Task<IHttpActionResult> PostNotifikacije(Notifikacije notifikacije)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Notifikacije.Add(notifikacije);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NotifikacijeExists(notifikacije.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = notifikacije.id }, notifikacije);
        }

        // DELETE: api/Notifikacije/5
        [ResponseType(typeof(Notifikacije))]
        public async Task<IHttpActionResult> DeleteNotifikacije(string id)
        {
            Notifikacije notifikacije = await db.Notifikacije.FindAsync(id);
            if (notifikacije == null)
            {
                return NotFound();
            }

            db.Notifikacije.Remove(notifikacije);
            await db.SaveChangesAsync();

            return Ok(notifikacije);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NotifikacijeExists(string id)
        {
            return db.Notifikacije.Count(e => e.id == id) > 0;
        }
    }
}