using System;
using System.Collections.Generic;
using System.Text;
using AppVentas.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppVentas.Infraestructura.Datos.Configs
{
    class ProductoConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("tblProductos");
            builder.HasKey(x => x.productoId);
            
            builder.HasMany(producto => producto.VentaDetalles)
                .WithOne(detalle => detalle.Producto);
        }
    }
}
