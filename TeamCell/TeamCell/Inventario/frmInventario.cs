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
namespace TeamCell
{
    public partial class frmInventario : Form
    {
        WarehouseController warCont = new WarehouseController();
        InventarioController invCont = new InventarioController();
        ProductController prodCont = new ProductController();

        public frmInventario()
        {
            InitializeComponent();
        }

        private void frmInventario_Load(object sender, EventArgs e)
        {
            cbBodega.DataSource = warCont.getWarehouse();
            cbBodega.DisplayMember = "Name";
            cbBodega.ValueMember = "IdWarehouse";

            cbProducto.DataSource = prodCont.getProduct();
            cbProducto.DisplayMember = "Name";
            cbProducto.ValueMember = "IdProducto";
        }
        public  Boolean IsNumeric(object valor)
        {
            int result;
            return int.TryParse(valor.ToString(), out result);
        }
        private void cbBodega_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(IsNumeric( cbBodega.SelectedValue))
            {
                Filtrar();
            }
        }

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsNumeric( cbProducto.SelectedValue))
            {
                Filtrar();
            }
        }

        private void Filtrar()
        {
            grdcDetalles.DataSource = invCont.FiltroXbodegaXProducto((int)cbBodega.SelectedValue,(int)cbProducto.SelectedValue);
        }


    }
}
