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
    class UnidadMedidaController
    {


        static HttpClient cliente;
        static HttpContent content;
        static DataTable dt;

        static HttpResponseMessage res;

        public static string URL = "http://confety-001-site1.itempurl.com/UnidadDeMedida";
        public string ex = "usuarios/guardar";  
        public static async Task<DataTable> obtenerMedidas(string token)
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
    }
}
