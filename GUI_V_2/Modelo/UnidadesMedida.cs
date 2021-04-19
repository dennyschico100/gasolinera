using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolinera.Modelo
{
    class UnidadesMedida
    {
        private int id_unidad;
        private string nombre_unidad;

        public UnidadesMedida(int id_unidad, string nombre_unidad)
        {
            this.Id_unidad = id_unidad;
            this.Nombre_unidad = nombre_unidad;
        }

        public int Id_unidad
        {
            get
            {
                return id_unidad;
            }

            set
            {
                id_unidad = value;
            }
        }

        public string Nombre_unidad
        {
            get
            {
                return nombre_unidad;
            }

            set
            {
                nombre_unidad = value;
            }
        }
    }
}
