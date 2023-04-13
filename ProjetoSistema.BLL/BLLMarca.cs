﻿using ProjetoSistema.DAL;
using ProjetoSistema.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.BLL
{
    public class BLLMarca
    {
        private readonly DALConexao _conn;

        public BLLMarca(DALConexao conn)
        {
            this._conn = conn;
        }

        public void Adicionar(ModelMarca obj)
        {
            if (obj.DescricaoMarca.Trim().Length.Equals(0))
            {
                throw new Exception("A Descrição da Marca é obrigatória!");
            }

            DALMarca d = new(_conn);
            d.Adicionar(obj);
        }

        public void Editar(ModelMarca obj)
        {
            if (obj.MarcaId <= 0)
            {
                throw new Exception("O código da Marca é obrigatório!");
            }
            if (obj.DescricaoMarca.Trim().Length.Equals(0))
            {
                throw new Exception("A Descrição da Marca é obrigatória!");
            }

            DALMarca d = new(_conn);
            d.Editar(obj);
        }

        public void Excluir(int id)
        {
            DALMarca d = new(_conn);
            d.Excluir(id);
        }

        public DataTable PesquisaSql(String pesquisa, String status, String valor)
        {
            DALMarca d = new(_conn);
            return d.PesquisaSql(pesquisa, status, valor);
        }

        public ModelMarca Abrir(int id)
        {
            DALMarca d = new(_conn);
            return d.Abrir(id);
        }

        public int VerificarMarca(String valor)
        {
            DALMarca d = new(_conn);
            return d.VerificarMarca(valor);
        }
    }
}