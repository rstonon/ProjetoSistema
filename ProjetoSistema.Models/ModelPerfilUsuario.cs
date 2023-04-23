using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.Model
{
    public class ModelPerfilUsuario
    {
        public ModelPerfilUsuario()
        {
            PerfilUsuarioId = 0;
            StatusId = 1;
            NomePerfil = "";
        }

        public ModelPerfilUsuario(int perfilUsuarioId, int statusId, string nomePerfil)
        {
            PerfilUsuarioId = perfilUsuarioId;
            StatusId = statusId;
            NomePerfil = nomePerfil;
        }

        public int PerfilUsuarioId { get; set; }
        public int StatusId { get; set; }
        public string NomePerfil { get; set; }
    }
}
