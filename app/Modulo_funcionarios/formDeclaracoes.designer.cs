namespace app
{
    partial class formDeclaracoes
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
            this.tabDeclaracao = new System.Windows.Forms.DataGridView();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtReferencia = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVlrVlTransp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtVlrVlRef = new System.Windows.Forms.TextBox();
            this.btnAlterarValores = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tabDeclaracao)).BeginInit();
            this.SuspendLayout();
            // 
            // tabDeclaracao
            // 
            this.tabDeclaracao.AllowUserToAddRows = false;
            this.tabDeclaracao.AllowUserToDeleteRows = false;
            this.tabDeclaracao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabDeclaracao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabDeclaracao.Location = new System.Drawing.Point(12, 58);
            this.tabDeclaracao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabDeclaracao.Name = "tabDeclaracao";
            this.tabDeclaracao.RowHeadersVisible = false;
            this.tabDeclaracao.RowTemplate.Height = 24;
            this.tabDeclaracao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.tabDeclaracao.Size = new System.Drawing.Size(834, 324);
            this.tabDeclaracao.TabIndex = 0;
            this.tabDeclaracao.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabDeclaracao_CellValueChanged);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.Location = new System.Drawing.Point(699, 504);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(147, 28);
            this.btnImprimir.TabIndex = 10;
            this.btnImprimir.Text = "Visualizar Impressão";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // txtReferencia
            // 
            this.txtReferencia.CustomFormat = "dd/MM/yyyy";
            this.txtReferencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtReferencia.Location = new System.Drawing.Point(12, 27);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(130, 22);
            this.txtReferencia.TabIndex = 96;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 396);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(331, 37);
            this.label4.TabIndex = 87;
            this.label4.Text = "Valor Vale Transporte";
            // 
            // txtVlrVlTransp
            // 
            this.txtVlrVlTransp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtVlrVlTransp.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVlrVlTransp.Location = new System.Drawing.Point(411, 393);
            this.txtVlrVlTransp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVlrVlTransp.Name = "txtVlrVlTransp";
            this.txtVlrVlTransp.Size = new System.Drawing.Size(100, 44);
            this.txtVlrVlTransp.TabIndex = 5;
            this.txtVlrVlTransp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 450);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(299, 37);
            this.label7.TabIndex = 93;
            this.label7.Text = "Valor Vale Refeição";
            // 
            // txtVlrVlRef
            // 
            this.txtVlrVlRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtVlrVlRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVlrVlRef.Location = new System.Drawing.Point(411, 447);
            this.txtVlrVlRef.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVlrVlRef.Name = "txtVlrVlRef";
            this.txtVlrVlRef.Size = new System.Drawing.Size(100, 44);
            this.txtVlrVlRef.TabIndex = 7;
            this.txtVlrVlRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnAlterarValores
            // 
            this.btnAlterarValores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAlterarValores.Location = new System.Drawing.Point(355, 503);
            this.btnAlterarValores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAlterarValores.Name = "btnAlterarValores";
            this.btnAlterarValores.Size = new System.Drawing.Size(137, 28);
            this.btnAlterarValores.TabIndex = 10;
            this.btnAlterarValores.Text = "Alterar Valores";
            this.btnAlterarValores.UseVisualStyleBackColor = true;
            this.btnAlterarValores.Click += new System.EventHandler(this.btnAlterarValores_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(361, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 37);
            this.label1.TabIndex = 87;
            this.label1.Text = "R$";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(361, 450);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 37);
            this.label2.TabIndex = 87;
            this.label2.Text = "R$";
            // 
            // formDeclaracoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 542);
            this.Controls.Add(this.txtReferencia);
            this.Controls.Add(this.txtVlrVlRef);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtVlrVlTransp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAlterarValores);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.tabDeclaracao);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "formDeclaracoes";
            this.Text = "Declarações de Vale Transporte/Vale Refeição";
            this.Load += new System.EventHandler(this.formDeclaracoes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabDeclaracao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tabDeclaracao;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DateTimePicker txtReferencia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVlrVlTransp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtVlrVlRef;
        private System.Windows.Forms.Button btnAlterarValores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}