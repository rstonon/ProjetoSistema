using ProjetoSistema.BLL;
using ProjetoSistema.DAL;
using ProjetoSistema.GUI.Classes;
using ProjetoSistema.Model;
using ProjetoSistema.Models;

namespace GUI
{
    public partial class FrmGruposCadastro : Form
    {
        public int codigo;
        public string tipoGrupo;
        public string operacao;
        public string origem;
        private int empresaId;
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
                        EmpresaId = empresaId,
                        TipoGrupo = comboBox1.Text,
                        NomeGrupo = textBox2.Text
                    };

                    DALConexao conn = new(DadosConexao.StringConexao);
                    BLLGrupo bll = new(conn);

                    if (operacao.Equals("Inclusão"))
                    {
                        bll.Adicionar(model);

                        ModelLog modelLog = new()
                        {
                            EmpresaId = EmpresaConfig.empresaId,
                            Data = DateTime.Now,
                            TipoLog = 'C',
                            Tela = "Grupos",
                            Usuario = UsuarioConfig.nomeUsuario,
                            Descricao = @$"Adicionou o Grupo: {model.GrupoId} - {model.NomeGrupo}",
                        };

                        DALConexao connLog = new(DadosConexao.StringConexaoLog);
                        BLLLog bllLog = new(connLog);
                        bllLog.GerarLog(EmpresaConfig.empresaId, modelLog);
                    }
                    else
                    {
                        model.GrupoId = Convert.ToInt32(textBox1.Text);
                        bll.Editar(model);

                        ModelLog modelLog = new()
                        {
                            EmpresaId = EmpresaConfig.empresaId,
                            Data = DateTime.Now,
                            TipoLog = 'U',
                            Tela = "Grupos",
                            Usuario = UsuarioConfig.nomeUsuario,
                            Descricao = @$"Alterou o cadastro do Grupo: {model.GrupoId} - {model.NomeGrupo}",
                        };

                        DALConexao connLog = new(DadosConexao.StringConexaoLog);
                        BLLLog bllLog = new(connLog);
                        bllLog.GerarLog(EmpresaConfig.empresaId, modelLog);
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

                ModelLog modelLog = new()
                {
                    EmpresaId = EmpresaConfig.empresaId,
                    Data = DateTime.Now,
                    TipoLog = 'G',
                    Tela = "Grupos",
                    Usuario = UsuarioConfig.nomeUsuario,
                    Descricao = "Cancelou o salvamento do Grupo: " + textBox1.Text + " - " + textBox2.Text,
                };

                DALConexao connLog = new(DadosConexao.StringConexaoLog);
                BLLLog bllLog = new(connLog);
                bllLog.GerarLog(EmpresaConfig.empresaId, modelLog);
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
            int[] statusId = new int[2];
            statusId[0] = 1;
            statusId[1] = 2;

            DALConexao conn = new(DadosConexao.StringConexao);
            BLLStatus bll = new(conn);
            cbxStatus.DataSource = bll.PesquisaSql(statusId);
            cbxStatus.DisplayMember = "descricao_status";
            cbxStatus.ValueMember = "status_id";

            textBox1.Text = this.codigo.ToString();

            if (String.IsNullOrEmpty(tipoGrupo))
            {
                tipoGrupo = "Grupo de Produtos";
            }

            comboBox1.Text = tipoGrupo;

            if (!operacao.Equals("Inclusão") && !UsuarioConfig.TemPermissao("group.edit"))
            {
                btnSalvar.Enabled = false;
            }
            if (UsuarioConfig.TemPermissao("group.view"))
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
                    BLLGrupo bll = new(conn);
                    ModelGrupo model = bll.Abrir(EmpresaConfig.empresaId, codigo);
                    textBox1.Text = model.GrupoId.ToString();
                    cbxStatus.SelectedValue = model.StatusId;
                    comboBox1.Text = model.TipoGrupo;
                    textBox2.Text = model.NomeGrupo;
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
