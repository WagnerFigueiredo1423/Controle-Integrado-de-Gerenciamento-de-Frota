namespace app
{
    partial class formPagFuncionarios
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
            this.tabPagamentos = new System.Windows.Forms.TabControl();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.dropMes = new System.Windows.Forms.ComboBox();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.btnApagar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tabPagamentos
            // 
            this.tabPagamentos.Location = new System.Drawing.Point(12, 58);
            this.tabPagamentos.Name = "tabPagamentos";
            this.tabPagamentos.SelectedIndex = 0;
            this.tabPagamentos.Size = new System.Drawing.Size(955, 681);
            this.tabPagamentos.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 97;
            this.label3.Text = "Mês";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 96;
            this.label1.Text = "Ano";
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(17, 29);
            this.txtAno.Margin = new System.Windows.Forms.Padding(4);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(85, 22);
            this.txtAno.TabIndex = 93;
            // 
            // dropMes
            // 
            this.dropMes.FormattingEnabled = true;
            this.dropMes.Items.AddRange(new object[] {
            "Janeiro",
            "Fevereiro",
            "Março",
            "Abril",
            "Maio",
            "Junho",
            "Julho",
            "Agosto",
            "Setembro",
            "Outubro",
            "Novembro",
            "Dezembro"});
            this.dropMes.Location = new System.Drawing.Point(110, 27);
            this.dropMes.Margin = new System.Windows.Forms.Padding(4);
            this.dropMes.Name = "dropMes";
            this.dropMes.Size = new System.Drawing.Size(160, 24);
            this.dropMes.TabIndex = 94;
            this.dropMes.Text = "Selecione";
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Location = new System.Drawing.Point(110, 745);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(90, 32);
            this.btnVisualizar.TabIndex = 99;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // btnApagar
            // 
            this.btnApagar.Location = new System.Drawing.Point(12, 745);
            this.btnApagar.Name = "btnApagar";
            this.btnApagar.Size = new System.Drawing.Size(90, 32);
            this.btnApagar.TabIndex = 100;
            this.btnApagar.Text = "Apagar";
            this.btnApagar.UseVisualStyleBackColor = true;
            this.btnApagar.Click += new System.EventHandler(this.btnApagar_Click);
            // 
            // formPagFuncionarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 793);
            this.Controls.Add(this.btnApagar);
            this.Controls.Add(this.btnVisualizar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.dropMes);
            this.Controls.Add(this.tabPagamentos);
            this.Name = "formPagFuncionarios";
            this.Text = "Pagamento Funcionários";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formPagFuncionarios_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabPagamentos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.ComboBox dropMes;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.Button btnApagar;
    }
}