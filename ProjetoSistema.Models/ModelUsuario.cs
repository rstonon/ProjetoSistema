using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.Model
{
    public class ModelUsuario
    {
        public ModelUsuario()
        {
            UsuarioId = 0;
            StatusId = 1;
            NomeUsuario = "";
            Senha = "";
        }

        public ModelUsuario(int usuarioId, int statusId, string nomeUsuario, string senha)
        {
            UsuarioId = usuarioId;
            StatusId = statusId;
            NomeUsuario = nomeUsuario;
            Senha = senha;
        }

        public int UsuarioId { get; set; }
        public int StatusId { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
    }
}
