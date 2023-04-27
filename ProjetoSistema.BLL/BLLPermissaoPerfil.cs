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
    public class BLLPermissaoPerfil
    {
        private readonly DALConexao _conn;

        public BLLPermissaoPerfil(DALConexao conn)
        {
            this._conn = conn;
        }

        public void Adicionar(ModelPermissaoPerfil obj)
        {
            if (obj.PerfilId <= 0)
            {
                throw new Exception("O Perfil é obrigatório.");
            }
            if (obj.PermissaoId <= 0)
            {
                throw new Exception("A Permissão é obrigatória.");
            }

            DALPermissaoPerfil d = new(_conn);
            d.Adicionar(obj);
        }

        public void Excluir(int empresaId, int id)
        {
            DALPermissaoPerfil d = new(_conn);
            d.Excluir(empresaId, id);
        }

        public DataTable PesquisaSql(int empresaId, int perfilId, string valor)
        {
            DALPermissaoPerfil d = new(_conn);
            return d.PesquisaSql(empresaId, perfilId, valor);
        }

        public int VerificarPermissaPerfil(int empresaId, int usuarioId, int permissaoId)
        {
            DALPermissaoPerfil d = new(_conn);
            return d.VerificarPermissaoPerfil(empresaId, usuarioId, permissaoId);
        }
    }
}
