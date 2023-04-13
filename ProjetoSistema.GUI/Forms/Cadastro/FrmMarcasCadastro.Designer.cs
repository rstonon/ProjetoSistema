namespace GUI
{
    partial class FrmMarcasCadastro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMarcasCadastro));
            btnCancelar = new Button();
            btnSalvar = new Button();
            button5 = new Button();
            pnBotoes = new Panel();
            pnDados = new Panel();
            label5 = new Label();
            cbxStatus = new ComboBox();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            pnBotoes.SuspendLayout();
            pnDados.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderColor = Color.Silver;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
            btnCancelar.ImageAlign = ContentAlignment.MiddleRight;
            btnCancelar.Location = new Point(8, 65);
            btnCancelar.Margin = new Padding(4, 3, 4, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(136, 53);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextAlign = ContentAlignment.BottomLeft;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Cursor = Cursors.Hand;
            btnSalvar.FlatAppearance.BorderColor = Color.Silver;
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnSalvar.Image = (Image)resources.GetObject("btnSalvar.Image");
            btnSalvar.ImageAlign = ContentAlignment.MiddleRight;
            btnSalvar.Location = new Point(8, 6);
            btnSalvar.Margin = new Padding(4, 3, 4, 3);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(136, 53);
            btnSalvar.TabIndex = 0;
            btnSalvar.Text = "Salvar";
            btnSalvar.TextAlign = ContentAlignment.BottomLeft;
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // button5
            // 
            button5.Cursor = Cursors.Hand;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            button5.ImageAlign = ContentAlignment.MiddleRight;
            button5.Location = new Point(8, 6);
            button5.Margin = new Padding(4, 3, 4, 3);
            button5.Name = "button5";
            button5.Size = new Size(136, 53);
            button5.TabIndex = 0;
            button5.Text = "Pesquisa";
            button5.TextAlign = ContentAlignment.BottomLeft;
            button5.UseVisualStyleBackColor = true;
            // 
            // pnBotoes
            // 
            pnBotoes.Controls.Add(btnCancelar);
            pnBotoes.Controls.Add(btnSalvar);
            pnBotoes.Controls.Add(button5);
            pnBotoes.Dock = DockStyle.Left;
            pnBotoes.Location = new Point(0, 0);
            pnBotoes.Margin = new Padding(4, 3, 4, 3);
            pnBotoes.Name = "pnBotoes";
            pnBotoes.Size = new Size(150, 729);
            pnBotoes.TabIndex = 1;
            // 
            // pnDados
            // 
            pnDados.Controls.Add(label5);
            pnDados.Controls.Add(cbxStatus);
            pnDados.Controls.Add(textBox2);
            pnDados.Controls.Add(label2);
            pnDados.Controls.Add(textBox1);
            pnDados.Controls.Add(label1);
            pnDados.Dock = DockStyle.Fill;
            pnDados.Location = new Point(150, 0);
            pnDados.Margin = new Padding(4, 3, 4, 3);
            pnDados.Name = "pnDados";
            pnDados.Size = new Size(1114, 729);
            pnDados.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(96, 18);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 4;
            label5.Text = "Status";
            // 
            // cbxStatus
            // 
            cbxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxStatus.FormattingEnabled = true;
            cbxStatus.Items.AddRange(new object[] { "Ativo", "Inativo" });
            cbxStatus.Location = new Point(99, 36);
            cbxStatus.Margin = new Padding(4, 3, 4, 3);
            cbxStatus.Name = "cbxStatus";
            cbxStatus.Size = new Size(94, 23);
            cbxStatus.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(201, 36);
            textBox2.Margin = new Padding(4, 3, 4, 3);
            textBox2.MaxLength = 50;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(425, 23);
            textBox2.TabIndex = 0;
            textBox2.Click += textBox2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(201, 18);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 0;
            label2.Text = "Descrição";
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(15, 36);
            textBox1.Margin = new Padding(4, 3, 4, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(76, 23);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 18);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 0;
            label1.Text = "Id";
            // 
            // FrmMarcasCadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 729);
            ControlBox = false;
            Controls.Add(pnDados);
            Controls.Add(pnBotoes);
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMarcasCadastro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Marcas";
            Load += FrmMarcaCadastro_Load;
            KeyDown += FrmColaboradoresTipoCadastro_KeyDown;
            pnBotoes.ResumeLayout(false);
            pnDados.ResumeLayout(false);
            pnDados.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel pnBotoes;
        private System.Windows.Forms.Panel pnDados;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private Label label5;
        private ComboBox cbxStatus;
    }
}