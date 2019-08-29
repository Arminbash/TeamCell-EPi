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
using DevExpress.Utils.Drawing.Animation;
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
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
           
            chekHandleIdentifier.Checked = false;
            chekLote.Checked = false;
            checkIVA.Checked = false;


        }
        private void FrmProduct_Load(object sender, EventArgs e)
        {
            BrandController branCont = new BrandController();
            cbMarca.DataSource = branCont.getBrand();
            cbMarca.DisplayMember = "NameBrand";
            cbMarca.ValueMember = "IdBrand";
            ProviderControlles proviCont = new ProviderControlles();
            cbProveedor.DataSource = proviCont.getProvider();
            cbProveedor.DisplayMember = "NameProvider";
            cbProveedor.ValueMember = "IdProvider";
           limpiar();

        }

        private void RellenarPrducto( ref Product prod)
        {
            prod.IdProducto = (int)spIdProduct.Value;
            prod.Codigo = txtNombreProducto.Text;
            prod.Name = txtNombreProducto.Text;
            prod.Description = txtDescripcion.Text;
            if (chekHandleIdentifier.Checked)
            {
                prod.HandleIdentifier = true;
            }
            else
            {
                prod.HandleIdentifier = false;
            }

            if (chekLote.Checked)
            {
                prod.DriveLot = true;
            }
            else
            {
                prod.DriveLot = false;
            }

            prod.TypeCosting = Convert.ToString(cbTipoCosteo.SelectedItem);
            if (checkIVA.Checked)
            {
                prod.Iva = true;
            }
            else
            {
                prod.Iva = false;
            }

            prod.Id_Brand = (int) cbMarca.SelectedValue;
            prod.Id_Provider = (int) cbProveedor.SelectedValue;
            prod.Status = true;

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
                Product prod = new Product();
                ProductController prodCont = new ProductController();
                prod = prodCont.getIdProduct((int)spIdProduct.Value);
                txtNombreProducto.Text = prod.Name;
                txtCodigo.Text = prod.Codigo;
                txtDescripcion.Text = prod.Description;
                chekHandleIdentifier.Checked = prod.HandleIdentifier;
                chekLote.Checked = prod.DriveLot;
                cbTipoCosteo.Text = prod.TypeCosting;
                checkIVA.Checked = prod.Iva;
                cbMarca.SelectedValue = prod.Id_Brand;
                cbProveedor.SelectedValue = prod.Id_Provider;

            }
        }

        private void grdcList_DoubleClick(object sender, EventArgs e)
        {
            if (grdList.GetFocusedRowCellValue(colIdProducto) != null)
                spIdProduct.Value = (int)grdList.GetFocusedRowCellValue(colIdProducto);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
