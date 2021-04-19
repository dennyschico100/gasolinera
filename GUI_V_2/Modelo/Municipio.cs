using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolinera.Modelo
{
    class Municipio
    {
        private int id_municipio;
        private string nombre;
        private int id_departamento;

        public int Id_municipio
        {
            get
            {
                return id_municipio;
            }

            set
            {
                id_municipio = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public int Id_departamento
        {
            get
            {
                return id_departamento;
            }

            set
            {
                id_departamento = value;
            }
        }

        public Municipio(int id_municipio, string nombre, int id_departamento)
        {
            this.Id_municipio = id_municipio;
            this.Nombre = nombre;
            this.Id_departamento = id_departamento;
        }


    }

}
