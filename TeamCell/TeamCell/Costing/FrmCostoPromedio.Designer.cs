namespace TeamCell.Costing
{
    partial class FrmCostoPromedio
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
            this.grdcList = new DevExpress.XtraGrid.GridControl();
            this.grdList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNameBrand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdCostingAverage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.SuspendLayout();
            // 
            // grdcList
            // 
            this.grdcList.Location = new System.Drawing.Point(27, 53);
            this.grdcList.MainView = this.grdList;
            this.grdcList.Name = "grdcList";
            this.grdcList.Size = new System.Drawing.Size(792, 266);
            this.grdcList.TabIndex = 14;
            this.grdcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdList});
            // 
            // grdList
            // 
            this.grdList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.colNameBrand,
            this.gridColumn2,
            this.colIdCostingAverage});
            this.grdList.GridControl = this.grdcList;
            this.grdList.Name = "grdList";
            // 
            // colNameBrand
            // 
            this.colNameBrand.Caption = "Costo";
            this.colNameBrand.FieldName = "Cost";
            this.colNameBrand.Name = "colNameBrand";
            this.colNameBrand.OptionsColumn.AllowEdit = false;
            this.colNameBrand.OptionsColumn.AllowFocus = false;
            this.colNameBrand.OptionsColumn.FixedWidth = true;
            this.colNameBrand.Visible = true;
            this.colNameBrand.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Kardex";
            this.gridColumn2.FieldName = "IdKardex";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.FixedWidth = true;
            // 
            // colIdCostingAverage
            // 
            this.colIdCostingAverage.Caption = "IdCostingAverage";
            this.colIdCostingAverage.FieldName = "IdCostingAverage";
            this.colIdCostingAverage.Name = "colIdCostingAverage";
            this.colIdCostingAverage.OptionsColumn.AllowEdit = false;
            this.colIdCostingAverage.OptionsColumn.AllowFocus = false;
            this.colIdCostingAverage.OptionsColumn.FixedWidth = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Codigo";
            this.gridColumn1.FieldName = "Codigo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 232;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Producto";
            this.gridColumn3.FieldNameSortGroup = "NameProduct";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 208;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Costeo";
            this.gridColumn4.FieldName = "TypeCosting";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 208;
            // 
            // FrmCostoPromedio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(868, 522);
            this.Controls.Add(this.grdcList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCostoPromedio";
            this.Text = "FrmCostoPromedio";
            this.Load += new System.EventHandler(this.FrmCostoPromedio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl grdcList;
        private DevExpress.XtraGrid.Views.Grid.GridView grdList;
        private DevExpress.XtraGrid.Columns.GridColumn colNameBrand;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colIdCostingAverage;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}