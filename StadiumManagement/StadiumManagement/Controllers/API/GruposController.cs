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
using StadiumManagement.Models;

namespace StadiumManagement.Controllers.API
{
    [RoutePrefix("API/Grupos")]
    public class GruposController : ApiController
    {
        private ControleContext db = new ControleContext();

        // GET Personalizado
        [Route("GetGrupos/{userId}")]
        public IHttpActionResult GetGrupos(int userId)
        {
            var grupos = db.Grupos.Where(g => g.UserId == userId).ToList();
            var objetos = db.Grupos.Where(gd => gd.UserId == userId).ToList();
            var empresas = new List<Grupos>();

            foreach(var objeto in objetos)
            {
                empresas.Add(db.Grupos.Find(objeto.GrupoId));
            }


            var resposta = new
            {
                EmpresasChef = grupos,
                MatriculadoEm = objetos
            };

            return Ok(resposta);
        }

        // GET: api/Grupos
        public IQueryable<Grupos> GetGrupos()
        {
            return db.Grupos;
        }

        // GET: api/Grupos/5
        //[ResponseType(typeof(Grupos))]
        //public IHttpActionResult GetGrupos(int id)
        //{
        //    Grupos grupos = db.Grupos.Find(id);
        //    if (grupos == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(grupos);
        //}

        // PUT: api/Grupos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGrupos(int id, Grupos grupos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grupos.GrupoId)
            {
                return BadRequest();
            }

            db.Entry(grupos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GruposExists(id))
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

        // POST: api/Grupos
        [ResponseType(typeof(Grupos))]
        public IHttpActionResult PostGrupos(Grupos grupos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Grupos.Add(grupos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = grupos.GrupoId }, grupos);
        }

        // DELETE: api/Grupos/5
        [ResponseType(typeof(Grupos))]
        public IHttpActionResult DeleteGrupos(int id)
        {
            Grupos grupos = db.Grupos.Find(id);
            if (grupos == null)
            {
                return NotFound();
            }

            db.Grupos.Remove(grupos);
            db.SaveChanges();

            return Ok(grupos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GruposExists(int id)
        {
            return db.Grupos.Count(e => e.GrupoId == id) > 0;
        }
    }
}