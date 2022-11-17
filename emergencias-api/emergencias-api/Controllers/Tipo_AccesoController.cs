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
    public class Tipo_AccesoController : ApiController
    {
        private m_Emergencias_V3Entities db = new m_Emergencias_V3Entities();

        // GET: api/Tipo_Acceso
        public IQueryable<Tipo_Acceso> GetTipo_Acceso()
        {
            return db.Tipo_Acceso;
        }

        // GET: api/Tipo_Acceso/5
        [ResponseType(typeof(Tipo_Acceso))]
        public async Task<IHttpActionResult> GetTipo_Acceso(int id)
        {
            Tipo_Acceso tipo_Acceso = await db.Tipo_Acceso.FindAsync(id);
            if (tipo_Acceso == null)
            {
                return NotFound();
            }

            return Ok(tipo_Acceso);
        }

        // PUT: api/Tipo_Acceso/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTipo_Acceso(int id, Tipo_Acceso tipo_Acceso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipo_Acceso.ID)
            {
                return BadRequest();
            }

            db.Entry(tipo_Acceso).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tipo_AccesoExists(id))
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

        // POST: api/Tipo_Acceso
        [ResponseType(typeof(Tipo_Acceso))]
        public async Task<IHttpActionResult> PostTipo_Acceso(Tipo_Acceso tipo_Acceso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tipo_Acceso.Add(tipo_Acceso);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tipo_Acceso.ID }, tipo_Acceso);
        }

        // DELETE: api/Tipo_Acceso/5
        [ResponseType(typeof(Tipo_Acceso))]
        public async Task<IHttpActionResult> DeleteTipo_Acceso(int id)
        {
            Tipo_Acceso tipo_Acceso = await db.Tipo_Acceso.FindAsync(id);
            if (tipo_Acceso == null)
            {
                return NotFound();
            }

            db.Tipo_Acceso.Remove(tipo_Acceso);
            await db.SaveChangesAsync();

            return Ok(tipo_Acceso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tipo_AccesoExists(int id)
        {
            return db.Tipo_Acceso.Count(e => e.ID == id) > 0;
        }
    }
}