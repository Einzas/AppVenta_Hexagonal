using System;
using System.Collections.Generic;
using System.Text;

namespace AppVentas.Dominio.Interfaces
{
    public interface IAgregar<TEntidad>
    {
        TEntidad Agregar(TEntidad entidad);
    }
}
