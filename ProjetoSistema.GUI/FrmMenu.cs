using GUI;
using ProjetoSistema.BLL;
using ProjetoSistema.DAL;
using ProjetoSistema.GUI.Classes;

namespace ProjetoSistema.GUI
{
    public partial class FrmMenu : Form
    {
        public static void OpenForm(Type frmType)
        {
            bool bolCtl = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType().Equals(frmType))
                {
                    form.BringToFront();
                    bolCtl = true;
                    break;
                }
            }

            if (!bolCtl)
            {
                Form frm = (Form)Activator.CreateInstance(frmType);
                frm.Show();
            }
        }
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UsuarioConfig.TemPermissao("brand.form"))
            {
                OpenForm(typeof(FrmGrupos));
            }

        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(typeof(FrmMarcas));
        }

        private void permissõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(typeof(FrmPermissoes));
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(typeof(FrmUsuarios));
        }

        private void FrmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}