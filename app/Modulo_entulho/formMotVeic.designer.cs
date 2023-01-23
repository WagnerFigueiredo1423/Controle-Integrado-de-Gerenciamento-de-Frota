namespace app
{
    partial class formMotVeic
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dropFuncionario = new System.Windows.Forms.ComboBox();
            this.dropVeiculo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Funcionário";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Veículo";
            // 
            // dropFuncionario
            // 
            this.dropFuncionario.FormattingEnabled = true;
            this.dropFuncionario.Location = new System.Drawing.Point(100, 6);
            this.dropFuncionario.Name = "dropFuncionario";
            this.dropFuncionario.Size = new System.Drawing.Size(136, 24);
            this.dropFuncionario.TabIndex = 2;
            // 
            // dropVeiculo
            // 
            this.dropVeiculo.FormattingEnabled = true;
            this.dropVeiculo.Location = new System.Drawing.Point(100, 39);
            this.dropVeiculo.Name = "dropVeiculo";
            this.dropVeiculo.Size = new System.Drawing.Size(136, 24);
            this.dropVeiculo.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(257, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 35);
            this.button1.TabIndex = 4;
            this.button1.Text = "Selecionar e fechar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // formMotVeic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 88);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dropVeiculo);
            this.Controls.Add(this.dropFuncionario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "formMotVeic";
            this.Text = "Selecione o Funcionário e o Veículo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formMotVeic_FormClosing);
            this.Load += new System.EventHandler(this.formMotVeic_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox dropFuncionario;
        private System.Windows.Forms.ComboBox dropVeiculo;
        private System.Windows.Forms.Button button1;
    }
}