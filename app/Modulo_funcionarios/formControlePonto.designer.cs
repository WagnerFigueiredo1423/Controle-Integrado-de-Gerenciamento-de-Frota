namespace app
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.btnImpressao = new System.Windows.Forms.Button();
            this.tabFuncionarios = new System.Windows.Forms.DataGridView();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabFuncionarios)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPontos
            // 
            this.tabPontos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPontos.Location = new System.Drawing.Point(0, 0);
            this.tabPontos.Margin = new System.Windows.Forms.Padding(2);
            this.tabPontos.Name = "tabPontos";
            this.tabPontos.SelectedIndex = 0;
            this.tabPontos.Size = new System.Drawing.Size(776, 653);
            this.tabPontos.TabIndex = 1;
            // 
            // txtCompetencia
            // 
            this.txtCompetencia.CustomFormat = "MM/yyyy";
            this.txtCompetencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtCompetencia.Location = new System.Drawing.Point(86, 11);
            this.txtCompetencia.Name = "txtCompetencia";
            this.txtCompetencia.Size = new System.Drawing.Size(82, 20);
            this.txtCompetencia.TabIndex = 2;
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
            this.splitContainer1.Panel2.Controls.Add(this.tabPontos);
            this.splitContainer1.Size = new System.Drawing.Size(1107, 653);
            this.splitContainer1.SplitterDistance = 327;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.txtCompetencia);
            this.splitContainer2.Panel1.Controls.Add(this.btnVisualizar);
            this.splitContainer2.Panel1.Controls.Add(this.btnImpressao);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabFuncionarios);
            this.splitContainer2.Size = new System.Drawing.Size(327, 653);
            this.splitContainer2.SplitterDistance = 48;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Competência:";
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Location = new System.Drawing.Point(174, 11);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(69, 23);
            this.btnVisualizar.TabIndex = 4;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // btnImpressao
            // 
            this.btnImpressao.Location = new System.Drawing.Point(249, 12);
            this.btnImpressao.Name = "btnImpressao";
            this.btnImpressao.Size = new System.Drawing.Size(69, 23);
            this.btnImpressao.TabIndex = 4;
            this.btnImpressao.Text = "Imprimir";
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
            this.tabFuncionarios.Name = "tabFuncionarios";
            this.tabFuncionarios.RowHeadersVisible = false;
            this.tabFuncionarios.Size = new System.Drawing.Size(327, 602);
            this.tabFuncionarios.TabIndex = 3;
            // 
            // formControlePonto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 653);
            this.Controls.Add(this.splitContainer1);
            this.Name = "formControlePonto";
            this.Text = "Controle de Pontos";
            this.Load += new System.EventHandler(this.formControlePonto_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabFuncionarios)).EndInit();
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
        private System.Windows.Forms.Button btnVisualizar;
    }
}