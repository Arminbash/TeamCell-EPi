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
using TeamCell.Main;
namespace TeamCell
{
    public partial class frmLogin : Form
    {
        UserController userController = new UserController();
        public frmLogin()
        {
            InitializeComponent();
        }
        private bool validate()
        {
            if (txtUser.Text == "")
            {
                MessageBox.Show("Escriba el nombre de usuario", "Error en datos.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtPass.Text == "")
            {
                MessageBox.Show("Escriba la contraseña", "Error en datos.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                if(userController.tryLogin(txtUser.Text,txtPass.Text))
                {
                    frmMain main = new frmMain();
                    main.idEmpleado = 0;
                    this.Show(main);
                    this.Visible = false;
                }
                else
                 MessageBox.Show("Usuario o Contraseña incorrectos.", "Usuario Invalido.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
