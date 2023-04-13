using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.Model
{
    public class ModelPermissao
    {
        public ModelPermissao()
        {
            PermissaoId = 0;
            StatusId = 1;
            Tela = "";
            DescricaoPermissao = "";
            Permissao = "";
        }
        public ModelPermissao(int permissaoId, int statusId, string tela, string descricaoPermissao, string permissao)
        {
            PermissaoId = permissaoId;
            StatusId = statusId;
            Tela = tela;
            DescricaoPermissao = descricaoPermissao;
            Permissao = permissao;
        }

        public int PermissaoId { get; set; }
        public int StatusId { get; set; }
        public string Tela { get; set; }
        public string DescricaoPermissao { get; set; }
        public string Permissao { get; set; }
    }
}