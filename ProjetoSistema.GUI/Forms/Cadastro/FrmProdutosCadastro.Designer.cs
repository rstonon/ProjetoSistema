namespace GUI
{
    partial class FrmProdutosCadastro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProdutosCadastro));
            btnCancelar = new Button();
            btnSalvar = new Button();
            button5 = new Button();
            pnBotoes = new Panel();
            pnDados = new Panel();
            textBox12 = new TextBox();
            textBox11 = new TextBox();
            textBox10 = new TextBox();
            label11 = new Label();
            textBox9 = new TextBox();
            label10 = new Label();
            textBox8 = new TextBox();
            textBox7 = new TextBox();
            label9 = new Label();
            label8 = new Label();
            textBox6 = new TextBox();
            button2 = new Button();
            textBox5 = new TextBox();
            label7 = new Label();
            button1 = new Button();
            textBox4 = new TextBox();
            label6 = new Label();
            button3 = new Button();
            textBox3 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            cbxTipoProduto = new ComboBox();
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
            pnDados.Controls.Add(textBox12);
            pnDados.Controls.Add(textBox11);
            pnDados.Controls.Add(textBox10);
            pnDados.Controls.Add(label11);
            pnDados.Controls.Add(textBox9);
            pnDados.Controls.Add(label10);
            pnDados.Controls.Add(textBox8);
            pnDados.Controls.Add(textBox7);
            pnDados.Controls.Add(label9);
            pnDados.Controls.Add(label8);
            pnDados.Controls.Add(textBox6);
            pnDados.Controls.Add(button2);
            pnDados.Controls.Add(textBox5);
            pnDados.Controls.Add(label7);
            pnDados.Controls.Add(button1);
            pnDados.Controls.Add(textBox4);
            pnDados.Controls.Add(label6);
            pnDados.Controls.Add(button3);
            pnDados.Controls.Add(textBox3);
            pnDados.Controls.Add(label3);
            pnDados.Controls.Add(label4);
            pnDados.Controls.Add(cbxTipoProduto);
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
            // textBox12
            // 
            textBox12.Enabled = false;
            textBox12.Location = new Point(880, 15);
            textBox12.Margin = new Padding(4, 3, 4, 3);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(76, 23);
            textBox12.TabIndex = 36;
            // 
            // textBox11
            // 
            textBox11.Enabled = false;
            textBox11.Location = new Point(658, 15);
            textBox11.Margin = new Padding(4, 3, 4, 3);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(76, 23);
            textBox11.TabIndex = 35;
            textBox11.TextChanged += textBox11_TextChanged;
            // 
            // textBox10
            // 
            textBox10.Enabled = false;
            textBox10.Location = new Point(425, 15);
            textBox10.Margin = new Padding(4, 3, 4, 3);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(76, 23);
            textBox10.TabIndex = 34;
            textBox10.TextChanged += textBox10_TextChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(742, 76);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(68, 15);
            label11.TabIndex = 33;
            label11.Text = "Valor Venda";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(742, 95);
            textBox9.Margin = new Padding(4, 3, 4, 3);
            textBox9.MaxLength = 50;
            textBox9.Name = "textBox9";
            textBox9.RightToLeft = RightToLeft.Yes;
            textBox9.Size = new Size(106, 23);
            textBox9.TabIndex = 32;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(628, 77);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(67, 15);
            label10.TabIndex = 31;
            label10.Text = "Valor Custo";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(628, 96);
            textBox8.Margin = new Padding(4, 3, 4, 3);
            textBox8.MaxLength = 50;
            textBox8.Name = "textBox8";
            textBox8.RightToLeft = RightToLeft.Yes;
            textBox8.Size = new Size(106, 23);
            textBox8.TabIndex = 30;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(562, 96);
            textBox7.Margin = new Padding(4, 3, 4, 3);
            textBox7.MaxLength = 50;
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(58, 23);
            textBox7.TabIndex = 28;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(562, 78);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(51, 15);
            label9.TabIndex = 29;
            label9.Text = "Unidade";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 77);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(92, 15);
            label8.TabIndex = 27;
            label8.Text = "Código Produto";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(15, 96);
            textBox6.Margin = new Padding(4, 3, 4, 3);
            textBox6.MaxLength = 50;
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(106, 23);
            textBox6.TabIndex = 26;
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderColor = Color.Silver;
            button2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(1018, 35);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(25, 25);
            button2.TabIndex = 25;
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(814, 36);
            textBox5.Margin = new Padding(4, 3, 4, 3);
            textBox5.MaxLength = 50;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(196, 23);
            textBox5.TabIndex = 23;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(814, 18);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(40, 15);
            label7.TabIndex = 24;
            label7.Text = "Marca";
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderColor = Color.Silver;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(776, 35);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(25, 25);
            button1.TabIndex = 22;
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(572, 37);
            textBox4.Margin = new Padding(4, 3, 4, 3);
            textBox4.MaxLength = 50;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(196, 23);
            textBox4.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(572, 19);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(63, 15);
            label6.TabIndex = 21;
            label6.Text = "Sub Grupo";
            // 
            // button3
            // 
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderColor = Color.Silver;
            button3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(534, 35);
            button3.Margin = new Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new Size(25, 25);
            button3.TabIndex = 19;
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(330, 36);
            textBox3.Margin = new Padding(4, 3, 4, 3);
            textBox3.MaxLength = 50;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(196, 23);
            textBox3.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(330, 18);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 9;
            label3.Text = "Grupo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(201, 18);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(76, 15);
            label4.TabIndex = 7;
            label4.Text = "Tipo Produto";
            // 
            // cbxTipoProduto
            // 
            cbxTipoProduto.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxTipoProduto.FormattingEnabled = true;
            cbxTipoProduto.Items.AddRange(new object[] { "Ativo", "Inativo", "Todos" });
            cbxTipoProduto.Location = new Point(201, 36);
            cbxTipoProduto.Margin = new Padding(4, 3, 4, 3);
            cbxTipoProduto.Name = "cbxTipoProduto";
            cbxTipoProduto.Size = new Size(121, 23);
            cbxTipoProduto.TabIndex = 6;
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
            textBox2.Location = new Point(129, 95);
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
            label2.Location = new Point(129, 77);
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
            // FrmProdutosCadastro
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
            Name = "FrmProdutosCadastro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Produtos";
            Load += FrmProdutoCadastro_Load;
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
        private Label label4;
        private ComboBox cbxTipoProduto;
        private TextBox textBox3;
        private Label label3;
        private Button button3;
        private Label label8;
        private TextBox textBox6;
        private Button button2;
        private TextBox textBox5;
        private Label label7;
        private Button button1;
        private TextBox textBox4;
        private Label label6;
        private TextBox textBox7;
        private Label label9;
        private Label label11;
        private TextBox textBox9;
        private Label label10;
        private TextBox textBox8;
        private TextBox textBox12;
        private TextBox textBox11;
        private TextBox textBox10;
    }
}