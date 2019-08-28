using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamCell.Notificacion
{
    public partial class FrmSuccess : Form
    {
        public FrmSuccess(string Mensaje)
        {
            InitializeComponent();
            label1.Text = Mensaje;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSuccess_Load(object sender, EventArgs e)
        {
            bunifuFormFadeTransition1.ShowAsyc(this);
        }

        public static void ConfirmacionFrom(string mensaje)
        {
            FrmSuccess frm = new FrmSuccess(mensaje);
            frm.ShowDialog();
        }
    }
}
