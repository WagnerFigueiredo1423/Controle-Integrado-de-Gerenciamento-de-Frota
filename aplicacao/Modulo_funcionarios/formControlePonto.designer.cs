namespace aplicacao
{
    partial class formControlePonto
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
            this.tabPontos = new System.Windows.Forms.TabControl();
            this.txtCompetencia = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImpressao = new System.Windows.Forms.Button();
            this.tabFuncionarios = new System.Windows.Forms.DataGridView();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabFuncionarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPontos
            // 
            this.tabPontos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPontos.Location = new System.Drawing.Point(0, 0);
            this.tabPontos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPontos.Name = "tabPontos";
            this.tabPontos.SelectedIndex = 0;
            this.tabPontos.Size = new System.Drawing.Size(1142, 578);
            this.tabPontos.TabIndex = 1;
            // 
            // txtCompetencia
            // 
            this.txtCompetencia.CustomFormat = "MM/yyyy";
            this.txtCompetencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtCompetencia.Location = new System.Drawing.Point(115, 13);
            this.txtCompetencia.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompetencia.Name = "txtCompetencia";
            this.txtCompetencia.Size = new System.Drawing.Size(108, 22);
            this.txtCompetencia.TabIndex = 2;
            this.txtCompetencia.ValueChanged += new System.EventHandler(this.txtCompetencia_ValueChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabPontos);
            this.splitContainer1.Size = new System.Drawing.Size(1476, 578);
            this.splitContainer1.SplitterDistance = 329;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Competência:";
            // 
            // btnImpressao
            // 
            this.btnImpressao.Location = new System.Drawing.Point(231, 12);
            this.btnImpressao.Margin = new System.Windows.Forms.Padding(4);
            this.btnImpressao.Name = "btnImpressao";
            this.btnImpressao.Size = new System.Drawing.Size(92, 28);
            this.btnImpressao.TabIndex = 4;
            this.btnImpressao.Text = "Visualizar";
            this.btnImpressao.UseVisualStyleBackColor = true;
            this.btnImpressao.Click += new System.EventHandler(this.btnImpressao_Click);
            // 
            // tabFuncionarios
            // 
            this.tabFuncionarios.AllowUserToAddRows = false;
            this.tabFuncionarios.AllowUserToDeleteRows = false;
            this.tabFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabFuncionarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFuncionarios.Location = new System.Drawing.Point(0, 0);
            this.tabFuncionarios.Margin = new System.Windows.Forms.Padding(4);
            this.tabFuncionarios.Name = "tabFuncionarios";
            this.tabFuncionarios.RowHeadersVisible = false;
            this.tabFuncionarios.Size = new System.Drawing.Size(329, 531);
            this.tabFuncionarios.TabIndex = 3;
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
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.txtCompetencia);
            this.splitContainer2.Panel1.Controls.Add(this.btnImpressao);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabFuncionarios);
            this.splitContainer2.Size = new System.Drawing.Size(329, 578);
            this.splitContainer2.SplitterDistance = 43;
            this.splitContainer2.TabIndex = 6;
            // 
            // formControlePonto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1476, 578);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formControlePonto";
            this.Text = "Controle de Pontos";
            this.Load += new System.EventHandler(this.formControlePonto_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabFuncionarios)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPontos;
        private System.Windows.Forms.DateTimePicker txtCompetencia;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnImpressao;
        private System.Windows.Forms.DataGridView tabFuncionarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}