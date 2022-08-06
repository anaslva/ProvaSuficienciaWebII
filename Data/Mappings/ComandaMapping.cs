using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvaSuficienciaWebII.Entities;

namespace ProvaSuficienciaWebII.Data.Mappings
{
    public class ComandaMapping : IEntityTypeConfiguration<Comanda>
    {
        public void Configure(EntityTypeBuilder<Comanda> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdUsuario);

            builder.Property(x => x.NomeUsuario);

            builder.Property(x => x.TelefoneUsuario);

            //FK
            builder
              .HasMany(x => x.Produtos)
              .WithOne(x => x.Comanda)
              .HasForeignKey(x => x.IdComanda)
              .HasPrincipalKey(x => x.Id);
        }
    }
}
