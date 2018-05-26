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
    public class PorukeController : ApiController
    {
<<<<<<< HEAD
        private ASPBatNetModel db = new ASPBatNetModel();
=======
        private MrezaModel db = new MrezaModel();
>>>>>>> 45dffc5a8043da3768f2ab4f342d4af552579fbc

        // GET: api/Poruke
        public IQueryable<Poruke> GetPoruke()
        {
            return db.Poruke;
        }

        // GET: api/Poruke/5
        [ResponseType(typeof(Poruke))]
        public async Task<IHttpActionResult> GetPoruke(string id)
        {
            Poruke poruke = await db.Poruke.FindAsync(id);
            if (poruke == null)
            {
                return NotFound();
            }

            return Ok(poruke);
        }

        // PUT: api/Poruke/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPoruke(string id, Poruke poruke)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != poruke.id)
            {
                return BadRequest();
            }

            db.Entry(poruke).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PorukeExists(id))
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

        // POST: api/Poruke
        [ResponseType(typeof(Poruke))]
        public async Task<IHttpActionResult> PostPoruke(Poruke poruke)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Poruke.Add(poruke);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PorukeExists(poruke.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = poruke.id }, poruke);
        }

        // DELETE: api/Poruke/5
        [ResponseType(typeof(Poruke))]
        public async Task<IHttpActionResult> DeletePoruke(string id)
        {
            Poruke poruke = await db.Poruke.FindAsync(id);
            if (poruke == null)
            {
                return NotFound();
            }

            db.Poruke.Remove(poruke);
            await db.SaveChangesAsync();

            return Ok(poruke);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PorukeExists(string id)
        {
            return db.Poruke.Count(e => e.id == id) > 0;
        }
    }
}