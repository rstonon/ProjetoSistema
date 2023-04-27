using ProjetoSistema.BLL;
using ProjetoSistema.DAL;
using ProjetoSistema.GUI.Classes;
using ProjetoSistema.Model;
using ProjetoSistema.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoSistema.GUI
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

            var connection = ConfigurationManager.ConnectionStrings["conexao"].ConnectionString;
            var connectionLog = ConfigurationManager.ConnectionStrings["conexaoLog"].ConnectionString;

            DadosConexao.connectionString = connection;
            DadosConexao.connectionStringLog = connectionLog;

        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnAcessar_Click(object sender, EventArgs e)
        {
            try
            {

                DALConexao conn = new(DadosConexao.StringConexao);
                BLLUsuario bll = new(conn);
                bool acessar = bll.Login(Convert.ToInt32(cbxEmpresas.SelectedValue), cbxUsuario.Text, textBox2.Text);

                if (acessar)
                {
                    UsuarioConfig.nomeUsuario = cbxUsuario.Text;

                    this.Hide();
                    FrmMenu frm = new();
                    frm.usuarioStripStatusLabel.Text = cbxUsuario.Text;
                    frm.Show();
                    EmpresaConfig.empresaId = Convert.ToInt32(cbxEmpresas.SelectedValue);

                    ModelLog model = new()
                    {
                        EmpresaId = EmpresaConfig.empresaId,
                        Data = DateTime.Now,
                        TipoLog = 'G',
                        Tela = "Sistema",
                        Usuario = UsuarioConfig.nomeUsuario,
                        Descricao = "Entrou no sistema",
                    };

                    DALConexao connLog = new(DadosConexao.StringConexaoLog);
                    BLLLog bllLog = new(connLog);
                    bllLog.GerarLog(EmpresaConfig.empresaId, model);

                }
                else
                {
                    MessageBox.Show("Credenciais Inválidas", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            DALConexao conn = new(DadosConexao.StringConexao);
            BLLEmpresa bll = new(conn);
            cbxEmpresas.DataSource = bll.PesquisaSql("Razão Social", "Ativo", "");
            cbxEmpresas.DisplayMember = "nome_fantasia";
            cbxEmpresas.ValueMember = "empresa_id";
        }

        private void cbxEmpresas_Leave(object sender, EventArgs e)
        {
            DALConexao conn = new(DadosConexao.StringConexao);
            BLLUsuario bll = new(conn);
            cbxUsuario.DataSource = bll.PesquisaSql(Convert.ToInt32(cbxEmpresas.SelectedValue), "Descrição", "Ativo", "");
            cbxUsuario.DisplayMember = "nome_usuario";
            cbxUsuario.ValueMember = "usuario_id";
        }
    }
}
