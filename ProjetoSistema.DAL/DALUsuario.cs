using MySql.Data.MySqlClient;
using ProjetoSistema.Model;
using ProjetoSistema.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.DAL
{
    public class DALUsuario
    {
        private readonly DALConexao _conn;

        public DALUsuario(DALConexao conn)
        {
            _conn = conn;
        }

        private static string MD5Hash(string input)
        {
            // Calcular o Hash
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = MD5.HashData(inputBytes);

            // Converter byte array para string hexadecimal
            StringBuilder sb = new();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public void Adicionar(ModelUsuario model)
        {
            try
            {
                MySqlCommand cmd = new()
                {
                    Connection = _conn.ObjetoConexao,
                    CommandText = "INSERT INTO sis_usuarios SET " +
                                        "Status_Id = @status, " +
                                        "nome_usuario = @nome, " +
                                        "senha = @senha; " +
                                        "SELECT @@IDENTITY;",
                };

                cmd.Parameters.AddWithValue("@status", 1);
                cmd.Parameters.AddWithValue("@nome", model.NomeUsuario);
                cmd.Parameters.AddWithValue("@senha", MD5Hash(model.Senha));
                _conn.Conectar();
                model.UsuarioId = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { _conn.Desconectar(); }
        }

        public void Editar(ModelUsuario model)
        {
            try
            {
                MySqlCommand cmd = new()
                {
                    Connection = _conn.ObjetoConexao,
                    CommandText = "UPDATE sis_usuarios SET " +
                                        "Status_Id = @status, " +
                                        "nome_usuario = @nome, " +
                                        "senha = @senha " +
                                        "WHERE usuario_Id = @id;",
                };

                cmd.Parameters.AddWithValue("@status", model.StatusId);
                cmd.Parameters.AddWithValue("@nome", model.NomeUsuario);
                cmd.Parameters.AddWithValue("@senha", MD5Hash(model.Senha));
                cmd.Parameters.AddWithValue("@id", model.UsuarioId);
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
                    CommandText = "UPDATE sis_usuarios SET " +
                                        "Status_Id = @status " +
                                        "WHERE usuario_Id = @id;",
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
                sql = "SELECT u.usuario_id, u.nome_usuario FROM sis_usuarios u inner join sis_status s on (u.status_id = s.status_id) WHERE u.usuario_Id = '" + valor + "'";
            }
            if (pesquisa.Equals("Descrição"))
            {
                sql = "SELECT u.usuario_id, u.nome_usuario FROM sis_usuarios u inner join sis_status s on (u.status_id = s.status_id) WHERE u.nome_usuario like '%" + valor + "%'";
            }

            Pesquisa = sql + stringStatus;

            MySqlDataAdapter da = new(Pesquisa, _conn.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public ModelUsuario Abrir(int id)
        {
            ModelUsuario model = new();
            MySqlCommand cmd = new()
            {
                Connection = _conn.ObjetoConexao,
                CommandText = "SELECT * FROM sis_usuarios WHERE usuario_id = @id;"
            };
            cmd.Parameters.AddWithValue("@id", id);
            _conn.Conectar();
            MySqlDataReader dr = cmd.ExecuteReader();
            List<ModelUsuario> lista = new();
            if (dr.HasRows)
            {
                dr.Read();
                model.UsuarioId = Convert.ToInt32(dr["usuario_id"]);
                model.StatusId = Convert.ToInt32(dr["status_id"]);
                model.NomeUsuario = Convert.ToString(dr["nome_usuario"]);
                model.Senha = Convert.ToString(dr["senha"]);
                lista.Add(model);
            }
            _conn.Desconectar();
            return model;
        }

        public int VerificaUsuario(String valor)
        {
            int r = 0;
            _ = new ModelUsuario();
            MySqlCommand cmd = new()
            {
                Connection = _conn.ObjetoConexao,
                CommandText = "SELECT nome_usuario FROM sis_usuarios WHERE nome_usuario = @nome;"
            };
            cmd.Parameters.AddWithValue("@nome", valor);
            _conn.Conectar();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                r = Convert.ToInt32(dr["marca_id"]);
            }
            _conn.Desconectar();
            return r;
        }

        public bool Login(string usuario, string senha)
        {
            try
            {
                MySqlCommand cmd = new()
                {
                    Connection = _conn.ObjetoConexao,
                    CommandText = "SELECT * FROM sis_usuarios WHERE nome_usuario = @usuario and senha = @senha and status_id = 1;"
                };
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@senha", senha);
                _conn.Conectar();
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception)
            {

                throw;
            }
            finally { _conn.Desconectar(); }
        }
    }
}
