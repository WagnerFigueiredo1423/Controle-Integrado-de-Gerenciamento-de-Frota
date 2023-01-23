namespace app
{
    partial class formRelAbast
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
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.tabRelatorio = new System.Windows.Forms.DataGridView();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dropMes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dropPlaca = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dropTipo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tabRelatorio)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisualizar.Location = new System.Drawing.Point(386, 378);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(75, 23);
            this.btnVisualizar.TabIndex = 23;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // tabRelatorio
            // 
            this.tabRelatorio.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.tabRelatorio.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tabRelatorio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabRelatorio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabRelatorio.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tabRelatorio.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.tabRelatorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabRelatorio.Location = new System.Drawing.Point(12, 62);
            this.tabRelatorio.Name = "tabRelatorio";
            this.tabRelatorio.RowHeadersVisible = false;
            this.tabRelatorio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabRelatorio.Size = new System.Drawing.Size(449, 311);
            this.tabRelatorio.TabIndex = 22;
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(163, 26);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(65, 20);
            this.txtAno.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(160, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Ano";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Mês";
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
            this.dropMes.Location = new System.Drawing.Point(234, 26);
            this.dropMes.Name = "dropMes";
            this.dropMes.Size = new System.Drawing.Size(121, 21);
            this.dropMes.TabIndex = 18;
            this.dropMes.Text = "Selecione";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(361, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Placa";
            // 
            // dropPlaca
            // 
            this.dropPlaca.FormattingEnabled = true;
            this.dropPlaca.Items.AddRange(new object[] {
            "Comparativo",
            "Evolutivo",
            "Comparativo/Evolutivo"});
            this.dropPlaca.Location = new System.Drawing.Point(361, 26);
            this.dropPlaca.Name = "dropPlaca";
            this.dropPlaca.Size = new System.Drawing.Size(100, 21);
            this.dropPlaca.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tipo";
            // 
            // dropTipo
            // 
            this.dropTipo.FormattingEnabled = true;
            this.dropTipo.Items.AddRange(new object[] {
            "Comparativo",
            "Evolutivo",
            "Comparativo/Evolutivo"});
            this.dropTipo.Location = new System.Drawing.Point(12, 25);
            this.dropTipo.Name = "dropTipo";
            this.dropTipo.Size = new System.Drawing.Size(145, 21);
            this.dropTipo.TabIndex = 14;
            this.dropTipo.Text = "Selecione";
            this.dropTipo.SelectedIndexChanged += new System.EventHandler(this.dropTipo_SelectedIndexChanged);
            // 
            // formRelAbast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 408);
            this.Controls.Add(this.btnVisualizar);
            this.Controls.Add(this.tabRelatorio);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dropMes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dropPlaca);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dropTipo);
            this.Name = "formRelAbast";
            this.Text = "Relatórios de Abastecimento";
            this.Load += new System.EventHandler(this.formRelAbast_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabRelatorio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.DataGridView tabRelatorio;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox dropMes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox dropPlaca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox dropTipo;
    }
}