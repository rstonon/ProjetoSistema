using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.DAL
{
    public class DadosConexao
    {
        public static string connectionString;
        public static string connectionStringLog;

        //public static string servidor;
        //public static string porta;
        //public static string database;
        //public static string user;
        //public static string password;

        //public static string servidorLog;
        //public static string portaLog;
        //public static string databaseLog;
        //public static string userLog;
        //public static string passwordLog;

        public static string StringConexao { get { return connectionString; } }
        //public static string StringConexao { get { return "Server=" + servidor + ";Port=" + porta + ";Database=" + database + ";Uid=" + user + ";Pwd=" + password + ";"; } }
        public static string StringConexaoLog { get { return connectionStringLog; } }
        //public static string StringConexaoLog { get { return "Server=" + servidorLog + ";Port=" + portaLog + ";Database=" + databaseLog + ";Uid=" + userLog + ";Pwd=" + passwordLog + ";"; } }
    }
}
