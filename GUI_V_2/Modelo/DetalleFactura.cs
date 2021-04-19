using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolinera.Modelo
{
    class DetalleFactura
    {
        private int id_detalle_factura;

        private int id_factura;
        private int cantidad;
        private string fecha_venta;
        private double monto;
        private int restados_de_stock;
        private int id_product;
        private int id_usuario;

        public int Id_detalle_factura
        {
            get
            {
                return id_detalle_factura;
            }

            set
            {
                id_detalle_factura = value;
            }
        }

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

        public int Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }

        public string Fecha_venta
        {
            get
            {
                return fecha_venta;
            }

            set
            {
                fecha_venta = value;
            }
        }

        public double Monto
        {
            get
            {
                return monto;
            }

            set
            {
                monto = value;
            }
        }

        public int Restados_de_stock
        {
            get
            {
                return restados_de_stock;
            }

            set
            {
                restados_de_stock = value;
            }
        }

        public int Id_product
        {
            get
            {
                return id_product;
            }

            set
            {
                id_product = value;
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

        public DetalleFactura(DetalleFactura df)
        {
            this.Id_detalle_factura = df.Id_detalle_factura;
            this.Id_factura = df.Id_factura;
            this.Cantidad = df.Cantidad;
            this.Fecha_venta = df.Fecha_venta;
            this.Monto = df.Monto;
            this.Restados_de_stock = df.Restados_de_stock;
            this.Id_product = df.Id_product;
            this.Id_usuario = df.Id_usuario;
        }

      
    }
}
