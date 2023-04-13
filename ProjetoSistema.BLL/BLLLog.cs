using ProjetoSistema.DAL;
using ProjetoSistema.Model;
using ProjetoSistema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.BLL
{
    public class BLLLog
    {
        private readonly DALConexao _conn;

        public BLLLog(DALConexao conn)
        {
            this._conn = conn;
        }

        public void Adicionar(ModelLog obj)
        {
            if (obj.Tela.Trim().Length.Equals(0))
            {
                throw new Exception("A Tela do Log é obrigatória.");
            }
            if (obj.TipoLog.Equals(0))
            {
                throw new Exception("O Tipo do Log é obrigatório.");
            }
            if (obj.Descricao.Trim().Length.Equals(0))
            {
                throw new Exception("A Descrição do Log é obrigatória.");
            }

            DALLog d = new(_conn);
            d.Adicionar(obj);
        }
    }
}
