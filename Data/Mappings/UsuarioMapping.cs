using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvaSuficienciaWebII.Models;

namespace ProvaSuficienciaWebII.Data.Mappings
{
    public class UsuarioMapping  : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome);

            builder.Property(x => x.Telefone);

        }
    }
}
