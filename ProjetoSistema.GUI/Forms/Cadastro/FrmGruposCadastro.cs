using ProjetoSistema.BLL;
using ProjetoSistema.DAL;
using ProjetoSistema.Models;

namespace GUI
{
    public partial class FrmGruposCadastro : Form
    {
        public int codigo;
        public string tipoGrupo;
        public string operacao;
        public string origem;
        FrmGrupos form;

        public FrmGruposCadastro(FrmGrupos form)
        {
            InitializeComponent();
            this.form = form;
        }

        public void LimparDados()
        {
            textBox1.Clear();
            textBox2.Clear();
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
                    ModelGrupo model = new()
                    {
                        StatusId = Convert.ToInt32(cbxStatus.SelectedValue),
                        TipoGrupo = comboBox1.Text,
                        NomeGrupo = textBox2.Text
                    };

                    DALConexao conn = new(DadosConexao.StringConexao);
                    BLLGrupo bll = new(conn);

                    if (operacao.Equals("Inclusão"))
                    {
                        bll.Adicionar(model);
                    }
                    else
                    {
                        model.GrupoId = Convert.ToInt32(textBox1.Text);
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

        private void FrmGrupoCadastro_Load(object sender, EventArgs e)
        {
            DALConexao conn = new(DadosConexao.StringConexao);
            BLLStatus bll = new(conn);
            cbxStatus.DataSource = bll.PesquisaSql();
            cbxStatus.DisplayMember = "descricao_status";
            cbxStatus.ValueMember = "status_id";

            textBox1.Text = this.codigo.ToString();

            if (String.IsNullOrEmpty(tipoGrupo))
            {
                tipoGrupo = "Grupo de Produtos";
            }

            comboBox1.Text = tipoGrupo;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (codigo > 0)
            {
                try
                {
                    DALConexao conn = new(DadosConexao.StringConexao);
                    BLLGrupo bll = new(conn);
                    ModelGrupo model = bll.Abrir(codigo);
                    textBox1.Text = model.GrupoId.ToString();
                    cbxStatus.SelectedValue = model.StatusId;
                    comboBox1.Text = model.TipoGrupo;
                    textBox2.Text = model.NomeGrupo;
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
