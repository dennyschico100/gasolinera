using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolinera.Modelo
{
    class Departamento
    {
        private int id_departamento;
        private string nombre;

        public Departamento(int id_departamento, string nombre)
        {
            this.Id_departamento = id_departamento;
            this.Nombre = nombre;
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
    }
}
