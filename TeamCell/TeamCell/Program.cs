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
=======
            Application.Run(new frmCountry());
>>>>>>> 4b375b2f8f7e2523cc0f727708659b964e8f0b4d
        }
    }
}
