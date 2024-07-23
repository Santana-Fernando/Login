using System;

namespace Domain.Usuario.Entidades
{
    public class Usuarios
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime data_nascimento { get; set; }
        public string cargo { get; set; }
        public string telefone { get; set; }
        public string cpf { get; set; }
        public string perfil_usuario { get; set; }
        public string matricula { get; set; }
        public string nome { get; set; }
        public string nome_empresa { get; set; }
        public string permissao { get; set; }
        public int id_empresa { get; set; }
    }
}
