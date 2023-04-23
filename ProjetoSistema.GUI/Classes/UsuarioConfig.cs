using MySql.Data.MySqlClient;
using Mysqlx.Expr;
using ProjetoSistema.DAL;
using ProjetoSistema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistema.GUI.Classes
{
    public abstract class UsuarioConfig
    {
        public static int usuarioId = 1;
        public static string nomeUsuario;

        public static bool TemPermissao(string permissao)
        {
            bool temPermissao = false;

            DALConexao conn = new(DadosConexao.StringConexao);
            try
            {
                MySqlCommand cmd = new()
                {
                    Connection = conn.ObjetoConexao,
                    CommandText = "select pp.permissao_perfil_id from sis_permissoes_perfil pp left join sis_permissoes p on (pp.permissao_id = p.permissao_id) inner join sis_usuarios u on (pp.perfil_id = u.perfil_id) where p.permissao = @permissao and u.perfil_id = @perfil;"
                };
                cmd.Parameters.AddWithValue("@permissao", permissao);
                cmd.Parameters.AddWithValue("@perfil", 1);
                conn.Conectar();
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    temPermissao = true;
                }
                else
                {
                    temPermissao = false;
                }
                return temPermissao;
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível verificar a existência de um registro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally { conn.Desconectar(); }
        }
    }
}
