using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Login.Entities
{
    public class Autenticacao
    {
        public string? matricula { get; set; }
        public string? nome { get; set; }
        public DateTime? data_nascimento { get; set; }
        public string? cargo { get; set; }
        public string? telefone { get; set; }
        public string? cpf { get; set; }
        public string? token { get; set; }
        public string? perfil_usuario { get; set; }
        public HttpStatusCode statusCode { get; set; }
        public string message { get; set; }
        public int? id_empresa { get; set; }
        public string? nome_Empresa { get; set; }
        public string? razao_social { get; set; }
        public string? cnpj { get; set; }
        public string? unidade { get; set; }
    }
}
