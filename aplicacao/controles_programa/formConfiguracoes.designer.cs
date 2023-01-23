namespace aplicacao
{
    partial class formConfiguracoes
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCaminhoImagem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbServidor = new System.Windows.Forms.RadioButton();
            this.rdbWeb = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.checkBackground = new System.Windows.Forms.CheckBox();
            this.rdbLocal = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.checkLogin = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.Location = new System.Drawing.Point(719, 124);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(442, 418);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(719, 550);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "Selecionar Imagem";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCaminhoImagem
            // 
            this.txtCaminhoImagem.Location = new System.Drawing.Point(719, 634);
            this.txtCaminhoImagem.Margin = new System.Windows.Forms.Padding(4);
            this.txtCaminhoImagem.Name = "txtCaminhoImagem";
            this.txtCaminhoImagem.Size = new System.Drawing.Size(442, 23);
            this.txtCaminhoImagem.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(715, 610);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Caminho";
            // 
            // rdbServidor
            // 
            this.rdbServidor.AutoSize = true;
            this.rdbServidor.Location = new System.Drawing.Point(12, 86);
            this.rdbServidor.Name = "rdbServidor";
            this.rdbServidor.Size = new System.Drawing.Size(79, 21);
            this.rdbServidor.TabIndex = 4;
            this.rdbServidor.TabStop = true;
            this.rdbServidor.Text = "Servidor";
            this.rdbServidor.UseVisualStyleBackColor = true;
            // 
            // rdbWeb
            // 
            this.rdbWeb.AutoSize = true;
            this.rdbWeb.Location = new System.Drawing.Point(12, 116);
            this.rdbWeb.Name = "rdbWeb";
            this.rdbWeb.Size = new System.Drawing.Size(55, 21);
            this.rdbWeb.TabIndex = 5;
            this.rdbWeb.TabStop = true;
            this.rdbWeb.Text = "Web";
            this.rdbWeb.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Banco de Dados";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(715, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Imagem de Fundo do Programa";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(12, 587);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(188, 41);
            this.btnSalvar.TabIndex = 8;
            this.btnSalvar.Text = "Salvar Configurações";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(208, 587);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(188, 41);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar e Fechar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // checkBackground
            // 
            this.checkBackground.AutoSize = true;
            this.checkBackground.Location = new System.Drawing.Point(719, 52);
            this.checkBackground.Name = "checkBackground";
            this.checkBackground.Size = new System.Drawing.Size(140, 21);
            this.checkBackground.TabIndex = 10;
            this.checkBackground.Text = "Imagem de Fundo";
            this.checkBackground.UseVisualStyleBackColor = true;
            this.checkBackground.CheckedChanged += new System.EventHandler(this.checkBackground_CheckedChanged);
            // 
            // rdbLocal
            // 
            this.rdbLocal.AutoSize = true;
            this.rdbLocal.Location = new System.Drawing.Point(12, 143);
            this.rdbLocal.Name = "rdbLocal";
            this.rdbLocal.Size = new System.Drawing.Size(60, 21);
            this.rdbLocal.TabIndex = 5;
            this.rdbLocal.TabStop = true;
            this.rdbLocal.Text = "Local";
            this.rdbLocal.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Login para o Sistema?";
            // 
            // checkLogin
            // 
            this.checkLogin.AutoSize = true;
            this.checkLogin.Location = new System.Drawing.Point(11, 219);
            this.checkLogin.Name = "checkLogin";
            this.checkLogin.Size = new System.Drawing.Size(50, 21);
            this.checkLogin.TabIndex = 12;
            this.checkLogin.Text = "Sim";
            this.checkLogin.UseVisualStyleBackColor = true;
            this.checkLogin.CheckedChanged += new System.EventHandler(this.checkLogin_CheckedChanged);
            // 
            // formConfiguracoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 674);
            this.Controls.Add(this.checkLogin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBackground);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdbLocal);
            this.Controls.Add(this.rdbWeb);
            this.Controls.Add(this.rdbServidor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCaminhoImagem);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formConfiguracoes";
            this.Text = "Configurações Gerais";
            this.Load += new System.EventHandler(this.formConfiguracoes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCaminhoImagem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbServidor;
        private System.Windows.Forms.RadioButton rdbWeb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox checkBackground;
        private System.Windows.Forms.RadioButton rdbLocal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkLogin;
    }
}