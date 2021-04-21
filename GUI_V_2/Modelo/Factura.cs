using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolinera.Modelo
{
    class Factura
    {
        private int id_factura;
        private string detalle;
        private int id_estado;
        private double monto_final;
        private int id_tipo_pago;
        private int id_usuario;

        public int Id_factura
        {
            get
            {
                return id_factura;
            }

            set
            {
                id_factura = value;
            }
        }

        public string Detalle
        {
            get
            {
                return detalle;
            }

            set
            {
                detalle = value;
            }
        }

        public int Id_estado
        {
            get
            {
                return id_estado;
            }

            set
            {
                id_estado = value;
            }
        }

        public double Monto_final
        {
            get
            {
                return monto_final;
            }

            set
            {
                monto_final = value;
            }
        }

        public int Id_tipo_pago
        {
            get
            {
                return id_tipo_pago;
            }

            set
            {
                id_tipo_pago = value;
            }
        }

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

        public Factura(Factura f)
        {
            this.Id_factura = f.Id_factura;
            this.Detalle = f.Detalle;
            this.Id_estado = f.Id_estado;
            this.Monto_final = f.Monto_final;
            this.Id_tipo_pago = f.Id_tipo_pago;
            this.Id_usuario = f.Id_usuario;
        }

        public Factura()
        {
        }
    }
}
