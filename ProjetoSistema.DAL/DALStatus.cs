using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.DAL
{
    public class DALStatus
    {
        private readonly DALConexao _conn;

        public DALStatus(DALConexao conn)
        {
            _conn = conn;
        }
        public DataTable PesquisaSql()
        {
            DataTable tabela = new();

            string Pesquisa;

            Pesquisa = "SELECT status_id, Descricao_Status FROM sis_status where status_id <> 3";

            MySqlDataAdapter da = new(Pesquisa, _conn.StringConexao);
            da.Fill(tabela);
            return tabela;

        }
    }
}
