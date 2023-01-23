namespace aplicacao
{
    partial class formRelConteiners
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabConteiners = new System.Windows.Forms.DataGridView();
            this.lblContLoc = new System.Windows.Forms.Label();
            this.lblContDisp = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.lblTempoRefresh = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tabConteiners)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Conteiners Locados:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Conteiners Disponíveis:";
            // 
            // tabConteiners
            // 
            this.tabConteiners.AllowUserToAddRows = false;
            this.tabConteiners.AllowUserToDeleteRows = false;
            this.tabConteiners.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.tabConteiners.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.tabConteiners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabConteiners.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabConteiners.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tabConteiners.Location = new System.Drawing.Point(0, 0);
            this.tabConteiners.Margin = new System.Windows.Forms.Padding(2);
            this.tabConteiners.Name = "tabConteiners";
            this.tabConteiners.RowHeadersVisible = false;
            this.tabConteiners.RowTemplate.Height = 24;
            this.tabConteiners.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabConteiners.Size = new System.Drawing.Size(395, 499);
            this.tabConteiners.TabIndex = 0;
            this.tabConteiners.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.tabConteiners_CellFormatting);
            this.tabConteiners.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabConteiners_MouseClick);
            // 
            // lblContLoc
            // 
            this.lblContLoc.AutoSize = true;
            this.lblContLoc.Location = new System.Drawing.Point(132, 11);
            this.lblContLoc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContLoc.Name = "lblContLoc";
            this.lblContLoc.Size = new System.Drawing.Size(28, 13);
            this.lblContLoc.TabIndex = 3;
            this.lblContLoc.Text = "XXX";
            // 
            // lblContDisp
            // 
            this.lblContDisp.AutoSize = true;
            this.lblContDisp.Location = new System.Drawing.Point(132, 37);
            this.lblContDisp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContDisp.Name = "lblContDisp";
            this.lblContDisp.Size = new System.Drawing.Size(28, 13);
            this.lblContDisp.TabIndex = 4;
            this.lblContDisp.Text = "XXX";
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
            this.splitContainer1.Panel2.Controls.Add(this.gmap);
            this.splitContainer1.Size = new System.Drawing.Size(1185, 567);
            this.splitContainer1.SplitterDistance = 395;
            this.splitContainer1.TabIndex = 5;
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
            this.splitContainer2.Panel1.Controls.Add(this.tabConteiners);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.lblTempoRefresh);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Panel2.Controls.Add(this.lblContDisp);
            this.splitContainer2.Panel2.Controls.Add(this.lblContLoc);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Size = new System.Drawing.Size(395, 567);
            this.splitContainer2.SplitterDistance = 499;
            this.splitContainer2.TabIndex = 5;
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(0, 0);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 18;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(786, 567);
            this.gmap.TabIndex = 2;
            this.gmap.Zoom = 13D;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nova Atualização: ";
            // 
            // lblTempoRefresh
            // 
            this.lblTempoRefresh.AutoSize = true;
            this.lblTempoRefresh.Location = new System.Drawing.Point(336, 11);
            this.lblTempoRefresh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTempoRefresh.Name = "lblTempoRefresh";
            this.lblTempoRefresh.Size = new System.Drawing.Size(28, 13);
            this.lblTempoRefresh.TabIndex = 6;
            this.lblTempoRefresh.Text = "XXX";
            // 
            // formRelConteiners
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 567);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "formRelConteiners";
            this.Text = "Relatórios de Conteiners";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formRelConteiners_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabConteiners)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView tabConteiners;
        private System.Windows.Forms.Label lblContLoc;
        private System.Windows.Forms.Label lblContDisp;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTempoRefresh;
    }
}