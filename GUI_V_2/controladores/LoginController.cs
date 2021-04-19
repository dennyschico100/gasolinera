﻿using Gasolinera.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gasolinera.controladores
{
    class LoginController
    {
        static HttpClient  cliente;
        static HttpContent content;
        static HttpResponseMessage res;
        static DataTable dt;

        private static string URL = "http://confety-001-site1.itempurl.com/login/authenticate";
        public LoginController()
        {

        }


     
        public static async Task<Usuarios> login(Login login)
        {
            cliente = new HttpClient();
            var jsonObject = JsonConvert.SerializeObject(login);

            var data = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            using (cliente = new HttpClient())
            {
                using (res = await cliente.PostAsync(URL, data))
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

    }
}
