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
    public partial class frmGrdProductos : Form
    {
        ProductController prodCont = new ProductController();
        public int idProducto = 0;
        public frmGrdProductos()
        {
            InitializeComponent();
        }

        private void frmGrdProductos_Load(object sender, EventArgs e)
        {
         grdcDetalles.DataSource = prodCont.getProduct();
        }

        private void grdDetalles_DoubleClick(object sender, EventArgs e)
        {
            if (grdDetalles.GetFocusedRowCellValue(colIdProducto) != null)
            {
                idProducto = (int)grdDetalles.GetFocusedRowCellValue(colIdProducto);
                this.Close();
            }
        }
    }
}
