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
    public class Tipo_SI_No_NSController : ApiController
    {
        private m_Emergencias_V3Entities db = new m_Emergencias_V3Entities();

        // GET: api/Tipo_SI_No_NS
        public IQueryable<Tipo_SI_No_NS> GetTipo_SI_No_NS()
        {
            return db.Tipo_SI_No_NS;
        }

        // GET: api/Tipo_SI_No_NS/5
        [ResponseType(typeof(Tipo_SI_No_NS))]
        public async Task<IHttpActionResult> GetTipo_SI_No_NS(byte id)
        {
            Tipo_SI_No_NS tipo_SI_No_NS = await db.Tipo_SI_No_NS.FindAsync(id);
            if (tipo_SI_No_NS == null)
            {
                return NotFound();
            }

            return Ok(tipo_SI_No_NS);
        }

        // PUT: api/Tipo_SI_No_NS/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTipo_SI_No_NS(byte id, Tipo_SI_No_NS tipo_SI_No_NS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipo_SI_No_NS.ID)
            {
                return BadRequest();
            }

            db.Entry(tipo_SI_No_NS).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tipo_SI_No_NSExists(id))
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

        // POST: api/Tipo_SI_No_NS
        [ResponseType(typeof(Tipo_SI_No_NS))]
        public async Task<IHttpActionResult> PostTipo_SI_No_NS(Tipo_SI_No_NS tipo_SI_No_NS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tipo_SI_No_NS.Add(tipo_SI_No_NS);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tipo_SI_No_NS.ID }, tipo_SI_No_NS);
        }

        // DELETE: api/Tipo_SI_No_NS/5
        [ResponseType(typeof(Tipo_SI_No_NS))]
        public async Task<IHttpActionResult> DeleteTipo_SI_No_NS(byte id)
        {
            Tipo_SI_No_NS tipo_SI_No_NS = await db.Tipo_SI_No_NS.FindAsync(id);
            if (tipo_SI_No_NS == null)
            {
                return NotFound();
            }

            db.Tipo_SI_No_NS.Remove(tipo_SI_No_NS);
            await db.SaveChangesAsync();

            return Ok(tipo_SI_No_NS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tipo_SI_No_NSExists(byte id)
        {
            return db.Tipo_SI_No_NS.Count(e => e.ID == id) > 0;
        }
    }
}