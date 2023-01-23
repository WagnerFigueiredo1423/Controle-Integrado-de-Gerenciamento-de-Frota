namespace app
{
    partial class formRelServ
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
            this.dropPlaca = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gridServicos = new System.Windows.Forms.DataGridView();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridServicos)).BeginInit();
            this.SuspendLayout();
            // 
            // dropPlaca
            // 
            this.dropPlaca.FormattingEnabled = true;
            this.dropPlaca.Location = new System.Drawing.Point(9, 24);
            this.dropPlaca.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dropPlaca.Name = "dropPlaca";
            this.dropPlaca.Size = new System.Drawing.Size(92, 21);
            this.dropPlaca.TabIndex = 0;
            this.dropPlaca.SelectedIndexChanged += new System.EventHandler(this.dropPlaca_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Placa";
            // 
            // gridServicos
            // 
            this.gridServicos.AllowUserToAddRows = false;
            this.gridServicos.AllowUserToDeleteRows = false;
            this.gridServicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridServicos.Location = new System.Drawing.Point(9, 48);
            this.gridServicos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridServicos.Name = "gridServicos";
            this.gridServicos.RowHeadersVisible = false;
            this.gridServicos.RowTemplate.Height = 24;
            this.gridServicos.Size = new System.Drawing.Size(751, 262);
            this.gridServicos.TabIndex = 2;
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(197, 23);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(563, 20);
            this.txtBusca.TabIndex = 3;
            this.txtBusca.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Busca";
            // 
            // formRelServ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 320);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBusca);
            this.Controls.Add(this.gridServicos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dropPlaca);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "formRelServ";
            this.Text = "Relatório de Serviços";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formRelServ_FormClosing);
            this.Load += new System.EventHandler(this.formRelServ_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridServicos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox dropPlaca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridServicos;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Label label2;
    }
}