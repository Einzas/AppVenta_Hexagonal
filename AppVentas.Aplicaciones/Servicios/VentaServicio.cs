using System;
using System.Collections.Generic;
using System.Text;
using AppVentas.Dominio;
using AppVentas.Dominio.Interfaces;
using AppVentas.Aplicaciones.Interfaces;
using AppVentas.Dominio.Interfaces.Repositorios;
namespace AppVentas.Aplicaciones.Servicios
{
    public class VentaServicio : IServicioMovimiento<Venta, Guid>
    {
        IRepositorioMovimiento<Venta, Guid> repoVenta;
        IRepositorioBase<Producto, Guid> repoProducto;
        IRepositorioDetalle<VentaDetalle, Guid> repoDetalle;
        public VentaServicio(
            IRepositorioMovimiento<Venta, Guid> _repoVenta, 
            IRepositorioBase<Producto, Guid> _repoProducto,
            IRepositorioDetalle<VentaDetalle, Guid> _repoDetalleVenta
            )
        {
            repoVenta = _repoVenta;
            repoProducto = _repoProducto;
            repoDetalle = _repoDetalleVenta;

        }
        public Venta Agregar(Venta entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("la 'Venta' es requerida.");
            var VentaAgregada = repoVenta.Agregar(entidad);

            entidad.VentaDetalles.ForEach(detalle =>
            {
                var productoSeleccionado = repoProducto.SeleccionarPorID(detalle.productoId);   
                if(productoSeleccionado == null)
                    throw new ArgumentNullException("El 'Producto' no existe.");
                
                detalle.costoUnitario = productoSeleccionado.costo;
                detalle.precioUnitario = productoSeleccionado.precio;
                detalle.subtotal = detalle.cantidadVendida * detalle.precioUnitario;
                detalle.impuesto = detalle.subtotal * 0.18m;
                detalle.total = detalle.subtotal + detalle.impuesto;
                repoDetalle.Agregar(detalle);

                productoSeleccionado.cantidadEnStock -= detalle.cantidadVendida;
                repoProducto.Editar(productoSeleccionado);

                entidad.subtotal += detalle.subtotal;
                entidad.impuesto += detalle.impuesto; 
                entidad.total += detalle.total;
            });

            repoVenta.GuardarTodosLosCambios(); 
            return entidad;
        }

        public void Anular(Guid entidadID)
        {
            repoVenta.Anular(entidadID);
            repoVenta.GuardarTodosLosCambios();
        }

        public List<Venta> Listar()
        {
            return repoVenta.Listar();

        }

        public Venta SeleccionarPorID(Guid entidadID)
        {
            return repoVenta.SeleccionarPorID(entidadID);
        }
    }
}
