using MySql.Data.MySqlClient;
using ProjetoSistema.Model;
using ProjetoSistema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.DAL
{
    public class DALLog
    {
        private readonly DALConexao _conn;

        public DALLog(DALConexao conn)
        {
            _conn = conn;
        }

        public void Adicionar(ModelLog model)
        {
            try
            {
                MySqlCommand cmd = new()
                {
                    Connection = _conn.ObjetoConexao,
                    CommandText = "INSERT INTO logs SET " +
                                        "tipo_log = @tipo, " +
                                        "tela = @tela, " +
                                        "descricao = @descricao; " +
                                        "SELECT @@IDENTITY;",
                };

                cmd.Parameters.AddWithValue("@tipo", model.TipoLog);
                cmd.Parameters.AddWithValue("@tela", model.Tela);
                cmd.Parameters.AddWithValue("@descricao", model.Descricao);
                _conn.Conectar();
                model.LogId = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { _conn.Desconectar(); }
        }
    }
}
