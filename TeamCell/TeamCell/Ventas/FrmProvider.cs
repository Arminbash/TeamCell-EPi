using Model.Models;
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
using TeamCell.Notificacion;

namespace TeamCell.Ventas
{
    public partial class FrmProvider : Form
    {
        public FrmProvider()
        {
            InitializeComponent();
        }

        private void RellenarProvider(ref Provider prov)
        {
            prov.IdProvider = (int)spIdProveedor.Value;
            prov.NameProvider = txtName.Text;
            prov.Status = true;
            
        }
        private void Limpiar()
        {
            ProviderControlles provCont = new ProviderControlles();
            grdcList.DataSource = provCont.getProvider();
            txtName.Text = "";
           
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (spIdProveedor.Value == 0)
            {
                Provider prov = new Provider();
                RellenarProvider(ref prov);
                ProviderControlles provCont = new ProviderControlles();
                if (provCont.AddOrUpdateEmployee(prov))
                {
                    FrmSuccess.ConfirmacionFrom("Guardado");
                    //MessageBox.Show("Se guardo correctamente.");
                    Limpiar();
                }
                else
                    MessageBox.Show("ocurrio un error al guardar.");
            }
        }

        private void FrmProvider_Load(object sender, EventArgs e)
        {
            Limpiar();
            List<Model.Models.TempModels.TeamProvider> lstCountry = new List<Model.Models.TempModels.TeamProvider>();
            using (Model.TeamCellContext db = new Model.TeamCellContext())
            {
                lstCountry = (from d in db.Country
                              select new Model.Models.TempModels.TeamProvider
                              {
                                  Id = d.IdCountry,
                                  Nombre = d.NameCountry

                              }).ToList();
            }
            Limpiar();
            cboCountry.DataSource = lstCountry;
            cboCountry.ValueMember = "Id";
            cboCountry.DisplayMember = "Nombre";

        }

        private void grdcList_DoubleClick(object sender, EventArgs e)
        {
            if (grdList.GetFocusedRowCellValue(colIdProvider) != null)
                spIdProveedor.Value = (int)grdList.GetFocusedRowCellValue(colIdProvider);
        }

        private void spIdProveedor_EditValueChanged(object sender, EventArgs e)
        {
            if (spIdProveedor.Value > 0)
            {
                Provider prov = new Provider();
                ProviderControlles provCont = new ProviderControlles();
                prov = provCont.getProviderXId((int)spIdProveedor.Value);
                txtName.Text = "" + prov.NameProvider;
               
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (spIdProveedor.Value > 0)
            {
                Provider prov = new Provider();
                RellenarProvider(ref prov);
                ProviderControlles provCont = new ProviderControlles();
                if (provCont.AddOrUpdateEmployee(prov))
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
