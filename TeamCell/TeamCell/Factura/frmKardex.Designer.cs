namespace TeamCell.Factura
{
    partial class frmKardex
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grdcTotal = new DevExpress.XtraGrid.GridControl();
            this.grdTotal = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxBodega = new System.Windows.Forms.ComboBox();
            this.grdcBodega = new DevExpress.XtraGrid.GridControl();
            this.grdBodega = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdcTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTotal)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdcBodega)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBodega)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(861, 469);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grdcTotal);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(853, 443);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Kardex Totalizado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grdcTotal
            // 
            this.grdcTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdcTotal.Location = new System.Drawing.Point(3, 3);
            this.grdcTotal.MainView = this.grdTotal;
            this.grdcTotal.Name = "grdcTotal";
            this.grdcTotal.Size = new System.Drawing.Size(847, 437);
            this.grdcTotal.TabIndex = 3;
            this.grdcTotal.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdTotal});
            // 
            // grdTotal
            // 
            this.grdTotal.GridControl = this.grdcTotal;
            this.grdTotal.Name = "grdTotal";
            this.grdTotal.OptionsBehavior.Editable = false;
            this.grdTotal.OptionsFind.AlwaysVisible = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.grdcBodega);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(853, 443);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Kardex por Bodega";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxBodega);
            this.groupBox1.Location = new System.Drawing.Point(278, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 58);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bodega";
            // 
            // cbxBodega
            // 
            this.cbxBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBodega.FormattingEnabled = true;
            this.cbxBodega.Location = new System.Drawing.Point(23, 19);
            this.cbxBodega.Name = "cbxBodega";
            this.cbxBodega.Size = new System.Drawing.Size(155, 21);
            this.cbxBodega.TabIndex = 0;
            this.cbxBodega.SelectedIndexChanged += new System.EventHandler(this.cbxBodega_SelectedIndexChanged);
            // 
            // grdcBodega
            // 
            this.grdcBodega.Location = new System.Drawing.Point(6, 67);
            this.grdcBodega.MainView = this.grdBodega;
            this.grdcBodega.Name = "grdcBodega";
            this.grdcBodega.Size = new System.Drawing.Size(841, 370);
            this.grdcBodega.TabIndex = 1;
            this.grdcBodega.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdBodega});
            // 
            // grdBodega
            // 
            this.grdBodega.GridControl = this.grdcBodega;
            this.grdBodega.Name = "grdBodega";
            this.grdBodega.OptionsBehavior.Editable = false;
            this.grdBodega.OptionsFind.AlwaysVisible = true;
            // 
            // frmKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(885, 493);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmKardex";
            this.Text = "Kardex";
            this.Load += new System.EventHandler(this.frmKardex_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdcTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTotal)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdcBodega)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBodega)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private DevExpress.XtraGrid.GridControl grdcTotal;
        private DevExpress.XtraGrid.Views.Grid.GridView grdTotal;
        private System.Windows.Forms.TabPage tabPage2;
        private DevExpress.XtraGrid.GridControl grdcBodega;
        private DevExpress.XtraGrid.Views.Grid.GridView grdBodega;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxBodega;

    }
}