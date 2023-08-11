using System;
using System.Collections.Generic;
using System.Text;
using AppVentas.Dominio.Interfaces;
namespace AppVentas.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioDetalle<TEntidad, TMovimientoID>
    : IAgregar<TEntidad>, ITransaccion
    {

    }
}
