using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.DAL
{
    public class DadosConexao
    {
        public static string StringConexao { get { return "Server=127.0.0.1;Port=3306;Database=projetoerp;Uid=root;Pwd=m4n5mn45;"; }  }
        public static string StringConexaoLog { get { return "Server=127.0.0.1;Port=3306;Database=projetoerp_log;Uid=root;Pwd=m4n5mn45;"; }  }
    }
}
