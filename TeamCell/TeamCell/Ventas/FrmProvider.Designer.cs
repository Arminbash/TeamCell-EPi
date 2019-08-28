namespace TeamCell.Ventas
{
    partial class FrmProvider
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProvider));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboCountry = new System.Windows.Forms.ComboBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grdcList = new DevExpress.XtraGrid.GridControl();
            this.grdList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNameProvider = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Id_Country = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdProvider = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spIdProveedor = new DevExpress.XtraEditors.SpinEdit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spIdProveedor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboCountry);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtStatus);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(759, 158);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalles";
            // 
            // cboCountry
            // 
            this.cboCountry.FormattingEnabled = true;
            this.cboCountry.Location = new System.Drawing.Point(139, 52);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(153, 26);
            this.cboCountry.TabIndex = 22;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Image = global::TeamCell.Properties.Resources.Data_Edit;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(591, 59);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(156, 37);
            this.btnEdit.TabIndex = 21;
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(591, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(156, 37);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(15, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "Estado:";
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(139, 120);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(153, 23);
            this.txtStatus.TabIndex = 11;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(139, 17);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(153, 23);
            this.txtName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(15, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pais:";
            // 
            // grdcList
            // 
            gridLevelNode1.RelationName = "Level1";
            gridLevelNode2.RelationName = "Level2";
            this.grdcList.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2});
            this.grdcList.Location = new System.Drawing.Point(8, 176);
            this.grdcList.MainView = this.grdList;
            this.grdcList.Name = "grdcList";
            this.grdcList.Size = new System.Drawing.Size(860, 235);
            this.grdcList.TabIndex = 12;
            this.grdcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdList});
            this.grdcList.DoubleClick += new System.EventHandler(this.grdcList_DoubleClick);
            // 
            // grdList
            // 
            this.grdList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNameProvider,
            this.Status,
            this.Id_Country,
            this.colIdProvider});
            this.grdList.GridControl = this.grdcList;
            this.grdList.Name = "grdList";
            this.grdList.OptionsBehavior.Editable = false;
            this.grdList.OptionsBehavior.ReadOnly = true;
            this.grdList.OptionsFind.AlwaysVisible = true;
            this.grdList.OptionsView.ShowFooter = true;
            this.grdList.OptionsView.ShowGroupPanel = false;
            // 
            // colNameProvider
            // 
            this.colNameProvider.Caption = "Nombre";
            this.colNameProvider.FieldName = "NameProvider";
            this.colNameProvider.Name = "colNameProvider";
            this.colNameProvider.Visible = true;
            this.colNameProvider.VisibleIndex = 0;
            // 
            // Status
            // 
            this.Status.Caption = "Estado";
            this.Status.FieldName = "Status";
            this.Status.Name = "Status";
            // 
            // Id_Country
            // 
            this.Id_Country.Caption = "Nombre_Pais";
            this.Id_Country.FieldName = "Id_Country";
            this.Id_Country.Name = "Id_Country";
            // 
            // colIdProvider
            // 
            this.colIdProvider.Caption = "IdProvider";
            this.colIdProvider.FieldName = "IdProvider";
            this.colIdProvider.Name = "colIdProvider";
            // 
            // spIdProveedor
            // 
            this.spIdProveedor.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spIdProveedor.Location = new System.Drawing.Point(777, 150);
            this.spIdProveedor.Name = "spIdProveedor";
            this.spIdProveedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spIdProveedor.Size = new System.Drawing.Size(100, 20);
            this.spIdProveedor.TabIndex = 13;
            this.spIdProveedor.Visible = false;
            this.spIdProveedor.EditValueChanged += new System.EventHandler(this.spIdProveedor_EditValueChanged);
            // 
            // FrmProvider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 423);
            this.Controls.Add(this.spIdProveedor);
            this.Controls.Add(this.grdcList);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmProvider";
            this.Text = "FrmProvider";
            this.Load += new System.EventHandler(this.FrmProvider_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spIdProveedor.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.GridControl grdcList;
        private DevExpress.XtraGrid.Views.Grid.GridView grdList;
        private DevExpress.XtraGrid.Columns.GridColumn colNameProvider;
        private DevExpress.XtraGrid.Columns.GridColumn Status;
        private DevExpress.XtraGrid.Columns.GridColumn Id_Country;
        private DevExpress.XtraGrid.Columns.GridColumn colIdProvider;
        private System.Windows.Forms.ComboBox cboCountry;
        private DevExpress.XtraEditors.SpinEdit spIdProveedor;
    }
}