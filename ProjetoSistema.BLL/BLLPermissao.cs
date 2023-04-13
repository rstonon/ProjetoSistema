using ProjetoSistema.DAL;
using ProjetoSistema.Model;
using ProjetoSistema.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.BLL
{
    public class BLLPermissao
    {
        private readonly DALConexao _conn;

        public BLLPermissao(DALConexao conn)
        {
            this._conn = conn;
        }

        public void Adicionar(ModelPermissao obj)
        {
            if (obj.Tela.Trim().Length.Equals(0))
            {
                throw new Exception("A Tela é obrigatória.");
            }
            if (obj.DescricaoPermissao.Trim().Length.Equals(0))
            {
                throw new Exception("A Descrição da Permissão é obrigatória.");
            }
            if (obj.Permissao.Trim().Length.Equals(0))
            {
                throw new Exception("A Permissão é obrigatória.");
            }

            DALPermissao d = new(_conn);
            d.Adicionar(obj);
        }

        public void Editar(ModelPermissao obj)
        {
            if (obj.PermissaoId <= 0)
            {
                throw new Exception("O código da Permissão é obrigatório.");
            }
            if (obj.DescricaoPermissao.Trim().Length.Equals(0))
            {
                throw new Exception("A Descrição da Permissão é obrigatória.");
            }
            if (obj.Permissao.Trim().Length.Equals(0))
            {
                throw new Exception("A Permissão é obrigatória.");
            }

            DALPermissao d = new(_conn);
            d.Editar(obj);
        }

        public void Excluir(int id)
        {
            DALPermissao d = new(_conn);
            d.Excluir(id);
        }

        public DataTable PesquisaSql(String pesquisa, String status, String valor)
        {
            DALPermissao d = new(_conn);
            return d.PesquisaSql(pesquisa, status, valor);
        }

        public ModelPermissao Abrir(int id)
        {
            DALPermissao d = new(_conn);
            return d.Abrir(id);
        }

        public int VerificarPermissao(String valor)
        {
            DALPermissao d = new(_conn);
            return d.VerificarPermissao(valor);
        }
    }
}
