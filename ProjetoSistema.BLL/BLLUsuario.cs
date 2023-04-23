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
    public class BLLUsuario
    {
        private readonly DALConexao _conn;

        public BLLUsuario(DALConexao conn)
        {
            this._conn = conn;
        }

        public void Adicionar(ModelUsuario obj)
        {
            if (obj.NomeUsuario.Trim().Length.Equals(0))
            {
                throw new Exception("O Nome do Usuário é obrigatório.");
            }
            if (obj.Senha.Trim().Length.Equals(0))
            {
                throw new Exception("A Senha do Usuário é obrigatório.");
            }
            if (obj.PerfilId <= 0)
            {
                throw new Exception("O Perfil do Usuário é obrigatório.");
            }

            DALUsuario d = new(_conn);
            d.Adicionar(obj);
        }

        public void Editar(ModelUsuario obj)
        {
            if (obj.UsuarioId <= 0)
            {
                throw new Exception("O código do tipo é obrigatório!");
            }
            if (obj.NomeUsuario.Trim().Length.Equals(0))
            {
                throw new Exception("O Nome do Usuário é obrigatório!");
            }
            if (obj.Senha.Trim().Length.Equals(0))
            {
                throw new Exception("A Senha do Usuário é obrigatório!");
            }
            if (obj.PerfilId <= 0)
            {
                throw new Exception("O Perfil do Usuário é obrigatório.");
            }

            DALUsuario d = new(_conn);
            d.Editar(obj);
        }

        public void Excluir(int id)
        {
            DALUsuario d = new(_conn);
            d.Excluir(id);
        }

        public DataTable PesquisaSql(String pesquisa, String status, String valor)
        {
            DALUsuario d = new(_conn);
            return d.PesquisaSql(pesquisa, status, valor);
        }

        public ModelUsuario Abrir(int id)
        {
            DALUsuario d = new(_conn);
            return d.Abrir(id);
        }

        public int VerificaUsuario(String valor)
        {
            DALUsuario d = new(_conn);
            return d.VerificaUsuario(valor);
        }

        public bool Login(string usuario, string senha)
        {

            if (usuario.Trim().Length.Equals(0))
            {
                throw new Exception("O Usuário é obrigatório.");
            }
            if (senha.Trim().Length.Equals(0))
            {
                throw new Exception("A Senha é obrigatória.");
            }

            DALUsuario d = new(_conn);
            return d.Login(usuario,senha);
        }
    }
}
