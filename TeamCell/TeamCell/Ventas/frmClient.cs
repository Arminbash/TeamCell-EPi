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

namespace TeamCell.Clientes
{
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
        }

        private bool isClienteValido()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe proporcionar el nombre del cliente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrEmpty(txtCedula.Text))
            {
                MessageBox.Show("Debe proporcionar la cédula del cliente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void limpiar()
        {
            ClientController clientComp = new ClientController();
            grdcList.DataSource = clientComp.GetClient();
            txtNombre.Text = "";
            txtCedula.Text="";
        }
        private void frmClient_Load(object sender, EventArgs e)
        {
            limpiar();
        }

        private void RellanarClinte(ref Client client)
        {
            client.Id = (int) spIdClient.Value;
            client.Name = txtNombre.Text;
            client.CardIdentification = txtCedula.Text;
            client.Status = true;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (spIdClient.Value==0)
            {
                if (isClienteValido())
                {
                    Client client = new Client();
                    RellanarClinte(ref client);
                    ClientController clientCont = new ClientController();
                    if (clientCont.AddOrUpdateClient(client))
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
           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (spIdClient.Value >0)
            {
                if (isClienteValido())
                {
                    Client client = new Client();
                    RellanarClinte(ref client);
                    ClientController clientCont = new ClientController();
                    if (clientCont.AddOrUpdateClient(client))
                    {
                        FrmSuccess.ConfirmacionFrom("Editado");
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show("ocurrio un error al editar.");
                    }   
                }
            }
        }

        private void spIdClient_EditValueChanged(object sender, EventArgs e)
        {
            if (spIdClient.Value > 0)
            {
                Client client = new Client();
                ClientController clientCont = new ClientController();
                client = clientCont.GetIdClient((int) spIdClient.Value);
                txtNombre.Text = client.Name;
                txtCedula.Text = client.CardIdentification;
            }
        }

        private void grdcList_DoubleClick(object sender, EventArgs e)
        {
            if (grdList.GetFocusedRowCellValue(colIdClient)!= null)
            {
                spIdClient.Value = (int)grdList.GetFocusedRowCellValue(colIdClient);
            }

        }
    }
}
