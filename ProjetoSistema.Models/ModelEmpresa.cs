using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.Model
{
    public class ModelEmpresa
    {
        public ModelEmpresa()
        {
            EmpresaId = 0;
            StatusId = 0;
            CpfCnpj = String.Empty;
            RazaoSocial = String.Empty;
            NomeFantasia = String.Empty;
        }
        public ModelEmpresa(int empresaId, int statusId, string cpfCnpj, string razaoSocial, string nomeFantasia)
        {
            EmpresaId = empresaId;
            StatusId = statusId;
            CpfCnpj = cpfCnpj;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
        }

        public int EmpresaId { get; set; }
        public int StatusId { get; set; }
        public string CpfCnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
    }
}
