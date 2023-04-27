using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.DAL
{
    public class DALTipoProduto
    {
        private readonly DALConexao _conn;

        public DALTipoProduto(DALConexao conn)
        {
            _conn = conn;
        }
        public DataTable PesquisaSql()
        {
            DataTable tabela = new();

            string Pesquisa;

            Pesquisa = @$"SELECT tipo_produto_id, descricao_tipo_produto FROM sis_tipo_produtos WHERE status_id <> 3 order by descricao_tipo_produto asc";


            MySqlDataAdapter da = new(Pesquisa, _conn.StringConexao);
            da.Fill(tabela);
            return tabela;

        }
    }
}
