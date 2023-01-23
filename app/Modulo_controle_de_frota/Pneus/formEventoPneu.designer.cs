namespace app
{
    partial class formEventoPneu
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
            this.txtDataEvento = new System.Windows.Forms.DateTimePicker();
            this.rdbDescartado = new System.Windows.Forms.RadioButton();
            this.rdbRecapagem = new System.Windows.Forms.RadioButton();
            this.rdbAtivo = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEvento = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataCompra = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBitola = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data do Evento";
            // 
            // txtDataEvento
            // 
            this.txtDataEvento.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataEvento.CustomFormat = "dd/MM/yyyy";
            this.txtDataEvento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDataEvento.Location = new System.Drawing.Point(15, 74);
            this.txtDataEvento.Name = "txtDataEvento";
            this.txtDataEvento.Size = new System.Drawing.Size(103, 20);
            this.txtDataEvento.TabIndex = 1;
            // 
            // rdbDescartado
            // 
            this.rdbDescartado.AutoSize = true;
            this.rdbDescartado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDescartado.Location = new System.Drawing.Point(307, 76);
            this.rdbDescartado.Name = "rdbDescartado";
            this.rdbDescartado.Size = new System.Drawing.Size(97, 20);
            this.rdbDescartado.TabIndex = 102;
            this.rdbDescartado.TabStop = true;
            this.rdbDescartado.Text = "Descartado";
            this.rdbDescartado.UseVisualStyleBackColor = true;
            // 
            // rdbRecapagem
            // 
            this.rdbRecapagem.AutoSize = true;
            this.rdbRecapagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbRecapagem.Location = new System.Drawing.Point(199, 76);
            this.rdbRecapagem.Name = "rdbRecapagem";
            this.rdbRecapagem.Size = new System.Drawing.Size(102, 20);
            this.rdbRecapagem.TabIndex = 101;
            this.rdbRecapagem.TabStop = true;
            this.rdbRecapagem.Text = "Recapagem";
            this.rdbRecapagem.UseVisualStyleBackColor = true;
            // 
            // rdbAtivo
            // 
            this.rdbAtivo.AutoSize = true;
            this.rdbAtivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbAtivo.Location = new System.Drawing.Point(137, 74);
            this.rdbAtivo.Name = "rdbAtivo";
            this.rdbAtivo.Size = new System.Drawing.Size(56, 20);
            this.rdbAtivo.TabIndex = 100;
            this.rdbAtivo.TabStop = true;
            this.rdbAtivo.Text = "Ativo";
            this.rdbAtivo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 16);
            this.label2.TabIndex = 103;
            this.label2.Text = "Descrição do Evento";
            // 
            // txtEvento
            // 
            this.txtEvento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEvento.Location = new System.Drawing.Point(12, 125);
            this.txtEvento.Multiline = true;
            this.txtEvento.Name = "txtEvento";
            this.txtEvento.Size = new System.Drawing.Size(383, 74);
            this.txtEvento.TabIndex = 104;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(12, 205);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 27);
            this.btnOk.TabIndex = 105;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(83, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 109;
            this.label3.Text = "Número";
            // 
            // txtNumero
            // 
            this.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(86, 28);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(97, 23);
            this.txtNumero.TabIndex = 107;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 108;
            this.label4.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(15, 29);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(55, 23);
            this.txtCodigo.TabIndex = 106;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(283, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 17);
            this.label5.TabIndex = 113;
            this.label5.Text = "Data da Compra";
            // 
            // txtDataCompra
            // 
            this.txtDataCompra.CustomFormat = "dd/MM/yyyy";
            this.txtDataCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataCompra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDataCompra.Location = new System.Drawing.Point(286, 31);
            this.txtDataCompra.Name = "txtDataCompra";
            this.txtDataCompra.Size = new System.Drawing.Size(108, 22);
            this.txtDataCompra.TabIndex = 112;
            this.txtDataCompra.Value = new System.DateTime(2014, 10, 8, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(196, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 17);
            this.label7.TabIndex = 111;
            this.label7.Text = "Bitola";
            // 
            // txtBitola
            // 
            this.txtBitola.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBitola.Location = new System.Drawing.Point(199, 30);
            this.txtBitola.Name = "txtBitola";
            this.txtBitola.Size = new System.Drawing.Size(71, 23);
            this.txtBitola.TabIndex = 110;
            // 
            // formEventoPneu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 242);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDataCompra);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBitola);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtEvento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdbDescartado);
            this.Controls.Add(this.rdbRecapagem);
            this.Controls.Add(this.rdbAtivo);
            this.Controls.Add(this.txtDataEvento);
            this.Controls.Add(this.label1);
            this.Name = "formEventoPneu";
            this.Text = "Evento do Pneu";
            this.Load += new System.EventHandler(this.formMotivoRetPneu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtDataEvento;
        private System.Windows.Forms.RadioButton rdbDescartado;
        private System.Windows.Forms.RadioButton rdbRecapagem;
        private System.Windows.Forms.RadioButton rdbAtivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEvento;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker txtDataCompra;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBitola;
    }
}