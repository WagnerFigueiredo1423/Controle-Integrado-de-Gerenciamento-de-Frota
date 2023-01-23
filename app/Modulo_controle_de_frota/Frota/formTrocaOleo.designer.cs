namespace app
{
    partial class formTrocaOleo
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
            this.btnNovo = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCadastro = new System.Windows.Forms.Button();
            this.tabTrocas = new System.Windows.Forms.DataGridView();
            this.dropFuncionario = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dropVeiculo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtKm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNextKm = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.DateTimePicker();
            this.txtNextData = new System.Windows.Forms.DateTimePicker();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.tabItens = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.btnExcluirPeca = new System.Windows.Forms.Button();
            this.btnAddPeca = new System.Windows.Forms.Button();
            this.rdbHistorico = new System.Windows.Forms.RadioButton();
            this.rdbAser = new System.Windows.Forms.RadioButton();
            this.rdbRealizadas = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tabTrocas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabItens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Location = new System.Drawing.Point(12, 37);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(110, 30);
            this.btnNovo.TabIndex = 53;
            this.btnNovo.Text = "F1 = Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 156);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 17);
            this.label6.TabIndex = 52;
            this.label6.Text = "Últimas Trocas";
            // 
            // btnCadastro
            // 
            this.btnCadastro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastro.Location = new System.Drawing.Point(130, 37);
            this.btnCadastro.Margin = new System.Windows.Forms.Padding(4);
            this.btnCadastro.Name = "btnCadastro";
            this.btnCadastro.Size = new System.Drawing.Size(110, 30);
            this.btnCadastro.TabIndex = 50;
            this.btnCadastro.Text = "F2 = Gravar";
            this.btnCadastro.UseVisualStyleBackColor = true;
            this.btnCadastro.Click += new System.EventHandler(this.btnCadastro_Click);
            // 
            // tabTrocas
            // 
            this.tabTrocas.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabTrocas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tabTrocas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabTrocas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabTrocas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tabTrocas.Location = new System.Drawing.Point(7, 177);
            this.tabTrocas.Margin = new System.Windows.Forms.Padding(4);
            this.tabTrocas.Name = "tabTrocas";
            this.tabTrocas.RowHeadersVisible = false;
            this.tabTrocas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabTrocas.Size = new System.Drawing.Size(680, 205);
            this.tabTrocas.TabIndex = 49;
            this.tabTrocas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabTrocas_CellClick);
            this.tabTrocas.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tabTrocas_KeyUp);
            // 
            // dropFuncionario
            // 
            this.dropFuncionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropFuncionario.FormattingEnabled = true;
            this.dropFuncionario.Location = new System.Drawing.Point(561, 27);
            this.dropFuncionario.Margin = new System.Windows.Forms.Padding(4);
            this.dropFuncionario.Name = "dropFuncionario";
            this.dropFuncionario.Size = new System.Drawing.Size(116, 24);
            this.dropFuncionario.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(561, 8);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 66;
            this.label5.Text = "Realizado por";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(266, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 64;
            this.label4.Text = "Data";
            // 
            // dropVeiculo
            // 
            this.dropVeiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropVeiculo.FormattingEnabled = true;
            this.dropVeiculo.Location = new System.Drawing.Point(119, 28);
            this.dropVeiculo.Margin = new System.Windows.Forms.Padding(4);
            this.dropVeiculo.Name = "dropVeiculo";
            this.dropVeiculo.Size = new System.Drawing.Size(116, 24);
            this.dropVeiculo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(119, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 60;
            this.label2.Text = "Veículo";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(9, 30);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(79, 23);
            this.txtCodigo.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 58;
            this.label1.Text = "Código";
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacoes.Location = new System.Drawing.Point(-45, -126);
            this.txtObservacoes.Margin = new System.Windows.Forms.Padding(4);
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.Size = new System.Drawing.Size(517, 56);
            this.txtObservacoes.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(-45, -146);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 17);
            this.label7.TabIndex = 56;
            this.label7.Text = "Observações";
            // 
            // txtKm
            // 
            this.txtKm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKm.Location = new System.Drawing.Point(398, 28);
            this.txtKm.Margin = new System.Windows.Forms.Padding(4);
            this.txtKm.Name = "txtKm";
            this.txtKm.Size = new System.Drawing.Size(132, 23);
            this.txtKm.TabIndex = 3;
            this.txtKm.TextChanged += new System.EventHandler(this.txtKm_TextChanged);
            this.txtKm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKm_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(398, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 17);
            this.label3.TabIndex = 69;
            this.label3.Text = "Km";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(398, 64);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 17);
            this.label9.TabIndex = 73;
            this.label9.Text = "Km Prox. Troca";
            // 
            // txtNextKm
            // 
            this.txtNextKm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNextKm.Location = new System.Drawing.Point(401, 85);
            this.txtNextKm.Margin = new System.Windows.Forms.Padding(4);
            this.txtNextKm.Name = "txtNextKm";
            this.txtNextKm.Size = new System.Drawing.Size(132, 23);
            this.txtNextKm.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(266, 64);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 17);
            this.label10.TabIndex = 70;
            this.label10.Text = "Data Prox. Troca";
            // 
            // txtData
            // 
            this.txtData.CustomFormat = "dd/MM/yyyy";
            this.txtData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtData.Location = new System.Drawing.Point(266, 30);
            this.txtData.Margin = new System.Windows.Forms.Padding(4);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(101, 23);
            this.txtData.TabIndex = 77;
            this.txtData.Value = new System.DateTime(2014, 10, 8, 0, 0, 0, 0);
            this.txtData.ValueChanged += new System.EventHandler(this.txtData_ValueChanged);
            // 
            // txtNextData
            // 
            this.txtNextData.CustomFormat = "dd/MM/yyyy";
            this.txtNextData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNextData.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtNextData.Location = new System.Drawing.Point(269, 85);
            this.txtNextData.Margin = new System.Windows.Forms.Padding(4);
            this.txtNextData.Name = "txtNextData";
            this.txtNextData.Size = new System.Drawing.Size(101, 23);
            this.txtNextData.TabIndex = 78;
            this.txtNextData.Value = new System.DateTime(2014, 10, 8, 0, 0, 0, 0);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAtualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.Location = new System.Drawing.Point(248, 37);
            this.btnAtualizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(110, 30);
            this.btnAtualizar.TabIndex = 79;
            this.btnAtualizar.Text = "F3 = Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Location = new System.Drawing.Point(366, 37);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(110, 30);
            this.btnExcluir.TabIndex = 80;
            this.btnExcluir.Text = "F4 = Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // tabItens
            // 
            this.tabItens.AllowUserToAddRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabItens.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.tabItens.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabItens.Location = new System.Drawing.Point(6, 407);
            this.tabItens.Margin = new System.Windows.Forms.Padding(4);
            this.tabItens.Name = "tabItens";
            this.tabItens.RowHeadersVisible = false;
            this.tabItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabItens.Size = new System.Drawing.Size(680, 135);
            this.tabItens.TabIndex = 54;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 386);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 17);
            this.label8.TabIndex = 55;
            this.label8.Text = "Itens";
            // 
            // btnExcluirPeca
            // 
            this.btnExcluirPeca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluirPeca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirPeca.Location = new System.Drawing.Point(401, 549);
            this.btnExcluirPeca.Name = "btnExcluirPeca";
            this.btnExcluirPeca.Size = new System.Drawing.Size(285, 41);
            this.btnExcluirPeca.TabIndex = 82;
            this.btnExcluirPeca.Text = "Excluir Item selecionado desta troca de Óleo";
            this.btnExcluirPeca.UseVisualStyleBackColor = true;
            this.btnExcluirPeca.Click += new System.EventHandler(this.btnExcluirPeca_Click);
            // 
            // btnAddPeca
            // 
            this.btnAddPeca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPeca.Location = new System.Drawing.Point(6, 549);
            this.btnAddPeca.Name = "btnAddPeca";
            this.btnAddPeca.Size = new System.Drawing.Size(252, 41);
            this.btnAddPeca.TabIndex = 81;
            this.btnAddPeca.Text = "Adicionar Itens à esta troca de Óleo";
            this.btnAddPeca.UseVisualStyleBackColor = true;
            this.btnAddPeca.Click += new System.EventHandler(this.btnAddPeca_Click);
            // 
            // rdbHistorico
            // 
            this.rdbHistorico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbHistorico.AutoSize = true;
            this.rdbHistorico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbHistorico.Location = new System.Drawing.Point(538, 48);
            this.rdbHistorico.Margin = new System.Windows.Forms.Padding(4);
            this.rdbHistorico.Name = "rdbHistorico";
            this.rdbHistorico.Size = new System.Drawing.Size(79, 20);
            this.rdbHistorico.TabIndex = 83;
            this.rdbHistorico.Text = "Histórico";
            this.rdbHistorico.UseVisualStyleBackColor = true;
            this.rdbHistorico.CheckedChanged += new System.EventHandler(this.rdbHistorico_CheckedChanged);
            // 
            // rdbAser
            // 
            this.rdbAser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbAser.AutoSize = true;
            this.rdbAser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbAser.Location = new System.Drawing.Point(538, 26);
            this.rdbAser.Margin = new System.Windows.Forms.Padding(4);
            this.rdbAser.Name = "rdbAser";
            this.rdbAser.Size = new System.Drawing.Size(148, 20);
            this.rdbAser.TabIndex = 85;
            this.rdbAser.Text = "A serem Realizadas";
            this.rdbAser.UseVisualStyleBackColor = true;
            this.rdbAser.CheckedChanged += new System.EventHandler(this.rdbAser_CheckedChanged);
            // 
            // rdbRealizadas
            // 
            this.rdbRealizadas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbRealizadas.AutoSize = true;
            this.rdbRealizadas.Checked = true;
            this.rdbRealizadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbRealizadas.Location = new System.Drawing.Point(538, 4);
            this.rdbRealizadas.Margin = new System.Windows.Forms.Padding(4);
            this.rdbRealizadas.Name = "rdbRealizadas";
            this.rdbRealizadas.Size = new System.Drawing.Size(95, 20);
            this.rdbRealizadas.TabIndex = 84;
            this.rdbRealizadas.TabStop = true;
            this.rdbRealizadas.Text = "Realizadas";
            this.rdbRealizadas.UseVisualStyleBackColor = true;
            this.rdbRealizadas.CheckedChanged += new System.EventHandler(this.rdbRealizadas_CheckedChanged);
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
            this.splitContainer1.Panel1.Controls.Add(this.txtObs);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.tabItens);
            this.splitContainer1.Panel1.Controls.Add(this.tabTrocas);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.txtNextData);
            this.splitContainer1.Panel1.Controls.Add(this.txtData);
            this.splitContainer1.Panel1.Controls.Add(this.btnExcluirPeca);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.txtNextKm);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddPeca);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.txtObservacoes);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txtKm);
            this.splitContainer1.Panel1.Controls.Add(this.txtCodigo);
            this.splitContainer1.Panel1.Controls.Add(this.dropFuncionario);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.dropVeiculo);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnNovo);
            this.splitContainer1.Panel2.Controls.Add(this.rdbHistorico);
            this.splitContainer1.Panel2.Controls.Add(this.btnCadastro);
            this.splitContainer1.Panel2.Controls.Add(this.rdbAser);
            this.splitContainer1.Panel2.Controls.Add(this.rdbRealizadas);
            this.splitContainer1.Panel2.Controls.Add(this.btnAtualizar);
            this.splitContainer1.Panel2.Controls.Add(this.btnExcluir);
            this.splitContainer1.Size = new System.Drawing.Size(691, 749);
            this.splitContainer1.SplitterDistance = 673;
            this.splitContainer1.TabIndex = 86;
            // 
            // txtObs
            // 
            this.txtObs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObs.Location = new System.Drawing.Point(11, 122);
            this.txtObs.Margin = new System.Windows.Forms.Padding(4);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(675, 28);
            this.txtObs.TabIndex = 83;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(9, 102);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 16);
            this.label11.TabIndex = 84;
            this.label11.Text = "Observações";
            // 
            // formTrocaOleo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 749);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formTrocaOleo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Controle de Trocas de Óleo";
            this.Load += new System.EventHandler(this.formTrocaOleo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formTrocaOleo_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tabTrocas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabItens)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCadastro;
        private System.Windows.Forms.DataGridView tabTrocas;
        private System.Windows.Forms.ComboBox dropFuncionario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox dropVeiculo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtObservacoes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtKm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNextKm;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker txtData;
        private System.Windows.Forms.DateTimePicker txtNextData;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.DataGridView tabItens;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnExcluirPeca;
        private System.Windows.Forms.Button btnAddPeca;
        private System.Windows.Forms.RadioButton rdbHistorico;
        private System.Windows.Forms.RadioButton rdbAser;
        private System.Windows.Forms.RadioButton rdbRealizadas;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label label11;
    }
}