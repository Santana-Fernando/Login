using Domain.Empresa.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infra.Data.EntityConfigurations.Empresas
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.Property(p => p.nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.razao_social).HasMaxLength(100).IsRequired();
            builder.Property(p => p.unidade).HasMaxLength(100).IsRequired();
            builder.Property(p => p.cnpj).HasMaxLength(14).IsRequired();

            builder.HasData(
                new Empresa
                {
                    id = 1,
                    nome = "system",
                    razao_social = "empresa system",
                    unidade = "GO",
                    cnpj = "48063859000176"
                }
           );
        }
    }
}
