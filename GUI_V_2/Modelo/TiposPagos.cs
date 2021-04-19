using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolinera.Modelo
{
    class TiposPagos
    {
        private int tipo_pago;
        private string nombre;

        public int Tipo_pago
        {
            get
            {
                return tipo_pago;
            }

            set
            {
                tipo_pago = value;
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

        public TiposPagos(int tipo_pago, string nomnbre)
        {
            this.Tipo_pago = tipo_pago;
            this.Nombre = nomnbre;
        }

    }

}
