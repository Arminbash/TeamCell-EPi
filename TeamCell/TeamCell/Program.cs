using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamCell.Clientes;
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
            Application.Run(new FrmProvider());
            Application.Run(new frmCountry());
=======
            Application.Run(new frmMain());
>>>>>>> 4a8799b6373765d17cefc61b14aaae191e1437f5
        }
    }
}
