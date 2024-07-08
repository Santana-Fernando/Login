using Domain.Usuario.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infra.Data.EntityConfigurations.Usuario
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.Property(p => p.email).HasMaxLength(100).IsRequired();
            builder.Property(p => p.nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.cargo).HasMaxLength(40).IsRequired();
            builder.Property(p => p.perfil_usuario).IsRequired();
            builder.Property(p => p.telefone).HasMaxLength(11).IsRequired();
            builder.Property(p => p.cpf).HasMaxLength(11).IsRequired();
            builder.Property(p => p.matricula).HasMaxLength(6).IsRequired();
            builder.Property(p => p.password).HasMaxLength(70).IsRequired();
            builder.Property(p => p.permissao).HasMaxLength(20).IsRequired();

            builder.HasData(
                new Usuarios
                {
                    id = 1,
                    nome = "system",
                    email = "system@gmail.com",
                    password = "$2a$10$e/IZDBCPryoa6XMwowkItuVWAeZmYOH1RiinVrcHVTm560uGIaUa2",
                    data_nascimento = DateTime.Now, 
                    cargo = "suporte", 
                    telefone = "99999999999",
                    cpf = "11111111111",
                    perfil_usuario = "https://static.vecteezy.com/ti/vetor-gratis/p3/2387693-icone-do-perfil-do-usuario-vetor.jpg", 
                    matricula = "000000",
                    nome_empresa = "system",
                    permissao = "admin"
                }
           );
        }
    }
}
