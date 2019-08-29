using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Model.Models;
using TeamCell.Clientes;
using TeamCell.Inventario;
using TeamCell.Pais;
using TeamCell.Ventas;
using TeamCell.Inventario;
using TeamCell.Factura;

namespace TeamCell
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public int idemp;
        public static int idEmpleado; 
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            idEmpleado = idemp;
            EmployeeController empCont = new EmployeeController();
            Employee emp = empCont.getEmployeeXId(idemp);
            if (emp != null)
            {
                lblEmpleado.Text = emp.FirstName + " " + emp.FirstSurname;    
            }
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

        private void btnCompras_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openFormInPanel(new frmCompras());
        }

        private void btnProductos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openFormInPanel(new FrmProduct());
        }

        private void btnProvider_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openFormInPanel(new FrmProvider());
        }

        private void btnMarca_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openFormInPanel(new FrmBrand());
        }

        private void btnCliente_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openFormInPanel(new frmClient());
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openFormInPanel(new frmCountry());
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openFormInPanel(new frmClient());
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openFormInPanel(new frmInventario());
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openFormInPanel(new frmInvetarioStocks());
        }

        private void barButtonItem4_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openFormInPanel(new frmFactura());
        }

        private void barButtonItem5_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openFormInPanel(new frmClient());
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openFormInPanel(new FrmWareHouse());
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openFormInPanel(new frmKardex());
        }
    }
}
