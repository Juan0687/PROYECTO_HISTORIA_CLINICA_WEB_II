//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi
{
    using System;
    using System.Collections.Generic;
    
    public partial class historia
    {
        public int id_historia { get; set; }
        public int id_doctor { get; set; }
        public int id_especialidad { get; set; }
        public int id_tipo { get; set; }
        public string peso { get; set; }
        public string talla { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }
        public string motivo_consulta { get; set; }
        public string alergias { get; set; }
        public System.DateTime fecha { get; set; }
    
        public virtual DOCTOR DOCTOR { get; set; }
        public virtual ESPECIALIDAD ESPECIALIDAD { get; set; }
        public virtual TIPO_SEGURO TIPO_SEGURO { get; set; }
    }
}
