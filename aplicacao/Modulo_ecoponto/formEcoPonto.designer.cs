namespace aplicacao
{
    partial class formEcoPonto
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
            this.dropEcopontos = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEcoPontos = new System.Windows.Forms.Button();
            this.btnLocacao = new System.Windows.Forms.Button();
            this.btnEditarLocacao = new System.Windows.Forms.Button();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dropVeicEntrega = new System.Windows.Forms.ComboBox();
            this.dropFuncEntrega = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.dropVeicRetirada = new System.Windows.Forms.ComboBox();
            this.dropFuncRetirada = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dropConteiner = new System.Windows.Forms.ComboBox();
            this.txtNroOs = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtVisAte = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.txtVisDe = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.tabLocacoes = new System.Windows.Forms.DataGridView();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.txtQtnLoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRelatorio = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblQtnReg = new System.Windows.Forms.Label();
            this.btnRelDet = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.checkBusca = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.tabLocacoes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dropEcopontos
            // 
            this.dropEcopontos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dropEcopontos.FormattingEnabled = true;
            this.dropEcopontos.Location = new System.Drawing.Point(178, 78);
            this.dropEcopontos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dropEcopontos.Name = "dropEcopontos";
            this.dropEcopontos.Size = new System.Drawing.Size(192, 21);
            this.dropEcopontos.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(176, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 100;
            this.label5.Text = "Ecoponto";
            // 
            // btnEcoPontos
            // 
            this.btnEcoPontos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEcoPontos.Location = new System.Drawing.Point(377, 75);
            this.btnEcoPontos.Margin = new System.Windows.Forms.Padding(4);
            this.btnEcoPontos.Name = "btnEcoPontos";
            this.btnEcoPontos.Size = new System.Drawing.Size(100, 28);
            this.btnEcoPontos.TabIndex = 104;
            this.btnEcoPontos.Text = "Ecopontos";
            this.btnEcoPontos.UseVisualStyleBackColor = true;
            this.btnEcoPontos.Click += new System.EventHandler(this.btnEcoPontos_Click);
            // 
            // btnLocacao
            // 
            this.btnLocacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLocacao.Location = new System.Drawing.Point(141, 166);
            this.btnLocacao.Margin = new System.Windows.Forms.Padding(4);
            this.btnLocacao.Name = "btnLocacao";
            this.btnLocacao.Size = new System.Drawing.Size(120, 30);
            this.btnLocacao.TabIndex = 105;
            this.btnLocacao.Text = "F2=Gravar";
            this.btnLocacao.UseVisualStyleBackColor = true;
            this.btnLocacao.Click += new System.EventHandler(this.btnLocacao_Click);
            // 
            // btnEditarLocacao
            // 
            this.btnEditarLocacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditarLocacao.Location = new System.Drawing.Point(268, 166);
            this.btnEditarLocacao.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditarLocacao.Name = "btnEditarLocacao";
            this.btnEditarLocacao.Size = new System.Drawing.Size(120, 30);
            this.btnEditarLocacao.TabIndex = 115;
            this.btnEditarLocacao.Text = "F3=Atualizar";
            this.btnEditarLocacao.UseVisualStyleBackColor = true;
            this.btnEditarLocacao.Click += new System.EventHandler(this.btnEditarLocacao_Click);
            // 
            // txtCod
            // 
            this.txtCod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCod.Enabled = false;
            this.txtCod.Location = new System.Drawing.Point(13, 80);
            this.txtCod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(47, 19);
            this.txtCod.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 122;
            this.label9.Text = "Código";
            // 
            // dropVeicEntrega
            // 
            this.dropVeicEntrega.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dropVeicEntrega.FormattingEnabled = true;
            this.dropVeicEntrega.Location = new System.Drawing.Point(593, 81);
            this.dropVeicEntrega.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dropVeicEntrega.Name = "dropVeicEntrega";
            this.dropVeicEntrega.Size = new System.Drawing.Size(95, 21);
            this.dropVeicEntrega.TabIndex = 5;
            this.dropVeicEntrega.SelectedIndexChanged += new System.EventHandler(this.dropVeicEntrega_SelectedIndexChanged);
            // 
            // dropFuncEntrega
            // 
            this.dropFuncEntrega.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dropFuncEntrega.FormattingEnabled = true;
            this.dropFuncEntrega.Location = new System.Drawing.Point(485, 80);
            this.dropFuncEntrega.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dropFuncEntrega.Name = "dropFuncEntrega";
            this.dropFuncEntrega.Size = new System.Drawing.Size(102, 21);
            this.dropFuncEntrega.TabIndex = 4;
            this.dropFuncEntrega.SelectedIndexChanged += new System.EventHandler(this.dropFuncEntrega_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(590, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 119;
            this.label10.Text = "Veículo Ent.";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(482, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 118;
            this.label11.Text = "Funcionário Ent.";
            // 
            // txtData
            // 
            this.txtData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtData.CustomFormat = "dd/MM/yyyy";
            this.txtData.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtData.Location = new System.Drawing.Point(67, 78);
            this.txtData.Margin = new System.Windows.Forms.Padding(4);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(105, 19);
            this.txtData.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(64, 58);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 116;
            this.label12.Text = "Data";
            // 
            // dropVeicRetirada
            // 
            this.dropVeicRetirada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dropVeicRetirada.FormattingEnabled = true;
            this.dropVeicRetirada.Location = new System.Drawing.Point(593, 129);
            this.dropVeicRetirada.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dropVeicRetirada.Name = "dropVeicRetirada";
            this.dropVeicRetirada.Size = new System.Drawing.Size(95, 21);
            this.dropVeicRetirada.TabIndex = 127;
            // 
            // dropFuncRetirada
            // 
            this.dropFuncRetirada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dropFuncRetirada.FormattingEnabled = true;
            this.dropFuncRetirada.Location = new System.Drawing.Point(485, 128);
            this.dropFuncRetirada.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dropFuncRetirada.Name = "dropFuncRetirada";
            this.dropFuncRetirada.Size = new System.Drawing.Size(103, 21);
            this.dropFuncRetirada.TabIndex = 126;
            this.dropFuncRetirada.SelectedIndexChanged += new System.EventHandler(this.dropFuncRetirada_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(590, 112);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 125;
            this.label13.Text = "Veículo Ret.";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(482, 109);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 13);
            this.label14.TabIndex = 124;
            this.label14.Text = "Funcionário Ret.";
            // 
            // dropConteiner
            // 
            this.dropConteiner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dropConteiner.FormattingEnabled = true;
            this.dropConteiner.Location = new System.Drawing.Point(784, 81);
            this.dropConteiner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dropConteiner.Name = "dropConteiner";
            this.dropConteiner.Size = new System.Drawing.Size(65, 21);
            this.dropConteiner.TabIndex = 7;
            // 
            // txtNroOs
            // 
            this.txtNroOs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNroOs.Location = new System.Drawing.Point(693, 82);
            this.txtNroOs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNroOs.Name = "txtNroOs";
            this.txtNroOs.Size = new System.Drawing.Size(63, 19);
            this.txtNroOs.TabIndex = 6;
            this.txtNroOs.TextChanged += new System.EventHandler(this.txtNroOs_TextChanged);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(781, 64);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 129;
            this.label15.Text = "Container";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(691, 64);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 13);
            this.label16.TabIndex = 128;
            this.label16.Text = "Número O.S.";
            // 
            // txtVisAte
            // 
            this.txtVisAte.CustomFormat = "dd/MM/yyyy";
            this.txtVisAte.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtVisAte.Location = new System.Drawing.Point(126, 26);
            this.txtVisAte.Margin = new System.Windows.Forms.Padding(4);
            this.txtVisAte.Name = "txtVisAte";
            this.txtVisAte.Size = new System.Drawing.Size(105, 19);
            this.txtVisAte.TabIndex = 1;
            this.txtVisAte.ValueChanged += new System.EventHandler(this.txtVisAte_ValueChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(124, 5);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(26, 13);
            this.label19.TabIndex = 139;
            this.label19.Text = "Até:";
            // 
            // txtVisDe
            // 
            this.txtVisDe.CustomFormat = "dd/MM/yyyy";
            this.txtVisDe.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtVisDe.Location = new System.Drawing.Point(13, 26);
            this.txtVisDe.Margin = new System.Windows.Forms.Padding(4);
            this.txtVisDe.Name = "txtVisDe";
            this.txtVisDe.Size = new System.Drawing.Size(105, 19);
            this.txtVisDe.TabIndex = 0;
            this.txtVisDe.ValueChanged += new System.EventHandler(this.txtVisDe_ValueChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(10, 6);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 13);
            this.label20.TabIndex = 24;
            this.label20.Text = "Visualizar De:";
            // 
            // tabLocacoes
            // 
            this.tabLocacoes.AllowUserToAddRows = false;
            this.tabLocacoes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.tabLocacoes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tabLocacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabLocacoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabLocacoes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.tabLocacoes.Location = new System.Drawing.Point(0, 0);
            this.tabLocacoes.Margin = new System.Windows.Forms.Padding(4);
            this.tabLocacoes.Name = "tabLocacoes";
            this.tabLocacoes.RowHeadersVisible = false;
            this.tabLocacoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabLocacoes.Size = new System.Drawing.Size(1206, 451);
            this.tabLocacoes.TabIndex = 109;
            this.tabLocacoes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabLocacoes_CellClick);
            this.tabLocacoes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabLocacoes_CellValueChanged);
            this.tabLocacoes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabLocacoes_KeyDown);
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNovo.Location = new System.Drawing.Point(13, 166);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(120, 30);
            this.btnNovo.TabIndex = 141;
            this.btnNovo.Text = "F1=Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExcluir.Location = new System.Drawing.Point(396, 166);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(120, 30);
            this.btnExcluir.TabIndex = 142;
            this.btnExcluir.Text = "F4=Deletar";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // txtQtnLoc
            // 
            this.txtQtnLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtQtnLoc.Location = new System.Drawing.Point(854, 82);
            this.txtQtnLoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtQtnLoc.Name = "txtQtnLoc";
            this.txtQtnLoc.Size = new System.Drawing.Size(84, 19);
            this.txtQtnLoc.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(851, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 143;
            this.label1.Text = "Quantidade de Locações";
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRelatorio.Location = new System.Drawing.Point(524, 166);
            this.btnRelatorio.Margin = new System.Windows.Forms.Padding(4);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(120, 30);
            this.btnRelatorio.TabIndex = 145;
            this.btnRelatorio.Text = "F5=Relatórios";
            this.btnRelatorio.UseVisualStyleBackColor = true;
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(692, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 147;
            this.label2.Text = "Qnt. Registros";
            // 
            // lblQtnReg
            // 
            this.lblQtnReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblQtnReg.AutoSize = true;
            this.lblQtnReg.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblQtnReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtnReg.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblQtnReg.Location = new System.Drawing.Point(694, 129);
            this.lblQtnReg.Name = "lblQtnReg";
            this.lblQtnReg.Size = new System.Drawing.Size(53, 31);
            this.lblQtnReg.TabIndex = 148;
            this.lblQtnReg.Text = "xxx";
            // 
            // btnRelDet
            // 
            this.btnRelDet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRelDet.Location = new System.Drawing.Point(652, 166);
            this.btnRelDet.Margin = new System.Windows.Forms.Padding(4);
            this.btnRelDet.Name = "btnRelDet";
            this.btnRelDet.Size = new System.Drawing.Size(155, 30);
            this.btnRelDet.TabIndex = 149;
            this.btnRelDet.Text = "F6=Relatórios Detalhado";
            this.btnRelDet.UseVisualStyleBackColor = true;
            this.btnRelDet.Click += new System.EventHandler(this.btnRelDet_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.tabLocacoes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.checkBusca);
            this.splitContainer1.Panel2.Controls.Add(this.label20);
            this.splitContainer1.Panel2.Controls.Add(this.btnRelDet);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.lblQtnReg);
            this.splitContainer1.Panel2.Controls.Add(this.dropEcopontos);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.btnEcoPontos);
            this.splitContainer1.Panel2.Controls.Add(this.btnRelatorio);
            this.splitContainer1.Panel2.Controls.Add(this.btnLocacao);
            this.splitContainer1.Panel2.Controls.Add(this.txtQtnLoc);
            this.splitContainer1.Panel2.Controls.Add(this.btnEditarLocacao);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.label12);
            this.splitContainer1.Panel2.Controls.Add(this.btnExcluir);
            this.splitContainer1.Panel2.Controls.Add(this.txtData);
            this.splitContainer1.Panel2.Controls.Add(this.btnNovo);
            this.splitContainer1.Panel2.Controls.Add(this.label11);
            this.splitContainer1.Panel2.Controls.Add(this.txtVisAte);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.label19);
            this.splitContainer1.Panel2.Controls.Add(this.dropFuncEntrega);
            this.splitContainer1.Panel2.Controls.Add(this.txtVisDe);
            this.splitContainer1.Panel2.Controls.Add(this.dropVeicEntrega);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.dropConteiner);
            this.splitContainer1.Panel2.Controls.Add(this.txtCod);
            this.splitContainer1.Panel2.Controls.Add(this.txtNroOs);
            this.splitContainer1.Panel2.Controls.Add(this.label14);
            this.splitContainer1.Panel2.Controls.Add(this.label15);
            this.splitContainer1.Panel2.Controls.Add(this.label13);
            this.splitContainer1.Panel2.Controls.Add(this.label16);
            this.splitContainer1.Panel2.Controls.Add(this.dropFuncRetirada);
            this.splitContainer1.Panel2.Controls.Add(this.dropVeicRetirada);
            this.splitContainer1.Size = new System.Drawing.Size(1206, 655);
            this.splitContainer1.SplitterDistance = 451;
            this.splitContainer1.TabIndex = 0;
            // 
            // checkBusca
            // 
            this.checkBusca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBusca.AutoSize = true;
            this.checkBusca.Location = new System.Drawing.Point(784, 133);
            this.checkBusca.Name = "checkBusca";
            this.checkBusca.Size = new System.Drawing.Size(115, 17);
            this.checkBusca.TabIndex = 150;
            this.checkBusca.Text = "Localizar Registros";
            this.checkBusca.UseVisualStyleBackColor = true;
            this.checkBusca.CheckedChanged += new System.EventHandler(this.checkBusca_CheckedChanged);
            // 
            // formEcoPonto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 655);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formEcoPonto";
            this.Text = "Controle de Eco Ponto";
            this.Load += new System.EventHandler(this.formEcoPonto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formEcoPonto_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tabLocacoes)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox dropEcopontos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEcoPontos;
        private System.Windows.Forms.Button btnLocacao;
        private System.Windows.Forms.Button btnEditarLocacao;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox dropVeicEntrega;
        private System.Windows.Forms.ComboBox dropFuncEntrega;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker txtData;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox dropVeicRetirada;
        private System.Windows.Forms.ComboBox dropFuncRetirada;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox dropConteiner;
        private System.Windows.Forms.TextBox txtNroOs;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker txtVisAte;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DateTimePicker txtVisDe;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridView tabLocacoes;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.TextBox txtQtnLoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRelatorio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblQtnReg;
        private System.Windows.Forms.Button btnRelDet;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox checkBusca;
    }
}