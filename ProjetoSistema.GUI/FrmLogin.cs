using ProjetoSistema.BLL;
using ProjetoSistema.DAL;
using ProjetoSistema.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                bool acessar = bll.Login(textBox1.Text, textBox2.Text);

                if (acessar)
                {
                    this.Hide();
                    FrmMenu frm = new();
                    frm.Show();
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
    }
}
