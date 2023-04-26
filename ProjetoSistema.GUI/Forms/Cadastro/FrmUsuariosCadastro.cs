using ProjetoSistema.BLL;
using ProjetoSistema.DAL;
using ProjetoSistema.GUI.Classes;
using ProjetoSistema.Model;
using ProjetoSistema.Models;

namespace GUI
{
    public partial class FrmUsuariosCadastro : Form
    {
        public int codigo;
        public string operacao;
        public string origem;
        readonly FrmUsuarios form;

        public FrmUsuariosCadastro(FrmUsuarios form)
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
                    ModelUsuario model = new()
                    {
                        StatusId = Convert.ToInt32(cbxStatus.SelectedValue),
                        NomeUsuario = textBox2.Text,
                        Senha = textBox3.Text,
                        PerfilId = Convert.ToInt32(cbxPerfil.SelectedValue)
                    };

                    DALConexao conn = new(DadosConexao.StringConexao);
                    BLLUsuario bll = new(conn);

                    if (operacao.Equals("Inclusão"))
                    {
                        bll.Adicionar(model);
                    }
                    else
                    {
                        model.UsuarioId = Convert.ToInt32(textBox1.Text);
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

        private void FrmUsuarioCadastro_Load(object sender, EventArgs e)
        {
            DALConexao conn = new(DadosConexao.StringConexao);
            BLLStatus bll = new(conn);
            cbxStatus.DataSource = bll.PesquisaSql();
            cbxStatus.DisplayMember = "descricao_status";
            cbxStatus.ValueMember = "status_id";

            BLLPerfilUsuario bllPerfil = new(conn);
            cbxPerfil.DataSource = bllPerfil.PesquisaSql(EmpresaConfig.empresaId, "Descrição", "Ativo", "");
            cbxPerfil.DisplayMember = "nome_perfil";
            cbxPerfil.ValueMember = "perfil_usuario_id";

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
                    BLLUsuario bll = new(conn);
                    ModelUsuario model = bll.Abrir(EmpresaConfig.empresaId, codigo);
                    textBox1.Text = model.UsuarioId.ToString();
                    cbxStatus.SelectedValue = model.StatusId;
                    textBox2.Text = model.NomeUsuario;
                    textBox3.Text = model.Senha;
                    cbxPerfil.SelectedValue = model.PerfilId;

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
        }
    }
}
