using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.Model
{
    public class ModelPermissaoPerfil
    {
        public ModelPermissaoPerfil()
        {
            PermissaoUsuarioId = 0;
            PerfilId = 0;
            PermissaoId = 0;
        }

        public ModelPermissaoPerfil(int permissaoUsuarioId, int perfilId, int permissaoId)
        {
            PermissaoUsuarioId = permissaoUsuarioId;
            PerfilId = perfilId;
            PermissaoId = permissaoId;
        }

        public int PermissaoUsuarioId { get; set; }
        public int PerfilId { get; set; }
        public int PermissaoId { get; set; }

    }
}
