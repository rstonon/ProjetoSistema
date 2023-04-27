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
    public class DALEmpresa
    {
        private readonly DALConexao _conn;

        public DALEmpresa(DALConexao conn)
        {
            _conn = conn;
        }

        public void Adicionar(ModelEmpresa model)
        {
            try
            {
                MySqlCommand cmd = new()
                {
                    Connection = _conn.ObjetoConexao,
                    CommandText = "INSERT INTO sis_empresas SET " +
                                        "Status_Id = @status, " +
                                        "cpf_cnpj = @cpfcnpj, " +
                                        "razao_social = @razaosocial, " +
                                        "nome_fantasia = @nomefantasia; " +
                                        "SELECT @@IDENTITY;",
                };

                cmd.Parameters.AddWithValue("@status", 1);
                cmd.Parameters.AddWithValue("@cpfcnpj", model.CpfCnpj);
                cmd.Parameters.AddWithValue("@razaosocial", model.RazaoSocial);
                cmd.Parameters.AddWithValue("@nome_fantasia", model.NomeFantasia);
                _conn.Conectar();
                model.EmpresaId = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { _conn.Desconectar(); }
        }

        public void Editar(ModelEmpresa model)
        {
            try
            {
                MySqlCommand cmd = new()
                {
                    Connection = _conn.ObjetoConexao,
                    CommandText = "UPDATE sis_empresas SET " +
                                        "Status_Id = @status, " +
                                        "cpf_cnpj = @cpfcnpj, " +
                                        "razao_social = @razaosocial, " +
                                        "nome_fantasia = @nomefantasia " +
                                        "WHERE Empresa_Id = @id;",
                };

                cmd.Parameters.AddWithValue("@status", model.StatusId);
                cmd.Parameters.AddWithValue("@cpfcnpj", model.CpfCnpj);
                cmd.Parameters.AddWithValue("@razaosocial", model.RazaoSocial);
                cmd.Parameters.AddWithValue("@nome_fantasia", model.NomeFantasia);
                cmd.Parameters.AddWithValue("@id", model.EmpresaId);
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
                    CommandText = "UPDATE sis_empresas SET " +
                                        "Status_Id = @status " +
                                        "WHERE Empresa_Id = @id;",
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

        public DataTable PesquisaSql(string pesquisa, string status, string valor)
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
                sql = @$"SELECT empresa_id, cpf_cnpj, razao_social, nome_fantasia FROM sis_empresas e inner join sis_status s on (e.status_id = s.status_id) WHERE e.empresa_id = {valor}";
            }
            if (pesquisa.Equals("Razão Social"))
            {
                sql = @$"SELECT empresa_id, cpf_cnpj, razao_social, nome_fantasia FROM sis_empresas e inner join sis_status s on (e.status_id = s.status_id) WHERE e.razao_social like '%{valor}%'";
            }
            if (pesquisa.Equals("Nome Fantasia"))
            {
                sql = @$"SELECT empresa_id, cpf_cnpj, razao_social, nome_fantasia FROM sis_empresas e inner join sis_status s on (e.status_id = s.status_id) WHERE e.nome_fantasia like '%{valor}%'";
            }

            Pesquisa = sql + stringStatus;

            MySqlDataAdapter da = new(Pesquisa, _conn.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public ModelEmpresa Abrir(int id)
        {
            ModelEmpresa model = new();
            MySqlCommand cmd = new()
            {
                Connection = _conn.ObjetoConexao,
                CommandText = "SELECT * FROM sis_empresas WHERE empresa_id = @id;"
            };
            cmd.Parameters.AddWithValue("@id", id);
            _conn.Conectar();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                model.EmpresaId = Convert.ToInt32(dr["empresa_id"]);
                model.StatusId = Convert.ToInt32(dr["status_id"]);
                model.CpfCnpj = Convert.ToString(dr["cpf_cnpj"]);
                model.RazaoSocial = Convert.ToString(dr["razao_social"]);
                model.NomeFantasia = Convert.ToString(dr["nome_fantasia"]);
            }
            _conn.Desconectar();
            return model;
        }

        public int VerificarEmpresa(string valor)
        {
            int r = 0;
            _ = new ModelMarca();
            MySqlCommand cmd = new()
            {
                Connection = _conn.ObjetoConexao,
                CommandText = "SELECT empresa_id FROM sis_empresas WHERE razao_social = @razaosocial or nome_fantasia = @razaosocial;"
            };
            cmd.Parameters.AddWithValue("@razaosocial", valor);
            _conn.Conectar();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                r = Convert.ToInt32(dr["empresa_id"]);
            }
            _conn.Desconectar();
            return r;
        }
    }
}
