namespace aplicacao
{
    partial class formEcoRelatorio
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblQtnLocacoes = new System.Windows.Forms.Label();
            this.lblVlrTotLocacoes = new System.Windows.Forms.Label();
            this.txtVlrLocacao = new System.Windows.Forms.TextBox();
            this.txtVlrMovimentacoes = new System.Windows.Forms.TextBox();
            this.lblVlrTotMovimentacoes = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblQtnMovimentacoes = new System.Windows.Forms.Label();
            this.tabFuncionarios = new System.Windows.Forms.DataGridView();
            this.tabVeiculos = new System.Windows.Forms.DataGridView();
            this.tabEcopontos = new System.Windows.Forms.DataGridView();
            this.tabQntDia = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tabFuncionarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabVeiculos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabEcopontos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabQntDia)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Relatório de Locações";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 17);
            this.label2.TabIndex = 145;
            this.label2.Text = "Quantidade de Locações";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 17);
            this.label3.TabIndex = 146;
            this.label3.Text = "Valor da Locação";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(416, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 147;
            this.label4.Text = "Total";
            // 
            // lblQtnLocacoes
            // 
            this.lblQtnLocacoes.AutoSize = true;
            this.lblQtnLocacoes.Location = new System.Drawing.Point(15, 166);
            this.lblQtnLocacoes.Name = "lblQtnLocacoes";
            this.lblQtnLocacoes.Size = new System.Drawing.Size(167, 17);
            this.lblQtnLocacoes.TabIndex = 148;
            this.lblQtnLocacoes.Text = "Quantidade de Locações";
            // 
            // lblVlrTotLocacoes
            // 
            this.lblVlrTotLocacoes.AutoSize = true;
            this.lblVlrTotLocacoes.Location = new System.Drawing.Point(416, 166);
            this.lblVlrTotLocacoes.Name = "lblVlrTotLocacoes";
            this.lblVlrTotLocacoes.Size = new System.Drawing.Size(40, 17);
            this.lblVlrTotLocacoes.TabIndex = 149;
            this.lblVlrTotLocacoes.Text = "Total";
            // 
            // txtVlrLocacao
            // 
            this.txtVlrLocacao.Location = new System.Drawing.Point(244, 163);
            this.txtVlrLocacao.Name = "txtVlrLocacao";
            this.txtVlrLocacao.Size = new System.Drawing.Size(136, 23);
            this.txtVlrLocacao.TabIndex = 150;
            this.txtVlrLocacao.TextChanged += new System.EventHandler(this.txtVlrLocacao_TextChanged);
            this.txtVlrLocacao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVlrLocacao_KeyPress);
            // 
            // txtVlrMovimentacoes
            // 
            this.txtVlrMovimentacoes.Location = new System.Drawing.Point(816, 160);
            this.txtVlrMovimentacoes.Name = "txtVlrMovimentacoes";
            this.txtVlrMovimentacoes.Size = new System.Drawing.Size(136, 23);
            this.txtVlrMovimentacoes.TabIndex = 156;
            this.txtVlrMovimentacoes.TextChanged += new System.EventHandler(this.txtVlrMovimentacoes_TextChanged);
            this.txtVlrMovimentacoes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVlrMovimentacoes_KeyPress);
            // 
            // lblVlrTotMovimentacoes
            // 
            this.lblVlrTotMovimentacoes.AutoSize = true;
            this.lblVlrTotMovimentacoes.Location = new System.Drawing.Point(978, 163);
            this.lblVlrTotMovimentacoes.Name = "lblVlrTotMovimentacoes";
            this.lblVlrTotMovimentacoes.Size = new System.Drawing.Size(40, 17);
            this.lblVlrTotMovimentacoes.TabIndex = 155;
            this.lblVlrTotMovimentacoes.Text = "Total";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(978, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 17);
            this.label9.TabIndex = 153;
            this.label9.Text = "Total";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(788, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(156, 17);
            this.label10.TabIndex = 152;
            this.label10.Text = "Valor da Movimentação";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(543, 136);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(204, 17);
            this.label11.TabIndex = 151;
            this.label11.Text = "Quantidade de Movimentações";
            // 
            // lblQtnMovimentacoes
            // 
            this.lblQtnMovimentacoes.AutoSize = true;
            this.lblQtnMovimentacoes.Location = new System.Drawing.Point(543, 163);
            this.lblQtnMovimentacoes.Name = "lblQtnMovimentacoes";
            this.lblQtnMovimentacoes.Size = new System.Drawing.Size(204, 17);
            this.lblQtnMovimentacoes.TabIndex = 157;
            this.lblQtnMovimentacoes.Text = "Quantidade de Movimentações";
            // 
            // tabFuncionarios
            // 
            this.tabFuncionarios.AllowUserToAddRows = false;
            this.tabFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabFuncionarios.Location = new System.Drawing.Point(19, 199);
            this.tabFuncionarios.Name = "tabFuncionarios";
            this.tabFuncionarios.RowTemplate.Height = 24;
            this.tabFuncionarios.Size = new System.Drawing.Size(443, 375);
            this.tabFuncionarios.TabIndex = 158;
            // 
            // tabVeiculos
            // 
            this.tabVeiculos.AllowUserToAddRows = false;
            this.tabVeiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabVeiculos.Location = new System.Drawing.Point(468, 199);
            this.tabVeiculos.Name = "tabVeiculos";
            this.tabVeiculos.RowTemplate.Height = 24;
            this.tabVeiculos.Size = new System.Drawing.Size(443, 375);
            this.tabVeiculos.TabIndex = 159;
            // 
            // tabEcopontos
            // 
            this.tabEcopontos.AllowUserToAddRows = false;
            this.tabEcopontos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tabEcopontos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabEcopontos.Location = new System.Drawing.Point(917, 199);
            this.tabEcopontos.Name = "tabEcopontos";
            this.tabEcopontos.RowTemplate.Height = 24;
            this.tabEcopontos.Size = new System.Drawing.Size(443, 375);
            this.tabEcopontos.TabIndex = 160;
            // 
            // tabQntDia
            // 
            this.tabQntDia.AllowUserToAddRows = false;
            this.tabQntDia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tabQntDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabQntDia.Location = new System.Drawing.Point(19, 580);
            this.tabQntDia.Name = "tabQntDia";
            this.tabQntDia.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.tabQntDia.Size = new System.Drawing.Size(1341, 120);
            this.tabQntDia.TabIndex = 161;
            // 
            // formEcoRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 709);
            this.Controls.Add(this.tabQntDia);
            this.Controls.Add(this.tabEcopontos);
            this.Controls.Add(this.tabVeiculos);
            this.Controls.Add(this.tabFuncionarios);
            this.Controls.Add(this.lblQtnMovimentacoes);
            this.Controls.Add(this.txtVlrMovimentacoes);
            this.Controls.Add(this.lblVlrTotMovimentacoes);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtVlrLocacao);
            this.Controls.Add(this.lblVlrTotLocacoes);
            this.Controls.Add(this.lblQtnLocacoes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formEcoRelatorio";
            this.Text = "formEcoRelatorio";
            this.Load += new System.EventHandler(this.formEcoRelatorio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabFuncionarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabVeiculos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabEcopontos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabQntDia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblQtnLocacoes;
        private System.Windows.Forms.Label lblVlrTotLocacoes;
        private System.Windows.Forms.TextBox txtVlrLocacao;
        private System.Windows.Forms.TextBox txtVlrMovimentacoes;
        private System.Windows.Forms.Label lblVlrTotMovimentacoes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblQtnMovimentacoes;
        private System.Windows.Forms.DataGridView tabFuncionarios;
        private System.Windows.Forms.DataGridView tabVeiculos;
        private System.Windows.Forms.DataGridView tabEcopontos;
        private System.Windows.Forms.DataGridView tabQntDia;
    }
}