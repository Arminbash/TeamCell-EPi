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
    public partial class frmInvetarioStocks : Form
    {

        InventarioController invCont = new InventarioController();
        public frmInvetarioStocks()
        {
            InitializeComponent();
        }

        private void frmInvetarioStocks_Load(object sender, EventArgs e)
        {
            grdcDetalles.DataSource = invCont.StockGlobal();
        }
    }
}
