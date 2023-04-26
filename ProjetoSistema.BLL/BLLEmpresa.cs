using ProjetoSistema.DAL;
using ProjetoSistema.Model;
using ProjetoSistema.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.BLL
{
    public class BLLEmpresa
    {
        private readonly DALConexao _conn;

        public BLLEmpresa(DALConexao conn)
        {
            _conn = conn;
        }

        public void Adicionar(ModelEmpresa obj)
        {
            if (obj.CpfCnpj.Trim().Length.Equals(0))
            {
                throw new Exception("O CPF/CNPJ é obrigatório.");
            }
            if (obj.RazaoSocial.Trim().Length.Equals(0))
            {
                throw new Exception("A Razão Social é obrigatória.");
            }
            if (obj.NomeFantasia.Trim().Length.Equals(0))
            {
                throw new Exception("O Nome Fantasia é obrigatório.");
            }

            DALEmpresa d = new(_conn);
            d.Adicionar(obj);
        }

        public void Editar(ModelEmpresa obj)
        {
            if (obj.EmpresaId <= 0)
            {
                throw new Exception("O código da Empresa é obrigatório.");
            }
            if (obj.CpfCnpj.Trim().Length.Equals(0))
            {
                throw new Exception("O CPF/CNPJ é obrigatório.");
            }
            if (obj.RazaoSocial.Trim().Length.Equals(0))
            {
                throw new Exception("A Razão Social é obrigatória.");
            }
            if (obj.NomeFantasia.Trim().Length.Equals(0))
            {
                throw new Exception("O Nome Fantasia é obrigatório.");
            }

            DALEmpresa d = new(_conn);
            d.Editar(obj);
        }

        public void Excluir(int id)
        {
            DALEmpresa d = new(_conn);
            d.Excluir(id);
        }

        public DataTable PesquisaSql(string pesquisa, string status, string valor)
        {
            DALEmpresa d = new(_conn);
            return d.PesquisaSql(pesquisa, status, valor);
        }

        public ModelEmpresa Abrir(int id)
        {
            DALEmpresa d = new(_conn);
            return d.Abrir(id);
        }

        public int VerificarEmpresa(string valor)
        {
            DALEmpresa d = new(_conn);
            return d.VerificarEmpresa(valor);
        }

    }
}
