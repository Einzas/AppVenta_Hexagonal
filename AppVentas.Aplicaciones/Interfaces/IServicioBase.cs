using System;
using System.Collections.Generic;
using System.Text;
using AppVentas.Dominio.Interfaces;
namespace AppVentas.Aplicaciones.Interfaces
{
    public interface IServicioBase<TEntidad, TEntidadID>
      : IAgregar<TEntidad>, IListar<TEntidad, TEntidadID>, IEditar<TEntidad>, IEliminar<TEntidadID>
    {

    }
}
