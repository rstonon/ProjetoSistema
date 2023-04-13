using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.DAL
{
    public class DALConexao
    {
        private String _stringConexao;
        private MySqlConnection _conn;

        public DALConexao(string dadosConexao)
        {
            this.ObjetoConexao = new MySqlConnection();
            this.StringConexao = dadosConexao;
            this.ObjetoConexao.ConnectionString = dadosConexao;
        }

        public string StringConexao { get => _stringConexao; set => _stringConexao = value; }
        public MySqlConnection ObjetoConexao { get => _conn; set => _conn = value; }

        public void Conectar()
        {
            this._conn.Open();
        }

        public void Desconectar()
        {
            this._conn.Close();
        }
    }
}
