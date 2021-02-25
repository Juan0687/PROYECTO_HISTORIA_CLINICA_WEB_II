using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class EspecialidadController : ApiController
    {

        [HttpGet]
        public IEnumerable<ESPECIALIDAD> Get()
        {
            using (HIST_CLINEntities bd = new HIST_CLINEntities())
            {
                var objEspecialidad = bd.ESPECIALIDAD.ToList();
                return objEspecialidad;
            }
        }

        [HttpGet]
        public IEnumerable<ESPECIALIDAD> Get(int id)
        {
            using (HIST_CLINEntities bd = new HIST_CLINEntities())
            {
                var objEspecialidad = bd.ESPECIALIDAD.Where(d => d.id_especialidad == id).ToList();
                return objEspecialidad;
            }
        }

        [HttpGet]
        public IEnumerable<ESPECIALIDAD> Get(string dato)
        {
            using (HIST_CLINEntities bd = new HIST_CLINEntities())
            {
                var objEspecialidad = bd.ESPECIALIDAD.Where(d => d.especialidad1.Contains(dato)).ToList();
                return objEspecialidad;
            }
        }

        [HttpPost]
        public IHttpActionResult Add()
        {
            using (HIST_CLINEntities bd = new HIST_CLINEntities())
            {
                var objEspecialidad = new ESPECIALIDAD();
                objEspecialidad.especialidad1 = "si";
                bd.ESPECIALIDAD.Add(objEspecialidad);
                bd.SaveChanges();
            }
            return Ok("Nuevo registro exitoso");
        }

    }
}
