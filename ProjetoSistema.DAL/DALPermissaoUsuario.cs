using MySql.Data.MySqlClient;
using ProjetoSistema.Model;
using ProjetoSistema.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.DAL
{
    public class DALPermissaoUsuario
    {
        private readonly DALConexao _conn;

        public DALPermissaoUsuario(DALConexao conn)
        {
            _conn = conn;
        }

        public void Adicionar(ModelPermissaoUsuario model)
        {
            try
            {
                MySqlCommand cmd = new()
                {
                    Connection = _conn.ObjetoConexao,
                    CommandText = "INSERT INTO sis_permissoes_usuario SET " +
                                        "usuario_id = @usuario, " +
                                        "permissao_id = @permissao; " +
                                        "SELECT @@IDENTITY;",
                };

                cmd.Parameters.AddWithValue("@usuario", model.UsuarioId);
                cmd.Parameters.AddWithValue("@permissao", model.PermissaoId);
                _conn.Conectar();
                model.PermissaoUsuarioId = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { _conn.Desconectar(); }
        }

        public void Excluir(int id)
        {
            try
            {
                MySqlCommand cmd = new()
                {
                    Connection = _conn.ObjetoConexao,
                    CommandText = "delete from sis_permissoes_usuario " +
                                        "WHERE permissao_usuario_id = @id;",
                };

                cmd.Parameters.AddWithValue("@id", id);
                _conn.Conectar();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { _conn.Desconectar(); }
        }

        public DataTable PesquisaSql(int usuarioId)
        {
            DataTable tabela = new();

            string Pesquisa;

            Pesquisa = "SELECT pu.permissao_usuario_id, p.tela, p.descricao_permissao FROM sis_permissoes_usuario pu inner join sis_usuarios u on (pu.usuario_id = u.usuario_id) inner join sis_permissoes p on (pu.permissao_id = p.permissao_id) WHERE pu.usuario_id = " + usuarioId;

            MySqlDataAdapter da = new(Pesquisa, _conn.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public int VerificarPermissaoUsuario(int usuarioId, int permissaoId)
        {
            int r = 0;
            _ = new ModelUsuario();
            MySqlCommand cmd = new()
            {
                Connection = _conn.ObjetoConexao,
                CommandText = "SELECT permissao_usuario_id FROM sis_permissoes_usuario WHERE usuario_id = @usuario and permissao_id = @permissao;"
            };
            cmd.Parameters.AddWithValue("@usuario", usuarioId);
            cmd.Parameters.AddWithValue("@permissao", permissaoId);
            _conn.Conectar();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                r = Convert.ToInt32(dr["permissao_usuario_id"]);
            }
            _conn.Desconectar();
            return r;
        }
    }
}
