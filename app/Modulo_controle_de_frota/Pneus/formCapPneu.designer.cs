namespace app
{
    partial class formCapPneu
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
            this.btnRelatorio = new System.Windows.Forms.Button();
            this.btnCompras = new System.Windows.Forms.Button();
            this.btnFornecedores = new System.Windows.Forms.Button();
            this.btnPneus = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.Location = new System.Drawing.Point(246, 128);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(110, 110);
            this.btnRelatorio.TabIndex = 12;
            this.btnRelatorio.Text = "Relatórios";
            this.btnRelatorio.UseVisualStyleBackColor = true;
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            // 
            // btnCompras
            // 
            this.btnCompras.Location = new System.Drawing.Point(246, 12);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(110, 110);
            this.btnCompras.TabIndex = 11;
            this.btnCompras.Text = "Compras";
            this.btnCompras.UseVisualStyleBackColor = true;
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            // 
            // btnFornecedores
            // 
            this.btnFornecedores.Location = new System.Drawing.Point(130, 128);
            this.btnFornecedores.Name = "btnFornecedores";
            this.btnFornecedores.Size = new System.Drawing.Size(110, 110);
            this.btnFornecedores.TabIndex = 10;
            this.btnFornecedores.Text = "Cadastro de Fornecedores";
            this.btnFornecedores.UseVisualStyleBackColor = true;
            this.btnFornecedores.Click += new System.EventHandler(this.btnFornecedores_Click);
            // 
            // btnPneus
            // 
            this.btnPneus.Location = new System.Drawing.Point(130, 12);
            this.btnPneus.Name = "btnPneus";
            this.btnPneus.Size = new System.Drawing.Size(110, 110);
            this.btnPneus.TabIndex = 9;
            this.btnPneus.Text = "Cadastro de Pneus";
            this.btnPneus.UseVisualStyleBackColor = true;
            this.btnPneus.Click += new System.EventHandler(this.btnPneus_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 110);
            this.button1.TabIndex = 14;
            this.button1.Text = "Recapagens";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 110);
            this.button2.TabIndex = 13;
            this.button2.Text = "Controle de Pneus nos Veículos";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // formCapPneu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 252);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnRelatorio);
            this.Controls.Add(this.btnCompras);
            this.Controls.Add(this.btnFornecedores);
            this.Controls.Add(this.btnPneus);
            this.Name = "formCapPneu";
            this.Text = "formCapPneu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formCapPneu_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRelatorio;
        private System.Windows.Forms.Button btnCompras;
        private System.Windows.Forms.Button btnFornecedores;
        private System.Windows.Forms.Button btnPneus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}