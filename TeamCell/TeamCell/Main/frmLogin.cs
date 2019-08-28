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
            if (txtUser.Text == "Usuario")
            {
                label6.Text = "Escriba el nombre del usuario";
                label6.Visible = true;
                //MessageBox.Show("Escriba el nombre de usuario", "Error en datos.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtPass.Text == "Contraseña")
            {
                label6.Text = "Escriba la Contraseña";
                label6.Visible = true;
                //MessageBox.Show("Escriba la contraseña", "Error en datos.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                if (userController.tryLogin(txtUser.Text, txtPass.Text))
                {
                    frmMain main = new frmMain();
                    main.idEmpleado = 0;
                    main.Show();
                    this.Visible = false;
                }
                else
                 label6.Visible = true;
                 //MessageBox.Show("Usuario o Contraseña incorrectos.", "Usuario Invalido.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Usuario")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
                
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Usuario";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Contraseña")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;

            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Contraseña";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }
    }
}
