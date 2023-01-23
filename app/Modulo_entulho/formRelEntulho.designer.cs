namespace app
{
    partial class formRelEntulho
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
            this.btnConteiners = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConteiners
            // 
            this.btnConteiners.Location = new System.Drawing.Point(12, 37);
            this.btnConteiners.Name = "btnConteiners";
            this.btnConteiners.Size = new System.Drawing.Size(496, 43);
            this.btnConteiners.TabIndex = 0;
            this.btnConteiners.Text = "Relatório de Conteiners";
            this.btnConteiners.UseVisualStyleBackColor = true;
            this.btnConteiners.Click += new System.EventHandler(this.btnConteiners_Click);
            // 
            // formRelEntulho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 303);
            this.Controls.Add(this.btnConteiners);
            this.Name = "formRelEntulho";
            this.Text = "Relatórios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formRelEntulho_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConteiners;
    }
}