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
    public class TehnologijeController : ApiController
    {
        private MrezaModel db = new MrezaModel();

        // GET: api/Tehnologije
        public IQueryable<Tehnologije> GetTehnologije()
        {
            return db.Tehnologije;
        }

        // GET: api/Tehnologije/5
        [ResponseType(typeof(Tehnologije))]
        public async Task<IHttpActionResult> GetTehnologije(string id)
        {
            Tehnologije tehnologije = await db.Tehnologije.FindAsync(id);
            if (tehnologije == null)
            {
                return NotFound();
            }

            return Ok(tehnologije);
        }

        // PUT: api/Tehnologije/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTehnologije(string id, Tehnologije tehnologije)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tehnologije.id)
            {
                return BadRequest();
            }

            db.Entry(tehnologije).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TehnologijeExists(id))
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

        // POST: api/Tehnologije
        [ResponseType(typeof(Tehnologije))]
        public async Task<IHttpActionResult> PostTehnologije(Tehnologije tehnologije)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tehnologije.Add(tehnologije);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TehnologijeExists(tehnologije.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tehnologije.id }, tehnologije);
        }

        // DELETE: api/Tehnologije/5
        [ResponseType(typeof(Tehnologije))]
        public async Task<IHttpActionResult> DeleteTehnologije(string id)
        {
            Tehnologije tehnologije = await db.Tehnologije.FindAsync(id);
            if (tehnologije == null)
            {
                return NotFound();
            }

            db.Tehnologije.Remove(tehnologije);
            await db.SaveChangesAsync();

            return Ok(tehnologije);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TehnologijeExists(string id)
        {
            return db.Tehnologije.Count(e => e.id == id) > 0;
        }
    }
}