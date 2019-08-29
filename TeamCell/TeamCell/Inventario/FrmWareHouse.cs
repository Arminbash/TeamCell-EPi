using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller.Controllers;
using Model.Models;
using TeamCell.Notificacion;

namespace TeamCell.Inventario
{
    public partial class FrmWareHouse : Form
    {
        public FrmWareHouse()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmWareHouse_Load(object sender, EventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            WarehouseController oWarehouse = new WarehouseController();
            grdcList.DataSource = oWarehouse.getWarehouse();
        }
        private void RellenarAlmacen(ref Warehouse oWarehouse)
        {
            oWarehouse.IdWarehouse = (int)spIdAlmacen.Value;
            oWarehouse.Name = txtName.Text;
            oWarehouse.Status = true;
        }
        private void Limpiar()
        {
            WarehouseController wareCont = new WarehouseController();
            grdcList.DataSource = wareCont.getWarehouse();
            txtName.Text = "";


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (spIdAlmacen.Value == 0)
            {
                Warehouse oWarehouse = new Warehouse();
                RellenarAlmacen(ref oWarehouse);
                WarehouseController wareCont = new WarehouseController();
                if (wareCont.AddOrUpdateWarehouse(oWarehouse))
                {
                    FrmSuccess.ConfirmacionFrom("Guardado");
                    //MessageBox.Show("Se guardo correctamente.");
                    Limpiar();
                }
                else
                    MessageBox.Show("ocurrio un error al guardar.");
            }
        }

        private void spIdAlmacen_EditValueChanged(object sender, EventArgs e)
        {
            if (spIdAlmacen.Value > 0)
            {
                Warehouse oWarehouse = new Warehouse();
                WarehouseController wareCont = new WarehouseController();
                oWarehouse = wareCont.getWarehouseXId((int)spIdAlmacen.Value);
                txtName.Text = "" + oWarehouse.Name;


            }
        }

        private void grdcList_DoubleClick(object sender, EventArgs e)
        {
            if (grdList.GetFocusedRowCellValue(colIdWarehouse) != null)
                spIdAlmacen.Value = (int)grdList.GetFocusedRowCellValue(colIdWarehouse);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (spIdAlmacen.Value > 0)
            {
                Warehouse oWarehouse = new Warehouse();
                RellenarAlmacen(ref oWarehouse);
                WarehouseController wareCont = new WarehouseController();
                if (wareCont.AddOrUpdateWarehouse(oWarehouse))
                {
                    FrmSuccess.ConfirmacionFrom("Editado");
                    //MessageBox.Show("Se edito correctamente.");
                    Limpiar();
                }
                else
                    MessageBox.Show("ocurrio un error al editar.");

            }
        }
    }
}
