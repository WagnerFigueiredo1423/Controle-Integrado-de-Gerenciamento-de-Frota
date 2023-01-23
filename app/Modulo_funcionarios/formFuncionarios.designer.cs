namespace app
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabFuncionarios = new System.Windows.Forms.DataGridView();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dropTipo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.txtPiso = new System.Windows.Forms.TextBox();
            this.txtFone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtValHab = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtNroHab = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.checkComissionado = new System.Windows.Forms.CheckBox();
            this.checkMotPoli = new System.Windows.Forms.CheckBox();
            this.checkAtivo = new System.Windows.Forms.CheckBox();
            this.dropCatHab = new System.Windows.Forms.ComboBox();
            this.dropEmpresa = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtFerias = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAdmissao = new System.Windows.Forms.DateTimePicker();
            this.txtClt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRg = new System.Windows.Forms.TextBox();
            this.txtCpf = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tabFuncionarios)).BeginInit();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabFuncionarios
            // 
            this.tabFuncionarios.AllowUserToAddRows = false;
            this.tabFuncionarios.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabFuncionarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tabFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabFuncionarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFuncionarios.Location = new System.Drawing.Point(3, 358);
            this.tabFuncionarios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabFuncionarios.Name = "tabFuncionarios";
            this.tabFuncionarios.RowHeadersVisible = false;
            this.tabFuncionarios.RowTemplate.Height = 24;
            this.tabFuncionarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabFuncionarios.Size = new System.Drawing.Size(1089, 156);
            this.tabFuncionarios.TabIndex = 27;
            this.tabFuncionarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabFuncionarios_CellContentClick);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExcluir.Location = new System.Drawing.Point(470, 7);
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
            this.btnEditar.Location = new System.Drawing.Point(312, 7);
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
            this.btnGravar.Location = new System.Drawing.Point(155, 7);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(151, 30);
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
            this.btnNovo.Size = new System.Drawing.Size(146, 30);
            this.btnNovo.TabIndex = 28;
            this.btnNovo.Text = "F1 = Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Controls.Add(this.tabFuncionarios, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel10, 0, 2);
            this.tableLayoutPanel9.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 3;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.99225F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.00775F));
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
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
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
            // panel1
            // 
            this.panel1.Controls.Add(this.txtObservacao);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.dropTipo);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtEndereco);
            this.panel1.Controls.Add(this.txtPiso);
            this.panel1.Controls.Add(this.txtFone);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtValHab);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.txtNroHab);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.checkComissionado);
            this.panel1.Controls.Add(this.checkMotPoli);
            this.panel1.Controls.Add(this.checkAtivo);
            this.panel1.Controls.Add(this.dropCatHab);
            this.panel1.Controls.Add(this.dropEmpresa);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtFerias);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtAdmissao);
            this.panel1.Controls.Add(this.txtClt);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtRg);
            this.panel1.Controls.Add(this.txtCpf);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtCod);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNome);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1089, 350);
            this.panel1.TabIndex = 37;
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(6, 242);
            this.txtObservacao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(876, 102);
            this.txtObservacao.TabIndex = 24;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(892, 24);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 240);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 224);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 16);
            this.label11.TabIndex = 23;
            this.label11.Text = "Observação";
            // 
            // dropTipo
            // 
            this.dropTipo.FormattingEnabled = true;
            this.dropTipo.Items.AddRange(new object[] {
            "Selecione",
            "ADMINISTRATIVO",
            "MOTORISTA",
            "MECANICO",
            "AJUDANTE",
            "OUTROS"});
            this.dropTipo.Location = new System.Drawing.Point(472, 132);
            this.dropTipo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dropTipo.Name = "dropTipo";
            this.dropTipo.Size = new System.Drawing.Size(161, 24);
            this.dropTipo.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(469, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "Tipo";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(660, 114);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(84, 16);
            this.label17.TabIndex = 16;
            this.label17.Text = "Piso Salarial";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(459, 172);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Fone";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(9, 190);
            this.txtEndereco.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(432, 22);
            this.txtEndereco.TabIndex = 15;
            // 
            // txtPiso
            // 
            this.txtPiso.Location = new System.Drawing.Point(663, 132);
            this.txtPiso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(117, 22);
            this.txtPiso.TabIndex = 17;
            // 
            // txtFone
            // 
            this.txtFone.Location = new System.Drawing.Point(455, 190);
            this.txtFone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFone.Name = "txtFone";
            this.txtFone.Size = new System.Drawing.Size(117, 22);
            this.txtFone.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Endereço";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(901, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 16);
            this.label13.TabIndex = 33;
            this.label13.Text = "Foto";
            // 
            // txtValHab
            // 
            this.txtValHab.CustomFormat = "dd/MM/aaaa";
            this.txtValHab.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtValHab.Location = new System.Drawing.Point(315, 134);
            this.txtValHab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtValHab.Name = "txtValHab";
            this.txtValHab.Size = new System.Drawing.Size(111, 22);
            this.txtValHab.TabIndex = 11;
            this.txtValHab.Value = new System.DateTime(2015, 3, 7, 0, 0, 0, 0);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(154, 111);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(128, 16);
            this.label15.TabIndex = 0;
            this.label15.Text = "Número Habilitação";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(312, 113);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(151, 16);
            this.label16.TabIndex = 0;
            this.label16.Text = "Vencimento Habilitação";
            // 
            // txtNroHab
            // 
            this.txtNroHab.Location = new System.Drawing.Point(157, 132);
            this.txtNroHab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNroHab.Name = "txtNroHab";
            this.txtNroHab.Size = new System.Drawing.Size(119, 22);
            this.txtNroHab.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 113);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(139, 16);
            this.label14.TabIndex = 0;
            this.label14.Text = "Categoria Habilitação";
            // 
            // checkComissionado
            // 
            this.checkComissionado.AutoSize = true;
            this.checkComissionado.Location = new System.Drawing.Point(666, 86);
            this.checkComissionado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkComissionado.Name = "checkComissionado";
            this.checkComissionado.Size = new System.Drawing.Size(114, 20);
            this.checkComissionado.TabIndex = 22;
            this.checkComissionado.Text = "Comissionado";
            this.checkComissionado.UseVisualStyleBackColor = true;
            // 
            // checkMotPoli
            // 
            this.checkMotPoli.AutoSize = true;
            this.checkMotPoli.Location = new System.Drawing.Point(533, 86);
            this.checkMotPoli.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkMotPoli.Name = "checkMotPoli";
            this.checkMotPoli.Size = new System.Drawing.Size(127, 20);
            this.checkMotPoli.TabIndex = 21;
            this.checkMotPoli.Text = "Motorista de Poli";
            this.checkMotPoli.UseVisualStyleBackColor = true;
            // 
            // checkAtivo
            // 
            this.checkAtivo.AutoSize = true;
            this.checkAtivo.Location = new System.Drawing.Point(533, 60);
            this.checkAtivo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkAtivo.Name = "checkAtivo";
            this.checkAtivo.Size = new System.Drawing.Size(57, 20);
            this.checkAtivo.TabIndex = 18;
            this.checkAtivo.Text = "Ativo";
            this.checkAtivo.UseVisualStyleBackColor = true;
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
            this.dropCatHab.Location = new System.Drawing.Point(9, 132);
            this.dropCatHab.Name = "dropCatHab";
            this.dropCatHab.Size = new System.Drawing.Size(83, 24);
            this.dropCatHab.TabIndex = 1;
            // 
            // dropEmpresa
            // 
            this.dropEmpresa.FormattingEnabled = true;
            this.dropEmpresa.Location = new System.Drawing.Point(293, 82);
            this.dropEmpresa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dropEmpresa.Name = "dropEmpresa";
            this.dropEmpresa.Size = new System.Drawing.Size(223, 24);
            this.dropEmpresa.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(290, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 16);
            this.label12.TabIndex = 26;
            this.label12.Text = "Empresa";
            // 
            // txtFerias
            // 
            this.txtFerias.CustomFormat = "dd/MM/aaaa";
            this.txtFerias.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFerias.Location = new System.Drawing.Point(140, 82);
            this.txtFerias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFerias.Name = "txtFerias";
            this.txtFerias.Size = new System.Drawing.Size(103, 22);
            this.txtFerias.TabIndex = 13;
            this.txtFerias.Value = new System.DateTime(2015, 3, 7, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(137, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Venc. Férias";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Admissão";
            // 
            // txtAdmissao
            // 
            this.txtAdmissao.CustomFormat = "dd/MM/aaaa";
            this.txtAdmissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtAdmissao.Location = new System.Drawing.Point(6, 82);
            this.txtAdmissao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAdmissao.Name = "txtAdmissao";
            this.txtAdmissao.Size = new System.Drawing.Size(107, 22);
            this.txtAdmissao.TabIndex = 11;
            this.txtAdmissao.Value = new System.DateTime(2015, 3, 7, 0, 0, 0, 0);
            // 
            // txtClt
            // 
            this.txtClt.Location = new System.Drawing.Point(689, 24);
            this.txtClt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtClt.Name = "txtClt";
            this.txtClt.Size = new System.Drawing.Size(153, 22);
            this.txtClt.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(686, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "CLT";
            // 
            // txtRg
            // 
            this.txtRg.Location = new System.Drawing.Point(554, 24);
            this.txtRg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRg.Name = "txtRg";
            this.txtRg.Size = new System.Drawing.Size(127, 22);
            this.txtRg.TabIndex = 7;
            // 
            // txtCpf
            // 
            this.txtCpf.Location = new System.Drawing.Point(428, 24);
            this.txtCpf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.Size = new System.Drawing.Size(120, 22);
            this.txtCpf.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(560, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "RG";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cód.";
            // 
            // txtCod
            // 
            this.txtCod.Enabled = false;
            this.txtCod.Location = new System.Drawing.Point(6, 24);
            this.txtCod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(64, 22);
            this.txtCod.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(432, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "CPF";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(90, 24);
            this.txtNome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(328, 22);
            this.txtNome.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome";
            // 
            // formFuncionarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
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
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView tabFuncionarios;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker txtFerias;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker txtAdmissao;
        private System.Windows.Forms.TextBox txtClt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox dropEmpresa;
        private System.Windows.Forms.CheckBox checkAtivo;
        private System.Windows.Forms.CheckBox checkMotPoli;
        private System.Windows.Forms.CheckBox checkComissionado;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker txtValHab;
        private System.Windows.Forms.TextBox txtNroHab;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox dropCatHab;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox dropTipo;
        private System.Windows.Forms.TextBox txtFone;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRg;
        private System.Windows.Forms.TextBox txtCpf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtPiso;
    }
}