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
            EmpresaId = 0;
            NomeGrupo = String.Empty;
            TipoGrupo = String.Empty;
        }
        public ModelGrupo(int grupoId, int statusId, int empresaId, string nomeGrupo, string tipoGrupo)
        {
            GrupoId = grupoId;
            StatusId = statusId;
            EmpresaId = empresaId;
            NomeGrupo = nomeGrupo;
            TipoGrupo = tipoGrupo;
        }

        public int GrupoId { get; set; }
        public int StatusId { get; set; }
        public int EmpresaId { get; set; }
        public string NomeGrupo { get; set; }
        public string TipoGrupo { get; set; }
    }
}
