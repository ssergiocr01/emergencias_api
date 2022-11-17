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
    public class EmergenciasController : ApiController
    {
        private m_Emergencias_V3Entities db = new m_Emergencias_V3Entities();

        // GET: api/Emergencias
        public IQueryable<Emergencia> GetEmergencias()
        {
            return db.Emergencias;
        }

        // GET: api/Emergencias/5
        [ResponseType(typeof(Emergencia))]
        public async Task<IHttpActionResult> GetEmergencia(int id)
        {
            Emergencia emergencia = await db.Emergencias.FindAsync(id);
            if (emergencia == null)
            {
                return NotFound();
            }

            return Ok(emergencia);
        }

        // PUT: api/Emergencias/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmergencia(int id, Emergencia emergencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emergencia.ID)
            {
                return BadRequest();
            }

            db.Entry(emergencia).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmergenciaExists(id))
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

        // POST: api/Emergencias
        [ResponseType(typeof(Emergencia))]
        public async Task<IHttpActionResult> PostEmergencia(Emergencia emergencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Emergencias.Add(emergencia);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmergenciaExists(emergencia.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = emergencia.ID }, emergencia);
        }

        // DELETE: api/Emergencias/5
        [ResponseType(typeof(Emergencia))]
        public async Task<IHttpActionResult> DeleteEmergencia(int id)
        {
            Emergencia emergencia = await db.Emergencias.FindAsync(id);
            if (emergencia == null)
            {
                return NotFound();
            }

            db.Emergencias.Remove(emergencia);
            await db.SaveChangesAsync();

            return Ok(emergencia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmergenciaExists(int id)
        {
            return db.Emergencias.Count(e => e.ID == id) > 0;
        }
    }
}