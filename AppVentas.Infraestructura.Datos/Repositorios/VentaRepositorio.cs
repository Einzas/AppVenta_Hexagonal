using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppVentas.Dominio;
using AppVentas.Dominio.Interfaces.Repositorios;
using AppVentas.Infraestructura.Datos.Contextos;
namespace AppVentas.Infraestructura.Datos.Repositorios
{
    public class VentaRepositorio : IRepositorioMovimiento<Venta, Guid>
    {
        private VentaContexto db;
        public VentaRepositorio(VentaContexto _db)
        {
            db = _db;
        }
        public Venta Agregar(Venta entidad)
        {
            entidad.ventaId = Guid.NewGuid();
            db.Ventas.Add(entidad);
            return entidad;
        }

        public void Anular(Guid entidadID)
        {
            var ventaSeleccionada = db.Ventas.Where(c => c.ventaId == entidadID).FirstOrDefault();
            if(ventaSeleccionada == null)
                throw new NullReferenceException("Esta intentado anular una venta que no existe.");
            ventaSeleccionada.anulado = true;

            db.Entry(ventaSeleccionada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<Venta> Listar()
        {
            return db.Ventas.ToList();
        }

        public Venta SeleccionarPorID(Guid entidadID)
        {
            var ventaSeleccionada = db.Ventas.Where(db => db.ventaId == entidadID).FirstOrDefault();
            return ventaSeleccionada; 
        }
    }
}
