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
    public partial class frmEmpleado : Form
    {
        public frmEmpleado()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            EmployeeController empCont = new EmployeeController();
            grdcList.DataSource = empCont.getEmployees();
            txtPrimerNombre.Text = "";
            txtSegundoNombre.Text = "";
            txtPrimerApellido.Text = "";
            txtSegundoApellido.Text = "";
            dtFechaNacimiento.DateTime = DateTime.Now;
            txtCedula.Text = "";
            txtEstado.Text = "";

        }
        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void RellenarEmpleado(ref Employee emp)
        {
            emp.IdEmployee = (int) spIdEmpleado.Value;
            emp.FirstName = txtPrimerNombre.Text;
            emp.SecondName = txtSegundoNombre.Text;
            emp.FirstSurname = txtPrimerApellido.Text;
            emp.SecondSurname = txtSegundoApellido.Text;
            emp.BirthDay = dtFechaNacimiento.DateTime;
            emp.IdentificationCard = txtCedula.Text;
            emp.State = txtEstado.Text;
            emp.Status = true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (spIdEmpleado.Value == 0)
            {
                Employee emp = new Employee();
                RellenarEmpleado(ref emp);
                EmployeeController empCont = new EmployeeController();
                if (empCont.AddOrUpdateEmployee(emp))
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
            if (spIdEmpleado.Value > 0)
            {
                Employee emp = new Employee();
                RellenarEmpleado(ref emp);
                EmployeeController empCont = new EmployeeController();
                if(empCont.AddOrUpdateEmployee(emp))
                {
                    FrmSuccess.ConfirmacionFrom("Editado");
                    //MessageBox.Show("Se edito correctamente.");
                    Limpiar();
                }
                else
                    MessageBox.Show("ocurrio un error al editar.");

            }
        }

        private void spIdEmpleado_EditValueChanged(object sender, EventArgs e)
        {
            if (spIdEmpleado.Value > 0)
            {
                Employee emp = new Employee();
                EmployeeController empCont = new EmployeeController();
                emp = empCont.getEmployeeXId((int)spIdEmpleado.Value);
                txtPrimerNombre.Text = ""+ emp.FirstName;
                txtSegundoNombre.Text = emp.SecondName;
                txtPrimerApellido.Text = emp.FirstSurname;
                txtSegundoApellido.Text = emp.SecondSurname;
                dtFechaNacimiento.DateTime = emp.BirthDay;
                txtCedula.Text = emp.IdentificationCard;
                txtEstado.Text = emp.State;
            }
        }

        private void grdcList_DoubleClick(object sender, EventArgs e)
        {
            if (grdList.GetFocusedRowCellValue(colIdEmployee) != null)
                spIdEmpleado.Value = (int)grdList.GetFocusedRowCellValue(colIdEmployee);
        }
    }
}
