using Domain.Empresa.Entidades;
using Domain.Login.Entities;
using Domain.Usuario.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Http
{
    public class HttpResponse
    {
        public Autenticacao Ok(Usuarios usuarios, Empresa empresa, string token)
        {
            return new Autenticacao()
            {
                matricula = usuarios.matricula,
                nome = usuarios.nome,
                data_nascimento = usuarios.data_nascimento,
                cargo = usuarios.cargo,
                telefone = usuarios.telefone,
                cpf = usuarios.cpf,
                token = token,
                perfil_usuario = usuarios.perfil_usuario,
                statusCode = System.Net.HttpStatusCode.OK,
                message = "OK",
                id_empresa =  empresa.id,
                nome_Empresa = empresa.nome,
                razao_social = empresa.razao_social,
                cnpj = empresa.cnpj,
                unidade = empresa.unidade
            };
        }

        public Autenticacao Forbidden()
        {
            return new Autenticacao()
            {
                statusCode = System.Net.HttpStatusCode.Forbidden,
                message = "Access denied"
            };
        }

        public Autenticacao BadRequest(List<string> fields)
        {
            return new Autenticacao()
            {
                statusCode = System.Net.HttpStatusCode.BadRequest,
                message = $"{string.Join(", ", fields)}"
            };
        }

        public Autenticacao NotFound()
        {
            return new Autenticacao()
            {
                statusCode = System.Net.HttpStatusCode.NotFound,
                message = "Not Found"
            };
        }

        public Autenticacao InternalServerError(string message)
        {
            return new Autenticacao()
            {
                statusCode = System.Net.HttpStatusCode.InternalServerError,
                message = message
            };
        }
    }
}
