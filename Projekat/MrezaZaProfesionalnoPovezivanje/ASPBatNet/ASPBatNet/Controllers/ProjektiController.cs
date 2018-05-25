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
    public class ProjektiController : ApiController
    {
        private MrezaModel db = new MrezaModel();

        // GET: api/Projekti
        public IQueryable<Projekti> GetProjekti()
        {
            return db.Projekti;
        }

        // GET: api/Projekti/5
        [ResponseType(typeof(Projekti))]
        public async Task<IHttpActionResult> GetProjekti(string id)
        {
            Projekti projekti = await db.Projekti.FindAsync(id);
            if (projekti == null)
            {
                return NotFound();
            }

            return Ok(projekti);
        }

        // PUT: api/Projekti/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProjekti(string id, Projekti projekti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projekti.id)
            {
                return BadRequest();
            }

            db.Entry(projekti).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjektiExists(id))
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

        // POST: api/Projekti
        [ResponseType(typeof(Projekti))]
        public async Task<IHttpActionResult> PostProjekti(Projekti projekti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Projekti.Add(projekti);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProjektiExists(projekti.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = projekti.id }, projekti);
        }

        // DELETE: api/Projekti/5
        [ResponseType(typeof(Projekti))]
        public async Task<IHttpActionResult> DeleteProjekti(string id)
        {
            Projekti projekti = await db.Projekti.FindAsync(id);
            if (projekti == null)
            {
                return NotFound();
            }

            db.Projekti.Remove(projekti);
            await db.SaveChangesAsync();

            return Ok(projekti);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjektiExists(string id)
        {
            return db.Projekti.Count(e => e.id == id) > 0;
        }
    }
}