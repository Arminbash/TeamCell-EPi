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

namespace TeamCell.Ventas
{
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
        }

        private void limpiar()
        {
            ProductController prodCont = new ProductController();
            grdcList.DataSource = prodCont.getProduct();
            txtNombreProducto.Text = "";
            txtPreci.Text = "";
            txtDescripcion.Text = "";
            

        }
        private void FrmProduct_Load(object sender, EventArgs e)
        {
            limpiar();

        }

        private void RellenarPrducto( ref Product prod)
        {
            //prod.IdProduct = (int) spIdProduct.Value;
            //prod.NameProduct = txtNombreProducto.Text;
            //prod.Preci = Decimal.Parse(txtPrecio.Text);
            //prod.Cost = Decimal.Parse(txtCosto.Text);
            //prod.Date = dtFecha.DateTime;
            //prod.Existence = Int32.Parse(txtExistencia.Text);
            //prod.Status = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (spIdProduct.Value==0)
            {
                Product prod= new Product();
                RellenarPrducto(ref prod);
                ProductController prodCont = new ProductController();
                if (prodCont.AddOrUpdateProduct(prod))
                {
                    FrmSuccess.ConfirmacionFrom("Guardado");
                    limpiar();
                }
                else
                    MessageBox.Show("ocurrio un error al guardar.");

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (spIdProduct.Value >0)
            {
                Product prod = new Product();
                RellenarPrducto(ref prod);
                ProductController prodCont = new ProductController();
                if (prodCont.AddOrUpdateProduct(prod))
                {
                    FrmSuccess.ConfirmacionFrom("Editado");
                    //MessageBox.Show("Se edito correctamente.");
                    limpiar();
                }
                else
                    MessageBox.Show("ocurrio un error al editar.");
            }
        }

        private void spIdProduct_EditValueChanged(object sender, EventArgs e)
        {
            if (spIdProduct.Value>0)
            {
                //Product prod = new Product();
                //ProductController prodCont =new ProductController();
                //prod = prodCont.getIdProduct((int) spIdProduct.Value);
                //txtNombreProducto.Text = prod.NameProduct;
                //txtPrecio.Text = Convert.ToString(prod.Preci);
                //txtCosto.Text = Convert.ToString(prod.Cost);
                //dtFecha.DateTime = prod.Date;
                //txtExistencia.Text = Convert.ToString(prod.Existence);

            }
        }

        private void grdcList_DoubleClick(object sender, EventArgs e)
        {
            if (grdList.GetFocusedRowCellValue(colIdProduct) != null)
                spIdProduct.Value = (int)grdList.GetFocusedRowCellValue(colIdProduct);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
