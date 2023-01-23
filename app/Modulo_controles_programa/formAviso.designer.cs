namespace app
{
    partial class formAviso
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPecas = new System.Windows.Forms.DataGridView();
            this.tabBoletos = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tabPecas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabBoletos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(16, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(426, 39);
            this.label1.TabIndex = 8;
            this.label1.Text = "Itens em falta no Estoque";
            // 
            // tabPecas
            // 
            this.tabPecas.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabPecas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tabPecas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabPecas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tabPecas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabPecas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tabPecas.Location = new System.Drawing.Point(24, 82);
            this.tabPecas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPecas.Name = "tabPecas";
            this.tabPecas.RowHeadersVisible = false;
            this.tabPecas.Size = new System.Drawing.Size(741, 609);
            this.tabPecas.TabIndex = 9;
            // 
            // tabBoletos
            // 
            this.tabBoletos.AllowUserToAddRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabBoletos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.tabBoletos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabBoletos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tabBoletos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabBoletos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tabBoletos.Location = new System.Drawing.Point(779, 82);
            this.tabBoletos.Margin = new System.Windows.Forms.Padding(4);
            this.tabBoletos.Name = "tabBoletos";
            this.tabBoletos.RowHeadersVisible = false;
            this.tabBoletos.Size = new System.Drawing.Size(741, 609);
            this.tabBoletos.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(774, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(428, 39);
            this.label2.TabIndex = 10;
            this.label2.Text = "Boletos que vencem Hoje";
            // 
            // formAviso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1535, 706);
            this.Controls.Add(this.tabBoletos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabPecas);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "formAviso";
            this.Text = "formAviso";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formAviso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabPecas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabBoletos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tabPecas;
        private System.Windows.Forms.DataGridView tabBoletos;
        private System.Windows.Forms.Label label2;
    }
}