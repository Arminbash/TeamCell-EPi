using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamCell.Clientes;
using TeamCell.Inventario;
using TeamCell.Pais;
using TeamCell.Ventas;

namespace TeamCell
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

<<<<<<< HEAD
            Application.Run(new FrmWareHouse());
=======
            Application.Run(new frmLogin());
>>>>>>> a3b429383b11f97cd490970793a56cb1df377fc5

        }
    }
}
