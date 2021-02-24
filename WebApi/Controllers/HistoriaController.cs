using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class HistoriaController : ApiController
    {


        [HttpGet]
        public IEnumerable<historia> Get()
        {
            using (HIST_CLINEntities bd = new HIST_CLINEntities())
            {
                var objhistoria = bd.historia.ToList();
                return objhistoria;
            }
        }

        [HttpGet]
        public IEnumerable<historia> Get(int id)
        {
            using (HIST_CLINEntities bd = new HIST_CLINEntities())
            {
                var objhistoria = bd.historia.Where(d => d.id_historia == id).ToList();
                return objhistoria;
            }
        }

        [HttpGet]
        public IEnumerable<historia> Get(string dato)
        {
            using (HIST_CLINEntities bd = new HIST_CLINEntities())
            {
                var objhistoria = bd.historia.Where(d => d.nombre.Contains(dato)).ToList();
                return objhistoria;
            }
        }

        [HttpPost]
        public IHttpActionResult Add()
        {
            using (HIST_CLINEntities bd = new HIST_CLINEntities())
            {
                var objhistoria = new historia();
                objhistoria.id_doctor = 1;
                objhistoria.id_especialidad = 2;
                objhistoria.id_tipo = 1;
                objhistoria.peso = "87";
                objhistoria.talla = "175";
                objhistoria.nombre = "Juan";
                objhistoria.apellido = "Perez";
                objhistoria.edad = 38;
                objhistoria.motivo_consulta = "prueba";
                objhistoria.alergias = "prueba_alergias";
                objhistoria.fecha = Convert.ToDateTime(25092019);
                bd.historia.Add(objhistoria);
                bd.SaveChanges();
            }
            return Ok("Nuevo registro exitoso");
        }


    }
}
