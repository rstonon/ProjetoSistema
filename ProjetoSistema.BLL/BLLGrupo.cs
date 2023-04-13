using ProjetoSistema.DAL;
using ProjetoSistema.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.BLL
{
    public class BLLGrupo
    {
        private readonly DALConexao _conn;

        public BLLGrupo(DALConexao conn)
        {
            this._conn = conn;
        }

        public void Adicionar(ModelGrupo obj)
        {
            if (obj.TipoGrupo.Trim().Length.Equals(0))
            {
                throw new Exception("O Tipo do Grupo é obrigatório!");
            }
            if (obj.NomeGrupo.Trim().Length.Equals(0))
            {
                throw new Exception("A Descrição do Grupo é obrigatória!");
            }

            DALGrupo d = new(_conn);
            d.Adicionar(obj);
        }

        public void Editar(ModelGrupo obj)
        {
            if (obj.GrupoId <= 0)
            {
                throw new Exception("O código do tipo é obrigatório!");
            }
            if (obj.TipoGrupo.Trim().Length.Equals(0))
            {
                throw new Exception("O Tipo do Grupo é obrigatório!");
            }
            if (obj.NomeGrupo.Trim().Length.Equals(0))
            {
                throw new Exception("A Descrição do Grupo é obrigatória!");
            }

            DALGrupo d = new(_conn);
            d.Editar(obj);
        }

        public void Excluir(int id)
        {
            DALGrupo d = new(_conn);
            d.Excluir(id);
        }

        public DataTable PesquisaSql(String pesquisa, String status, String tipo, String valor)
        {
            DALGrupo d = new(_conn);
            return d.PesquisaSql(pesquisa, status, tipo, valor);
        }

        public ModelGrupo Abrir(int id)
        {
            DALGrupo d = new(_conn);
            return d.Abrir(id);
        }

        public int VerificaGrupo(String tipo, String valor)
        {
            DALGrupo d = new(_conn);
            return d.VerificaGrupo(tipo, valor);
        }
    }
}
