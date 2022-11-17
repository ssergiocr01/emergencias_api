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
    public class Datos_PruebaController : ApiController
    {
        private m_Emergencias_V3Entities db = new m_Emergencias_V3Entities();

        // GET: api/Datos_Prueba
        public IQueryable<Datos_Prueba> GetDatos_Prueba()
        {
            return db.Datos_Prueba;
        }

        // GET: api/Datos_Prueba/5
        [ResponseType(typeof(Datos_Prueba))]
        public async Task<IHttpActionResult> GetDatos_Prueba(int id)
        {
            Datos_Prueba datos_Prueba = await db.Datos_Prueba.FindAsync(id);
            if (datos_Prueba == null)
            {
                return NotFound();
            }

            return Ok(datos_Prueba);
        }

        // PUT: api/Datos_Prueba/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDatos_Prueba(int id, Datos_Prueba datos_Prueba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != datos_Prueba.ID_Datos_Inspeccion)
            {
                return BadRequest();
            }

            db.Entry(datos_Prueba).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Datos_PruebaExists(id))
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

        // POST: api/Datos_Prueba
        [ResponseType(typeof(Datos_Prueba))]
        public async Task<IHttpActionResult> PostDatos_Prueba(Datos_Prueba datos_Prueba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Datos_Prueba.Add(datos_Prueba);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = datos_Prueba.ID_Datos_Inspeccion }, datos_Prueba);
        }

        // DELETE: api/Datos_Prueba/5
        [ResponseType(typeof(Datos_Prueba))]
        public async Task<IHttpActionResult> DeleteDatos_Prueba(int id)
        {
            Datos_Prueba datos_Prueba = await db.Datos_Prueba.FindAsync(id);
            if (datos_Prueba == null)
            {
                return NotFound();
            }

            db.Datos_Prueba.Remove(datos_Prueba);
            await db.SaveChangesAsync();

            return Ok(datos_Prueba);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Datos_PruebaExists(int id)
        {
            return db.Datos_Prueba.Count(e => e.ID_Datos_Inspeccion == id) > 0;
        }
    }
}