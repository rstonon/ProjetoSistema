using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.Model
{
    public class ModelLog
    {
        public ModelLog(int logId, int empresaId, char tipoLog, string tela, string descricao)
        {
            LogId = logId;
            EmpresaId = empresaId;
            TipoLog = tipoLog;
            Tela = tela;
            Descricao = descricao;
        }

        public int LogId { get; set; }
        public int EmpresaId { get; set; }
        public DateTime Data { get; set; }
        public char TipoLog { get; set; }
        public string Tela { get; set; }
        public string Descricao { get; set; }
    }
}
