﻿using ProjetoSistema.BLL;
using ProjetoSistema.DAL;
using ProjetoSistema.Model;
using ProjetoSistema.Models;

namespace GUI
{
    public partial class FrmPermissoesCadastro : Form
    {
        public int codigo;
        public string operacao;
        public string origem;
        FrmPermissoes form;

        public FrmPermissoesCadastro(FrmPermissoes form)
        {
            InitializeComponent();
            this.form = form;
        }

        public void LimparDados()
        {
            textBox1.Clear();
            textBox2.Clear();
            cbxStatus.SelectedValue = 1;
        }

        private void Cancelar()
        {
            Salvar();
        }

        private void Salvar()
        {
            if (MessageBox.Show("Deseja salvar os dados?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ModelPermissao model = new()
                    {
                        StatusId = Convert.ToInt32(cbxStatus.SelectedValue),
                        DescricaoPermissao = textBox2.Text,
                        Permissao = textBox3.Text
                    };

                    DALConexao conn = new(DadosConexao.StringConexao);
                    BLLPermissao bll = new(conn);

                    if (operacao.Equals("Inclusão"))
                    {
                        bll.Adicionar(model);
                    }
                    else
                    {
                        model.PermissaoId = Convert.ToInt32(textBox1.Text);
                        bll.Editar(model);
                    }
                    this.LimparDados();
                    this.Close();
                    form.PesquisaSql();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void FrmPermissoesCadastro_Load(object sender, EventArgs e)
        {
            int[] statusId = new int[2];
            statusId[0] = 1;
            statusId[1] = 2;

            DALConexao conn = new(DadosConexao.StringConexao);
            BLLStatus bll = new(conn);
            cbxStatus.DataSource = bll.PesquisaSql(statusId);
            cbxStatus.DisplayMember = "descricao_status";
            cbxStatus.ValueMember = "status_id";

            //cbxStatus.SelectedValue = 1;

            textBox1.Text = this.codigo.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (codigo > 0)
            {
                try
                {
                    DALConexao conn = new(DadosConexao.StringConexao);
                    BLLPermissao bll = new(conn);
                    ModelPermissao model = bll.Abrir(codigo);
                    textBox1.Text = model.PermissaoId.ToString();
                    cbxStatus.SelectedValue = model.StatusId;
                    textBox2.Text = model.DescricaoPermissao;
                    textBox3.Text = model.Permissao;
                    textBox4.Text = model.Tela;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void FrmColaboradoresTipoCadastro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
            if (e.KeyCode == Keys.F3)
            {
                Salvar();
            }
            if (e.KeyCode == Keys.F4)
            {
                Cancelar();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.SelectionStart = 0;
                textBox2.SelectionLength = textBox2.Text.Length;
            }
        }
    }
}
