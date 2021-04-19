using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolinera.Modelo
{
    class Categoria
    {
        private int id_categorial;
        private string nombre;

        public Categoria(int id_categorial, string nombre)
        {
            this.Id_categorial = id_categorial;
            this.Nombre = nombre;
        }

        public int Id_categorial
        {
            get
            {
                return id_categorial;
            }

            set
            {
                id_categorial = value;
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
