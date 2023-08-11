using System;
using System.Collections.Generic;
using System.Text;
using AppVentas.Dominio.Interfaces;

namespace AppVentas.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioMovimiento<TEntidad, TEntidadID>
        : IAgregar<TEntidad>, IListar<TEntidad, TEntidadID>, ITransaccion
    {
        void Anular(TEntidadID entidadID);
    }
}
