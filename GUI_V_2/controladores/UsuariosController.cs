﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Gasolinera.Modelo;
using System.Windows.Forms;
using System.Data;
using Newtonsoft.Json;
using Gasolinera.Modelo;
using System.IO;

namespace Gasolinera.controladores
{
    class UsuariosController
    {
        static HttpClient cliente;
        static HttpContent content;
        static DataTable dt;

        static HttpResponseMessage res;
        
        private static string URL = "http://confety-001-site1.itempurl.com/Usuarios";
        public string ex = "usuarios/guardar";

        public UsuariosController()
        {

        }

        public static async Task<DataTable> ObtenerDatos()
        {
            dt = new DataTable();

            using (cliente = new HttpClient())
            {
                using (res = await cliente.GetAsync("https://api.salud.gob.sv/departamentos?idPais=68"))
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
                    }

                }
            }

            return null;
        }

        public static async Task<User> guardar(Usuarios user)
        {

            /*
            var person = new Person("John Doe", "gardener");

            var json = JsonConvert.SerializeObject(person);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            */
            cliente = new HttpClient();
            var jsonObject = JsonConvert.SerializeObject(user);
            
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

        public static async Task<DataTable> obtenerDepartamentos()
        {
            dt = new DataTable();

            using (cliente = new HttpClient())
            {
                using (res = await cliente.GetAsync("https://api.salud.gob.sv/departamentos?idPais=68"))
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
                    }

                }
            }

            return null;
        }

        public static async Task<DataTable> obtenerMunicipios(int id )
        {
            dt = new DataTable();

            using (cliente = new HttpClient())
            {
                using (res = await cliente.GetAsync("https://api.salud.gob.sv/municipios?idDepartamento="+id))
                {

                    using (content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();

                        if (data != null)
                        {
                            dt = (DataTable)JsonConvert.DeserializeObject(data, typeof(DataTable));

                            Console.WriteLine(dt);
                            return dt;

                        }
                    }

                }
            }

            return null;

        }

        public async Task<Usuarios> buscarUsuario(int id)
        {
            Usuarios user;
            using (cliente = new HttpClient())
            {
                using (res = await cliente.GetAsync(URL))
                {

                    if (res.IsSuccessStatusCode)
                    {
                        using (content = res.Content)
                        {
                            string objResponse = await content.ReadAsStringAsync();
                            user = (Usuarios)JsonConvert.DeserializeObject(objResponse, typeof(Usuarios));
                            return user;

                        }
                    }
                }

            }
            return null;
        }

        
    }


}