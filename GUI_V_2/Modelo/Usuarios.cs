using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolinera.Modelo
{
    class Usuarios
    {

        private int id_usuario;
        private string nombre;
        private string clave;
        private string usuario;
        private string telefono;
        private string fecha_nacimiento;
        private string direccion_corta;
        private int id_municipio;
        private int id_rol;

        public int Id_usuario
        {
            get
            {
                return id_usuario;
            }

            set
            {
                id_usuario = value;
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
        public string Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }



        public string Clave
        {
            get
            {
                return clave;
            }

            set
            {
                clave = value;
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

        public string Fecha_nacimiento
        {
            get
            {
                return fecha_nacimiento;
            }

            set
            {
                fecha_nacimiento = value;
            }
        }

        public string Direccion_corta
        {
            get
            {
                return direccion_corta;
            }

            set
            {
                direccion_corta = value;
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

        public int Id_rol
        {
            get
            {
                return id_rol;
            }

            set
            {
                id_rol = value;
            }
        }
        public Usuarios() {

        }
        public Usuarios(Usuarios us )
        {
            this.Id_usuario = us.Id_usuario;
            this.Nombre = us.Nombre;
            this.usuario = us.usuario;
            this.Clave = us.Clave;
            this.Telefono = us.Telefono;
            this.Fecha_nacimiento = us.Fecha_nacimiento;
            this.Direccion_corta = us.Direccion_corta;
            this.Id_municipio = us.Id_municipio;
            this.Id_rol = us.Id_rol;
            
        }


    }
}
