using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolinera.Modelo
{
    class User
    {

        public string nombre = "Ricargo";
        public string apellido = "Rosa apellido prueba csharp";
        public string email = "pruebapodadasdsadasdsasst@gmail.com";
        public string dui = "98789";
        public int sexo = 1;
        public int rol = 3;
        public string telefono = "73580618";
        public string password1="presupuestos012456789";
        
        public User()
        {

        }

        public User(User u )
        {
            this.nombre = u.nombre;
            this.apellido = u.apellido;
            this.email = u.email;
            this.dui = u.dui;
            this.sexo = u.sexo;
            this.rol = u.rol;
            this.telefono = u.telefono;
            this.password1 = u.password1;
        }
    }
}

