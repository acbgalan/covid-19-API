using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Covid19.DAL;
using Covid19.DAL.Models;
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
        public IHttpActionResult PostCuestionario(Cuestionario cuestionario)
        {
            if (!ModelState.IsValid || cuestionario == null)
            {
                return BadRequest(ModelState);
            }

            db.Cuestionarios.Add(cuestionario);
            db.SaveChanges();

            return Ok(cuestionario);
        }


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
