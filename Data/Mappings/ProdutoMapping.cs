﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvaSuficienciaWebII.Models;

namespace ProvaSuficienciaWebII.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome);

            builder.Property(x => x.Preco);

            builder.Property(x => x.ComandaId);

            // FK
            builder.HasOne(x => x.Comanda)
                   .WithMany(x => x.Produtos)
                   .HasForeignKey(x => x.ComandaId);
        }
    }
}
