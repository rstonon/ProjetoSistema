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
    public class DALPermissaoPerfil
    {
        private readonly DALConexao _conn;

        public DALPermissaoPerfil(DALConexao conn)
        {
            _conn = conn;
        }

        public void Adicionar(ModelPermissaoPerfil model)
        {
            try
            {
                MySqlCommand cmd = new()
                {
                    Connection = _conn.ObjetoConexao,
                    CommandText = "INSERT INTO sis_permissoes_perfil SET " +
                                        "perfil_id = @perfil, " +
                                        "permissao_id = @permissao; " +
                                        "SELECT @@IDENTITY;",
                };

                cmd.Parameters.AddWithValue("@perfil", model.PerfilId);
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
                    CommandText = "delete from sis_permissoes_perfil " +
                                        "WHERE permissao_perfil_id = @id;",
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

        public DataTable PesquisaSql(int perfilId, string valor)
        {
            DataTable tabela = new();

            string Pesquisa;

            Pesquisa = "SELECT pp.permissao_perfil_id, p.tela, p.descricao_permissao FROM sis_permissoes_perfil pp inner join sis_perfis_usuarios u on (pp.perfil_id = u.perfil_usuario_id) inner join sis_permissoes p on (pp.permissao_id = p.permissao_id) WHERE pp.perfil_id = " + perfilId + " and p.descricao_permissao like '%" + valor + "%'";

            MySqlDataAdapter da = new(Pesquisa, _conn.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public int VerificarPermissaoPerfil(int perfilId, int permissaoId)
        {
            int r = 0;
            _ = new ModelUsuario();
            MySqlCommand cmd = new()
            {
                Connection = _conn.ObjetoConexao,
                CommandText = "SELECT permissao_perfil_id FROM sis_permissoes_perfil WHERE perfil_id = @perfil and permissao_id = @permissao;"
            };
            cmd.Parameters.AddWithValue("@perfil", perfilId);
            cmd.Parameters.AddWithValue("@permissao", permissaoId);
            _conn.Conectar();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                r = Convert.ToInt32(dr["permissao_perfil_id"]);
            }
            _conn.Desconectar();
            return r;
        }
    }
}
