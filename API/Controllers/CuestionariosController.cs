using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Covid19.DAL;
using Covid19.DAL.Models;

namespace Covid19.API.Controllers
{
    public class CuestionariosController : ApiController
    {
        private CovidContext db = new CovidContext();

        // GET: api/Cuestionarios
        public IQueryable<Cuestionario> GetCuestionarios()
        {
            return db.Cuestionarios;
        }

        // GET: api/Cuestionarios/5
        [ResponseType(typeof(Cuestionario))]
        public IHttpActionResult GetCuestionario(int id)
        {
            Cuestionario cuestionario = db.Cuestionarios.Find(id);
            if (cuestionario == null)
            {
                return NotFound();
            }

            return Ok(cuestionario);
        }

        // PUT: api/Cuestionarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCuestionario(int id, Cuestionario cuestionario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cuestionario.Id)
            {
                return BadRequest();
            }

            db.Entry(cuestionario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuestionarioExists(id))
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

        // POST: api/Cuestionarios
        [ResponseType(typeof(Cuestionario))]
        public IHttpActionResult PostCuestionario(Cuestionario cuestionario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cuestionarios.Add(cuestionario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cuestionario.Id }, cuestionario);
        }

        // DELETE: api/Cuestionarios/5
        [ResponseType(typeof(Cuestionario))]
        public IHttpActionResult DeleteCuestionario(int id)
        {
            Cuestionario cuestionario = db.Cuestionarios.Find(id);
            if (cuestionario == null)
            {
                return NotFound();
            }

            db.Cuestionarios.Remove(cuestionario);
            db.SaveChanges();

            return Ok(cuestionario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CuestionarioExists(int id)
        {
            return db.Cuestionarios.Count(e => e.Id == id) > 0;
        }
    }
}