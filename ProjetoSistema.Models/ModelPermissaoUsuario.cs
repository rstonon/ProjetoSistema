using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.Model
{
    public class ModelPermissaoUsuario
    {
        public ModelPermissaoUsuario()
        {
            PermissaoUsuarioId = 0;
            UsuarioId = 0;
            PermissaoId = 0;
        }

        public ModelPermissaoUsuario(int permissaoUsuarioId, int usuarioId, int permissaoId)
        {
            PermissaoUsuarioId = permissaoUsuarioId;
            UsuarioId = usuarioId;
            PermissaoId = permissaoId;
        }

        public int PermissaoUsuarioId { get; set; }
        public int UsuarioId { get; set; }
        public int PermissaoId { get; set; }

    }
}
