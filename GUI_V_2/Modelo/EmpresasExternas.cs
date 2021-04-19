using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolinera.Modelo
{
    class EmpresasExternas
    {
        private int id_empresa;
        private string nombre;
        private string telefono;

        public EmpresasExternas(int id_empresa, string nombre, string telefono)
        {
            this.Id_empresa = id_empresa;
            this.Nombre = nombre;
            this.Telefono = telefono;
        }

        public int Id_empresa
        {
            get
            {
                return id_empresa;
            }

            set
            {
                id_empresa = value;
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

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }
    }
}
