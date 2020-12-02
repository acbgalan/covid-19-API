using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Covid19.DAL;
using Covid19.DAL.Models;
using Covid19.DAL.DTOs;
using System.Web.Http.Description;

namespace Covid19.API.Controllers
{
    public class CuestionarioController : ApiController
    {
        private CovidContext db = new CovidContext();

        // GET: api/cuestionario
        public List<Cuestionario> GetAll()
        {
            var query = db.Cuestionarios;
            return query.ToList();
        }

        // GET: api/cuestionario/5
        [ResponseType(typeof(Cuestionario))]
        public IHttpActionResult GetCuestionario(int? id)
        {
            Cuestionario cuestionario = db.Cuestionarios.Find(id);

            if (cuestionario == null)
            {
                return NotFound();
            }

            return Ok(cuestionario);
        }

        // POST: api/cuestionario
        [ResponseType(typeof(Cuestionario))]
        public IHttpActionResult PostCuestionario([FromBody] CuestionarioDto request)
        {
            if (!ModelState.IsValid || request == null)
            {
                return BadRequest(ModelState);
            }

            Cuestionario cuestionario = new Cuestionario()
            {
                Operario = request.Operario,
                Nombre = request.Nombre,
                Fecha = DateTime.Now.Date,
                Perfil = request.Perfil,
                Respuesta = request.Respuesta,
                FechaRespuesta = DateTime.Now
            };

            db.Cuestionarios.Add(cuestionario);
            db.SaveChanges();

            return CreatedAtRoute("Default", new { id = cuestionario.Id }, cuestionario);
        }

        // PUT: api/cuestionario
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCuestionario(int id, [FromBody] TomaTemperaturaDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Cuestionario cuestionario = db.Cuestionarios.Find(id);

            if (cuestionario == null)
            {
                return NotFound();
            }

            cuestionario.Temperatura = request.Temperatura;
            cuestionario.FechaTemperatura = DateTime.Now;
            cuestionario.Supervisor = request.Supervisor;
            cuestionario.SupervisorNombre = request.SupervisorNombre;

            db.Entry(cuestionario).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }


        [NonAction]
        public bool CuestionarioExists(int id)
        {
            return db.Cuestionarios.Where(x => x.Id == id).Count() > 0;
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }

    }
}
