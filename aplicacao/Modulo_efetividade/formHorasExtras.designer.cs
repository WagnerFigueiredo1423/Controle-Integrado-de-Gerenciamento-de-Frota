namespace aplicacao
{
    partial class formHorasExtras
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
            this.label5 = new System.Windows.Forms.Label();
            this.dropMotorista = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.dropMes = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDomTrab = new System.Windows.Forms.Label();
            this.lblFerTrab = new System.Windows.Forms.Label();
            this.lblMadTrab = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabDomingos = new System.Windows.Forms.DataGridView();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.tabFeriados = new System.Windows.Forms.DataGridView();
            this.tabMadrugadas = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotHrMes = new System.Windows.Forms.Label();
            this.lblTotDiasTrab = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblTotHrDom = new System.Windows.Forms.Label();
            this.lblTotHrFer = new System.Windows.Forms.Label();
            this.lblTotHrMad = new System.Windows.Forms.Label();
            this.tabDias = new System.Windows.Forms.DataGridView();
            this.lblDiasTrab = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.lblTotHrDia = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tabDomingos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabFeriados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMadrugadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabDias)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(274, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 17);
            this.label5.TabIndex = 92;
            this.label5.Text = "Motorista";
            // 
            // dropMotorista
            // 
            this.dropMotorista.FormattingEnabled = true;
            this.dropMotorista.Items.AddRange(new object[] {
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
            this.dropMotorista.Location = new System.Drawing.Point(277, 32);
            this.dropMotorista.Margin = new System.Windows.Forms.Padding(4);
            this.dropMotorista.Name = "dropMotorista";
            this.dropMotorista.Size = new System.Drawing.Size(132, 24);
            this.dropMotorista.TabIndex = 89;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 91;
            this.label3.Text = "Mês";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 90;
            this.label1.Text = "Ano";
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(16, 34);
            this.txtAno.Margin = new System.Windows.Forms.Padding(4);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(85, 22);
            this.txtAno.TabIndex = 87;
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
            this.dropMes.Location = new System.Drawing.Point(109, 32);
            this.dropMes.Margin = new System.Windows.Forms.Padding(4);
            this.dropMes.Name = "dropMes";
            this.dropMes.Size = new System.Drawing.Size(160, 24);
            this.dropMes.TabIndex = 88;
            this.dropMes.Text = "Selecione";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 17);
            this.label6.TabIndex = 95;
            this.label6.Text = "Domingos Trabalhados:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 340);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 17);
            this.label7.TabIndex = 96;
            this.label7.Text = "Feriados Trabalhados:";
            // 
            // lblDomTrab
            // 
            this.lblDomTrab.AutoSize = true;
            this.lblDomTrab.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomTrab.ForeColor = System.Drawing.Color.Blue;
            this.lblDomTrab.Location = new System.Drawing.Point(176, 208);
            this.lblDomTrab.Name = "lblDomTrab";
            this.lblDomTrab.Size = new System.Drawing.Size(28, 17);
            this.lblDomTrab.TabIndex = 97;
            this.lblDomTrab.Text = "XX";
            // 
            // lblFerTrab
            // 
            this.lblFerTrab.AutoSize = true;
            this.lblFerTrab.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFerTrab.ForeColor = System.Drawing.Color.Blue;
            this.lblFerTrab.Location = new System.Drawing.Point(169, 340);
            this.lblFerTrab.Name = "lblFerTrab";
            this.lblFerTrab.Size = new System.Drawing.Size(28, 17);
            this.lblFerTrab.TabIndex = 98;
            this.lblFerTrab.Text = "XX";
            // 
            // lblMadTrab
            // 
            this.lblMadTrab.AutoSize = true;
            this.lblMadTrab.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMadTrab.ForeColor = System.Drawing.Color.Blue;
            this.lblMadTrab.Location = new System.Drawing.Point(193, 472);
            this.lblMadTrab.Name = "lblMadTrab";
            this.lblMadTrab.Size = new System.Drawing.Size(28, 17);
            this.lblMadTrab.TabIndex = 100;
            this.lblMadTrab.Text = "XX";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 472);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(175, 17);
            this.label9.TabIndex = 99;
            this.label9.Text = "Madrugadas Trabalhadas:";
            // 
            // tabDomingos
            // 
            this.tabDomingos.AllowUserToAddRows = false;
            this.tabDomingos.AllowUserToDeleteRows = false;
            this.tabDomingos.AllowUserToResizeColumns = false;
            this.tabDomingos.AllowUserToResizeRows = false;
            this.tabDomingos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabDomingos.Location = new System.Drawing.Point(14, 228);
            this.tabDomingos.Name = "tabDomingos";
            this.tabDomingos.RowHeadersVisible = false;
            this.tabDomingos.RowTemplate.Height = 24;
            this.tabDomingos.Size = new System.Drawing.Size(911, 109);
            this.tabDomingos.TabIndex = 101;
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Location = new System.Drawing.Point(14, 607);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(95, 32);
            this.btnVisualizar.TabIndex = 103;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // tabFeriados
            // 
            this.tabFeriados.AllowUserToAddRows = false;
            this.tabFeriados.AllowUserToDeleteRows = false;
            this.tabFeriados.AllowUserToResizeColumns = false;
            this.tabFeriados.AllowUserToResizeRows = false;
            this.tabFeriados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabFeriados.Location = new System.Drawing.Point(14, 360);
            this.tabFeriados.Name = "tabFeriados";
            this.tabFeriados.RowHeadersVisible = false;
            this.tabFeriados.RowTemplate.Height = 24;
            this.tabFeriados.Size = new System.Drawing.Size(911, 109);
            this.tabFeriados.TabIndex = 104;
            // 
            // tabMadrugadas
            // 
            this.tabMadrugadas.AllowUserToAddRows = false;
            this.tabMadrugadas.AllowUserToDeleteRows = false;
            this.tabMadrugadas.AllowUserToResizeColumns = false;
            this.tabMadrugadas.AllowUserToResizeRows = false;
            this.tabMadrugadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabMadrugadas.Location = new System.Drawing.Point(14, 492);
            this.tabMadrugadas.Name = "tabMadrugadas";
            this.tabMadrugadas.RowHeadersVisible = false;
            this.tabMadrugadas.RowTemplate.Height = 24;
            this.tabMadrugadas.Size = new System.Drawing.Size(911, 109);
            this.tabMadrugadas.TabIndex = 105;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(478, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 106;
            this.label2.Text = "Horas Trabalhadas:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(478, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 17);
            this.label4.TabIndex = 107;
            this.label4.Text = "Dias Trabalhados:";
            // 
            // lblTotHrMes
            // 
            this.lblTotHrMes.AutoSize = true;
            this.lblTotHrMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotHrMes.ForeColor = System.Drawing.Color.Blue;
            this.lblTotHrMes.Location = new System.Drawing.Point(618, 14);
            this.lblTotHrMes.Name = "lblTotHrMes";
            this.lblTotHrMes.Size = new System.Drawing.Size(53, 17);
            this.lblTotHrMes.TabIndex = 108;
            this.lblTotHrMes.Text = "XX:XX";
            // 
            // lblTotDiasTrab
            // 
            this.lblTotDiasTrab.AutoSize = true;
            this.lblTotDiasTrab.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotDiasTrab.ForeColor = System.Drawing.Color.Blue;
            this.lblTotDiasTrab.Location = new System.Drawing.Point(618, 39);
            this.lblTotDiasTrab.Name = "lblTotDiasTrab";
            this.lblTotDiasTrab.Size = new System.Drawing.Size(28, 17);
            this.lblTotDiasTrab.TabIndex = 109;
            this.lblTotDiasTrab.Text = "XX";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(233, 472);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 17);
            this.label11.TabIndex = 110;
            this.label11.Text = "Totais de Horas:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(234, 340);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 17);
            this.label12.TabIndex = 111;
            this.label12.Text = "Totais de Horas:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(234, 208);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 17);
            this.label13.TabIndex = 112;
            this.label13.Text = "Totais de Horas:";
            // 
            // lblTotHrDom
            // 
            this.lblTotHrDom.AutoSize = true;
            this.lblTotHrDom.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotHrDom.ForeColor = System.Drawing.Color.Blue;
            this.lblTotHrDom.Location = new System.Drawing.Point(353, 208);
            this.lblTotHrDom.Name = "lblTotHrDom";
            this.lblTotHrDom.Size = new System.Drawing.Size(53, 17);
            this.lblTotHrDom.TabIndex = 116;
            this.lblTotHrDom.Text = "XX:XX";
            // 
            // lblTotHrFer
            // 
            this.lblTotHrFer.AutoSize = true;
            this.lblTotHrFer.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotHrFer.ForeColor = System.Drawing.Color.Blue;
            this.lblTotHrFer.Location = new System.Drawing.Point(353, 340);
            this.lblTotHrFer.Name = "lblTotHrFer";
            this.lblTotHrFer.Size = new System.Drawing.Size(53, 17);
            this.lblTotHrFer.TabIndex = 117;
            this.lblTotHrFer.Text = "XX:XX";
            // 
            // lblTotHrMad
            // 
            this.lblTotHrMad.AutoSize = true;
            this.lblTotHrMad.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotHrMad.ForeColor = System.Drawing.Color.Blue;
            this.lblTotHrMad.Location = new System.Drawing.Point(353, 472);
            this.lblTotHrMad.Name = "lblTotHrMad";
            this.lblTotHrMad.Size = new System.Drawing.Size(53, 17);
            this.lblTotHrMad.TabIndex = 118;
            this.lblTotHrMad.Text = "XX:XX";
            // 
            // tabDias
            // 
            this.tabDias.AllowUserToAddRows = false;
            this.tabDias.AllowUserToDeleteRows = false;
            this.tabDias.AllowUserToResizeColumns = false;
            this.tabDias.AllowUserToResizeRows = false;
            this.tabDias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabDias.Location = new System.Drawing.Point(14, 96);
            this.tabDias.Name = "tabDias";
            this.tabDias.RowHeadersVisible = false;
            this.tabDias.RowTemplate.Height = 24;
            this.tabDias.Size = new System.Drawing.Size(911, 109);
            this.tabDias.TabIndex = 133;
            // 
            // lblDiasTrab
            // 
            this.lblDiasTrab.AutoSize = true;
            this.lblDiasTrab.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiasTrab.ForeColor = System.Drawing.Color.Blue;
            this.lblDiasTrab.Location = new System.Drawing.Point(193, 76);
            this.lblDiasTrab.Name = "lblDiasTrab";
            this.lblDiasTrab.Size = new System.Drawing.Size(28, 17);
            this.lblDiasTrab.TabIndex = 132;
            this.lblDiasTrab.Text = "XX";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(9, 76);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(180, 17);
            this.label30.TabIndex = 131;
            this.label30.Text = "Dias Normais Trabalhados:";
            // 
            // lblTotHrDia
            // 
            this.lblTotHrDia.AutoSize = true;
            this.lblTotHrDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotHrDia.ForeColor = System.Drawing.Color.Blue;
            this.lblTotHrDia.Location = new System.Drawing.Point(353, 76);
            this.lblTotHrDia.Name = "lblTotHrDia";
            this.lblTotHrDia.Size = new System.Drawing.Size(53, 17);
            this.lblTotHrDia.TabIndex = 135;
            this.lblTotHrDia.Text = "XX:XX";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(234, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 17);
            this.label10.TabIndex = 134;
            this.label10.Text = "Totais de Horas:";
            // 
            // formHorasExtras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 648);
            this.Controls.Add(this.lblTotHrDia);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tabDias);
            this.Controls.Add(this.lblDiasTrab);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.lblTotHrMad);
            this.Controls.Add(this.lblTotHrFer);
            this.Controls.Add(this.lblTotHrDom);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblTotDiasTrab);
            this.Controls.Add(this.lblTotHrMes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabMadrugadas);
            this.Controls.Add(this.tabFeriados);
            this.Controls.Add(this.btnVisualizar);
            this.Controls.Add(this.tabDomingos);
            this.Controls.Add(this.lblMadTrab);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblFerTrab);
            this.Controls.Add(this.lblDomTrab);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dropMotorista);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.dropMes);
            this.Name = "formHorasExtras";
            this.Text = "Horas Extras";
            this.Load += new System.EventHandler(this.formHorasExtras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabDomingos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabFeriados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMadrugadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabDias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox dropMotorista;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.ComboBox dropMes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDomTrab;
        private System.Windows.Forms.Label lblFerTrab;
        private System.Windows.Forms.Label lblMadTrab;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView tabDomingos;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.DataGridView tabFeriados;
        private System.Windows.Forms.DataGridView tabMadrugadas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotHrMes;
        private System.Windows.Forms.Label lblTotDiasTrab;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblTotHrDom;
        private System.Windows.Forms.Label lblTotHrFer;
        private System.Windows.Forms.Label lblTotHrMad;
        private System.Windows.Forms.DataGridView tabDias;
        private System.Windows.Forms.Label lblDiasTrab;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label lblTotHrDia;
        private System.Windows.Forms.Label label10;
    }
}