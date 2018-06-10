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
    public class KorisniciController : ApiController
    {
        private ASPBatNetModel db = new ASPBatNetModel();

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        // GET: api/Korisnici
        public IQueryable<Korisnici> GetKorisnici()
        {
            return db.Korisnici;
        }

        // GET: api/Korisnici/5
        [ResponseType(typeof(Korisnici))]
        public async Task<IHttpActionResult> GetKorisnici(string id)
        {
            Korisnici korisnici = await db.Korisnici.FindAsync(id);
            if (korisnici == null)
            {
                return NotFound();
            }

            return Ok(korisnici);
        }

        // PUT: api/Korisnici/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKorisnici(string id, Korisnici korisnici)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != korisnici.id)
            {
                return BadRequest();
            }

            db.Entry(korisnici).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KorisniciExists(id))
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

        // POST: api/Korisnici
        [ResponseType(typeof(Korisnici))]
        public async Task<IHttpActionResult> PostKorisnici(Korisnici korisnici)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Korisnici.Add(korisnici);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KorisniciExists(korisnici.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = korisnici.id }, korisnici);
        }

        // DELETE: api/Korisnici/5
        [ResponseType(typeof(Korisnici))]
        public async Task<IHttpActionResult> DeleteKorisnici(string id)
        {
            Korisnici korisnici = await db.Korisnici.FindAsync(id);
            if (korisnici == null)
            {
                return NotFound();
            }

            db.Korisnici.Remove(korisnici);
            await db.SaveChangesAsync();

            return Ok(korisnici);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KorisniciExists(string id)
        {
            return db.Korisnici.Count(e => e.id == id) > 0;
        }
    }
}