using System;
using System.Collections.Generic;
using System.Text;
using AppVentas.Dominio;
using AppVentas.Dominio.Interfaces;
using AppVentas.Aplicaciones.Interfaces;
using AppVentas.Dominio.Interfaces.Repositorios;

namespace AppVentas.Aplicaciones.Servicios
{
    public class ProductoServicio : IServicioBase<Producto, Guid>
    {
        private readonly IRepositorioBase<Producto, Guid> repoProducto;
        public ProductoServicio(IRepositorioBase<Producto, Guid> _repoProducto)
        {
            repoProducto = _repoProducto;
        }
        public Producto Agregar(Producto entidad)
        {
            if(entidad == null)
                throw new ArgumentNullException("El 'Producto' es requerido.");
            var resultProducto = repoProducto.Agregar(entidad);
            repoProducto.GuardarTodosLosCambios();
            return resultProducto;
        }

        public void Editar(Producto entidad)
        {
            if(entidad == null)
                throw new ArgumentNullException("El 'Producto' es requerido para editar.");
            repoProducto.Editar(entidad);
            repoProducto.GuardarTodosLosCambios();

        }

        public void Eliminar(Guid entidadID)

        {
            repoProducto.Eliminar(entidadID);
            repoProducto.GuardarTodosLosCambios();
        }

        public List<Producto> Listar()
        {
            return repoProducto.Listar();
        }

        public Producto SeleccionarPorID(Guid entidadID)
        {
            return repoProducto.SeleccionarPorID(entidadID);
        }
    }

}
