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
    public class BLLPerfilUsuario
    {
        private readonly DALConexao _conn;

        public BLLPerfilUsuario(DALConexao conn)
        {
            this._conn = conn;
        }

        public void Adicionar(ModelPerfilUsuario obj)
        {
            if (obj.NomePerfil.Trim().Length.Equals(0))
            {
                throw new Exception("O Nome do Perfil é obrigatório.");
            }

            DALPerfilUsuario d = new(_conn);
            d.Adicionar(obj);
        }

        public void Editar(ModelPerfilUsuario obj)
        {
            if (obj.PerfilUsuarioId <= 0)
            {
                throw new Exception("O código do Perfil é obrigatório.");
            }
            if (obj.NomePerfil.Trim().Length.Equals(0))
            {
                throw new Exception("O Nome do Perfil é obrigatório.");
            }

            DALPerfilUsuario d = new(_conn);
            d.Editar(obj);
        }

        public void Excluir(int id)
        {
            DALPerfilUsuario d = new(_conn);
            d.Excluir(id);
        }

        public DataTable PesquisaSql(String pesquisa, String status, String valor)
        {
            DALPerfilUsuario d = new(_conn);
            return d.PesquisaSql(pesquisa, status, valor);
        }

        public ModelPerfilUsuario Abrir(int id)
        {
            DALPerfilUsuario d = new(_conn);
            return d.Abrir(id);
        }

        public int VerificarPerfil(String valor)
        {
            DALPerfilUsuario d = new(_conn);
            return d.VerificarPerfil(valor);
        }
    }
}
