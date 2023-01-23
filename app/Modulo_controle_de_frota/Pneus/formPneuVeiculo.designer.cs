namespace app
{
    partial class formPneuVeiculo
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
            this.label1 = new System.Windows.Forms.Label();
            this.dropVeiculo = new System.Windows.Forms.ComboBox();
            this.tabPneus = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAdicionarPneu = new System.Windows.Forms.Button();
            this.btnRemoverPneu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tabPneus)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Veículo";
            // 
            // dropVeiculo
            // 
            this.dropVeiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropVeiculo.FormattingEnabled = true;
            this.dropVeiculo.Location = new System.Drawing.Point(15, 28);
            this.dropVeiculo.Name = "dropVeiculo";
            this.dropVeiculo.Size = new System.Drawing.Size(121, 24);
            this.dropVeiculo.TabIndex = 1;
            this.dropVeiculo.SelectedIndexChanged += new System.EventHandler(this.dropVeiculo_SelectedIndexChanged);
            // 
            // tabPneus
            // 
            this.tabPneus.AllowUserToAddRows = false;
            this.tabPneus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPneus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tabPneus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tabPneus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabPneus.Location = new System.Drawing.Point(15, 91);
            this.tabPneus.Name = "tabPneus";
            this.tabPneus.RowHeadersVisible = false;
            this.tabPneus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabPneus.Size = new System.Drawing.Size(802, 150);
            this.tabPneus.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Pneus";
            // 
            // btnAdicionarPneu
            // 
            this.btnAdicionarPneu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarPneu.Location = new System.Drawing.Point(15, 247);
            this.btnAdicionarPneu.Name = "btnAdicionarPneu";
            this.btnAdicionarPneu.Size = new System.Drawing.Size(201, 38);
            this.btnAdicionarPneu.TabIndex = 8;
            this.btnAdicionarPneu.Text = "Adicionar Pneu";
            this.btnAdicionarPneu.UseVisualStyleBackColor = true;
            this.btnAdicionarPneu.Click += new System.EventHandler(this.btnAdicionarPneu_Click);
            // 
            // btnRemoverPneu
            // 
            this.btnRemoverPneu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoverPneu.Location = new System.Drawing.Point(314, 247);
            this.btnRemoverPneu.Name = "btnRemoverPneu";
            this.btnRemoverPneu.Size = new System.Drawing.Size(201, 38);
            this.btnRemoverPneu.TabIndex = 9;
            this.btnRemoverPneu.Text = "Remover Pneu";
            this.btnRemoverPneu.UseVisualStyleBackColor = true;
            this.btnRemoverPneu.Click += new System.EventHandler(this.btnRemoverPneu_Click);
            // 
            // formPneuVeiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 406);
            this.Controls.Add(this.btnRemoverPneu);
            this.Controls.Add(this.btnAdicionarPneu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tabPneus);
            this.Controls.Add(this.dropVeiculo);
            this.Controls.Add(this.label1);
            this.Name = "formPneuVeiculo";
            this.Text = "formPneuVeiculo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formPneuVeiculo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabPneus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox dropVeiculo;
        private System.Windows.Forms.DataGridView tabPneus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAdicionarPneu;
        private System.Windows.Forms.Button btnRemoverPneu;
    }
}