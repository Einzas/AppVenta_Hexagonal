using System;
using System.Collections.Generic;
using System.Text;
using AppVentas.Dominio.Interfaces;

namespace AppVentas.Aplicaciones.Interfaces
{
    public interface IServicioMovimiento<TEntidad, TEntidadID>
        : IAgregar<TEntidad>, IListar<TEntidad, TEntidadID>  
    {
        void Anular(TEntidadID entidadID);
    }
}
