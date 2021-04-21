using Gasolinera.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_V_2.controladores
{
    class FacturaController
    {
        static HttpClient cliente;
        static HttpContent content;
        static DataTable dt;

        static HttpResponseMessage res;

        public static string URL = "http://confety-001-site1.itempurl.com/Factura";
        public string ex = "usuarios/guardar";
        public static async Task<DataTable> ObtenerDatos(string token)
        {
            dt = new DataTable();

            using (cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                /*
                 var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:55600/identity");
                 request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                 */
                using (res = await cliente.GetAsync(URL))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        using (content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();

                            if (data != null)
                            {
                                //Make sure to add a reference to System.Net.Http.Formatting.dll
                                dt = (DataTable)JsonConvert.DeserializeObject(data, typeof(DataTable));

                                Console.WriteLine(dt);
                                return dt;

                            }
                            else
                            {
                                MessageBox.Show(data);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(res.ToString());

                    }


                }
            }

            return null;
        }
        public static async Task<Productos> guardar(Producto productos, string acceso)
        {

            /*
            var person = new Person("John Doe", "gardener");

            var json = JsonConvert.SerializeObject(person);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            */
            cliente = new HttpClient();
            string accessToken = "";
            var jsonObject = JsonConvert.SerializeObject(productos);


            var data = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            using (cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("Authorization", "Bearer " + acceso);

                using (res = await cliente.PostAsync(URL, data))
                {
                    if (res.IsSuccessStatusCode)
                    {

                        using (content = res.Content)
                        {
                            string objResponse = await content.ReadAsStringAsync();
                            //user = (User)JsonConvert.DeserializeObject(objResponse, typeof(Usuarios));
                            MessageBox.Show("PRODUCTO GUARDADO");
                            //return user;
                        }
                    }
                    else
                    {
                        MessageBox.Show("OCURRIO UN ERROR ");

                    }
                }


            }
            return null;
        }
        public static async Task<Productos> modificar(Producto productos, string acceso)
        {

            /*
            var person = new Person("John Doe", "gardener");

            var json = JsonConvert.SerializeObject(person);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            */
            cliente = new HttpClient();
            string accessToken = "";
            var jsonObject = JsonConvert.SerializeObject(productos);
            MessageBox.Show(jsonObject);

            var data = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            using (cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("Authorization", "Bearer " + acceso);

                using (res = await cliente.PutAsync(URL, data))
                {
                    if (res.IsSuccessStatusCode)
                    {

                        using (content = res.Content)
                        {
                            string objResponse = await content.ReadAsStringAsync();
                            //user = (User)JsonConvert.DeserializeObject(objResponse, typeof(Usuarios));
                            MessageBox.Show(objResponse);
                            //return user;
                        }
                    }
                    else
                    {
                        //MessageBox.Show(res.ToString());

                    }
                }


            }
            return null;
        }

        public static async Task<Producto> obtenerPorId(int id, string acceso)
        {
            dt = new DataTable();
            Producto producto;
            using (cliente = new HttpClient())
            {

                cliente.DefaultRequestHeaders.Add("Authorization", "Bearer " + acceso);

                var URI = URL + "/" + id;
                using (res = await cliente.GetAsync(URI))
                {
                    URI = "";
                    if (res.IsSuccessStatusCode)
                    {
                        using (content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();

                            if (data != null)
                            {
                                //Make sure to add a reference to System.Net.Http.Formatting.dll
                                //dt = (DataTable)JsonConvert.DeserializeObject(data, typeof(DataTable));

                                producto = (Producto)JsonConvert.DeserializeObject(data, typeof(Producto));

                                //return producto;
                                return producto;


                            }
                            else
                            {
                            }

                        }
                    }
                    else
                    {

                    }


                }
            }
            return null;
        }

    }
}
