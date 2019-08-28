using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model.Models;
using Controller;
using TeamCell.Notificacion;

namespace TeamCell
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }
        private bool isUsuarioValido()
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Debe proporcionar el nombre de usuario", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Debe proporcionar la contraseña del usuario", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void Limpiar()
        {
            spIdUsuario.Value = 0;
            txtPassword.Text = "";
            txtUserName.Text = "";
            UserController userCont = new UserController();
            grdcList.DataSource = userCont.getUsersActive();
        }
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            UserController userCont = new UserController();
            grdcList.DataSource = userCont.getUsersActive();
            EmployeeController empCont = new EmployeeController();
            cbEmpleado.DataSource = empCont.getEmployees();
            cbEmpleado.DisplayMember = "FirstName";
            cbEmpleado.ValueMember = "IdEmployee";
        }

        private void grdcList_DoubleClick(object sender, EventArgs e)
        {
            if(grdList.GetFocusedRowCellValue(colIdUser) != null)
            {
                spIdUsuario.Value = (int) grdList.GetFocusedRowCellValue(colIdUser);
            }      
        }
        private void spIdUsuario_EditValueChanged(object sender, EventArgs e)
        {
            UserController userCont = new UserController();
            User user = new User();
            user = userCont.getUserXId((int) spIdUsuario.Value);
            txtUserName.Text = user.UserName;
            cbEmpleado.SelectedValue = user.IdEmployee;
        }

        private void RellenarUsuario(ref TempUser userTemp)
        {
            userTemp.IdUser = (int) spIdUsuario.Value;
            userTemp.UserName = txtUserName.Text;
            userTemp.Password = txtPassword.Text;
            userTemp.IdEmployee = (int) cbEmpleado.SelectedValue;
            userTemp.Status = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (spIdUsuario.Value == 0)
            {
                if (isUsuarioValido())
                {
                    UserController userCont = new UserController();
                    TempUser userTemp = new TempUser();
                    RellenarUsuario(ref userTemp);
                    if (userCont.addUser(userTemp))
                    {
                        FrmSuccess.ConfirmacionFrom("Guardado");
                        //MessageBox.Show("Se guardo correctamente.");
                        Limpiar();
                    }
                    else
                        MessageBox.Show("ocurrio un error al guardar.");   
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(spIdUsuario.Value > 0)
            {
                if (isUsuarioValido())
                {
                    UserController userCont = new UserController();
                    TempUser userTemp = new TempUser();
                    RellenarUsuario(ref userTemp);
                    if (userCont.editUser(userTemp))
                    {
                        FrmSuccess.ConfirmacionFrom("Edito");
                        //MessageBox.Show("Se edito correctamente.");
                        Limpiar();
                    }
                    else
                        MessageBox.Show("ocurrio un error al editar.");   
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (spIdUsuario.Value > 0)
            {
                if (isUsuarioValido())
                {
                    UserController userCont = new UserController();
                    TempUser userTemp = new TempUser();
                    RellenarUsuario(ref userTemp);
                    userTemp.Password = "12345";
                    if (userCont.editUser(userTemp))
                    {
                        MessageBox.Show("Se edito correctamente.");
                        Limpiar();
                    }
                    else
                        MessageBox.Show("ocurrio un error al editar.");   
                }
            }
        }
    }
}
