using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz_HC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbRespuesta.Text = "";
            string url = "http://192.168.0.9:800/api/producto";
            ProductoRequest objProducto = new ProductoRequest();
            objProducto.Nombre = txtNombre.Text;
            objProducto.Precio = Int32.Parse(txtApellido.Text);
            objProducto.Cantidad = Int32.Parse(txtFono.Text);

            string resultado = Send<ProductoRequest>(url, objProducto, "POST");
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
