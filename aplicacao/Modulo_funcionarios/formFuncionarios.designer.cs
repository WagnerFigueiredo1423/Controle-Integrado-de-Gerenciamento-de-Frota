namespace aplicacao
{
    partial class formFuncionarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabFuncionarios = new System.Windows.Forms.DataGridView();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAdmissao = new System.Windows.Forms.DateTimePicker();
            this.txtFerias = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.dropEmpresa = new System.Windows.Forms.ComboBox();
            this.checkAtivo = new System.Windows.Forms.CheckBox();
            this.checkMotPoli = new System.Windows.Forms.CheckBox();
            this.checkComissionado = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtValHab = new System.Windows.Forms.DateTimePicker();
            this.txtNroHab = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dropCatHab = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dropTipo = new System.Windows.Forms.ComboBox();
            this.txtFone = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtClt = new System.Windows.Forms.TextBox();
            this.txtCpf = new System.Windows.Forms.TextBox();
            this.txtRg = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.tabFuncionarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabFuncionarios
            // 
            this.tabFuncionarios.AllowUserToAddRows = false;
            this.tabFuncionarios.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabFuncionarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.tabFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabFuncionarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFuncionarios.Location = new System.Drawing.Point(3, 364);
            this.tabFuncionarios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabFuncionarios.Name = "tabFuncionarios";
            this.tabFuncionarios.RowHeadersVisible = false;
            this.tabFuncionarios.RowTemplate.Height = 24;
            this.tabFuncionarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabFuncionarios.Size = new System.Drawing.Size(1089, 150);
            this.tabFuncionarios.TabIndex = 27;
            this.tabFuncionarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabFuncionarios_CellContentClick);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExcluir.Location = new System.Drawing.Point(474, 7);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(138, 30);
            this.btnExcluir.TabIndex = 31;
            this.btnExcluir.Text = "F4 = Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditar.Location = new System.Drawing.Point(316, 7);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(150, 30);
            this.btnEditar.TabIndex = 30;
            this.btnEditar.Text = "F3 = Atualizar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGravar.Location = new System.Drawing.Point(157, 7);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(153, 30);
            this.btnGravar.TabIndex = 29;
            this.btnGravar.Text = "F2 = Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNovo.Location = new System.Drawing.Point(3, 7);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(148, 30);
            this.btnNovo.TabIndex = 28;
            this.btnNovo.Text = "F1 = Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 22);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 245);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 20);
            this.label13.TabIndex = 33;
            this.label13.Text = "Foto";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(1089, 356);
            this.tableLayoutPanel7.TabIndex = 35;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(883, 350);
            this.tableLayoutPanel1.TabIndex = 36;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.42857F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.42857F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.tableLayoutPanel4.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label7, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtAdmissao, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.txtFerias, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label12, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.dropEmpresa, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.checkAtivo, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.checkMotPoli, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.checkComissionado, 4, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 73);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(877, 64);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Admissão";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(141, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Venc. Férias";
            // 
            // txtAdmissao
            // 
            this.txtAdmissao.CustomFormat = "dd/MM/aaaa";
            this.txtAdmissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtAdmissao.Location = new System.Drawing.Point(3, 28);
            this.txtAdmissao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAdmissao.Name = "txtAdmissao";
            this.txtAdmissao.Size = new System.Drawing.Size(107, 26);
            this.txtAdmissao.TabIndex = 11;
            this.txtAdmissao.Value = new System.DateTime(2015, 3, 7, 0, 0, 0, 0);
            // 
            // txtFerias
            // 
            this.txtFerias.CustomFormat = "dd/MM/aaaa";
            this.txtFerias.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFerias.Location = new System.Drawing.Point(141, 28);
            this.txtFerias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFerias.Name = "txtFerias";
            this.txtFerias.Size = new System.Drawing.Size(103, 26);
            this.txtFerias.TabIndex = 13;
            this.txtFerias.Value = new System.DateTime(2015, 3, 7, 0, 0, 0, 0);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(279, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 20);
            this.label12.TabIndex = 26;
            this.label12.Text = "Empresa";
            // 
            // dropEmpresa
            // 
            this.dropEmpresa.FormattingEnabled = true;
            this.dropEmpresa.Location = new System.Drawing.Point(279, 28);
            this.dropEmpresa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dropEmpresa.Name = "dropEmpresa";
            this.dropEmpresa.Size = new System.Drawing.Size(223, 28);
            this.dropEmpresa.TabIndex = 25;
            // 
            // checkAtivo
            // 
            this.checkAtivo.AutoSize = true;
            this.checkAtivo.Location = new System.Drawing.Point(508, 2);
            this.checkAtivo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkAtivo.Name = "checkAtivo";
            this.checkAtivo.Size = new System.Drawing.Size(68, 22);
            this.checkAtivo.TabIndex = 18;
            this.checkAtivo.Text = "Ativo";
            this.checkAtivo.UseVisualStyleBackColor = true;
            // 
            // checkMotPoli
            // 
            this.checkMotPoli.AutoSize = true;
            this.checkMotPoli.Location = new System.Drawing.Point(508, 28);
            this.checkMotPoli.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkMotPoli.Name = "checkMotPoli";
            this.checkMotPoli.Size = new System.Drawing.Size(157, 24);
            this.checkMotPoli.TabIndex = 21;
            this.checkMotPoli.Text = "Motorista de Poli";
            this.checkMotPoli.UseVisualStyleBackColor = true;
            // 
            // checkComissionado
            // 
            this.checkComissionado.AutoSize = true;
            this.checkComissionado.Location = new System.Drawing.Point(693, 28);
            this.checkComissionado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkComissionado.Name = "checkComissionado";
            this.checkComissionado.Size = new System.Drawing.Size(137, 24);
            this.checkComissionado.TabIndex = 22;
            this.checkComissionado.Text = "Comissionado";
            this.checkComissionado.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.label14, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label15, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtValHab, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtNroHab, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label16, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.dropCatHab, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 143);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(877, 64);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(170, 20);
            this.label14.TabIndex = 0;
            this.label14.Text = "Categoria Habilitação";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(266, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(157, 20);
            this.label15.TabIndex = 0;
            this.label15.Text = "Número Habilitação";
            // 
            // txtValHab
            // 
            this.txtValHab.CustomFormat = "dd/MM/aaaa";
            this.txtValHab.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtValHab.Location = new System.Drawing.Point(704, 22);
            this.txtValHab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtValHab.Name = "txtValHab";
            this.txtValHab.Size = new System.Drawing.Size(111, 26);
            this.txtValHab.TabIndex = 11;
            this.txtValHab.Value = new System.DateTime(2015, 3, 7, 0, 0, 0, 0);
            // 
            // txtNroHab
            // 
            this.txtNroHab.Location = new System.Drawing.Point(266, 22);
            this.txtNroHab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNroHab.Name = "txtNroHab";
            this.txtNroHab.Size = new System.Drawing.Size(119, 26);
            this.txtNroHab.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(704, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(102, 20);
            this.label16.TabIndex = 0;
            this.label16.Text = "Vencimento Habilitação";
            // 
            // dropCatHab
            // 
            this.dropCatHab.FormattingEnabled = true;
            this.dropCatHab.Items.AddRange(new object[] {
            "Selecione",
            "A",
            "B",
            "C",
            "D",
            "E",
            "AB",
            "AC",
            "AD",
            "AE"});
            this.dropCatHab.Location = new System.Drawing.Point(3, 23);
            this.dropCatHab.Name = "dropCatHab";
            this.dropCatHab.Size = new System.Drawing.Size(83, 28);
            this.dropCatHab.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.txtEndereco, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.label9, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label10, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.dropTipo, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.txtFone, 1, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 213);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(877, 64);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Endereço";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEndereco.Location = new System.Drawing.Point(3, 22);
            this.txtEndereco.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(432, 26);
            this.txtEndereco.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(441, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "Fone";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(660, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "Tipo";
            // 
            // dropTipo
            // 
            this.dropTipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dropTipo.FormattingEnabled = true;
            this.dropTipo.Items.AddRange(new object[] {
            "Selecione",
            "ADMINISTRATIVO",
            "MOTORISTA",
            "MECANICO",
            "AJUDANTE",
            "OUTROS"});
            this.dropTipo.Location = new System.Drawing.Point(660, 22);
            this.dropTipo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dropTipo.Name = "dropTipo";
            this.dropTipo.Size = new System.Drawing.Size(214, 28);
            this.dropTipo.TabIndex = 19;
            // 
            // txtFone
            // 
            this.txtFone.Location = new System.Drawing.Point(441, 22);
            this.txtFone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFone.Name = "txtFone";
            this.txtFone.Size = new System.Drawing.Size(135, 26);
            this.txtFone.TabIndex = 17;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.txtObservacao, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 283);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(877, 64);
            this.tableLayoutPanel6.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 20);
            this.label11.TabIndex = 23;
            this.label11.Text = "Observação";
            // 
            // txtObservacao
            // 
            this.txtObservacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObservacao.Location = new System.Drawing.Point(3, 22);
            this.txtObservacao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(876, 40);
            this.txtObservacao.TabIndex = 24;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.txtClt, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtCpf, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtRg, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtNome, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtCod, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(877, 64);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // txtClt
            // 
            this.txtClt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtClt.Location = new System.Drawing.Point(721, 22);
            this.txtClt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtClt.Name = "txtClt";
            this.txtClt.Size = new System.Drawing.Size(153, 26);
            this.txtClt.TabIndex = 9;
            // 
            // txtCpf
            // 
            this.txtCpf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCpf.Location = new System.Drawing.Point(407, 22);
            this.txtCpf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.Size = new System.Drawing.Size(151, 26);
            this.txtCpf.TabIndex = 5;
            // 
            // txtRg
            // 
            this.txtRg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRg.Location = new System.Drawing.Point(564, 22);
            this.txtRg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRg.Name = "txtRg";
            this.txtRg.Size = new System.Drawing.Size(151, 26);
            this.txtRg.TabIndex = 7;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(73, 22);
            this.txtNome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(328, 26);
            this.txtNome.TabIndex = 3;
            // 
            // txtCod
            // 
            this.txtCod.Enabled = false;
            this.txtCod.Location = new System.Drawing.Point(3, 22);
            this.txtCod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(64, 26);
            this.txtCod.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cód.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(407, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "CPF";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(564, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "RG";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(721, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "CLT";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.pictureBox1, 0, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(892, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.Size = new System.Drawing.Size(194, 350);
            this.tableLayoutPanel8.TabIndex = 35;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Controls.Add(this.tabFuncionarios, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel10, 0, 2);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 3;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.15504F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.84496F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(1095, 561);
            this.tableLayoutPanel9.TabIndex = 36;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 4;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.24731F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.75269F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 158F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143F));
            this.tableLayoutPanel10.Controls.Add(this.btnNovo, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.btnExcluir, 3, 0);
            this.tableLayoutPanel10.Controls.Add(this.btnGravar, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.btnEditar, 2, 0);
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 519);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(615, 39);
            this.tableLayoutPanel10.TabIndex = 36;
            // 
            // formFuncionarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 561);
            this.Controls.Add(this.tableLayoutPanel9);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "formFuncionarios";
            this.Text = "Cadastro de Funcionários";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formFuncionarios_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formFuncionarios_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tabFuncionarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView tabFuncionarios;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker txtAdmissao;
        private System.Windows.Forms.DateTimePicker txtFerias;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox dropEmpresa;
        private System.Windows.Forms.CheckBox checkAtivo;
        private System.Windows.Forms.CheckBox checkMotPoli;
        private System.Windows.Forms.CheckBox checkComissionado;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker txtValHab;
        private System.Windows.Forms.TextBox txtNroHab;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox dropCatHab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox dropTipo;
        private System.Windows.Forms.TextBox txtFone;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtClt;
        private System.Windows.Forms.TextBox txtCpf;
        private System.Windows.Forms.TextBox txtRg;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}