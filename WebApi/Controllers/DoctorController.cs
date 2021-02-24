using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class DoctorController : ApiController
    {
        [HttpGet]
        public IEnumerable<DOCTOR> Get()
        {
            using (HIST_CLINEntities bd = new HIST_CLINEntities())
            {
                var objDOCTOR = bd.DOCTOR.ToList();
                return objDOCTOR;
            }
        }

        [HttpGet]
        public IEnumerable<DOCTOR> Get(int id)
        {
            using (HIST_CLINEntities bd = new HIST_CLINEntities())
            {
                var objDOCTOR = bd.DOCTOR.Where(d => d.id_doctor == id).ToList();
                return objDOCTOR;
            }
        }

        [HttpGet]
        public IEnumerable<DOCTOR> Get(string dato)
        {
            using (HIST_CLINEntities bd = new HIST_CLINEntities())
            {
                var objDOCTOR = bd.DOCTOR.Where(d => d.nombre_doctor.Contains(dato)).ToList();
                return objDOCTOR;
            }
        }

        [HttpPost]
        public IHttpActionResult Add()
        {
            using (HIST_CLINEntities bd = new HIST_CLINEntities())
            {           
                    var objDOCTOR = new DOCTOR();
                    objDOCTOR.nombre_doctor = "Stephen";
                    objDOCTOR.apellido_doctor = "Paucara";
                    bd.DOCTOR.Add(objDOCTOR);
                    bd.SaveChanges();
            }
            return Ok("Nuevo registro exitoso");
        }
        
    }
}
