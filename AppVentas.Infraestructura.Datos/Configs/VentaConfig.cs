using System;
using System.Collections.Generic;
using System.Text;
using AppVentas.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppVentas.Infraestructura.Datos.Configs
{
    class VentaConfig : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.ToTable("tblVentas");
            builder.HasKey(x => x.ventaId);

            builder.HasMany(venta => venta.VentaDetalles)
                .WithOne(detalle => detalle.Venta);
        }
    }
}
