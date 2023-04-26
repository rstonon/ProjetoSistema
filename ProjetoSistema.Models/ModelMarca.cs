using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.Models
{
    public class ModelMarca
    {
        public ModelMarca()
        {
            MarcaId = 0;
            StatusId = 1;
            EmpresaId = 0;
            DescricaoMarca = "";
        }

        public ModelMarca(int marcaId, int statusId, int empresaId, string descricaoMarca)
        {
            MarcaId = marcaId;
            StatusId = statusId;
            EmpresaId = empresaId;
            DescricaoMarca = descricaoMarca;
        }

        public int MarcaId { get; set; }
        public int StatusId { get; set; }
        public int EmpresaId { get; set; }
        public string DescricaoMarca { get; set; }
    }
}
