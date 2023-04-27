using ProjetoSistema.DAL;
using ProjetoSistema.Model;
using ProjetoSistema.Models;
using System.Data;

namespace ProjetoSistema.BLL
{
    public class BLLProduto
    {
        private readonly DALConexao _conn;

        public BLLProduto(DALConexao conn)
        {
            _conn = conn;
        }

        public void Adicionar(int empresaId, ModelProduto obj)
        {
            if (obj.StatusId <= 0)
            {
                throw new Exception("O Status do Produto é obrigatório.");
            }
            if (obj.EmpresaId <= 0)
            {
                throw new Exception("A Empresa do Produto é obrigatório.");
            }
            if (obj.TipoProdutoId <= 0)
            {
                throw new Exception("O Tipo do Produto é obrigatório.");
            }
            if (obj.CodigoProduto.Trim().Length.Equals(0))
            {
                throw new Exception("A Código do Produto é obrigatória.");
            }
            if (obj.DescricaoProduto.Trim().Length.Equals(0))
            {
                throw new Exception("A Descrição do Produto é obrigatória.");
            }
            if (obj.UnidadeMedida.Trim().Length.Equals(0))
            {
                throw new Exception("A Unidade de Medida do Produto é obrigatória.");
            }
            if (obj.CustoProduto < 0)
            {
                throw new Exception("O Custo do Produto deve ser maior ou igual a 0.");
            }
            if (obj.ValorVenda < 0)
            {
                throw new Exception("O Valor de Venda do Produto deve ser maior ou igual a 0.");
            }

            DALProduto d = new(_conn);
            d.Adicionar(empresaId, obj);
        }

        public void Editar(ModelProduto obj)
        {
            if (obj.ProdutoId <= 0)
            {
                throw new Exception("O código do Produto é obrigatório.");
            }
            if (obj.StatusId <= 0)
            {
                throw new Exception("O Status do Produto é obrigatório.");
            }
            if (obj.EmpresaId <= 0)
            {
                throw new Exception("A Empresa do Produto é obrigatório.");
            }
            if (obj.TipoProdutoId <= 0)
            {
                throw new Exception("O Tipo do Produto é obrigatório.");
            }
            if (obj.CodigoProduto.Trim().Length.Equals(0))
            {
                throw new Exception("A Código do Produto é obrigatória.");
            }
            if (obj.DescricaoProduto.Trim().Length.Equals(0))
            {
                throw new Exception("A Descrição do Produto é obrigatória.");
            }
            if (obj.UnidadeMedida.Trim().Length.Equals(0))
            {
                throw new Exception("A Unidade de Medida do Produto é obrigatória.");
            }
            if (obj.CustoProduto < 0)
            {
                throw new Exception("O Custo do Produto deve ser maior ou igual a 0.");
            }
            if (obj.ValorVenda < 0)
            {
                throw new Exception("O Valor de Venda do Produto deve ser maior ou igual a 0.");
            }

            DALProduto d = new(_conn);
            d.Editar(obj);
        }

        public void Excluir(int empresaId, int id)
        {
            DALProduto d = new(_conn);
            d.Excluir(empresaId, id);
        }

        public DataTable PesquisaSql(int empresaId, string pesquisa, string status, string valor)
        {
            DALProduto d = new(_conn);
            return d.PesquisaSql(empresaId, pesquisa, status, valor);
        }

        public ModelProduto Abrir(int empresaId, int id)
        {
            DALProduto d = new(_conn);
            return d.Abrir(empresaId, id);
        }

        public int VerificarCodigoProduto(int empresaId, string valor)
        {
            DALProduto d = new(_conn);
            return d.VerificarCodigoProduto(empresaId, valor);
        }
    }
}
