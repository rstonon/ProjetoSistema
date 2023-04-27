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
    public class DALProduto
    {
        private readonly DALConexao _conn;

        public DALProduto(DALConexao conn)
        {
            _conn = conn;
        }

        public void Adicionar(int empresaId, ModelProduto model)
        {
            try
            {
                MySqlCommand cmd = new()
                {
                    Connection = _conn.ObjetoConexao,
                    CommandText = "INSERT INTO pro_produtos SET " +
                                        "Status_Id = @status, " +
                                        "Empresa_Id = @empresa, " +
                                        "tipo_produto_id = @tipoProduto, " +
                                        "grupo_id = @grupo, " +
                                        "subgrupo_id = @subgrupo, " +
                                        "marca_id = @marca, " +
                                        "codigo_produto = @codigoProduto, " +
                                        "descricao_produto = @descricaoProduto, " +
                                        "unidade_medida = @unidadeMedida, " +
                                        "custo_produto = @custoProduto, " +
                                        "valor_venda = @valorVenda; " +
                                        "SELECT @@IDENTITY;",
                };

                cmd.Parameters.AddWithValue("@status", 1);
                cmd.Parameters.AddWithValue("@empresa", empresaId);
                cmd.Parameters.AddWithValue("@tipoProduto", model.TipoProdutoId);
                cmd.Parameters.AddWithValue("@grupo", model.GrupoId);
                cmd.Parameters.AddWithValue("@subgrupo", model.SubGrupoId);
                cmd.Parameters.AddWithValue("@marca", model.MarcaId);
                cmd.Parameters.AddWithValue("@codigoProduto", model.CodigoProduto);
                cmd.Parameters.AddWithValue("@descricaoProduto", model.DescricaoProduto);
                cmd.Parameters.AddWithValue("@unidadeMedida", model.UnidadeMedida);
                cmd.Parameters.AddWithValue("@custoProduto", model.CustoProduto);
                cmd.Parameters.AddWithValue("@valorVenda", model.ValorVenda);
                _conn.Conectar();
                model.ProdutoId = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { _conn.Desconectar(); }
        }

        public void Editar(ModelProduto model)
        {
            try
            {
                MySqlCommand cmd = new()
                {
                    Connection = _conn.ObjetoConexao,
                    CommandText = "UPDATE pro_produtos SET " +
                                        "Status_Id = @status, " +
                                        "Empresa_Id = @empresa, " +
                                        "tipo_produto_id = @tipoProduto, " +
                                        "grupo_id = @grupo, " +
                                        "subgrupo_id = @subgrupo, " +
                                        "marca_id = @marca, " +
                                        "codigo_produto = @codigoProduto, " +
                                        "descricao_produto = @descricaoProduto, " +
                                        "unidade_medida = @unidadeMedida, " +
                                        "custo_produto = @custoProduto, " +
                                        "valor_venda = @valorVenda " +
                                        "WHERE produto_Id = @id;",
                };

                cmd.Parameters.AddWithValue("@status", model.StatusId);
                cmd.Parameters.AddWithValue("@empresa", model.EmpresaId);
                cmd.Parameters.AddWithValue("@tipoProduto", model.TipoProdutoId);
                cmd.Parameters.AddWithValue("@grupo", model.GrupoId);
                cmd.Parameters.AddWithValue("@subgrupo", model.SubGrupoId);
                cmd.Parameters.AddWithValue("@marca", model.MarcaId);
                cmd.Parameters.AddWithValue("@codigoProduto", model.CodigoProduto);
                cmd.Parameters.AddWithValue("@descricaoProduto", model.DescricaoProduto);
                cmd.Parameters.AddWithValue("@unidadeMedida", model.UnidadeMedida);
                cmd.Parameters.AddWithValue("@custoProduto", model.CustoProduto);
                cmd.Parameters.AddWithValue("@valorVenda", model.ValorVenda);
                cmd.Parameters.AddWithValue("@id", model.ProdutoId);
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
                    CommandText = "UPDATE pro_produtos SET " +
                                        "Status_Id = @status " +
                                        "WHERE empresa_id = @empresa " +
                                        "and produto_Id = @id;",
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



            if (pesquisa.Equals("Código Produto"))
            {
                sql = @$"SELECT p.produto_Id, p.codigo_produto, p.descricao_produto, p.unidade_medida FROM pro_produtos p inner join sis_status s on (p.status_id = s.status_id) WHERE p.empresa_id = {empresaId} and p.produto_Id = '{valor}'";
            }
            if (pesquisa.Equals("Descrição Produto"))
            {
                sql = @$"SELECT p.produto_Id, p.codigo_produto, p.descricao_produto, p.unidade_medida FROM pro_produtos p inner join sis_status s on (p.status_id = s.status_id) WHERE p.empresa_id = {empresaId} and p.descricao_produto like '%{valor}%'";
            }

            Pesquisa = sql + stringStatus;

            MySqlDataAdapter da = new(Pesquisa, _conn.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public ModelProduto Abrir(int empresaId, int id)
        {
            ModelProduto model = new();
            MySqlCommand cmd = new()
            {
                Connection = _conn.ObjetoConexao,
                CommandText = "SELECT * FROM pro_produtos WHERE empresa_id = @empresa and produto_Id = @id;"
            };
            cmd.Parameters.AddWithValue("@empresa", empresaId);
            cmd.Parameters.AddWithValue("@id", id);
            _conn.Conectar();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                model.ProdutoId = Convert.ToInt32(dr["produto_id"]);
                model.StatusId = Convert.ToInt32(dr["status_id"]);
                model.EmpresaId = Convert.ToInt32(dr["empresa_id"]);
                model.TipoProdutoId = Convert.ToInt32(dr["tipo_produto_id"]);
                model.GrupoId = Convert.ToInt32(dr["grupo_id"]);
                model.SubGrupoId = Convert.ToInt32(dr["subgrupo_id"]);
                model.MarcaId = Convert.ToInt32(dr["marca_id"]);
                model.CodigoProduto = Convert.ToString(dr["codigo_produto"]);
                model.DescricaoProduto = Convert.ToString(dr["descricao_produto"]);
                model.UnidadeMedida = Convert.ToString(dr["unidade_medida"]);
                model.CustoProduto = Convert.ToDecimal(dr["custo_produto"]);
                model.ValorVenda = Convert.ToDecimal(dr["valor_venda"]);
            }
            _conn.Desconectar();
            return model;
        }

        public int VerificarCodigoProduto(int empresaId, string valor)
        {
            int r = 0;
            _ = new ModelProduto();
            MySqlCommand cmd = new()
            {
                Connection = _conn.ObjetoConexao,
                CommandText = "SELECT descricao_produto FROM pro_produtos WHERE empresa_id = @empresa and codigo_produto = @descricao;"
            };
            cmd.Parameters.AddWithValue("@empresa", empresaId);
            cmd.Parameters.AddWithValue("@descricao", valor);
            _conn.Conectar();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                r = Convert.ToInt32(dr["descricao_produto"]);
            }
            _conn.Desconectar();
            return r;
        }
    }
}
