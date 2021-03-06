using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_HC.Models.Request
{
    class historiaRequest
    {
        public float peso { get; set; }
        public float talla { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }
        public string motivo_consulta { get; set; }
        public string alergias { get; set; }
        public string fecha { get; set; }
    }
}
