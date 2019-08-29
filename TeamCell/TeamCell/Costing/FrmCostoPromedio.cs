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

namespace TeamCell.Costing
{
    public partial class FrmCostoPromedio : Form
    {
        public FrmCostoPromedio()
        {
            InitializeComponent();
        }

        private void FrmCostoPromedio_Load(object sender, EventArgs e)
        {
            CostingAverageController costi = new CostingAverageController();
            grdcList.DataSource = costi.getCostingAverage();
        }
    }
}
