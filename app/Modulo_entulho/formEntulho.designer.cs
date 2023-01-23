namespace app
{
    partial class formEntulho
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
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnMovimento = new System.Windows.Forms.Button();
            this.btnLivroCaixa = new System.Windows.Forms.Button();
            this.btnRelatorios = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(13, 13);
            this.btnClientes.Margin = new System.Windows.Forms.Padding(4);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(147, 135);
            this.btnClientes.TabIndex = 21;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnMovimento
            // 
            this.btnMovimento.Location = new System.Drawing.Point(207, 13);
            this.btnMovimento.Margin = new System.Windows.Forms.Padding(4);
            this.btnMovimento.Name = "btnMovimento";
            this.btnMovimento.Size = new System.Drawing.Size(147, 135);
            this.btnMovimento.TabIndex = 22;
            this.btnMovimento.Text = "Movimento Diário";
            this.btnMovimento.UseVisualStyleBackColor = true;
            this.btnMovimento.Click += new System.EventHandler(this.btnMovimento_Click);
            // 
            // btnLivroCaixa
            // 
            this.btnLivroCaixa.Location = new System.Drawing.Point(13, 197);
            this.btnLivroCaixa.Margin = new System.Windows.Forms.Padding(4);
            this.btnLivroCaixa.Name = "btnLivroCaixa";
            this.btnLivroCaixa.Size = new System.Drawing.Size(147, 135);
            this.btnLivroCaixa.TabIndex = 23;
            this.btnLivroCaixa.Text = "Livro Caixa";
            this.btnLivroCaixa.UseVisualStyleBackColor = true;
            this.btnLivroCaixa.Click += new System.EventHandler(this.btnLivroCaixa_Click);
            // 
            // btnRelatorios
            // 
            this.btnRelatorios.Location = new System.Drawing.Point(207, 197);
            this.btnRelatorios.Margin = new System.Windows.Forms.Padding(4);
            this.btnRelatorios.Name = "btnRelatorios";
            this.btnRelatorios.Size = new System.Drawing.Size(147, 135);
            this.btnRelatorios.TabIndex = 24;
            this.btnRelatorios.Text = "Relatórios";
            this.btnRelatorios.UseVisualStyleBackColor = true;
            this.btnRelatorios.Click += new System.EventHandler(this.btnRelatorios_Click);
            // 
            // formEntulho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 353);
            this.Controls.Add(this.btnRelatorios);
            this.Controls.Add(this.btnLivroCaixa);
            this.Controls.Add(this.btnMovimento);
            this.Controls.Add(this.btnClientes);
            this.Name = "formEntulho";
            this.Text = "Controle de Entulhos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formEntulho_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnMovimento;
        private System.Windows.Forms.Button btnLivroCaixa;
        private System.Windows.Forms.Button btnRelatorios;
    }
}