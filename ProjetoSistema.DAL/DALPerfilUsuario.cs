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
    public class DALPerfilUsuario
    {
        private readonly DALConexao _conn;
        public DALPerfilUsuario(DALConexao conn)
        {
            _conn = conn;
        }

        public void Adicionar(ModelPerfilUsuario model)
        {
            try
            {
                MySqlCommand cmd = new()
                {
                    Connection = _conn.ObjetoConexao,
                    CommandText = "INSERT INTO sis_perfis_usuarios SET " +
                                        "Status_Id = @status, " +
                                        "nome_perfil = @perfil; " +
                                        "SELECT @@IDENTITY;",
                };

                cmd.Parameters.AddWithValue("@status", 1);
                cmd.Parameters.AddWithValue("@perfil", model.NomePerfil);
                _conn.Conectar();
                model.PerfilUsuarioId = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { _conn.Desconectar(); }
        }

        public void Editar(ModelPerfilUsuario model)
        {
            try
            {
                MySqlCommand cmd = new()
                {
                    Connection = _conn.ObjetoConexao,
                    CommandText = "UPDATE sis_perfis_usuarios SET " +
                                        "Status_Id = @status, " +
                                        "nome_perfil = @perfil " +
                                        "WHERE perfil_usuario_id = @id;",
                };

                cmd.Parameters.AddWithValue("@status", model.StatusId);
                cmd.Parameters.AddWithValue("@perfil", model.NomePerfil);
                cmd.Parameters.AddWithValue("@id", model.PerfilUsuarioId);
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
                    CommandText = "UPDATE sis_perfis_usuarios SET " +
                                        "Status_Id = @status " +
                                        "WHERE perfil_usuario_id = @id;",
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
            string stringStatus = "";
            string stringTipo = "";

            if (status != "" && status != "Todos")
            {
                if (status == "Ativo")
                {
                    status = "1";
                }
                if (status == "Inativo")
                {
                    status = "2";
                }

                stringStatus = " and status_id = '" + status + "'";

            }
            

            if (pesquisa.Equals("Código"))
            {
                sql = "SELECT perfil_usuario_id, nome_perfil FROM sis_perfis_usuarios WHERE perfil_usuario_id = '" + valor + "'";
            }
            if (pesquisa.Equals("Descrição"))
            {
                sql = "SELECT perfil_usuario_id, nome_perfil FROM sis_perfis_usuarios WHERE nome_perfil like '%" + valor + "%'";
            }

            Pesquisa = sql + stringStatus + stringTipo;

            MySqlDataAdapter da = new(Pesquisa, _conn.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public ModelPerfilUsuario Abrir(int id)
        {
            ModelPerfilUsuario model = new();
            MySqlCommand cmd = new()
            {
                Connection = _conn.ObjetoConexao,
                CommandText = "SELECT * FROM sis_perfis_usuarios WHERE perfil_usuario_id = @id;"
            };
            cmd.Parameters.AddWithValue("@id", id);
            _conn.Conectar();
            MySqlDataReader dr = cmd.ExecuteReader();
            List<ModelPerfilUsuario> lista = new();
            if (dr.HasRows)
            {
                dr.Read();
                model.PerfilUsuarioId = Convert.ToInt32(dr["perfil_usuario_id"]);
                model.StatusId = Convert.ToInt32(dr["status_id"]);
                model.NomePerfil = Convert.ToString(dr["nome_perfil"]);
                lista.Add(model);
            }
            _conn.Desconectar();
            return model;
        }

        public int VerificarPerfil(String valor)
        {
            int r = 0;
            _ = new ModelGrupo();
            MySqlCommand cmd = new()
            {
                Connection = _conn.ObjetoConexao,
                CommandText = "SELECT nome_perfil FROM sis_perfis_usuarios WHERE nome_perfil = @perfil and status_id <> 3;"
            };
            cmd.Parameters.AddWithValue("@perfil", valor);
            _conn.Conectar();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                r = Convert.ToInt32(dr["perfil_usuario_id"]);
            }
            _conn.Desconectar();
            return r;
        }
    }
}
