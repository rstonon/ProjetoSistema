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
            DescricaoMarca = "";
        }

        public ModelMarca(int marcaId, int statusId, string descricaoMarca)
        {
            MarcaId = marcaId;
            StatusId = statusId;
            DescricaoMarca = descricaoMarca;
        }

        public int MarcaId { get; set; }
        public int StatusId { get; set; }
        public string DescricaoMarca { get; set; }
    }
}
