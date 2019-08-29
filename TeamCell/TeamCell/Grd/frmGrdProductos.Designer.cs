namespace TeamCell
{
    partial class frmGrdProductos
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
            this.grdcDetalles = new DevExpress.XtraGrid.GridControl();
            this.grdDetalles = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdProducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdcDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // grdcDetalles
            // 
            this.grdcDetalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdcDetalles.Location = new System.Drawing.Point(0, 0);
            this.grdcDetalles.MainView = this.grdDetalles;
            this.grdcDetalles.Name = "grdcDetalles";
            this.grdcDetalles.Size = new System.Drawing.Size(565, 379);
            this.grdcDetalles.TabIndex = 0;
            this.grdcDetalles.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdDetalles});
            // 
            // grdDetalles
            // 
            this.grdDetalles.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdProducto,
            this.colCodigo,
            this.colName});
            this.grdDetalles.GridControl = this.grdcDetalles;
            this.grdDetalles.Name = "grdDetalles";
            this.grdDetalles.OptionsBehavior.Editable = false;
            this.grdDetalles.OptionsBehavior.ReadOnly = true;
            this.grdDetalles.OptionsFind.AlwaysVisible = true;
            this.grdDetalles.OptionsView.ShowFooter = true;
            this.grdDetalles.DoubleClick += new System.EventHandler(this.grdDetalles_DoubleClick);
            // 
            // colIdProducto
            // 
            this.colIdProducto.Caption = "IdProducto";
            this.colIdProducto.FieldName = "IdProducto";
            this.colIdProducto.Name = "colIdProducto";
            // 
            // colCodigo
            // 
            this.colCodigo.Caption = "Codigo";
            this.colCodigo.FieldName = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Codigo", "{0}")});
            this.colCodigo.Visible = true;
            this.colCodigo.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.Caption = "Nombre";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // frmGrdProductos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(565, 379);
            this.Controls.Add(this.grdcDetalles);
            this.Name = "frmGrdProductos";
            this.Text = "Lista Productos";
            this.Load += new System.EventHandler(this.frmGrdProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdcDetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetalles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdcDetalles;
        private DevExpress.XtraGrid.Views.Grid.GridView grdDetalles;
        private DevExpress.XtraGrid.Columns.GridColumn colIdProducto;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
    }
}