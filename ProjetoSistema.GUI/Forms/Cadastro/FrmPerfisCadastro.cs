using ProjetoSistema.BLL;
using ProjetoSistema.DAL;
using ProjetoSistema.GUI.Classes;
using ProjetoSistema.Model;
using ProjetoSistema.Models;

namespace GUI
{
    public partial class FrmPerfisCadastro : Form
    {
        public int codigo;
        public string operacao;
        public string origem;
        FrmPerfis form;

        public FrmPerfisCadastro(FrmPerfis form)
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
                    ModelPerfilUsuario model = new()
                    {
                        StatusId = Convert.ToInt32(cbxStatus.SelectedValue),
                        NomePerfil = textBox2.Text,
                    };

                    DALConexao conn = new(DadosConexao.StringConexao);
                    BLLPerfilUsuario bll = new(conn);

                    if (operacao.Equals("Inclusão"))
                    {
                        bll.Adicionar(model);
                    }
                    else
                    {
                        model.PerfilUsuarioId = Convert.ToInt32(textBox1.Text);
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
            DALConexao conn = new(DadosConexao.StringConexao);
            BLLStatus bll = new(conn);
            cbxStatus.DataSource = bll.PesquisaSql();
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
                    BLLPerfilUsuario bll = new(conn);
                    ModelPerfilUsuario model = bll.Abrir(EmpresaConfig.empresaId, codigo);
                    textBox1.Text = model.PerfilUsuarioId.ToString();
                    cbxStatus.SelectedValue = model.StatusId;
                    textBox2.Text = model.NomePerfil;

                    CarregarPermissoes();
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

        private void button1_Click(object sender, EventArgs e)
        {
            FrmPermissoes f = new();
            f.codigoPerfil = Convert.ToInt32(textBox1.Text);
            f.pnSelecionar.Visible = true;
            f.ShowDialog();
            CarregarPermissoes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExcluirPermissao();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CarregarPermissoes();
        }

        public void CarregarPermissoes()
        {
            DALConexao conn = new(DadosConexao.StringConexao);
            BLLPermissaoPerfil bll = new(conn);
            DgvDados.DataSource = bll.PesquisaSql(EmpresaConfig.empresaId, Convert.ToInt32(textBox1.Text), textBox4.Text);

            DgvDados.Columns[0].HeaderText = "Código";
            DgvDados.Columns[0].Width = 80;
            DgvDados.Columns[0].Visible = false;
            DgvDados.Columns[1].HeaderText = "Tela";
            DgvDados.Columns[1].Width = 250;
            DgvDados.Columns[2].HeaderText = "Descrição";
            DgvDados.Columns[2].Width = 550;
        }

        public void ExcluirPermissao()
        {
            try
            {
                DialogResult d = MessageBox.Show("Deseja realmente excluir a permissão?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (d.ToString().Equals("Yes"))
                {
                    DALConexao conn = new(DadosConexao.StringConexao);
                    BLLPermissaoPerfil bll = new(conn);
                    bll.Excluir(EmpresaConfig.empresaId, Convert.ToInt32(DgvDados.CurrentRow.Cells[0].Value.ToString()));
                    CarregarPermissoes();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
