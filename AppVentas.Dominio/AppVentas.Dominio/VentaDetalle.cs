using System;
using System.Collections.Generic;
using System.Text;

namespace AppVentas.Dominio
{
    public class VentaDetalle
    {
        public Guid ventaId { get; set; }
        public Guid productoId { get; set; }
        public decimal costoUnitario { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal cantidadVendida { get; set; }
        public decimal subtotal { get; set; }
        public decimal impuesto { get; set; }
        public decimal total { get; set; }

        public Producto Producto { get; set; }
        public Venta Venta { get; set; }
    }
}
