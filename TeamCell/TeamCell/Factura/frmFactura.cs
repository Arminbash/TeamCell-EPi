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

namespace TeamCell
{
    public partial class frmFactura : Form
    {
        List<DetallesGrd> listProd = new List<DetallesGrd>();
        WarehouseController warCont = new WarehouseController();
        ProviderControlles provCont = new ProviderControlles();
        PurchaseController pursCont = new PurchaseController();
        DetailPurchaseController detPurCont = new DetailPurchaseController();
        KardexController kardCont = new KardexController();
        CostingAverageController costAveCont = new CostingAverageController();
        CostingWeightedController cosWeiCont = new CostingWeightedController();

        public frmFactura()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            listProd.Clear();
            grdcDetalles.DataSource = null;
            txtNoFactura.Text = "";
            dtFechaFactura.DateTime = DateTime.Now;


            cbCliente.DataSource = provCont.getProvider();
            cbCliente.DisplayMember = "NameProvider";
            cbCliente.ValueMember = "IdProvider";

        }
        private class DetallesGrd
        {
            public int IdDetalle { get; set; }
            public int IdProducto { get; set; }
            public string Codigo { get; set; }
            public string Nombre { get; set; }
            public decimal Cantidad { get; set; }
            public decimal Costo { get; set; }
            public decimal Desc { get; set; }
            public decimal Subtotal { get; set; }
            public decimal IVA { get; set; }
            public decimal Total { get; set; }

        }
        private void frmFactura_Load(object sender, EventArgs e)
        {

        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int idProducto = 0;
            frmGrdProductos frm = new frmGrdProductos();
            frm.ShowDialog();
            idProducto = frm.idProducto;
            frm.Dispose();
            if (idProducto != 0)
            {
                Product prod = new Product();
                ProductController prodCont = new ProductController();
                prod = prodCont.getIdProduct(idProducto);
                DetallesGrd det = new DetallesGrd();
                det.IdProducto = prod.IdProducto;
                det.Codigo = prod.Codigo;
                det.Nombre = prod.Name;
                det.Cantidad = 0;
                det.Costo = 0;
                det.Desc = 0;
                det.Subtotal = 0;
                det.IVA = 0;
                det.Total = 0;
                listProd.Add(det);
            }
            grdcDetalles.DataSource = null;
            grdcDetalles.DataSource = listProd;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (grdDetalles.GetFocusedRowCellValue(colIdProducto) != null)
            {
                int idProducto = 0;
                idProducto = (int)grdDetalles.GetFocusedRowCellValue(colIdProducto);
                listProd.Remove(listProd.Find(x => x.IdProducto == idProducto));
                grdcDetalles.DataSource = null;
                grdcDetalles.DataSource = listProd;
            }
        }

        private void grdDetalles_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int idProducto = 0;
            idProducto = (int)grdDetalles.GetRowCellValue(e.RowHandle, colIdProducto);
            CalcularGrid(idProducto);
        }

        private void CalcularGrid(int idProducto)
        {
            decimal Cantidad = listProd.Where(x => x.IdProducto == idProducto).FirstOrDefault().Cantidad;
            decimal Costo = listProd.Where(x => x.IdProducto == idProducto).FirstOrDefault().Costo;
            decimal Descuento = listProd.Where(x => x.IdProducto == idProducto).FirstOrDefault().Desc;
            decimal IVA = listProd.Where(x => x.IdProducto == idProducto).FirstOrDefault().IVA;
            decimal subtotal = (Cantidad * Costo) * (1 - (Descuento / 100));
            decimal Total = subtotal * (1 + (IVA / 100));
            listProd.Where(x => x.IdProducto == idProducto).FirstOrDefault().Subtotal = subtotal;
            listProd.Where(x => x.IdProducto == idProducto).FirstOrDefault().Total = Total;
            grdcDetalles.DataSource = null;
            grdcDetalles.DataSource = listProd;
        }

    }
}
