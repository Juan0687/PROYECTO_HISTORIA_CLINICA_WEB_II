using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class TipoController : ApiController
    {

        [HttpGet]
        public IEnumerable<TIPO_SEGURO> Get()
        {
            using (HIST_CLINEntities bd = new HIST_CLINEntities())
            {
                var objtipo = bd.TIPO_SEGURO.ToList();
                return objtipo;
            }
        }

        [HttpGet]
        public IEnumerable<TIPO_SEGURO> Get(int id)
        {
            using (HIST_CLINEntities bd = new HIST_CLINEntities())
            {
                var objtipo = bd.TIPO_SEGURO.Where(d => d.id_tipo == id).ToList();
                return objtipo;
            }
        }

        [HttpGet]
        public IEnumerable<TIPO_SEGURO> Get(string dato)
        {
            using (HIST_CLINEntities bd = new HIST_CLINEntities())
            {
                var objtipo = bd.TIPO_SEGURO.Where(d => d.tipo.Contains(dato)).ToList();
                return objtipo;
            }
        }

        [HttpPost]
        public IHttpActionResult Add()
        {
            using (HIST_CLINEntities bd = new HIST_CLINEntities())
            {
                var objtipo = new TIPO_SEGURO();
                objtipo.tipo = "si";
                bd.TIPO_SEGURO.Add(objtipo);
                bd.SaveChanges();
            }
            return Ok("Nuevo registro exitoso");
        }

    }
}
