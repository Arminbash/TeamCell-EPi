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

namespace TeamCell.Pais
{
    public partial class frmCountry : Form
    {
        public frmCountry()
        {
            InitializeComponent();
        }

        private void limpiar()
        {
            CountryController counCont = new CountryController();
            grdcList.DataSource = counCont.getCountry();
            txtNombrePais.Text = "";
        }
        private void frmCountry_Load(object sender, EventArgs e)
        {
            limpiar();
        }

        private void RellenarPais(ref Country country)
        {
            country.IdCountry = (int) spIdCountry.Value;
            country.NameCountry = txtNombrePais.Text;
            country.Status = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (spIdCountry.Value==0)
            {
                
                Country country = new Country();
                RellenarPais(ref country);
                CountryController contCont = new CountryController();
                if (contCont.AddOrUpdateCountry(country))
                {
                    FrmSuccess.ConfirmacionFrom("Guardado");
                    limpiar();
                }
                else
                {
                    MessageBox.Show("ocurrio un error al guardar.");
                }

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (spIdCountry.Value > 0)
            {

                Country country = new Country();
                RellenarPais(ref country);
                CountryController contCont = new CountryController();
                if (contCont.AddOrUpdateCountry(country))
                {
                    FrmSuccess.ConfirmacionFrom("Guardado");
                    limpiar();
                }
                else
                {
                    MessageBox.Show("ocurrio un error al guardar.");
                }

            }
        }

        private void spIdCountry_EditValueChanged(object sender, EventArgs e)
        {
            if (spIdCountry.Value > 0)
            {
                Country country= new Country();
                CountryController contCont = new CountryController();
                country = contCont.GetIdCountry((int)spIdCountry.Value);
                txtNombrePais.Text = country.NameCountry;
              
            }
        }

        private void grdcList_DoubleClick(object sender, EventArgs e)
        {
            if (grdList.GetFocusedRowCellValue(colIdCountry) != null)
            {
                spIdCountry.Value = (int)grdList.GetFocusedRowCellValue(colIdCountry);
            }
        }
    }
}
