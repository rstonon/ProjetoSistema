using ProjetoSistema.BLL;
using ProjetoSistema.DAL;
using ProjetoSistema.GUI;
using ProjetoSistema.GUI.Classes;
using System.Data;

namespace GUI
{
    public partial class FrmGrupos : Form
    {

        public int codigo = 0;
        public string origem;
        public string pesquisarPor;
        public string status;
        public string tipo;

        public void AlteraBotoes(int op)
        {
            BtnNovo.Visible = false;
            BtnAbrir.Visible = false;
            BtnExcluir.Visible = false;
            BtnRelatorios.Visible = false;
            BtnPesquisa.Visible = false;
            BtnFechar.Visible = false;

            if (op == 1)
            {
                BtnNovo.Visible = true;
                BtnAbrir.Visible = true;
                BtnExcluir.Visible = true;
                BtnRelatorios.Visible = true;
                BtnFechar.Visible = true;
                tbcDados.SelectedTab = tpPesquisa;
            }

            if (op == 2)
            {
                BtnPesquisa.Visible = true;
                tbcDados.SelectedTab = tpRelatorios;
            }
        }

        public void PesquisaSql()
        {
            DALConexao conn = new(DadosConexao.StringConexao);
            BLLGrupo bll = new(conn);

            DgvDados.DataSource = bll.PesquisaSql(EmpresaConfig.empresaId, cbxPesquisarPor.Text, cbxStatus.Text, cbxTipo.Text, txtPalavraChave.Text);


            CarregarDados();
        }

        private void CarregarDados()
        {
            DgvDados.Columns[0].HeaderText = "Código";
            DgvDados.Columns[0].Width = 80;
            DgvDados.Columns[0].Visible = false;
            DgvDados.Columns[1].HeaderText = "Descrição";
            DgvDados.Columns[1].Width = 550;

            DgvDados.Focus();
        }

        public void Excluir()
        {
            try
            {
                DialogResult d = MessageBox.Show("Deseja realmente excluir o registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (d.ToString().Equals("Yes"))
                {
                    DALConexao conn = new(DadosConexao.StringConexao);
                    BLLGrupo bll = new(conn);
                    bll.Excluir(EmpresaConfig.empresaId, Convert.ToInt32(DgvDados.CurrentRow.Cells[0].Value.ToString()));
                }
                PesquisaSql();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Relatórios()
        {
            AlteraBotoes(2);
        }
        private void Lista()
        {
            AlteraBotoes(1);
        }

        private void Novo()
        {
            FrmGruposCadastro f = new(this)
            {
                operacao = "Inclusão",
                tipoGrupo = cbxTipo.Text,
            };
            f.ShowDialog();
            f.LimparDados();
        }

        private void Abrir()
        {
            int item = Convert.ToInt32(DgvDados.CurrentRow.Cells[0].Value);

            if (item > 0)
            {
                codigo = item;
            }
            else
            {
                MessageBox.Show("Favor selecionar um registro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmGruposCadastro f = new(this)
            {
                codigo = this.codigo,
                operacao = "Edição"
            };
            f.ShowDialog();

        }

        private void Selecionar()
        {
            int item = Convert.ToInt32(DgvDados.CurrentRow.Cells[0].Value);

            if (item > 0)
            {
                this.codigo = item;
                this.Close();
            }
            else
            {
                MessageBox.Show("Favor selecionar um registro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public FrmGrupos()
        {
            InitializeComponent();
        }

        private void FrmGrupos_Load(object sender, EventArgs e)
        {
            DALConexao conn = new(DadosConexao.StringConexao);
            BLLStatus bll = new(conn);
            cbxStatus.DataSource = bll.PesquisaSql();
            cbxStatus.DisplayMember = "descricao_status";
            cbxStatus.ValueMember = "status_id";

            DataTable source = (DataTable)this.cbxStatus.DataSource;
            DataRow row = source.NewRow();
            row[1] = "Todos";
            source.Rows.InsertAt(row, 0);

            if (pnSelecionar.Visible == false)
            {
                DgvDados.Height = 609;
            }
            else
            {
                DgvDados.Height = 534;
            }

            if (pesquisarPor == null)
            {
                cbxPesquisarPor.Text = "Descrição";
            }
            else
            {
                cbxPesquisarPor.Text = pesquisarPor;
            }

            if (status == null)
            {
                cbxStatus.Text = "Ativo";
            }
            else
            {
                cbxStatus.Text = status;
            }

            if (tipo == null)
            {
                cbxTipo.Text = "Grupo de Produtos";
            }
            else
            {
                cbxTipo.Text = tipo;
            }

            AlteraBotoes(1);

            if (!UsuarioConfig.TemPermissao("group.create"))
            {
                BtnNovo.Enabled = false;
            }
            if (!UsuarioConfig.TemPermissao("group.view"))
            {
                BtnAbrir.Enabled = false;
            }
            if (!UsuarioConfig.TemPermissao("group.delete"))
            {
                BtnExcluir.Enabled = false;
            }
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void BtnPesquisa_Click(object sender, EventArgs e)
        {
            Lista();
        }

        private void FrmGrupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
            if (e.KeyCode == Keys.F1)
            {
                Novo();
            }
            if (e.KeyCode == Keys.F2)
            {
                Abrir();
            }
            if (e.KeyCode == Keys.F6)
            {
                Excluir();
            }
            if (e.KeyCode == Keys.F7)
            {
                Relatórios();
            }
            if (e.KeyCode == Keys.F8)
            {
                Lista();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            PesquisaSql();
        }

        private void BtnRelatorios_Click(object sender, EventArgs e)
        {
            Relatórios();
        }

        private void BtnAbrir_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void DgvDados_DoubleClick(object sender, EventArgs e)
        {
            if (pnSelecionar.Visible == true)
            {
                Selecionar();
            }
            else
            {
                Abrir();
            }
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSelecionar_Click(object sender, EventArgs e)
        {
            Selecionar();
        }
    }
}
