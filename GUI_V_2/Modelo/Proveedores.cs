using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolinera.Modelo
{
    class Proveedores
    {

        private int id_proveedor;
        private string nombre;
        private string telefono;
        private int id_empresa;
        private int id_municipio;

        public int Id_proveedor
        {
            get
            {
                return id_proveedor;
            }

            set
            {
                id_proveedor = value;
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

        public Proveedores(int id_proveedor, string nombre, string telefono, int id_empresa, int id_municipio)
        {
            this.Id_proveedor = id_proveedor;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Id_empresa = id_empresa;
            this.Id_municipio = id_municipio;
        }

    }
}
