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

namespace TeamCell.Ventas
{
    public partial class FrmBrand : Form
    {
        public FrmBrand()
        {
            InitializeComponent();
        }

        private void FrmBrand_Load(object sender, EventArgs e)
        {
            Refresh();
        }
        private void Limpiar()
        {
            BrandController branCont = new BrandController();
            grdcList.DataSource = branCont.getBrand();
            txtName.Text = "";
        

        }

        private void Refresh()
        {
            BrandController oBrand = new BrandController();
            grdcList.DataSource = oBrand.getBrand();
        }
        private void RellenarMarca(ref Brand bran)
        {
            bran.IdBrand = (int)spIdMarca.Value;
            bran.NameBrand = txtName.Text;
            bran.Status = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (spIdMarca.Value == 0)
            {
                Brand bran = new Brand();
                RellenarMarca(ref bran);
                BrandController branCont = new BrandController();
                if (branCont.AddOrUpdateEmployee(bran))
                {
                    FrmSuccess.ConfirmacionFrom("Guardado");
                    //MessageBox.Show("Se guardo correctamente.");
                    Limpiar();
                }
                else
                    MessageBox.Show("ocurrio un error al guardar.");
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (spIdMarca.Value > 0)
            {
                Brand bran = new Brand();
                RellenarMarca(ref bran);
                BrandController empCont = new BrandController();
                if (empCont.AddOrUpdateEmployee(bran))
                {
                    FrmSuccess.ConfirmacionFrom("Editado");
                    //MessageBox.Show("Se edito correctamente.");
                    Limpiar();
                }
                else
                    MessageBox.Show("ocurrio un error al editar.");

            }
        }

        private void spIdMarca_EditValueChanged(object sender, EventArgs e)
        {
            if (spIdMarca.Value > 0)
            {
                Brand bran = new Brand();
                BrandController branCont = new BrandController();
                bran = branCont.getBrandXId((int)spIdMarca.Value);
                txtName.Text = "" + bran.NameBrand;
                
                
            }
        }

        private void grList_DoubleClick(object sender, EventArgs e)
        {
            if (grdList.GetFocusedRowCellValue(colIdBrand) != null)
                spIdMarca.Value = (int)grdList.GetFocusedRowCellValue(colIdBrand);
        }

        private void grList_ProcessGridKey(object sender, KeyEventArgs e)
        {

        }
    }
}
