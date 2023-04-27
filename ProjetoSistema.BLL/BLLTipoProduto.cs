using ProjetoSistema.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.BLL
{
    public class BLLTipoProduto
    {
        private readonly DALConexao _conn;

        public BLLTipoProduto(DALConexao conn)
        {
            _conn = conn;
        }

        public DataTable PesquisaSql()
        {
            DALTipoProduto d = new(_conn);
            return d.PesquisaSql();
        }
    }
}
