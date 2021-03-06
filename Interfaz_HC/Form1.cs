using Interfaz_HC.Models.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Interfaz_HC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void registrarbtn_Click(object sender, EventArgs e)
        {
            lbRespuesta.Text = "";
            string url = "http://192.168.0.9:90/api/DOCTOR";
            DOCTORRequest objDOCTOR = new DOCTORRequest();
            tipoRequest objtipo = new tipoRequest();
            EspecialidadRequest objEspecialidad = new EspecialidadRequest();
            historiaRequest objhistoria = new historiaRequest();

            objDOCTOR.Nombre = txtNombre.Text;
            objDOCTOR.Precio = Int32.Parse(txtApellido.Text);
            objDOCTOR.Cantidad = Int32.Parse(txtFono.Text);

            string resultado = Send<DOCTORRequest>(url, objDOCTOR, "POST");
            lbRespuesta.Text = resultado;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string respuesta = await GetDatos();
            List<ProductoRequest> lst = JsonConvert.DeserializeObject<List<ProductoRequest>>(respuesta);
            dataGridView1.DataSource = lst;
        }

        public async Task<string> GetDatos()
        {
            WebRequest objRequest = WebRequest.Create("http://192.168.0.9:800/api/producto");
            WebResponse objResponse = objRequest.GetResponse();
            StreamReader cadena = new StreamReader(objResponse.GetResponseStream());
            return await cadena.ReadToEndAsync();

        }


        public string Send<T>(string url, T objectRequest, string method = "POST")
        {
            string result = "";

            try
            {

                JavaScriptSerializer js = new JavaScriptSerializer();

                //serializamos el objeto
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(objectRequest);

                //peticion
                WebRequest request = WebRequest.Create(url);
                //headers
                request.Method = method;
                request.PreAuthenticate = true;
                request.ContentType = "application/json;charset=utf-8'";
                request.Timeout = 10000; //esto es opcional

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

            }
            catch (Exception e)
            {
                result = e.Message;

            }

            return result;
        }


    }
}
