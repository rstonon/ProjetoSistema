using MySql.Data.MySqlClient;
using ProjetoSistema.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.DAL
{
    public class DALMarca
    {
        private readonly DALConexao _conn;

        public DALMarca(DALConexao conn)
        {
            _conn = conn;
        }

        public void Adicionar(int empresaId, ModelMarca model)
        {
            try
            {
                MySqlCommand cmd = new()
                {
                    Connection = _conn.ObjetoConexao,
                    CommandText = "INSERT INTO mar_marcas SET " +
                                        "Status_Id = @status, " +
                                        "Empresa_Id = @empresa, " +
                                        "descricao_marca = @descricao; " +
                                        "SELECT @@IDENTITY;",
                };

                cmd.Parameters.AddWithValue("@status", 1);
                cmd.Parameters.AddWithValue("@empresa", empresaId);
                cmd.Parameters.AddWithValue("@descricao", model.DescricaoMarca);
                _conn.Conectar();
                model.MarcaId = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { _conn.Desconectar(); }
        }

        public void Editar(ModelMarca model)
        {
            try
            {
                MySqlCommand cmd = new()
                {
                    Connection = _conn.ObjetoConexao,
                    CommandText = "UPDATE mar_marcas SET " +
                                        "Status_Id = @status, " +
                                        "Empresa_Id = @empresa, " +
                                        "descricao_marca = @descricao " +
                                        "WHERE marca_Id = @id;",
                };

                cmd.Parameters.AddWithValue("@status", model.StatusId);
                cmd.Parameters.AddWithValue("@empresa", model.EmpresaId);
                cmd.Parameters.AddWithValue("@descricao", model.DescricaoMarca);
                cmd.Parameters.AddWithValue("@id", model.MarcaId);
                _conn.Conectar();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { _conn.Desconectar(); }
        }

        public void Excluir(int empresaId, int id)
        {
            try
            {
                MySqlCommand cmd = new()
                {
                    Connection = _conn.ObjetoConexao,
                    CommandText = "UPDATE mar_marcas SET " +
                                        "Status_Id = @status " +
                                        "WHERE empresa_id = @empresa " +
                                        "and marca_Id = @id;",
                };

                cmd.Parameters.AddWithValue("@status", 3);
                cmd.Parameters.AddWithValue("@empresa", empresaId);
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

        public DataTable PesquisaSql(int empresaId, string pesquisa, string status, string valor)
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
                sql = @$"SELECT marca_id, descricao_marca FROM mar_marcas m inner join sis_status s on (m.status_id = s.status_id) WHERE m.empresa_id = {empresaId} and m.marca_Id = '{valor}'";
            }
            if (pesquisa.Equals("Descrição"))
            {
                sql = @$"SELECT marca_id, descricao_marca FROM mar_marcas m inner join sis_status s on (m.status_id = s.status_id) WHERE m.empresa_id = {empresaId} and m.descricao_marca like '%{valor}%'";
            }

            Pesquisa = sql + stringStatus;

            MySqlDataAdapter da = new(Pesquisa, _conn.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public ModelMarca Abrir(int empresaId, int id)
        {
            ModelMarca model = new();
            MySqlCommand cmd = new()
            {
                Connection = _conn.ObjetoConexao,
                CommandText = "SELECT * FROM mar_marcas WHERE empresa_id = @empresa and marca_id = @id;"
            };
            cmd.Parameters.AddWithValue("@empresa", empresaId);
            cmd.Parameters.AddWithValue("@id", id);
            _conn.Conectar();
            MySqlDataReader dr = cmd.ExecuteReader();
            List<ModelMarca> lista = new();
            if (dr.HasRows)
            {
                dr.Read();
                model.MarcaId = Convert.ToInt32(dr["marca_id"]);
                model.StatusId = Convert.ToInt32(dr["status_id"]);
                model.EmpresaId = Convert.ToInt32(dr["empresa_id"]);
                model.DescricaoMarca = Convert.ToString(dr["descricao_marca"]);
                lista.Add(model);
            }
            _conn.Desconectar();
            return model;
        }

        public int VerificarMarca(int empresaId, string valor)
        {
            int r = 0;
            _ = new ModelMarca();
            MySqlCommand cmd = new()
            {
                Connection = _conn.ObjetoConexao,
                CommandText = "SELECT descricao_marca FROM mar_marcas WHERE empresa_id = @empresa and descricao_marca = @descricao;"
            };
            cmd.Parameters.AddWithValue("@empresa", empresaId);
            cmd.Parameters.AddWithValue("@descricao", valor);
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
    }
}
