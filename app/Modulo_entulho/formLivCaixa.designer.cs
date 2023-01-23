namespace app
{
    partial class formLivCaixa
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
            this.components = new System.ComponentModel.Container();
            this.tabPagamentos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDataInicial = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDinheiro_a_receber = new System.Windows.Forms.Label();
            this.lblCheque_a_receber = new System.Windows.Forms.Label();
            this.lblDeposito_a_receber = new System.Windows.Forms.Label();
            this.lblBoleto_a_receber = new System.Windows.Forms.Label();
            this.lblCartao_a_receber = new System.Windows.Forms.Label();
            this.lblOutros_a_receber = new System.Windows.Forms.Label();
            this.lblTotal_a_receber = new System.Windows.Forms.Label();
            this.btn_atualizar = new System.Windows.Forms.Button();
            this.btn_pendencias = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblTotal_recebido = new System.Windows.Forms.Label();
            this.lblOutros_recebido = new System.Windows.Forms.Label();
            this.lblCartao_recebido = new System.Windows.Forms.Label();
            this.lblBoleto_recebido = new System.Windows.Forms.Label();
            this.lblDeposito_recebido = new System.Windows.Forms.Label();
            this.lblCheque_recebido = new System.Windows.Forms.Label();
            this.lblDinheiro_recebido = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblOutros_total = new System.Windows.Forms.Label();
            this.lblCartao_total = new System.Windows.Forms.Label();
            this.lblBoleto_total = new System.Windows.Forms.Label();
            this.lblDeposito_total = new System.Windows.Forms.Label();
            this.lblCheque_total = new System.Windows.Forms.Label();
            this.lblDinheiro_total = new System.Windows.Forms.Label();
            this.txtDataFinal = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.checkBuscaGeral = new System.Windows.Forms.CheckBox();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.btnRefrash = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tabPagamentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPagamentos
            // 
            this.tabPagamentos.AllowUserToAddRows = false;
            this.tabPagamentos.AllowUserToDeleteRows = false;
            this.tabPagamentos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.tabPagamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabPagamentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPagamentos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.tabPagamentos.Location = new System.Drawing.Point(0, 0);
            this.tabPagamentos.Margin = new System.Windows.Forms.Padding(2);
            this.tabPagamentos.Name = "tabPagamentos";
            this.tabPagamentos.RowHeadersVisible = false;
            this.tabPagamentos.RowTemplate.Height = 24;
            this.tabPagamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.tabPagamentos.Size = new System.Drawing.Size(966, 514);
            this.tabPagamentos.TabIndex = 0;
            this.tabPagamentos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabPagamentos_CellClick);
            this.tabPagamentos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabPagamentos_CellEndEdit);
            this.tabPagamentos.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabPagamentos_CellValidated);
            this.tabPagamentos.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.tabPagamentos_ColumnHeaderMouseClick);
            this.tabPagamentos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.tabPagamentos_EditingControlShowing);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-52, -58);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pagamentos";
            // 
            // txtDataInicial
            // 
            this.txtDataInicial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDataInicial.CustomFormat = "dd/MM/yyyy";
            this.txtDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDataInicial.Location = new System.Drawing.Point(26, 19);
            this.txtDataInicial.Margin = new System.Windows.Forms.Padding(2);
            this.txtDataInicial.Name = "txtDataInicial";
            this.txtDataInicial.Size = new System.Drawing.Size(102, 20);
            this.txtDataInicial.TabIndex = 2;
            this.txtDataInicial.ValueChanged += new System.EventHandler(this.txtDataInicial_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(277, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Totais:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Dinheiro:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 87);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cheque:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 115);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Depósito:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 144);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Boleto:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 172);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Cartão:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 201);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Outros:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 236);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 20);
            this.label9.TabIndex = 12;
            this.label9.Text = "Total:";
            // 
            // lblDinheiro_a_receber
            // 
            this.lblDinheiro_a_receber.AutoSize = true;
            this.lblDinheiro_a_receber.ForeColor = System.Drawing.Color.Red;
            this.lblDinheiro_a_receber.Location = new System.Drawing.Point(107, 58);
            this.lblDinheiro_a_receber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDinheiro_a_receber.Name = "lblDinheiro_a_receber";
            this.lblDinheiro_a_receber.Size = new System.Drawing.Size(41, 13);
            this.lblDinheiro_a_receber.TabIndex = 13;
            this.lblDinheiro_a_receber.Text = "label10";
            // 
            // lblCheque_a_receber
            // 
            this.lblCheque_a_receber.AutoSize = true;
            this.lblCheque_a_receber.ForeColor = System.Drawing.Color.Red;
            this.lblCheque_a_receber.Location = new System.Drawing.Point(107, 87);
            this.lblCheque_a_receber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCheque_a_receber.Name = "lblCheque_a_receber";
            this.lblCheque_a_receber.Size = new System.Drawing.Size(41, 13);
            this.lblCheque_a_receber.TabIndex = 14;
            this.lblCheque_a_receber.Text = "label10";
            // 
            // lblDeposito_a_receber
            // 
            this.lblDeposito_a_receber.AutoSize = true;
            this.lblDeposito_a_receber.ForeColor = System.Drawing.Color.Red;
            this.lblDeposito_a_receber.Location = new System.Drawing.Point(107, 115);
            this.lblDeposito_a_receber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeposito_a_receber.Name = "lblDeposito_a_receber";
            this.lblDeposito_a_receber.Size = new System.Drawing.Size(41, 13);
            this.lblDeposito_a_receber.TabIndex = 15;
            this.lblDeposito_a_receber.Text = "label10";
            // 
            // lblBoleto_a_receber
            // 
            this.lblBoleto_a_receber.AutoSize = true;
            this.lblBoleto_a_receber.ForeColor = System.Drawing.Color.Red;
            this.lblBoleto_a_receber.Location = new System.Drawing.Point(107, 144);
            this.lblBoleto_a_receber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBoleto_a_receber.Name = "lblBoleto_a_receber";
            this.lblBoleto_a_receber.Size = new System.Drawing.Size(41, 13);
            this.lblBoleto_a_receber.TabIndex = 16;
            this.lblBoleto_a_receber.Text = "label10";
            // 
            // lblCartao_a_receber
            // 
            this.lblCartao_a_receber.AutoSize = true;
            this.lblCartao_a_receber.ForeColor = System.Drawing.Color.Red;
            this.lblCartao_a_receber.Location = new System.Drawing.Point(107, 172);
            this.lblCartao_a_receber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCartao_a_receber.Name = "lblCartao_a_receber";
            this.lblCartao_a_receber.Size = new System.Drawing.Size(41, 13);
            this.lblCartao_a_receber.TabIndex = 17;
            this.lblCartao_a_receber.Text = "label10";
            // 
            // lblOutros_a_receber
            // 
            this.lblOutros_a_receber.AutoSize = true;
            this.lblOutros_a_receber.ForeColor = System.Drawing.Color.Red;
            this.lblOutros_a_receber.Location = new System.Drawing.Point(107, 201);
            this.lblOutros_a_receber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOutros_a_receber.Name = "lblOutros_a_receber";
            this.lblOutros_a_receber.Size = new System.Drawing.Size(41, 13);
            this.lblOutros_a_receber.TabIndex = 18;
            this.lblOutros_a_receber.Text = "label10";
            // 
            // lblTotal_a_receber
            // 
            this.lblTotal_a_receber.AutoSize = true;
            this.lblTotal_a_receber.ForeColor = System.Drawing.Color.Red;
            this.lblTotal_a_receber.Location = new System.Drawing.Point(107, 241);
            this.lblTotal_a_receber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal_a_receber.Name = "lblTotal_a_receber";
            this.lblTotal_a_receber.Size = new System.Drawing.Size(41, 13);
            this.lblTotal_a_receber.TabIndex = 19;
            this.lblTotal_a_receber.Text = "label10";
            // 
            // btn_atualizar
            // 
            this.btn_atualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_atualizar.Location = new System.Drawing.Point(11, 58);
            this.btn_atualizar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_atualizar.Name = "btn_atualizar";
            this.btn_atualizar.Size = new System.Drawing.Size(117, 26);
            this.btn_atualizar.TabIndex = 159;
            this.btn_atualizar.Text = "Atualizar Dados\r\n";
            this.btn_atualizar.UseVisualStyleBackColor = true;
            // 
            // btn_pendencias
            // 
            this.btn_pendencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_pendencias.Location = new System.Drawing.Point(154, 58);
            this.btn_pendencias.Margin = new System.Windows.Forms.Padding(2);
            this.btn_pendencias.Name = "btn_pendencias";
            this.btn_pendencias.Size = new System.Drawing.Size(117, 26);
            this.btn_pendencias.TabIndex = 160;
            this.btn_pendencias.Text = "Relatório Pendências";
            this.btn_pendencias.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(97, 30);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(61, 13);
            this.label20.TabIndex = 161;
            this.label20.Text = "A Receber:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label21.Location = new System.Drawing.Point(185, 31);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 13);
            this.label21.TabIndex = 169;
            this.label21.Text = "Recebido:";
            // 
            // lblTotal_recebido
            // 
            this.lblTotal_recebido.AutoSize = true;
            this.lblTotal_recebido.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTotal_recebido.Location = new System.Drawing.Point(192, 241);
            this.lblTotal_recebido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal_recebido.Name = "lblTotal_recebido";
            this.lblTotal_recebido.Size = new System.Drawing.Size(41, 13);
            this.lblTotal_recebido.TabIndex = 168;
            this.lblTotal_recebido.Text = "label10";
            // 
            // lblOutros_recebido
            // 
            this.lblOutros_recebido.AutoSize = true;
            this.lblOutros_recebido.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblOutros_recebido.Location = new System.Drawing.Point(192, 201);
            this.lblOutros_recebido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOutros_recebido.Name = "lblOutros_recebido";
            this.lblOutros_recebido.Size = new System.Drawing.Size(41, 13);
            this.lblOutros_recebido.TabIndex = 167;
            this.lblOutros_recebido.Text = "label10";
            // 
            // lblCartao_recebido
            // 
            this.lblCartao_recebido.AutoSize = true;
            this.lblCartao_recebido.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCartao_recebido.Location = new System.Drawing.Point(192, 172);
            this.lblCartao_recebido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCartao_recebido.Name = "lblCartao_recebido";
            this.lblCartao_recebido.Size = new System.Drawing.Size(41, 13);
            this.lblCartao_recebido.TabIndex = 166;
            this.lblCartao_recebido.Text = "label10";
            // 
            // lblBoleto_recebido
            // 
            this.lblBoleto_recebido.AutoSize = true;
            this.lblBoleto_recebido.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblBoleto_recebido.Location = new System.Drawing.Point(192, 144);
            this.lblBoleto_recebido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBoleto_recebido.Name = "lblBoleto_recebido";
            this.lblBoleto_recebido.Size = new System.Drawing.Size(41, 13);
            this.lblBoleto_recebido.TabIndex = 165;
            this.lblBoleto_recebido.Text = "label10";
            // 
            // lblDeposito_recebido
            // 
            this.lblDeposito_recebido.AutoSize = true;
            this.lblDeposito_recebido.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblDeposito_recebido.Location = new System.Drawing.Point(192, 115);
            this.lblDeposito_recebido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeposito_recebido.Name = "lblDeposito_recebido";
            this.lblDeposito_recebido.Size = new System.Drawing.Size(41, 13);
            this.lblDeposito_recebido.TabIndex = 164;
            this.lblDeposito_recebido.Text = "label10";
            // 
            // lblCheque_recebido
            // 
            this.lblCheque_recebido.AutoSize = true;
            this.lblCheque_recebido.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCheque_recebido.Location = new System.Drawing.Point(192, 87);
            this.lblCheque_recebido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCheque_recebido.Name = "lblCheque_recebido";
            this.lblCheque_recebido.Size = new System.Drawing.Size(41, 13);
            this.lblCheque_recebido.TabIndex = 163;
            this.lblCheque_recebido.Text = "label10";
            // 
            // lblDinheiro_recebido
            // 
            this.lblDinheiro_recebido.AutoSize = true;
            this.lblDinheiro_recebido.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblDinheiro_recebido.Location = new System.Drawing.Point(192, 58);
            this.lblDinheiro_recebido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDinheiro_recebido.Name = "lblDinheiro_recebido";
            this.lblDinheiro_recebido.Size = new System.Drawing.Size(41, 13);
            this.lblDinheiro_recebido.TabIndex = 162;
            this.lblDinheiro_recebido.Text = "label10";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotal.Location = new System.Drawing.Point(284, 240);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(41, 13);
            this.lblTotal.TabIndex = 176;
            this.lblTotal.Text = "label10";
            // 
            // lblOutros_total
            // 
            this.lblOutros_total.AutoSize = true;
            this.lblOutros_total.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOutros_total.Location = new System.Drawing.Point(284, 199);
            this.lblOutros_total.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOutros_total.Name = "lblOutros_total";
            this.lblOutros_total.Size = new System.Drawing.Size(41, 13);
            this.lblOutros_total.TabIndex = 175;
            this.lblOutros_total.Text = "label10";
            // 
            // lblCartao_total
            // 
            this.lblCartao_total.AutoSize = true;
            this.lblCartao_total.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCartao_total.Location = new System.Drawing.Point(284, 171);
            this.lblCartao_total.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCartao_total.Name = "lblCartao_total";
            this.lblCartao_total.Size = new System.Drawing.Size(41, 13);
            this.lblCartao_total.TabIndex = 174;
            this.lblCartao_total.Text = "label10";
            // 
            // lblBoleto_total
            // 
            this.lblBoleto_total.AutoSize = true;
            this.lblBoleto_total.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBoleto_total.Location = new System.Drawing.Point(284, 142);
            this.lblBoleto_total.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBoleto_total.Name = "lblBoleto_total";
            this.lblBoleto_total.Size = new System.Drawing.Size(41, 13);
            this.lblBoleto_total.TabIndex = 173;
            this.lblBoleto_total.Text = "label10";
            // 
            // lblDeposito_total
            // 
            this.lblDeposito_total.AutoSize = true;
            this.lblDeposito_total.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDeposito_total.Location = new System.Drawing.Point(284, 114);
            this.lblDeposito_total.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeposito_total.Name = "lblDeposito_total";
            this.lblDeposito_total.Size = new System.Drawing.Size(41, 13);
            this.lblDeposito_total.TabIndex = 172;
            this.lblDeposito_total.Text = "label10";
            // 
            // lblCheque_total
            // 
            this.lblCheque_total.AutoSize = true;
            this.lblCheque_total.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCheque_total.Location = new System.Drawing.Point(284, 85);
            this.lblCheque_total.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCheque_total.Name = "lblCheque_total";
            this.lblCheque_total.Size = new System.Drawing.Size(41, 13);
            this.lblCheque_total.TabIndex = 171;
            this.lblCheque_total.Text = "label10";
            // 
            // lblDinheiro_total
            // 
            this.lblDinheiro_total.AutoSize = true;
            this.lblDinheiro_total.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDinheiro_total.Location = new System.Drawing.Point(284, 57);
            this.lblDinheiro_total.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDinheiro_total.Name = "lblDinheiro_total";
            this.lblDinheiro_total.Size = new System.Drawing.Size(41, 13);
            this.lblDinheiro_total.TabIndex = 170;
            this.lblDinheiro_total.Text = "label10";
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDataFinal.CustomFormat = "dd/MM/yyyy";
            this.txtDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDataFinal.Location = new System.Drawing.Point(161, 19);
            this.txtDataFinal.Margin = new System.Windows.Forms.Padding(2);
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.Size = new System.Drawing.Size(102, 20);
            this.txtDataFinal.TabIndex = 3;
            this.txtDataFinal.ValueChanged += new System.EventHandler(this.txtDataFinal_ValueChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.lblTotal);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.lblOutros_total);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.lblCartao_total);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.lblBoleto_total);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.lblDeposito_total);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.lblCheque_total);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.lblDinheiro_total);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.label21);
            this.splitContainer1.Panel2.Controls.Add(this.lblDinheiro_a_receber);
            this.splitContainer1.Panel2.Controls.Add(this.lblTotal_recebido);
            this.splitContainer1.Panel2.Controls.Add(this.lblCheque_a_receber);
            this.splitContainer1.Panel2.Controls.Add(this.lblOutros_recebido);
            this.splitContainer1.Panel2.Controls.Add(this.lblDeposito_a_receber);
            this.splitContainer1.Panel2.Controls.Add(this.lblCartao_recebido);
            this.splitContainer1.Panel2.Controls.Add(this.lblBoleto_a_receber);
            this.splitContainer1.Panel2.Controls.Add(this.lblBoleto_recebido);
            this.splitContainer1.Panel2.Controls.Add(this.lblCartao_a_receber);
            this.splitContainer1.Panel2.Controls.Add(this.lblDeposito_recebido);
            this.splitContainer1.Panel2.Controls.Add(this.lblOutros_a_receber);
            this.splitContainer1.Panel2.Controls.Add(this.lblCheque_recebido);
            this.splitContainer1.Panel2.Controls.Add(this.lblTotal_a_receber);
            this.splitContainer1.Panel2.Controls.Add(this.lblDinheiro_recebido);
            this.splitContainer1.Panel2.Controls.Add(this.label20);
            this.splitContainer1.Size = new System.Drawing.Size(1322, 613);
            this.splitContainer1.SplitterDistance = 966;
            this.splitContainer1.TabIndex = 177;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tabPagamentos);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.checkBuscaGeral);
            this.splitContainer2.Panel2.Controls.Add(this.txtBusca);
            this.splitContainer2.Panel2.Controls.Add(this.txtDataInicial);
            this.splitContainer2.Panel2.Controls.Add(this.btnRefrash);
            this.splitContainer2.Panel2.Controls.Add(this.btn_pendencias);
            this.splitContainer2.Panel2.Controls.Add(this.txtDataFinal);
            this.splitContainer2.Panel2.Controls.Add(this.btn_atualizar);
            this.splitContainer2.Size = new System.Drawing.Size(966, 613);
            this.splitContainer2.SplitterDistance = 514;
            this.splitContainer2.TabIndex = 0;
            // 
            // checkBuscaGeral
            // 
            this.checkBuscaGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBuscaGeral.AutoSize = true;
            this.checkBuscaGeral.Location = new System.Drawing.Point(706, 21);
            this.checkBuscaGeral.Name = "checkBuscaGeral";
            this.checkBuscaGeral.Size = new System.Drawing.Size(170, 17);
            this.checkBuscaGeral.TabIndex = 162;
            this.checkBuscaGeral.Text = "Buscar em Todos os Registros";
            this.checkBuscaGeral.UseVisualStyleBackColor = true;
            // 
            // txtBusca
            // 
            this.txtBusca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBusca.Location = new System.Drawing.Point(308, 19);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(335, 20);
            this.txtBusca.TabIndex = 161;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);
            // 
            // btnRefrash
            // 
            this.btnRefrash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefrash.Location = new System.Drawing.Point(308, 58);
            this.btnRefrash.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefrash.Name = "btnRefrash";
            this.btnRefrash.Size = new System.Drawing.Size(117, 26);
            this.btnRefrash.TabIndex = 160;
            this.btnRefrash.Text = "Atualizar Tabela";
            this.btnRefrash.UseVisualStyleBackColor = true;
            this.btnRefrash.Click += new System.EventHandler(this.btnRefrash_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // formLivCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 613);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "formLivCaixa";
            this.Text = "Fluxo de Caixa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formLivCaixa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabPagamentos)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tabPagamentos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtDataInicial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDinheiro_a_receber;
        private System.Windows.Forms.Label lblCheque_a_receber;
        private System.Windows.Forms.Label lblDeposito_a_receber;
        private System.Windows.Forms.Label lblBoleto_a_receber;
        private System.Windows.Forms.Label lblCartao_a_receber;
        private System.Windows.Forms.Label lblOutros_a_receber;
        private System.Windows.Forms.Label lblTotal_a_receber;
        private System.Windows.Forms.Button btn_atualizar;
        private System.Windows.Forms.Button btn_pendencias;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblTotal_recebido;
        private System.Windows.Forms.Label lblOutros_recebido;
        private System.Windows.Forms.Label lblCartao_recebido;
        private System.Windows.Forms.Label lblBoleto_recebido;
        private System.Windows.Forms.Label lblDeposito_recebido;
        private System.Windows.Forms.Label lblCheque_recebido;
        private System.Windows.Forms.Label lblDinheiro_recebido;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblOutros_total;
        private System.Windows.Forms.Label lblCartao_total;
        private System.Windows.Forms.Label lblBoleto_total;
        private System.Windows.Forms.Label lblDeposito_total;
        private System.Windows.Forms.Label lblCheque_total;
        private System.Windows.Forms.Label lblDinheiro_total;
        private System.Windows.Forms.DateTimePicker txtDataFinal;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnRefrash;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.CheckBox checkBuscaGeral;
    }
}