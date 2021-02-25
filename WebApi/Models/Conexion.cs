using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace WebApi.Models
{
    public class Conexion
    {

        public string CadenaConexion { get; set; }
        public string Consulta { get; set; }
        public DataTable DT = new DataTable();
        private SqlDataAdapter AD;

        public Conexion()
        {
            CadenaConexion = "";
            Consulta = "";
        }
        public Conexion(string ConsultaSQL)
        {
            CadenaConexion = "";
            Consulta = ConsultaSQL;
        }
        public Conexion (string ConsultaSQL, string Cadena)

        {
            CadenaConexion = Cadena;
            Consulta = ConsultaSQL;
        }
    }
}