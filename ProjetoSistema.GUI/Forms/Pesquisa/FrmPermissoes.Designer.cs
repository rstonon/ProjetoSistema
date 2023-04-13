namespace GUI
{
    partial class FrmPermissoes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPermissoes));
            pnBotoes = new Panel();
            BtnFechar = new Button();
            BtnRelatorios = new Button();
            BtnExcluir = new Button();
            BtnAbrir = new Button();
            BtnNovo = new Button();
            BtnPesquisa = new Button();
            panel1 = new Panel();
            tbcDados = new TabControl();
            tpPesquisa = new TabPage();
            DgvDados = new DataGridView();
            pnPesquisa = new Panel();
            label3 = new Label();
            cbxStatus = new ComboBox();
            label2 = new Label();
            txtPalavraChave = new TextBox();
            label1 = new Label();
            cbxPesquisarPor = new ComboBox();
            BtnPesquisar = new Button();
            pnSelecionar = new Panel();
            BtnSelecionar = new Button();
            tpRelatorios = new TabPage();
            panel2 = new Panel();
            BtnSelecionarRelatorio = new Button();
            pnBotoes.SuspendLayout();
            panel1.SuspendLayout();
            tbcDados.SuspendLayout();
            tpPesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvDados).BeginInit();
            pnPesquisa.SuspendLayout();
            pnSelecionar.SuspendLayout();
            tpRelatorios.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pnBotoes
            // 
            pnBotoes.Controls.Add(BtnFechar);
            pnBotoes.Controls.Add(BtnRelatorios);
            pnBotoes.Controls.Add(BtnExcluir);
            pnBotoes.Controls.Add(BtnAbrir);
            pnBotoes.Controls.Add(BtnNovo);
            pnBotoes.Controls.Add(BtnPesquisa);
            pnBotoes.Dock = DockStyle.Left;
            pnBotoes.Location = new Point(0, 0);
            pnBotoes.Margin = new Padding(4, 3, 4, 3);
            pnBotoes.Name = "pnBotoes";
            pnBotoes.Size = new Size(150, 729);
            pnBotoes.TabIndex = 1;
            // 
            // BtnFechar
            // 
            BtnFechar.Cursor = Cursors.Hand;
            BtnFechar.FlatAppearance.BorderColor = Color.Silver;
            BtnFechar.FlatStyle = FlatStyle.Flat;
            BtnFechar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BtnFechar.Image = (Image)resources.GetObject("BtnFechar.Image");
            BtnFechar.ImageAlign = ContentAlignment.MiddleRight;
            BtnFechar.Location = new Point(8, 242);
            BtnFechar.Margin = new Padding(4, 3, 4, 3);
            BtnFechar.Name = "BtnFechar";
            BtnFechar.Size = new Size(136, 53);
            BtnFechar.TabIndex = 1;
            BtnFechar.Text = "Fechar";
            BtnFechar.TextAlign = ContentAlignment.BottomLeft;
            BtnFechar.UseVisualStyleBackColor = true;
            BtnFechar.Click += BtnFechar_Click;
            // 
            // BtnRelatorios
            // 
            BtnRelatorios.Cursor = Cursors.Hand;
            BtnRelatorios.FlatAppearance.BorderColor = Color.Silver;
            BtnRelatorios.FlatStyle = FlatStyle.Flat;
            BtnRelatorios.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BtnRelatorios.Image = (Image)resources.GetObject("BtnRelatorios.Image");
            BtnRelatorios.ImageAlign = ContentAlignment.MiddleRight;
            BtnRelatorios.Location = new Point(8, 183);
            BtnRelatorios.Margin = new Padding(4, 3, 4, 3);
            BtnRelatorios.Name = "BtnRelatorios";
            BtnRelatorios.Size = new Size(136, 53);
            BtnRelatorios.TabIndex = 0;
            BtnRelatorios.Text = "Relatórios";
            BtnRelatorios.TextAlign = ContentAlignment.BottomLeft;
            BtnRelatorios.UseVisualStyleBackColor = true;
            BtnRelatorios.Click += BtnRelatorios_Click;
            // 
            // BtnExcluir
            // 
            BtnExcluir.Cursor = Cursors.Hand;
            BtnExcluir.FlatAppearance.BorderColor = Color.Silver;
            BtnExcluir.FlatStyle = FlatStyle.Flat;
            BtnExcluir.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BtnExcluir.Image = (Image)resources.GetObject("BtnExcluir.Image");
            BtnExcluir.ImageAlign = ContentAlignment.MiddleRight;
            BtnExcluir.Location = new Point(8, 123);
            BtnExcluir.Margin = new Padding(4, 3, 4, 3);
            BtnExcluir.Name = "BtnExcluir";
            BtnExcluir.Size = new Size(136, 53);
            BtnExcluir.TabIndex = 0;
            BtnExcluir.Text = "Excluir";
            BtnExcluir.TextAlign = ContentAlignment.BottomLeft;
            BtnExcluir.UseVisualStyleBackColor = true;
            BtnExcluir.Click += BtnExcluir_Click;
            // 
            // BtnAbrir
            // 
            BtnAbrir.Cursor = Cursors.Hand;
            BtnAbrir.FlatAppearance.BorderColor = Color.Silver;
            BtnAbrir.FlatStyle = FlatStyle.Flat;
            BtnAbrir.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BtnAbrir.Image = (Image)resources.GetObject("BtnAbrir.Image");
            BtnAbrir.ImageAlign = ContentAlignment.MiddleRight;
            BtnAbrir.Location = new Point(8, 65);
            BtnAbrir.Margin = new Padding(4, 3, 4, 3);
            BtnAbrir.Name = "BtnAbrir";
            BtnAbrir.Size = new Size(136, 53);
            BtnAbrir.TabIndex = 0;
            BtnAbrir.Text = "Abrir";
            BtnAbrir.TextAlign = ContentAlignment.BottomLeft;
            BtnAbrir.UseVisualStyleBackColor = true;
            BtnAbrir.Click += BtnAbrir_Click;
            // 
            // BtnNovo
            // 
            BtnNovo.Cursor = Cursors.Hand;
            BtnNovo.FlatAppearance.BorderColor = Color.Silver;
            BtnNovo.FlatStyle = FlatStyle.Flat;
            BtnNovo.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BtnNovo.Image = (Image)resources.GetObject("BtnNovo.Image");
            BtnNovo.ImageAlign = ContentAlignment.MiddleRight;
            BtnNovo.Location = new Point(8, 6);
            BtnNovo.Margin = new Padding(4, 3, 4, 3);
            BtnNovo.Name = "BtnNovo";
            BtnNovo.Size = new Size(136, 53);
            BtnNovo.TabIndex = 0;
            BtnNovo.Text = "Novo";
            BtnNovo.TextAlign = ContentAlignment.BottomLeft;
            BtnNovo.UseVisualStyleBackColor = true;
            BtnNovo.Click += BtnNovo_Click;
            // 
            // BtnPesquisa
            // 
            BtnPesquisa.Cursor = Cursors.Hand;
            BtnPesquisa.FlatAppearance.BorderColor = Color.Silver;
            BtnPesquisa.FlatStyle = FlatStyle.Flat;
            BtnPesquisa.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BtnPesquisa.Image = (Image)resources.GetObject("BtnPesquisa.Image");
            BtnPesquisa.ImageAlign = ContentAlignment.MiddleRight;
            BtnPesquisa.Location = new Point(8, 6);
            BtnPesquisa.Margin = new Padding(4, 3, 4, 3);
            BtnPesquisa.Name = "BtnPesquisa";
            BtnPesquisa.Size = new Size(136, 53);
            BtnPesquisa.TabIndex = 0;
            BtnPesquisa.Text = "Pesquisa";
            BtnPesquisa.TextAlign = ContentAlignment.BottomLeft;
            BtnPesquisa.UseVisualStyleBackColor = true;
            BtnPesquisa.Click += BtnPesquisa_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(tbcDados);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(150, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1114, 729);
            panel1.TabIndex = 4;
            // 
            // tbcDados
            // 
            tbcDados.Alignment = TabAlignment.Bottom;
            tbcDados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbcDados.Controls.Add(tpPesquisa);
            tbcDados.Controls.Add(tpRelatorios);
            tbcDados.Location = new Point(6, 6);
            tbcDados.Margin = new Padding(4, 3, 4, 3);
            tbcDados.Name = "tbcDados";
            tbcDados.Padding = new Point(50, 3);
            tbcDados.SelectedIndex = 0;
            tbcDados.Size = new Size(1108, 743);
            tbcDados.TabIndex = 0;
            // 
            // tpPesquisa
            // 
            tpPesquisa.Controls.Add(DgvDados);
            tpPesquisa.Controls.Add(pnPesquisa);
            tpPesquisa.Controls.Add(pnSelecionar);
            tpPesquisa.Location = new Point(4, 4);
            tpPesquisa.Margin = new Padding(4, 3, 4, 3);
            tpPesquisa.Name = "tpPesquisa";
            tpPesquisa.Padding = new Padding(4, 3, 4, 3);
            tpPesquisa.Size = new Size(1100, 715);
            tpPesquisa.TabIndex = 0;
            tpPesquisa.Text = "Pesquisa";
            tpPesquisa.UseVisualStyleBackColor = true;
            // 
            // DgvDados
            // 
            DgvDados.AllowUserToAddRows = false;
            DgvDados.AllowUserToDeleteRows = false;
            DgvDados.AllowUserToResizeColumns = false;
            DgvDados.AllowUserToResizeRows = false;
            DgvDados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DgvDados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvDados.Location = new Point(4, 103);
            DgvDados.Margin = new Padding(4, 3, 4, 3);
            DgvDados.Name = "DgvDados";
            DgvDados.ReadOnly = true;
            DgvDados.RowHeadersWidth = 35;
            DgvDados.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            DgvDados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvDados.Size = new Size(1092, 534);
            DgvDados.TabIndex = 2;
            DgvDados.Text = "dataGridView1";
            DgvDados.DoubleClick += DgvDados_DoubleClick;
            // 
            // pnPesquisa
            // 
            pnPesquisa.Controls.Add(label3);
            pnPesquisa.Controls.Add(cbxStatus);
            pnPesquisa.Controls.Add(label2);
            pnPesquisa.Controls.Add(txtPalavraChave);
            pnPesquisa.Controls.Add(label1);
            pnPesquisa.Controls.Add(cbxPesquisarPor);
            pnPesquisa.Controls.Add(BtnPesquisar);
            pnPesquisa.Dock = DockStyle.Top;
            pnPesquisa.Location = new Point(4, 3);
            pnPesquisa.Margin = new Padding(4, 3, 4, 3);
            pnPesquisa.Name = "pnPesquisa";
            pnPesquisa.Size = new Size(1092, 100);
            pnPesquisa.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(136, 33);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 2;
            label3.Text = "Status";
            // 
            // cbxStatus
            // 
            cbxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxStatus.FormattingEnabled = true;
            cbxStatus.Items.AddRange(new object[] { "Ativo", "Inativo", "Todos" });
            cbxStatus.Location = new Point(139, 51);
            cbxStatus.Margin = new Padding(4, 3, 4, 3);
            cbxStatus.Name = "cbxStatus";
            cbxStatus.Size = new Size(121, 23);
            cbxStatus.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(264, 33);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 2;
            label2.Text = "Palavra-Chave";
            // 
            // txtPalavraChave
            // 
            txtPalavraChave.Location = new Point(268, 51);
            txtPalavraChave.Margin = new Padding(4, 3, 4, 3);
            txtPalavraChave.Name = "txtPalavraChave";
            txtPalavraChave.Size = new Size(235, 23);
            txtPalavraChave.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 33);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 2;
            label1.Text = "Pesquisar Por";
            // 
            // cbxPesquisarPor
            // 
            cbxPesquisarPor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxPesquisarPor.FormattingEnabled = true;
            cbxPesquisarPor.Items.AddRange(new object[] { "Código", "Descrição", "Tela" });
            cbxPesquisarPor.Location = new Point(10, 51);
            cbxPesquisarPor.Margin = new Padding(4, 3, 4, 3);
            cbxPesquisarPor.Name = "cbxPesquisarPor";
            cbxPesquisarPor.Size = new Size(121, 23);
            cbxPesquisarPor.TabIndex = 1;
            // 
            // BtnPesquisar
            // 
            BtnPesquisar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnPesquisar.Cursor = Cursors.Hand;
            BtnPesquisar.FlatAppearance.BorderColor = Color.Silver;
            BtnPesquisar.FlatStyle = FlatStyle.Flat;
            BtnPesquisar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BtnPesquisar.Image = (Image)resources.GetObject("BtnPesquisar.Image");
            BtnPesquisar.ImageAlign = ContentAlignment.MiddleRight;
            BtnPesquisar.Location = new Point(951, 21);
            BtnPesquisar.Margin = new Padding(4, 3, 4, 3);
            BtnPesquisar.Name = "BtnPesquisar";
            BtnPesquisar.Size = new Size(136, 53);
            BtnPesquisar.TabIndex = 0;
            BtnPesquisar.Text = "Pesquisar";
            BtnPesquisar.TextAlign = ContentAlignment.BottomLeft;
            BtnPesquisar.UseVisualStyleBackColor = true;
            BtnPesquisar.Click += BtnPesquisar_Click;
            // 
            // pnSelecionar
            // 
            pnSelecionar.Controls.Add(BtnSelecionar);
            pnSelecionar.Dock = DockStyle.Bottom;
            pnSelecionar.Location = new Point(4, 637);
            pnSelecionar.Margin = new Padding(4, 3, 4, 3);
            pnSelecionar.Name = "pnSelecionar";
            pnSelecionar.Size = new Size(1092, 75);
            pnSelecionar.TabIndex = 0;
            pnSelecionar.Visible = false;
            // 
            // BtnSelecionar
            // 
            BtnSelecionar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnSelecionar.Cursor = Cursors.Hand;
            BtnSelecionar.FlatAppearance.BorderColor = Color.Silver;
            BtnSelecionar.FlatStyle = FlatStyle.Flat;
            BtnSelecionar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BtnSelecionar.Image = (Image)resources.GetObject("BtnSelecionar.Image");
            BtnSelecionar.ImageAlign = ContentAlignment.MiddleRight;
            BtnSelecionar.Location = new Point(950, 17);
            BtnSelecionar.Margin = new Padding(4, 3, 4, 3);
            BtnSelecionar.Name = "BtnSelecionar";
            BtnSelecionar.Size = new Size(136, 53);
            BtnSelecionar.TabIndex = 0;
            BtnSelecionar.Text = "Selecionar";
            BtnSelecionar.TextAlign = ContentAlignment.BottomLeft;
            BtnSelecionar.UseVisualStyleBackColor = true;
            BtnSelecionar.Click += BtnSelecionar_Click;
            // 
            // tpRelatorios
            // 
            tpRelatorios.Controls.Add(panel2);
            tpRelatorios.Location = new Point(4, 4);
            tpRelatorios.Margin = new Padding(4, 3, 4, 3);
            tpRelatorios.Name = "tpRelatorios";
            tpRelatorios.Padding = new Padding(4, 3, 4, 3);
            tpRelatorios.Size = new Size(1100, 715);
            tpRelatorios.TabIndex = 1;
            tpRelatorios.Text = "Relatórios";
            tpRelatorios.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(BtnSelecionarRelatorio);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(4, 637);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1092, 75);
            panel2.TabIndex = 0;
            // 
            // BtnSelecionarRelatorio
            // 
            BtnSelecionarRelatorio.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnSelecionarRelatorio.Cursor = Cursors.Hand;
            BtnSelecionarRelatorio.FlatAppearance.BorderColor = Color.Silver;
            BtnSelecionarRelatorio.FlatStyle = FlatStyle.Flat;
            BtnSelecionarRelatorio.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BtnSelecionarRelatorio.Image = (Image)resources.GetObject("BtnSelecionarRelatorio.Image");
            BtnSelecionarRelatorio.ImageAlign = ContentAlignment.MiddleRight;
            BtnSelecionarRelatorio.Location = new Point(951, 12);
            BtnSelecionarRelatorio.Margin = new Padding(4, 3, 4, 3);
            BtnSelecionarRelatorio.Name = "BtnSelecionarRelatorio";
            BtnSelecionarRelatorio.Size = new Size(136, 53);
            BtnSelecionarRelatorio.TabIndex = 0;
            BtnSelecionarRelatorio.Text = "Selecionar";
            BtnSelecionarRelatorio.TextAlign = ContentAlignment.BottomLeft;
            BtnSelecionarRelatorio.UseVisualStyleBackColor = true;
            // 
            // FrmPermissoes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 729);
            Controls.Add(panel1);
            Controls.Add(pnBotoes);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmPermissoes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Permissões";
            Load += FrmPermissoes_Load;
            KeyDown += FrmModelo_KeyDown;
            pnBotoes.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tbcDados.ResumeLayout(false);
            tpPesquisa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvDados).EndInit();
            pnPesquisa.ResumeLayout(false);
            pnPesquisa.PerformLayout();
            pnSelecionar.ResumeLayout(false);
            tpRelatorios.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TabPage tpPesquisa;
        private System.Windows.Forms.TabPage tpRelatorios;
        private System.Windows.Forms.Button BtnPesquisa;
        protected System.Windows.Forms.Panel pnBotoes;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Button BtnNovo;
        protected System.Windows.Forms.TabControl tbcDados;
        protected System.Windows.Forms.Button BtnRelatorios;
        protected System.Windows.Forms.Button BtnExcluir;
        protected System.Windows.Forms.Button BtnAbrir;
        protected System.Windows.Forms.DataGridView DgvDados;
        protected System.Windows.Forms.Panel pnPesquisa;
        protected System.Windows.Forms.Button BtnSelecionar;
        protected System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.Button BtnSelecionarRelatorio;
        private System.Windows.Forms.Button BtnPesquisar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPalavraChave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxPesquisarPor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxStatus;
        protected Button BtnFechar;
        public Panel pnSelecionar;
    }
}