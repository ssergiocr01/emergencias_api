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
using emergencias_api.Models;

namespace emergencias_api.Controllers
{
    public class InstitucionesController : ApiController
    {
        private m_Emergencias_V3Entities db = new m_Emergencias_V3Entities();

        // GET: api/Instituciones
        public IQueryable<Institucione> GetInstituciones()
        {
            return db.Instituciones;
        }

        // GET: api/Instituciones/5
        [ResponseType(typeof(Institucione))]
        public async Task<IHttpActionResult> GetInstitucione(int id)
        {
            Institucione institucione = await db.Instituciones.FindAsync(id);
            if (institucione == null)
            {
                return NotFound();
            }

            return Ok(institucione);
        }

        // PUT: api/Instituciones/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInstitucione(int id, Institucione institucione)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != institucione.ID)
            {
                return BadRequest();
            }

            db.Entry(institucione).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstitucioneExists(id))
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

        // POST: api/Instituciones
        [ResponseType(typeof(Institucione))]
        public async Task<IHttpActionResult> PostInstitucione(Institucione institucione)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Instituciones.Add(institucione);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = institucione.ID }, institucione);
        }

        // DELETE: api/Instituciones/5
        [ResponseType(typeof(Institucione))]
        public async Task<IHttpActionResult> DeleteInstitucione(int id)
        {
            Institucione institucione = await db.Instituciones.FindAsync(id);
            if (institucione == null)
            {
                return NotFound();
            }

            db.Instituciones.Remove(institucione);
            await db.SaveChangesAsync();

            return Ok(institucione);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InstitucioneExists(int id)
        {
            return db.Instituciones.Count(e => e.ID == id) > 0;
        }
    }
}