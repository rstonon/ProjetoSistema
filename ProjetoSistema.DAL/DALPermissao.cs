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
    public class DALPermissao
    {
        private readonly DALConexao _conn;

        public DALPermissao(DALConexao conn)
        {
            _conn = conn;
        }

        public void Adicionar(ModelPermissao model)
        {
            try
            {
                MySqlCommand cmd = new()
                {
                    Connection = _conn.ObjetoConexao,
                    CommandText = "INSERT INTO sis_permissoes SET " +
                                        "status_id = @status, " +
                                        "tela = @tela, " +
                                        "descricao_permissao = @descricao, " +
                                        "permissao = @permissao; " +
                                        "SELECT @@IDENTITY;",
                };

                cmd.Parameters.AddWithValue("@status", model.StatusId);
                cmd.Parameters.AddWithValue("@tela", model.Tela);
                cmd.Parameters.AddWithValue("@descricao", model.DescricaoPermissao);
                cmd.Parameters.AddWithValue("@permissao", model.Permissao);
                _conn.Conectar();
                model.PermissaoId = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { _conn.Desconectar(); }
        }

        public void Editar(ModelPermissao model)
        {
            try
            {
                MySqlCommand cmd = new()
                {
                    Connection = _conn.ObjetoConexao,
                    CommandText = "UPDATE sis_permissoes SET " +
                                        "status_id = @status, " +
                                        "tela = @tela, " +
                                        "descricao_permissao = @descricao, " +
                                        "permissao = @permissao " +
                                        "WHERE permissao_Id = @id;",
                };

                cmd.Parameters.AddWithValue("@status", model.StatusId);
                cmd.Parameters.AddWithValue("@tela", model.Tela);
                cmd.Parameters.AddWithValue("@descricao", model.DescricaoPermissao);
                cmd.Parameters.AddWithValue("@permissao", model.Permissao);
                cmd.Parameters.AddWithValue("@id", model.PermissaoId);
                _conn.Conectar();
                cmd.ExecuteNonQuery();

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
                    CommandText = "UPDATE sis_permissoes SET " +
                                        "Status_Id = @status " +
                                        "WHERE marca_Id = @id;",
                };

                cmd.Parameters.AddWithValue("@status", 3);
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

        public DataTable PesquisaSql(String pesquisa, String status, String valor)
        {
            DataTable tabela = new();

            string Pesquisa;
            string sql = "";
            string stringStatus;

            stringStatus = " and s.descricao_status = '" + status + "'";

            if (status.Equals("Todos"))
            {
                stringStatus = " and s.status_id <> 3";
            }



            if (pesquisa.Equals("Código"))
            {
                sql = "SELECT permissao_id, tela, descricao_permissao FROM sis_permissoes p inner join sis_status s on (p.status_id = s.status_id) WHERE p.permissoes_Id = '" + valor + "'";
            }
            if (pesquisa.Equals("Descrição"))
            {
                sql = "SELECT permissao_id, tela, descricao_permissao FROM sis_permissoes p inner join sis_status s on (p.status_id = s.status_id) WHERE p.descricao_permissao like '%" + valor + "%'";
            }
            if (pesquisa.Equals("Tela"))
            {
                sql = "SELECT permissao_id, tela, descricao_permissao FROM sis_permissoes p inner join sis_status s on (p.status_id = s.status_id) WHERE p.tela like '%" + valor + "%'";
            }

            Pesquisa = sql + stringStatus;

            MySqlDataAdapter da = new(Pesquisa, _conn.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public ModelPermissao Abrir(int id)
        {
            ModelPermissao model = new();
            MySqlCommand cmd = new()
            {
                Connection = _conn.ObjetoConexao,
                CommandText = "SELECT * FROM sis_permissoes WHERE permissao_id = @id;"
            };
            cmd.Parameters.AddWithValue("@id", id);
            _conn.Conectar();
            MySqlDataReader dr = cmd.ExecuteReader();
            List<ModelPermissao> lista = new();
            if (dr.HasRows)
            {
                dr.Read();
                model.PermissaoId = Convert.ToInt32(dr["permissao_id"]);
                model.StatusId = Convert.ToInt32(dr["status_id"]);
                model.Tela = Convert.ToString(dr["tela"]);
                model.DescricaoPermissao = Convert.ToString(dr["descricao_permissao"]);
                model.Permissao = Convert.ToString(dr["permissao"]);
                lista.Add(model);
            }
            _conn.Desconectar();
            return model;
        }

        public int VerificarPermissao(String valor)
        {
            int r = 0;
            _ = new ModelPermissao();
            MySqlCommand cmd = new()
            {
                Connection = _conn.ObjetoConexao,
                CommandText = "SELECT permissao FROM sis_permissoes WHERE permissao = @descricao;"
            };
            cmd.Parameters.AddWithValue("@descricao", valor);
            _conn.Conectar();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                r = Convert.ToInt32(dr["permissao_id"]);
            }
            _conn.Desconectar();
            return r;
        }
    }
}
