using System;
using System.Collections.Generic;
using System.Text;

namespace AppVentas.Dominio.Interfaces
{
    public interface IEliminar<TEntidadID>
    {
        void Eliminar(TEntidadID entidadID);
    }
}
