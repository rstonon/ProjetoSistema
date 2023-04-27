using MySql.Data.MySqlClient;
using ProjetoSistema.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.DAL
{
    public class DALGrupo
    {
        private readonly DALConexao _conn;

        public DALGrupo(DALConexao conn)
        {
            _conn = conn;
        }

        public void Adicionar(ModelGrupo model)
        {
            try
            {
                MySqlCommand cmd = new()
                {
                    Connection = _conn.ObjetoConexao,
                    CommandText = "INSERT INTO grp_grupos SET " +
                                        "Status_Id = @status, " +
                                        "Empresa_Id = @empresa, " +
                                        "descricao_grupo = @descricao, " +
                                        "Tipo_Grupo = @tipo; " +
                                        "SELECT @@IDENTITY;",
                };

                cmd.Parameters.AddWithValue("@status", 1);
                cmd.Parameters.AddWithValue("@empresa", model.EmpresaId);
                cmd.Parameters.AddWithValue("@descricao", model.NomeGrupo);
                cmd.Parameters.AddWithValue("@tipo", model.TipoGrupo);
                _conn.Conectar();
                model.GrupoId = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { _conn.Desconectar(); }
        }

        public void Editar(ModelGrupo model)
        {
            try
            {
                MySqlCommand cmd = new()
                {
                    Connection = _conn.ObjetoConexao,
                    CommandText = "UPDATE grp_grupos SET " +
                                        "Status_Id = @status, " +
                                        "Empresa_Id = @empresa, " +
                                        "descricao_grupo = @descricao, " +
                                        "Tipo_Grupo = @tipo " +
                                        "WHERE Grupo_Id = @id;",
                };

                cmd.Parameters.AddWithValue("@status", model.StatusId);
                cmd.Parameters.AddWithValue("@empresa", model.EmpresaId);
                cmd.Parameters.AddWithValue("@descricao", model.NomeGrupo);
                cmd.Parameters.AddWithValue("@tipo", model.TipoGrupo);
                cmd.Parameters.AddWithValue("@id", model.GrupoId);
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
                    CommandText = "UPDATE grp_grupos SET " +
                                        "Status_Id = @status " +
                                        "WHERE empresa_id = @empresa " +
                                        "and Grupo_Id = @id;",
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

        public DataTable PesquisaSql(int empresaId, string pesquisa, string status, string tipo, string valor)
        {
            DataTable tabela = new();

            string Pesquisa;
            string sql = "";
            string stringStatus = "";
            string stringTipo = "";

            stringStatus = " and s.descricao_status = '" + status + "'";

            if (status.Equals("Todos"))
            {
                stringStatus = " and s.status_id <> 3";
            }

            if (tipo != "" && tipo != "Todos")
            {
                stringTipo = " and g.tipo_grupo = '" + tipo + "'";
            }

            if (pesquisa.Equals("Código"))
            {
                sql = @$"SELECT g.grupo_id, g.descricao_grupo FROM grp_grupos g inner join sis_status s on (g.status_id = s.status_id) WHERE empresa_id = {empresaId} and Grupo_Id = '{valor}'";
            }
            if (pesquisa.Equals("Descrição"))
            {
                sql = @$"SELECT g.grupo_id, g.descricao_grupo FROM grp_grupos g inner join sis_status s on (g.status_id = s.status_id) WHERE empresa_id = {empresaId} and descricao_grupo like '%{valor}%'";
            }

            Pesquisa = sql + stringStatus + stringTipo;

            MySqlDataAdapter da = new(Pesquisa, _conn.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public ModelGrupo Abrir(int empresaId, int id)
        {
            ModelGrupo model = new();
            MySqlCommand cmd = new()
            {
                Connection = _conn.ObjetoConexao,
                CommandText = "SELECT * FROM grp_grupos WHERE empresa_id = @empresa and grupo_id = @id;"
            };
            cmd.Parameters.AddWithValue("@empresa", empresaId);
            cmd.Parameters.AddWithValue("@id", id);
            _conn.Conectar();
            MySqlDataReader dr = cmd.ExecuteReader();
            List<ModelGrupo> lista = new();
            if (dr.HasRows)
            {
                dr.Read();
                model.GrupoId = Convert.ToInt32(dr["grupo_id"]);
                model.StatusId = Convert.ToInt32(dr["status_id"]);
                model.EmpresaId = Convert.ToInt32(dr["empresa_id"]);
                model.TipoGrupo = Convert.ToString(dr["tipo_grupo"]);
                model.NomeGrupo = Convert.ToString(dr["descricao_grupo"]);
                lista.Add(model);
            }
            _conn.Desconectar();
            return model;
        }

        public int VerificarGrupo(int empresaId, string tipo, string valor)
        {
            int r = 0;
            _ = new ModelGrupo();
            MySqlCommand cmd = new()
            {
                Connection = _conn.ObjetoConexao,
                CommandText = "SELECT descricao_grupo FROM grp_grupos WHERE empresa_id = @empresa and tipo_grupo = @tipo and descricao_grupo = @descricao;"
            };
            cmd.Parameters.AddWithValue("@empresa", empresaId);
            cmd.Parameters.AddWithValue("@tipo", tipo);
            cmd.Parameters.AddWithValue("@descricao", valor);
            _conn.Conectar();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                r = Convert.ToInt32(dr["grupo_id"]);
            }
            _conn.Desconectar();
            return r;
        }
    }
}
