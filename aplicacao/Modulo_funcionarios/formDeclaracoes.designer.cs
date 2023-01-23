namespace aplicacao
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtQntVlTransp = new System.Windows.Forms.TextBox();
            this.txtVlrVlTransp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotVlTransp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVlrVlRef = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotVlRef = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQntVlRef = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkVlTransp = new System.Windows.Forms.CheckBox();
            this.checkVlRef = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtReferencia = new System.Windows.Forms.DateTimePicker();
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
            this.tabDeclaracao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabDeclaracao.Size = new System.Drawing.Size(834, 310);
            this.tabDeclaracao.TabIndex = 0;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.Location = new System.Drawing.Point(699, 435);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(147, 28);
            this.btnImprimir.TabIndex = 10;
            this.btnImprimir.Text = "Visualizar Impressão";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 387);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 85;
            this.label2.Text = "Qnt Vale Transp.";
            // 
            // txtQntVlTransp
            // 
            this.txtQntVlTransp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtQntVlTransp.Location = new System.Drawing.Point(164, 384);
            this.txtQntVlTransp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtQntVlTransp.Name = "txtQntVlTransp";
            this.txtQntVlTransp.Size = new System.Drawing.Size(59, 26);
            this.txtQntVlTransp.TabIndex = 4;
            this.txtQntVlTransp.TextChanged += new System.EventHandler(this.txtQntVlTransp_TextChanged);
            this.txtQntVlTransp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQntVlTransp_KeyPress);
            // 
            // txtVlrVlTransp
            // 
            this.txtVlrVlTransp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtVlrVlTransp.Location = new System.Drawing.Point(164, 411);
            this.txtVlrVlTransp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVlrVlTransp.Name = "txtVlrVlTransp";
            this.txtVlrVlTransp.Size = new System.Drawing.Size(59, 26);
            this.txtVlrVlTransp.TabIndex = 5;
            this.txtVlrVlTransp.TextChanged += new System.EventHandler(this.txtVlrVlTransp_TextChanged);
            this.txtVlrVlTransp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVlrVlTransp_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 414);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 20);
            this.label4.TabIndex = 87;
            this.label4.Text = "Valor Vale Transp.";
            // 
            // txtTotVlTransp
            // 
            this.txtTotVlTransp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotVlTransp.Enabled = false;
            this.txtTotVlTransp.Location = new System.Drawing.Point(164, 438);
            this.txtTotVlTransp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotVlTransp.Name = "txtTotVlTransp";
            this.txtTotVlTransp.Size = new System.Drawing.Size(59, 26);
            this.txtTotVlTransp.TabIndex = 90;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 441);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 20);
            this.label5.TabIndex = 89;
            this.label5.Text = "Total Vale Transp.";
            // 
            // txtVlrVlRef
            // 
            this.txtVlrVlRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtVlrVlRef.Location = new System.Drawing.Point(380, 411);
            this.txtVlrVlRef.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVlrVlRef.Name = "txtVlrVlRef";
            this.txtVlrVlRef.Size = new System.Drawing.Size(59, 26);
            this.txtVlrVlRef.TabIndex = 7;
            this.txtVlrVlRef.TextChanged += new System.EventHandler(this.txtVlrVlRef_TextChanged);
            this.txtVlrVlRef.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVlrVlRef_KeyPress);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(259, 441);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 20);
            this.label6.TabIndex = 95;
            this.label6.Text = "Total Vale Ref.";
            // 
            // txtTotVlRef
            // 
            this.txtTotVlRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotVlRef.Enabled = false;
            this.txtTotVlRef.Location = new System.Drawing.Point(380, 438);
            this.txtTotVlRef.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotVlRef.Name = "txtTotVlRef";
            this.txtTotVlRef.Size = new System.Drawing.Size(59, 26);
            this.txtTotVlRef.TabIndex = 94;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(258, 414);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 20);
            this.label7.TabIndex = 93;
            this.label7.Text = "Valor Vale Ref.";
            // 
            // txtQntVlRef
            // 
            this.txtQntVlRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtQntVlRef.Location = new System.Drawing.Point(380, 384);
            this.txtQntVlRef.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtQntVlRef.Name = "txtQntVlRef";
            this.txtQntVlRef.Size = new System.Drawing.Size(59, 26);
            this.txtQntVlRef.TabIndex = 6;
            this.txtQntVlRef.TextChanged += new System.EventHandler(this.txtQntVlRef_TextChanged);
            this.txtQntVlRef.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQntVlRef_KeyPress);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(270, 387);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 20);
            this.label8.TabIndex = 91;
            this.label8.Text = "Qnt Vale Ref.";
            // 
            // checkVlTransp
            // 
            this.checkVlTransp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkVlTransp.AutoSize = true;
            this.checkVlTransp.Location = new System.Drawing.Point(461, 382);
            this.checkVlTransp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkVlTransp.Name = "checkVlTransp";
            this.checkVlTransp.Size = new System.Drawing.Size(150, 24);
            this.checkVlTransp.TabIndex = 8;
            this.checkVlTransp.Text = "Vale Transporte";
            this.checkVlTransp.UseVisualStyleBackColor = true;
            this.checkVlTransp.CheckedChanged += new System.EventHandler(this.checkVlTransp_CheckedChanged);
            // 
            // checkVlRef
            // 
            this.checkVlRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkVlRef.AutoSize = true;
            this.checkVlRef.Location = new System.Drawing.Point(461, 410);
            this.checkVlRef.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkVlRef.Name = "checkVlRef";
            this.checkVlRef.Size = new System.Drawing.Size(135, 24);
            this.checkVlRef.TabIndex = 9;
            this.checkVlRef.Text = "Vale Refeição";
            this.checkVlRef.UseVisualStyleBackColor = true;
            this.checkVlRef.CheckedChanged += new System.EventHandler(this.checkVlRef_CheckedChanged);
            // 
            // txtReferencia
            // 
            this.txtReferencia.CustomFormat = "dd/MM/yyyy";
            this.txtReferencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtReferencia.Location = new System.Drawing.Point(12, 27);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(130, 26);
            this.txtReferencia.TabIndex = 96;
            // 
            // formDeclaracoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 473);
            this.Controls.Add(this.txtReferencia);
            this.Controls.Add(this.checkVlRef);
            this.Controls.Add(this.checkVlTransp);
            this.Controls.Add(this.txtVlrVlRef);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTotVlRef);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtQntVlRef);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTotVlTransp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtVlrVlTransp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtQntVlTransp);
            this.Controls.Add(this.label2);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQntVlTransp;
        private System.Windows.Forms.TextBox txtVlrVlTransp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotVlTransp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtVlrVlRef;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotVlRef;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtQntVlRef;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkVlTransp;
        private System.Windows.Forms.CheckBox checkVlRef;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DateTimePicker txtReferencia;
    }
}