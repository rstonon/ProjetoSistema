using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.Model
{
    public class ModelProduto
    {
        public ModelProduto()
        {
            ProdutoId = 0;
            StatusId = 0;
            EmpresaId = 0;
            TipoProdutoId = 0;
            GrupoId = 0;
            SubGrupoId = 0;
            MarcaId = 0;
            CodigoProduto = string.Empty;
            DescricaoProduto = string.Empty;
            UnidadeMedida = string.Empty;
            CustoProduto = 0;
            ValorVenda = 0;
        }

        public ModelProduto(int produtoId, int statusId, int empresaId, int tipoProdutoId, int grupoId, int subGrupoId, int marcaId, string codigoProduto, string descricaoProduto, string unidadeMedida, decimal custoProduto, decimal valorVenda)
        {
            ProdutoId = produtoId;
            StatusId = statusId;
            EmpresaId = empresaId;
            TipoProdutoId = tipoProdutoId;
            GrupoId = grupoId;
            SubGrupoId = subGrupoId;
            MarcaId = marcaId;
            CodigoProduto = codigoProduto;
            DescricaoProduto = descricaoProduto;
            UnidadeMedida = unidadeMedida;
            CustoProduto = custoProduto;
            ValorVenda = valorVenda;
        }

        public int ProdutoId { get; set; }
        public int StatusId { get; set; }
        public int EmpresaId { get; set; }
        public int TipoProdutoId { get; set; }
        public int GrupoId { get; set; }
        public int SubGrupoId { get; set; }
        public int MarcaId { get; set; }
        public string CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public string UnidadeMedida { get; set; }
        public decimal CustoProduto { get; set; }
        public decimal ValorVenda { get; set; }

    }
}
