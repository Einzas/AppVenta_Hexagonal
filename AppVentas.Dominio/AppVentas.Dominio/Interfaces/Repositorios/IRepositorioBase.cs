using System;
using System.Collections.Generic;
using System.Text;

namespace AppVentas.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntidad, TEntidadID>
    : IAgregar<TEntidad>, IListar<TEntidad, TEntidadID>, IEditar<TEntidad>, IEliminar<TEntidadID>, ITransaccion
    { 
    
    }

    
}
