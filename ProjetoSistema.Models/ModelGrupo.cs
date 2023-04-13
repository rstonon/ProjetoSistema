using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.Models
{
    public class ModelGrupo
    {
        public ModelGrupo()
        {
            GrupoId = 0;
            StatusId = 1;
            NomeGrupo = "";
            TipoGrupo = "";
        }
        public ModelGrupo(int grupoId, int statusId, string nomeGrupo, string tipoGrupo)
        {
            GrupoId = grupoId;
            StatusId = statusId;
            NomeGrupo = nomeGrupo;
            TipoGrupo = tipoGrupo;
        }

        public int GrupoId { get; set; }
        public int StatusId { get; set; }
        public string NomeGrupo { get; set; }
        public string TipoGrupo { get; set; }
    }
}
