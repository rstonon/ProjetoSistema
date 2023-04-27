using ProjetoSistema.BLL;
using ProjetoSistema.DAL;
using ProjetoSistema.GUI.Classes;
using ProjetoSistema.Models;

namespace GUI
{
    public partial class FrmMarcasCadastro : Form
    {
        public int codigo;
        public string operacao;
        public string origem;
        private int empresaId;
        FrmMarcas form;

        public FrmMarcasCadastro(FrmMarcas form)
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
                    ModelMarca model = new()
                    {
                        StatusId = Convert.ToInt32(cbxStatus.SelectedValue),
                        EmpresaId = empresaId,
                        DescricaoMarca = textBox2.Text,
                    };

                    DALConexao conn = new(DadosConexao.StringConexao);
                    BLLMarca bll = new(conn);

                    if (operacao.Equals("Inclusão"))
                    {
                        bll.Adicionar(EmpresaConfig.empresaId, model);
                    }
                    else
                    {
                        model.MarcaId = Convert.ToInt32(textBox1.Text);
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

        private void FrmMarcaCadastro_Load(object sender, EventArgs e)
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
                    BLLMarca bll = new(conn);
                    ModelMarca model = bll.Abrir(EmpresaConfig.empresaId, codigo);
                    textBox1.Text = model.MarcaId.ToString();
                    cbxStatus.SelectedValue = model.StatusId;
                    textBox2.Text = model.DescricaoMarca;
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
    }
}
