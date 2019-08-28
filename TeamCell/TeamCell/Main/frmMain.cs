using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamCell
{
    public partial class frmMain : Form
    {
        public int idEmpleado; 
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
        private void openFormInPanel(object formChild)
        {
            if (this.Container.Controls.Count > 0)
                this.Container.Controls.RemoveAt(0);
            Form fc = formChild as Form;
            fc.TopLevel = false;
            fc.Dock = DockStyle.Fill;
            this.Container.Controls.Add(fc);
            this.Container.Tag = fc; fc.Show();
        }
        private void btnUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openFormInPanel(new frmUsuarios());
        }

        private void btnEmpleados_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openFormInPanel(new frmEmpleado());
        }
    }
}
