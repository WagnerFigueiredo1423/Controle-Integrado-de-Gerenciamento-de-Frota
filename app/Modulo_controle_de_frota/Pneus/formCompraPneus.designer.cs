namespace app
{
    partial class formCompraPneus
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabCompras = new System.Windows.Forms.DataGridView();
            this.lblValorCompra = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataCompra = new System.Windows.Forms.DateTimePicker();
            this.btnExcluiPeca = new System.Windows.Forms.Button();
            this.btnAddPeca = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnNova = new System.Windows.Forms.Button();
            this.tabPneus = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNroNota = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFornecedor = new System.Windows.Forms.Button();
            this.dropFornecedores = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBolteos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tabCompras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPneus)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Location = new System.Drawing.Point(468, 746);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(141, 37);
            this.btnExcluir.TabIndex = 54;
            this.btnExcluir.Text = "F4 = Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(319, 746);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(141, 37);
            this.btnEditar.TabIndex = 53;
            this.btnEditar.Text = "F3 = Atualizar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 85);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 20);
            this.label7.TabIndex = 52;
            this.label7.Text = "Compras";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 369);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 20);
            this.label6.TabIndex = 51;
            this.label6.Text = "Itens";
            // 
            // tabCompras
            // 
            this.tabCompras.AllowUserToAddRows = false;
            this.tabCompras.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCompras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tabCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tabCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tabCompras.DefaultCellStyle = dataGridViewCellStyle2;
            this.tabCompras.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tabCompras.Location = new System.Drawing.Point(20, 110);
            this.tabCompras.Margin = new System.Windows.Forms.Padding(4);
            this.tabCompras.Name = "tabCompras";
            this.tabCompras.RowHeadersVisible = false;
            this.tabCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabCompras.Size = new System.Drawing.Size(1048, 246);
            this.tabCompras.TabIndex = 50;
            this.tabCompras.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabCompras_CellClick);
            this.tabCompras.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabCompras_CellEnter);
            // 
            // lblValorCompra
            // 
            this.lblValorCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValorCompra.AutoSize = true;
            this.lblValorCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorCompra.ForeColor = System.Drawing.Color.Red;
            this.lblValorCompra.Location = new System.Drawing.Point(899, 710);
            this.lblValorCompra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorCompra.Name = "lblValorCompra";
            this.lblValorCompra.Size = new System.Drawing.Size(42, 25);
            this.lblValorCompra.TabIndex = 49;
            this.lblValorCompra.Text = "xxx";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(663, 710);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 25);
            this.label5.TabIndex = 48;
            this.label5.Text = "Valor Total da Compra:";
            // 
            // txtDataCompra
            // 
            this.txtDataCompra.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataCompra.CustomFormat = "dd/MM/yyyy";
            this.txtDataCompra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDataCompra.Location = new System.Drawing.Point(924, 36);
            this.txtDataCompra.Margin = new System.Windows.Forms.Padding(4);
            this.txtDataCompra.Name = "txtDataCompra";
            this.txtDataCompra.Size = new System.Drawing.Size(143, 22);
            this.txtDataCompra.TabIndex = 47;
            // 
            // btnExcluiPeca
            // 
            this.btnExcluiPeca.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluiPeca.Location = new System.Drawing.Point(733, 647);
            this.btnExcluiPeca.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcluiPeca.Name = "btnExcluiPeca";
            this.btnExcluiPeca.Size = new System.Drawing.Size(335, 59);
            this.btnExcluiPeca.TabIndex = 46;
            this.btnExcluiPeca.Text = "Excluir Itens";
            this.btnExcluiPeca.UseVisualStyleBackColor = true;
            this.btnExcluiPeca.Click += new System.EventHandler(this.btnExcluiPeca_Click);
            // 
            // btnAddPeca
            // 
            this.btnAddPeca.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPeca.Location = new System.Drawing.Point(20, 647);
            this.btnAddPeca.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPeca.Name = "btnAddPeca";
            this.btnAddPeca.Size = new System.Drawing.Size(335, 59);
            this.btnAddPeca.TabIndex = 45;
            this.btnAddPeca.Text = "Adicionar Itens";
            this.btnAddPeca.UseVisualStyleBackColor = true;
            this.btnAddPeca.Click += new System.EventHandler(this.btnAddPeca_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizar.Location = new System.Drawing.Point(169, 746);
            this.btnFinalizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(141, 37);
            this.btnFinalizar.TabIndex = 44;
            this.btnFinalizar.Text = "F2 = Gravar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnNova
            // 
            this.btnNova.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNova.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNova.Location = new System.Drawing.Point(20, 746);
            this.btnNova.Margin = new System.Windows.Forms.Padding(4);
            this.btnNova.Name = "btnNova";
            this.btnNova.Size = new System.Drawing.Size(141, 37);
            this.btnNova.TabIndex = 43;
            this.btnNova.Text = "F1 = Novo";
            this.btnNova.UseVisualStyleBackColor = true;
            this.btnNova.Click += new System.EventHandler(this.btnNova_Click);
            // 
            // tabPneus
            // 
            this.tabPneus.AllowUserToAddRows = false;
            this.tabPneus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPneus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tabPneus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tabPneus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tabPneus.DefaultCellStyle = dataGridViewCellStyle4;
            this.tabPneus.Location = new System.Drawing.Point(20, 394);
            this.tabPneus.Margin = new System.Windows.Forms.Padding(4);
            this.tabPneus.Name = "tabPneus";
            this.tabPneus.RowHeadersVisible = false;
            this.tabPneus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabPneus.Size = new System.Drawing.Size(1048, 246);
            this.tabPneus.TabIndex = 42;
            this.tabPneus.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabPneus_CellValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(920, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 20);
            this.label4.TabIndex = 41;
            this.label4.Text = "Data da Compra";
            // 
            // txtNroNota
            // 
            this.txtNroNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroNota.Location = new System.Drawing.Point(692, 36);
            this.txtNroNota.Margin = new System.Windows.Forms.Padding(4);
            this.txtNroNota.Name = "txtNroNota";
            this.txtNroNota.Size = new System.Drawing.Size(197, 26);
            this.txtNroNota.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(688, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 20);
            this.label3.TabIndex = 39;
            this.label3.Text = "Número da Nota Fiscal";
            // 
            // btnFornecedor
            // 
            this.btnFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFornecedor.Location = new System.Drawing.Point(563, 36);
            this.btnFornecedor.Margin = new System.Windows.Forms.Padding(4);
            this.btnFornecedor.Name = "btnFornecedor";
            this.btnFornecedor.Size = new System.Drawing.Size(104, 30);
            this.btnFornecedor.TabIndex = 38;
            this.btnFornecedor.Text = "Adicionar";
            this.btnFornecedor.UseVisualStyleBackColor = true;
            this.btnFornecedor.Click += new System.EventHandler(this.btnFornecedor_Click_1);
            // 
            // dropFornecedores
            // 
            this.dropFornecedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropFornecedores.FormattingEnabled = true;
            this.dropFornecedores.Location = new System.Drawing.Point(133, 36);
            this.dropFornecedores.Margin = new System.Windows.Forms.Padding(4);
            this.dropFornecedores.Name = "dropFornecedores";
            this.dropFornecedores.Size = new System.Drawing.Size(403, 28);
            this.dropFornecedores.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(129, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "Fornecedor";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(20, 36);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(79, 26);
            this.txtCodigo.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "Código";
            // 
            // btnBolteos
            // 
            this.btnBolteos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBolteos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBolteos.Location = new System.Drawing.Point(617, 746);
            this.btnBolteos.Margin = new System.Windows.Forms.Padding(4);
            this.btnBolteos.Name = "btnBolteos";
            this.btnBolteos.Size = new System.Drawing.Size(141, 37);
            this.btnBolteos.TabIndex = 55;
            this.btnBolteos.Text = "F5 = Boletos";
            this.btnBolteos.UseVisualStyleBackColor = true;
            this.btnBolteos.Click += new System.EventHandler(this.btnBolteos_Click);
            // 
            // formCompraPneus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 798);
            this.Controls.Add(this.btnBolteos);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tabCompras);
            this.Controls.Add(this.lblValorCompra);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDataCompra);
            this.Controls.Add(this.btnExcluiPeca);
            this.Controls.Add(this.btnAddPeca);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.btnNova);
            this.Controls.Add(this.tabPneus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNroNota);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFornecedor);
            this.Controls.Add(this.dropFornecedores);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formCompraPneus";
            this.Text = "Controle e Cadastro de Compra de Pneus";
            this.Load += new System.EventHandler(this.formCompraPneus_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formCompraPneus_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tabCompras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPneus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView tabCompras;
        private System.Windows.Forms.Label lblValorCompra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker txtDataCompra;
        private System.Windows.Forms.Button btnExcluiPeca;
        private System.Windows.Forms.Button btnAddPeca;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Button btnNova;
        private System.Windows.Forms.DataGridView tabPneus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNroNota;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFornecedor;
        private System.Windows.Forms.ComboBox dropFornecedores;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBolteos;
    }
}