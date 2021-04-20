using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolinera.Modelo
{
    class Producto
    {
        private int id_producto;
        private string nombre;
        private double precio;
        private string fecha_registro;
        private string imagen;
        private int cantidad_en_stock;
        private int estado_producto;
        private int id_unidad;
        private int id_proveedor;
        private int id_usuario;
        private int id_categoria;
        public Producto()
        {

        }
        public int Id_producto
        {
            get
            {
                return id_producto;
            }

            set
            {
                id_producto = value;
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

        public double Precio
        {
            get
            {
                return precio;
            }

            set
            {
                precio = value;
            }
        }

        public string Fecha_registro
        {
            get
            {
                return fecha_registro;
            }

            set
            {
                fecha_registro = value;
            }
        }

        public string Imagen
        {
            get
            {
                return imagen;
            }

            set
            {
                imagen = value;
            }
        }

        public int Cantidad_en_stock
        {
            get
            {
                return cantidad_en_stock;
            }

            set
            {
                cantidad_en_stock = value;
            }
        }

        public int Estado_producto
        {
            get
            {
                return estado_producto;
            }

            set
            {
                estado_producto = value;
            }
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

        public int Id_categoria
        {
            get
            {
                return id_categoria;
            }

            set
            {
                id_categoria = value;
            }
        }

        public Producto(Producto p )
        {
            this.id_producto = p.id_producto;
            this.nombre = p.nombre;
            this.precio = p.precio;
            this.fecha_registro = p.fecha_registro;
            this.imagen = p.imagen;
            this.cantidad_en_stock = p.cantidad_en_stock;
            this.estado_producto = p.estado_producto;
            this.id_unidad = p.id_unidad;
            this.id_proveedor = p.id_proveedor;
            this.id_usuario = p.id_usuario;
            this.id_categoria = p.id_categoria;
        }
    }
}
