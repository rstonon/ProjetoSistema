using ProjetoSistema.BLL;
using ProjetoSistema.DAL;
using ProjetoSistema.GUI.Classes;
using ProjetoSistema.Model;
using ProjetoSistema.Models;

namespace GUI
{
    public partial class FrmProdutosCadastro : Form
    {
        public int codigo;
        public string operacao;
        public string origem;
        private int empresaId;
        FrmProdutos form;

        public FrmProdutosCadastro(FrmProdutos form)
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
                    ModelProduto model = new()
                    {
                        StatusId = Convert.ToInt32(cbxStatus.SelectedValue),
                        EmpresaId = empresaId,
                        DescricaoProduto = textBox2.Text,
                    };

                    DALConexao conn = new(DadosConexao.StringConexao);
                    BLLProduto bll = new(conn);

                    if (operacao.Equals("Inclusão"))
                    {
                        bll.Adicionar(EmpresaConfig.empresaId, model);
                    }
                    else
                    {
                        model.ProdutoId = Convert.ToInt32(textBox1.Text);
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

        private void FrmProdutoCadastro_Load(object sender, EventArgs e)
        {
            int[] statusId = new int[2];
            statusId[0] = 1;
            statusId[1] = 2;

            DALConexao conn = new(DadosConexao.StringConexao);
            BLLStatus bll = new(conn);
            cbxStatus.DataSource = bll.PesquisaSql(statusId);
            cbxStatus.DisplayMember = "descricao_status";
            cbxStatus.ValueMember = "status_id";

            BLLTipoProduto bllTipoProduto = new(conn);
            cbxTipoProduto.DataSource = bllTipoProduto.PesquisaSql();
            cbxTipoProduto.DisplayMember = "descricao_tipo_produto";
            cbxTipoProduto.ValueMember = "tipo_produto_id";

            textBox1.Text = this.codigo.ToString();

            if (!operacao.Equals("Inclusão") && !UsuarioConfig.TemPermissao("product.edit"))
            {
                btnSalvar.Enabled = false;
            }
            if (UsuarioConfig.TemPermissao("product.view"))
            {
                pnDados.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (codigo > 0)
            {
                try
                {
                    DALConexao conn = new(DadosConexao.StringConexao);
                    BLLProduto bll = new(conn);
                    ModelProduto model = bll.Abrir(EmpresaConfig.empresaId, codigo);
                    textBox1.Text = model.ProdutoId.ToString();
                    cbxStatus.SelectedValue = model.StatusId;
                    textBox2.Text = model.DescricaoProduto;
                    empresaId = model.EmpresaId;
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

        private void button3_Click(object sender, EventArgs e)
        {
            using (FrmGrupos frm = new())
            {
                frm.pnSelecionar.Visible = true;
                frm.tipo = "Grupo de Produtos";
                frm.ShowDialog();
                textBox10.Text = frm.codigo.ToString();
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox10.Text))
            {
                try
                {
                    DALConexao conn = new(DadosConexao.StringConexao);
                    BLLGrupo bll = new(conn);
                    ModelGrupo model = bll.Abrir(EmpresaConfig.empresaId, Convert.ToInt32(textBox10.Text));
                    textBox3.Text = model.NomeGrupo.ToString();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FrmGrupos frm = new())
            {
                frm.pnSelecionar.Visible = true;
                frm.tipo = "Sub Grupo de Produtos";
                frm.ShowDialog();
                textBox11.Text = frm.codigo.ToString();
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox11.Text))
            {
                try
                {
                    DALConexao conn = new(DadosConexao.StringConexao);
                    BLLGrupo bll = new(conn);
                    ModelGrupo model = bll.Abrir(EmpresaConfig.empresaId, Convert.ToInt32(textBox11.Text));
                    textBox4.Text = model.NomeGrupo.ToString();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
