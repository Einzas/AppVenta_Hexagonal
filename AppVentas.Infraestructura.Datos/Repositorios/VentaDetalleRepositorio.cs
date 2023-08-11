using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AppVentas.Dominio;
using AppVentas.Dominio.Interfaces.Repositorios;
using AppVentas.Infraestructura.Datos.Contextos;
using System.IO;

namespace AppVentas.Infraestructura.Datos.Repositorios
{
    public class VentaDetalleRepositorio : IRepositorioDetalle<VentaDetalle, Guid>

    {
        private VentaContexto db;

        public VentaDetalleRepositorio(VentaContexto _db)
        {
            db = _db;
        }
        public VentaDetalle Agregar(VentaDetalle entidad)
        {
            db.VentaDetalles.Add(entidad);
            return entidad;
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }
    }
}
