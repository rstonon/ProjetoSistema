namespace ProjetoSistema.GUI
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            textBox1 = new TextBox();
            label1 = new Label();
            textBox2 = new TextBox();
            BtnFechar = new Button();
            BtnAcessar = new Button();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Window;
            textBox1.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(12, 156);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(343, 36);
            textBox1.TabIndex = 0;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(133, 47);
            label1.Name = "label1";
            label1.Size = new Size(99, 45);
            label1.TabIndex = 1;
            label1.Text = "Login";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Window;
            textBox2.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(12, 254);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(343, 36);
            textBox2.TabIndex = 2;
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // BtnFechar
            // 
            BtnFechar.Cursor = Cursors.Hand;
            BtnFechar.FlatAppearance.BorderColor = Color.Silver;
            BtnFechar.FlatStyle = FlatStyle.Flat;
            BtnFechar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BtnFechar.Image = (Image)resources.GetObject("BtnFechar.Image");
            BtnFechar.ImageAlign = ContentAlignment.MiddleRight;
            BtnFechar.Location = new Point(268, 346);
            BtnFechar.Margin = new Padding(4, 3, 4, 3);
            BtnFechar.Name = "BtnFechar";
            BtnFechar.Size = new Size(86, 35);
            BtnFechar.TabIndex = 4;
            BtnFechar.Text = "Sair";
            BtnFechar.TextAlign = ContentAlignment.MiddleLeft;
            BtnFechar.UseVisualStyleBackColor = true;
            BtnFechar.Click += BtnFechar_Click;
            // 
            // BtnAcessar
            // 
            BtnAcessar.Cursor = Cursors.Hand;
            BtnAcessar.FlatAppearance.BorderColor = Color.Silver;
            BtnAcessar.FlatStyle = FlatStyle.Flat;
            BtnAcessar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BtnAcessar.Image = (Image)resources.GetObject("BtnAcessar.Image");
            BtnAcessar.ImageAlign = ContentAlignment.MiddleRight;
            BtnAcessar.Location = new Point(13, 346);
            BtnAcessar.Margin = new Padding(4, 3, 4, 3);
            BtnAcessar.Name = "BtnAcessar";
            BtnAcessar.Size = new Size(247, 35);
            BtnAcessar.TabIndex = 3;
            BtnAcessar.Text = "Acessar";
            BtnAcessar.UseVisualStyleBackColor = true;
            BtnAcessar.Click += BtnAcessar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 138);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 5;
            label2.Text = "Usuário";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 236);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 6;
            label3.Text = "Senha";
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(367, 394);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(BtnAcessar);
            Controls.Add(BtnFechar);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private TextBox textBox2;
        protected Button BtnFechar;
        protected Button BtnAcessar;
        private Label label2;
        private Label label3;
    }
}