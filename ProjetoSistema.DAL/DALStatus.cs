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
        public DataTable PesquisaSql(int[] id)
        {
            DataTable tabela = new();

            string Pesquisa;

            string pesquisa = "";

            foreach (var status in id)
            {
                pesquisa += status + ",";
            }

            if (pesquisa.EndsWith(","))
            {
                pesquisa = pesquisa.Remove(pesquisa.Length - 1);
            }

            Pesquisa = @$"SELECT status_id, Descricao_Status FROM sis_status where status_id IN ({pesquisa}) and status_id <> 3 order by descricao_status asc";


            MySqlDataAdapter da = new(Pesquisa, _conn.StringConexao);
            da.Fill(tabela);
            return tabela;

        }
    }
}
