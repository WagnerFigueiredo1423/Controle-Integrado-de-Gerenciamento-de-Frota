namespace aplicacao
{
    partial class formParamEnderClientes
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
            this.btnParmAtom = new System.Windows.Forms.Button();
            this.tabEnderecos = new System.Windows.Forms.DataGridView();
            this.txtEnderecoAntigo = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtEnderecoNovo = new System.Windows.Forms.TextBox();
            this.lblEnderTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEnderAtual = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.lstEnderecos = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.tabEnderecos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnParmAtom
            // 
            this.btnParmAtom.Location = new System.Drawing.Point(910, 183);
            this.btnParmAtom.Name = "btnParmAtom";
            this.btnParmAtom.Size = new System.Drawing.Size(124, 23);
            this.btnParmAtom.TabIndex = 5;
            this.btnParmAtom.Text = "Automático";
            this.btnParmAtom.UseVisualStyleBackColor = true;
            this.btnParmAtom.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabEnderecos
            // 
            this.tabEnderecos.AllowUserToAddRows = false;
            this.tabEnderecos.AllowUserToDeleteRows = false;
            this.tabEnderecos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabEnderecos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabEnderecos.Location = new System.Drawing.Point(0, 0);
            this.tabEnderecos.Name = "tabEnderecos";
            this.tabEnderecos.ReadOnly = true;
            this.tabEnderecos.Size = new System.Drawing.Size(1046, 361);
            this.tabEnderecos.TabIndex = 4;
            this.tabEnderecos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabEnderecos_CellContentClick);
            // 
            // txtEnderecoAntigo
            // 
            this.txtEnderecoAntigo.Location = new System.Drawing.Point(12, 16);
            this.txtEnderecoAntigo.Name = "txtEnderecoAntigo";
            this.txtEnderecoAntigo.Size = new System.Drawing.Size(1022, 20);
            this.txtEnderecoAntigo.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabEnderecos);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtEnderecoNovo);
            this.splitContainer1.Panel2.Controls.Add(this.lblEnderTotal);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.lblEnderAtual);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.btnAlterar);
            this.splitContainer1.Panel2.Controls.Add(this.lstEnderecos);
            this.splitContainer1.Panel2.Controls.Add(this.txtEnderecoAntigo);
            this.splitContainer1.Panel2.Controls.Add(this.btnParmAtom);
            this.splitContainer1.Size = new System.Drawing.Size(1046, 583);
            this.splitContainer1.SplitterDistance = 361;
            this.splitContainer1.TabIndex = 7;
            // 
            // txtEnderecoNovo
            // 
            this.txtEnderecoNovo.Location = new System.Drawing.Point(12, 42);
            this.txtEnderecoNovo.Name = "txtEnderecoNovo";
            this.txtEnderecoNovo.Size = new System.Drawing.Size(1022, 20);
            this.txtEnderecoNovo.TabIndex = 10;
            this.txtEnderecoNovo.TextChanged += new System.EventHandler(this.txtEnderecoNovo_TextChanged);
            // 
            // lblEnderTotal
            // 
            this.lblEnderTotal.AutoSize = true;
            this.lblEnderTotal.Location = new System.Drawing.Point(275, 183);
            this.lblEnderTotal.Name = "lblEnderTotal";
            this.lblEnderTotal.Size = new System.Drawing.Size(35, 13);
            this.lblEnderTotal.TabIndex = 9;
            this.lblEnderTotal.Text = "label1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "de";
            // 
            // lblEnderAtual
            // 
            this.lblEnderAtual.AutoSize = true;
            this.lblEnderAtual.Location = new System.Drawing.Point(105, 181);
            this.lblEnderAtual.Name = "lblEnderAtual";
            this.lblEnderAtual.Size = new System.Drawing.Size(35, 13);
            this.lblEnderAtual.TabIndex = 9;
            this.lblEnderAtual.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Endereço:";
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(780, 183);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(124, 23);
            this.btnAlterar.TabIndex = 8;
            this.btnAlterar.Text = "Manual";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // lstEnderecos
            // 
            this.lstEnderecos.FormattingEnabled = true;
            this.lstEnderecos.Location = new System.Drawing.Point(12, 84);
            this.lstEnderecos.Name = "lstEnderecos";
            this.lstEnderecos.Size = new System.Drawing.Size(1022, 69);
            this.lstEnderecos.TabIndex = 7;
            this.lstEnderecos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstEnderecos_MouseClick);
            // 
            // formParamEnderClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 583);
            this.Controls.Add(this.splitContainer1);
            this.Name = "formParamEnderClientes";
            this.Text = "Parametrização de Endereços";
            this.Load += new System.EventHandler(this.formParamEnderClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabEnderecos)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tabEnderecos;
        private System.Windows.Forms.Button btnParmAtom;
        private System.Windows.Forms.TextBox txtEnderecoAntigo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lstEnderecos;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Label lblEnderTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEnderAtual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEnderecoNovo;
    }
}