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
    public class BLLPermissaoUsuario
    {
        private readonly DALConexao _conn;

        public BLLPermissaoUsuario(DALConexao conn)
        {
            this._conn = conn;
        }

        public void Adicionar(ModelPermissaoUsuario obj)
        {
            if (obj.UsuarioId <= 0)
            {
                throw new Exception("O Usuário é obrigatório.");
            }
            if (obj.PermissaoId <= 0)
            {
                throw new Exception("A Permissão é obrigatória.");
            }

            DALPermissaoUsuario d = new(_conn);
            d.Adicionar(obj);
        }

        public void Excluir(int id)
        {
            DALPermissaoUsuario d = new(_conn);
            d.Excluir(id);
        }

        public DataTable PesquisaSql(int usuario)
        {
            DALPermissaoUsuario d = new(_conn);
            return d.PesquisaSql(usuario);
        }

        public int VerificarPermissaoUsuario(int usuarioId, int permissaoId)
        {
            DALPermissaoUsuario d = new(_conn);
            return d.VerificarPermissaoUsuario(usuarioId, permissaoId);
        }
    }
}
