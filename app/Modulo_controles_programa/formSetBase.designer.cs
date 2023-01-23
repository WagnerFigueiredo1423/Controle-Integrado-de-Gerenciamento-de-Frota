namespace app
{
    partial class formSetBase
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
            this.checkLogin = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rdbLocal = new System.Windows.Forms.RadioButton();
            this.rdbWeb = new System.Windows.Forms.RadioButton();
            this.rdbServidor = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkLogin
            // 
            this.checkLogin.AutoSize = true;
            this.checkLogin.Location = new System.Drawing.Point(162, 38);
            this.checkLogin.Name = "checkLogin";
            this.checkLogin.Size = new System.Drawing.Size(43, 17);
            this.checkLogin.TabIndex = 18;
            this.checkLogin.Text = "Sim";
            this.checkLogin.UseVisualStyleBackColor = true;
            this.checkLogin.CheckedChanged += new System.EventHandler(this.checkLogin_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(160, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Login para o Sistema?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Banco de Dados";
            // 
            // rdbLocal
            // 
            this.rdbLocal.AutoSize = true;
            this.rdbLocal.Location = new System.Drawing.Point(16, 100);
            this.rdbLocal.Name = "rdbLocal";
            this.rdbLocal.Size = new System.Drawing.Size(51, 17);
            this.rdbLocal.TabIndex = 14;
            this.rdbLocal.TabStop = true;
            this.rdbLocal.Text = "Local";
            this.rdbLocal.UseVisualStyleBackColor = true;
            // 
            // rdbWeb
            // 
            this.rdbWeb.AutoSize = true;
            this.rdbWeb.Location = new System.Drawing.Point(16, 73);
            this.rdbWeb.Name = "rdbWeb";
            this.rdbWeb.Size = new System.Drawing.Size(48, 17);
            this.rdbWeb.TabIndex = 15;
            this.rdbWeb.TabStop = true;
            this.rdbWeb.Text = "Web";
            this.rdbWeb.UseVisualStyleBackColor = true;
            // 
            // rdbServidor
            // 
            this.rdbServidor.AutoSize = true;
            this.rdbServidor.Location = new System.Drawing.Point(16, 43);
            this.rdbServidor.Name = "rdbServidor";
            this.rdbServidor.Size = new System.Drawing.Size(64, 17);
            this.rdbServidor.TabIndex = 13;
            this.rdbServidor.TabStop = true;
            this.rdbServidor.Text = "Servidor";
            this.rdbServidor.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(151, 130);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 41);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar e Fechar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(13, 130);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(120, 41);
            this.btnSalvar.TabIndex = 19;
            this.btnSalvar.Text = "Salvar Configurações";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // formSetBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 184);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.checkLogin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdbLocal);
            this.Controls.Add(this.rdbWeb);
            this.Controls.Add(this.rdbServidor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formSetBase";
            this.Text = "formSetBase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkLogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdbLocal;
        private System.Windows.Forms.RadioButton rdbWeb;
        private System.Windows.Forms.RadioButton rdbServidor;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
    }
}